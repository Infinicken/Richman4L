using System;
using System . Collections;
using System . Diagnostics;
using System . Linq;

using Windows . ApplicationModel;
using Windows . ApplicationModel . Activation;
using Windows . UI . ViewManagement;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Navigation;

using WenceyWang . Richman4L . Apps . Uni . Pages;
using WenceyWang . Richman4L . Properties;

//using Microsoft . ApplicationInsights ;

namespace WenceyWang . Richman4L . Apps . Uni
{

	/// <summary>
	///     Richman4L Universal
	/// </summary>
	public sealed partial class App : Application
	{

		public new static App Current { get; private set; }

		internal string WindowTitle
		{
			get { return ApplicationView . GetForCurrentView ( ) . Title; }
			set
			{
				ApplicationView . GetForCurrentView ( ) . Title = value;
				TitleChanged?.Invoke ( this , EventArgs . Empty );
			}
		}

		/// <summary>
		///     初始化单一实例应用程序对象。这是执行的创作代码的第一行，
		///     已执行，逻辑上等同于 main() 或 WinMain()。
		/// </summary>
		public App ( )
		{
			Current = this;

			//WindowsAppInitializer . InitializeAsync (
			//	WindowsCollectors . Metadata |
			//	WindowsCollectors . Session ) ;
			InitializeComponent ( );
			Suspending += OnSuspending;
			UnhandledException += OnUnhandledException;
			Resuming += OnResuming;
		}

		[CanBeNull]
		public event EventHandler TitleChanged;

		private void OnResuming ( object sender , object e ) { }

		private void OnUnhandledException ( object sender , UnhandledExceptionEventArgs e ) { e . Handled = false; }

		public Frame CurrentFrame => Window . Current . Content as Frame;

		public Frame RootFrame { get; private set; }

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
				DebugSettings . EnableFrameRateCounter = true;
			}
#endif

			RootFrame = Window . Current . Content as Frame;

			// 不要在窗口已包含内容时重复应用程序初始化，
			// 只需确保窗口处于活动状态
			if ( RootFrame == null )
			{
				// 创建要充当导航上下文的框架，并导航到第一页
				RootFrame = new Frame ( );

				RootFrame . NavigationFailed += OnNavigationFailed;

				if ( e . PreviousExecutionState == ApplicationExecutionState . Terminated )
				{
					//TODO: 从之前挂起的应用程序加载状态
				}

				// 将框架放在当前窗口中
				Window . Current . Content = RootFrame;
			}

			if ( RootFrame . Content == null )
			{
				RootFrame . Navigate ( typeof ( StartPage ) , e . Arguments );
			}


			RootFrame . SizeChanged += Frame_SizeChanged;

			// 确保当前窗口处于活动状态
			Window . Current . Activate ( );

			WindowTitle = "Starting";
		}

		private void Frame_SizeChanged ( object sender , SizeChangedEventArgs e )
		{
			//Todo:检查画面大小
			if ( ( Math . Max ( CurrentFrame . RenderSize . Height , CurrentFrame . Width ) < 640 ) | ( Math . Min ( CurrentFrame . RenderSize . Height , CurrentFrame . Width ) < 360 ) )
			{
				//Too small to display


			}
		}


		/// <summary>
		///     导航到特定页失败时调用
		/// </summary>
		/// <param name="sender">导航失败的框架</param>
		/// <param name="e">有关导航失败的详细信息</param>
		private void OnNavigationFailed ( object sender , NavigationFailedEventArgs e )
		{
			throw new Exception ( "Failed to load Page " + e . SourcePageType . FullName );
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
			SuspendingDeferral deferral = e . SuspendingOperation . GetDeferral ( );

			//TODO: 保存应用程序状态并停止任何后台活动
			deferral . Complete ( );
		}

	}

}
