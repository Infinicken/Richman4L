using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;
using System . Threading . Tasks ;

using Windows . System . Profile ;
using Windows . UI ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;

using Edi . UWP . Helpers ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;
using WenceyWang . Richman4L . Apps . Uni . UI . Pages . Initialization ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Pages
{

	/// <summary>
	///     起始动画页
	/// </summary>
	public sealed partial class StartPage : AnimatePage
	{

		private Task _taskToWait ;

		public static Color PageColor => XamlResources . Resources . Black ;

		public StartPage ( ) { InitializeComponent ( ) ; }

		private async void Page_Loaded ( object sender , RoutedEventArgs e )
		{
#if DEBUG


			ContentDialog debugDialog = new ContentDialog
										{
											Title = "这是一个不稳定的预发布软件" ,
											Content = "您猛然惊醒，却已身处某难以名状的未来游戏中。这里有Bug，随处可见，难以避免。这个来自未来的游戏并不稳定，它只是用于测试。" ,
											PrimaryButtonText = "我认命了" ,
											SecondaryButtonText = "让我离开这里"
										} ;

			ContentDialogResult result = await debugDialog . ShowAsync ( ) ;

			if ( result != ContentDialogResult . Primary )
			{
				App . Current . Exit ( ) ;
			}

#endif

			Debug . WriteLine ( "Loaded" ) ;
			Debug . WriteLine ( AnalyticsInfo . DeviceForm ) ;
			Debug . WriteLine ( AnalyticsInfo . VersionInfo . DeviceFamily ) ;

			await Mobile . HideWindowsMobileStatusBar ( ) ;

			StartStoryboard . Completed += StartStoryboard_Completed ;
			StartStoryboard . Begin ( ) ;
			_taskToWait = Task . WhenAll ( Startup . RunAllTask ( ) , XamlMapRenderers . Startup . RunAllTask ( ) ) ;
		}

		private async void StartStoryboard_Completed ( object sender , object e )
		{
			await _taskToWait ;

			GameTitleManager . GenerateNewTitle ( ) ;

			if ( AppSettings . Current . AcceptLicence )
			{
				this . NavigateTo <MainPage> ( ) ;
			}
			else
			{
				this . NavigateTo <LicensePage> ( ) ;
			}
		}

		public override void AddControl ( ) { }

		public override void RemoveControl ( ) { }

	}

}
