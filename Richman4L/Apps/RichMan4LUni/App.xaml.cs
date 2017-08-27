using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

using Windows . ApplicationModel ;
using Windows . ApplicationModel . Activation ;
using Windows . UI . Composition ;
using Windows . UI . ViewManagement ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Hosting ;
using Windows . UI . Xaml . Navigation ;

using AutoLazy ;

using Microsoft . Graphics . Canvas . Effects ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Apps . Uni . UI . Pages ;

namespace WenceyWang . Richman4L . Apps . Uni
{

	/// <summary>
	///     Richman4L Universal
	/// </summary>
	public sealed partial class App : Application
	{

		[Lazy]
		private string Version
		{
			get
			{
				StringBuilder result = new StringBuilder ( ) ;

				result . Append ( "Richman4L Universal" ) ;
				result . Append ( " " ) ;
				result . Append ( typeof ( App ) . GetTypeInfo ( ) . Assembly . GetName ( ) . Version ) ;

				result . Append ( "Richman4L" ) ;

				return result . ToString ( ) ;
			}
		}


		public new static App Current => Application . Current as App ;

		internal string WindowTitle
		{
			get => ApplicationView . GetForCurrentView ( ) . Title ;
			set
			{
				ApplicationView . GetForCurrentView ( ) . Title = value ;
				TitleChanged ? . Invoke ( this , EventArgs . Empty ) ;
			}
		}

		public Panel ViewRoot
		{
			get => Window . Current . Content as Panel ;
			private set => Window . Current . Content = value ;
		}

		public Frame WindowTooSmallFrame { get ; private set ; }

		public Frame RootFrame { get ; private set ; }

		public bool IsInTooSmallState { get ; private set ; }

		private Visual viewRootVisual { get ; set ; }

		public float ViewSaturation
		{
			get
			{
				float temp ;
				viewRootVisual . Properties . TryGetScalar ( nameof(SaturationEffect . Saturation) , out temp ) ;
				return temp ;
			}
			set => viewRootVisual . Properties . InsertScalar ( nameof(SaturationEffect . Saturation) , value ) ;
		}

		/// <summary>
		///     初始化单一实例应用程序对象。这是执行的创作代码的第一行，
		///     已执行，逻辑上等同于 main() 或 WinMain()。
		/// </summary>
		public App ( )
		{
			InitializeComponent ( ) ;
			Suspending += OnSuspending ;
			UnhandledException += OnUnhandledException ;
			Resuming += OnResuming ;
		}

		[CanBeNull]
		public event EventHandler TitleChanged ;

		private void OnResuming ( object sender , object e ) { }

		private async void OnUnhandledException ( object sender , UnhandledExceptionEventArgs e )
		{
#if !DEBUG
			e.Handled = true;
			ContentDialog dialog = new ContentDialog
										{
											Title = "发生了没有被处理的异常" ,
											Content = "异常的细节：" ,
											PrimaryButtonText = "我认命了" ,
											SecondaryButtonText = "我觉得我还可以抢救一下"
										} ;

			ContentDialogResult result = await dialog . ShowAsync ( ) ;

			if ( result == ContentDialogResult . Primary )
			{
				Current . Exit ( ) ;
			}
			else
			{
				dialog = new ContentDialog { Title = "未定义的行为", Content = "我们无法预测程序接下来的行为，" };
			}
#endif
		}

