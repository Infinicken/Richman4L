using System ;
using System . Collections ;
using System . Diagnostics ;
using System . Linq ;
using System . Threading . Tasks ;

using Windows . Foundation . Metadata ;
using Windows . System . Profile ;
using Windows . UI ;
using Windows . UI . ViewManagement ;
using Windows . UI . Xaml ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni . UI .Pages
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
			Debug . WriteLine ( "Loaded" ) ;
			Debug . WriteLine ( AnalyticsInfo . DeviceForm ) ;
			Debug . WriteLine ( AnalyticsInfo . VersionInfo . DeviceFamily ) ;
			if ( ApiInformation . IsMethodPresent ( typeof ( StatusBar ) . FullName , nameof ( StatusBar . HideAsync ) ) )
			{
				await StatusBar . GetForCurrentView ( ) . HideAsync ( ) ;
			}

			StartStoryboard . Completed += StartStoryboard_Completed ;
			StartStoryboard . Begin ( ) ;
			_taskToWait = Task . WhenAll ( Startup . RunAllTask ( ) , XamlMapRenderers . Startup . RunAllTask ( ) ) ;
		}

		private void StartStoryboard_Completed ( object sender , object e )
		{
			_taskToWait . Wait ( ) ;

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