		/// <summary>
		///     在应用程序由最终用户正常启动时进行调用。
		///     将在启动应用程序以打开特定文件等情况下使用。
		/// </summary>
		/// <param name="e">有关启动请求和过程的详细信息。</param>
		protected override void OnLaunched ( LaunchActivatedEventArgs e )
		{
#if DEBUG
			if ( Debugger . IsAttached )
			{
				DebugSettings . EnableFrameRateCounter = true ;

				//DebugSettings . EnableRedrawRegions = true ;
			}
#endif

			if ( RootFrame == null )
			{
				RootFrame = new Frame { CacheSize = 0 } ;

				RootFrame . NavigationFailed += OnNavigationFailed ;
				RootFrame . SizeChanged += Frame_SizeChanged ;

				if ( e . PreviousExecutionState == ApplicationExecutionState . Terminated )
				{
					//TODO: 从之前挂起的应用程序加载状态
				}

				RootFrame . Navigate ( typeof ( StartPage ) , e . Arguments ) ;
			}

			if ( WindowTooSmallFrame == null )
			{
				WindowTooSmallFrame = new Frame { CacheSize = 0 } ;
				WindowTooSmallFrame . SizeChanged += Frame_SizeChanged ;

				WindowTooSmallFrame . Navigate ( typeof ( FrameTooSmallPage ) ) ;
			}

			if ( ViewRoot == null )
			{
				ViewRoot = new Grid ( ) ;
				ViewRoot . Children . Add ( RootFrame ) ;
				ViewRoot . Children . Add ( WindowTooSmallFrame ) ;

				{
					viewRootVisual = ElementCompositionPreview . GetElementVisual ( ViewRoot ) ;
					viewRootVisual . Properties . InsertScalar ( nameof(SaturationEffect . Saturation) , 1f ) ;
					Compositor compositor = viewRootVisual . Compositor ;

					CompositionBackdropBrush backdropBrush = compositor . CreateBackdropBrush ( ) ;

					SaturationEffect graphicsEffect = new SaturationEffect
													{
														Name = nameof(SaturationEffect) ,
														Source = new CompositionEffectSourceParameter ( nameof(backdropBrush) )
													} ;

					CompositionEffectFactory effectFactory =
						compositor . CreateEffectFactory ( graphicsEffect ,
															new [ ] { $"{nameof(SaturationEffect)}.{nameof(graphicsEffect . Saturation)}" } ) ;
					CompositionEffectBrush effectBrush = effectFactory . CreateBrush ( ) ;

					effectBrush . Properties . InsertScalar ( $"{nameof(SaturationEffect)}.{nameof(graphicsEffect . Saturation)}" ,
															0f ) ;

					ExpressionAnimation bindSaturationAnimation =
						compositor . CreateExpressionAnimation ( $"{nameof(viewRootVisual)}.{nameof(SaturationEffect . Saturation)}" ) ;

					bindSaturationAnimation . SetReferenceParameter ( $"{nameof(viewRootVisual)}" , viewRootVisual ) ;

					effectBrush . StartAnimation ( $"{nameof(SaturationEffect)}.{nameof(graphicsEffect . Saturation)}" ,
													bindSaturationAnimation ) ;
					effectBrush . SetSourceParameter ( nameof(backdropBrush) , backdropBrush ) ;


					SpriteVisual glassVisual = compositor . CreateSpriteVisual ( ) ;
					glassVisual . Brush = effectBrush ;

					ExpressionAnimation bindSizeAnimation =
						compositor . CreateExpressionAnimation ( $"{nameof(viewRootVisual)}.{nameof(viewRootVisual . Size)}" ) ;
					bindSizeAnimation . SetReferenceParameter ( $"{nameof(viewRootVisual)}" , viewRootVisual ) ;
					glassVisual . StartAnimation ( $"{nameof(glassVisual . Size)}" , bindSizeAnimation ) ;

					ElementCompositionPreview . SetElementChildVisual ( ViewRoot , glassVisual ) ;
				}
			}

			SetVisibility ( ) ;

			// 确保当前窗口处于活动状态
			Window . Current . Activate ( ) ;

			WindowTitle = "Starting" ;
		}

		private void Frame_SizeChanged ( object sender , SizeChangedEventArgs e ) { SetVisibility ( ) ; }


		private void SetVisibility ( )
		{
			if ( ( Math . Max ( ViewRoot . RenderSize . Height , ViewRoot . RenderSize . Width ) < 640 )
				| ( Math . Min ( ViewRoot . RenderSize . Height , ViewRoot . RenderSize . Width ) < 360 ) )
			{
				//Too small to display
				if ( ! IsInTooSmallState )
				{
					RootFrame . Visibility = Visibility . Collapsed ;
					WindowTooSmallFrame . Visibility = Visibility . Visible ;
					IsInTooSmallState = true ;
				}
			}
			else
			{
				if ( IsInTooSmallState )
				{
					RootFrame . Visibility = Visibility . Visible ;
					WindowTooSmallFrame . Visibility = Visibility . Collapsed ;
					IsInTooSmallState = false ;
				}
			}
		}

		/// <summary>
		///     导航到特定页失败时调用
		/// </summary>
		/// <param name="sender">导航失败的框架</param>
		/// <param name="e">有关导航失败的详细信息</param>
		private void OnNavigationFailed ( object sender , NavigationFailedEventArgs e )
		{
			throw new Exception ( "Failed to load Page " + e . SourcePageType . FullName ) ;
		}


		/// <summary>
		///     在将要挂起应用程序执行时调用。  在不知道应用程序
		///     无需知道应用程序会被终止还是会恢复，
		///     并让内存内容保持不变。
		/// </summary>
		/// <param name="sender">挂起的请求的源。</param>
		/// <param name="e">有关挂起请求的详细信息。</param>
		private void OnSuspending ( object sender , SuspendingEventArgs e )
		{
			SuspendingDeferral deferral = e . SuspendingOperation . GetDeferral ( ) ;

			//TODO: 保存应用程序状态并停止任何后台活动
			deferral . Complete ( ) ;
		}

	}

}
