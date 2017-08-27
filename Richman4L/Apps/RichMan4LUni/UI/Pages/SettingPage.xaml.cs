using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . Foundation . Metadata ;
using Windows . Phone . UI . Input ;
using Windows . UI ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Navigation ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Pages
{

	/// <summary>
	///     设置页
	/// </summary>
	public sealed partial class SettingPage : AnimatePage
	{

		public static Color PageColor => XamlResources . Resources . DeepRed ;

		public SettingPage ( ) { InitializeComponent ( ) ; }

		protected override void OnNavigatedTo ( NavigationEventArgs e ) { }

		private void Page_Loaded ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( ) ;
			}
			if ( AppSettings . Current . ComicSansMode )
			{
				MainGrid . TurnOnComicSansMode ( ) ;
			}
			StartStoryboard . Completed += StartStoryboard_Completed ;
			StartStoryboard . Begin ( ) ;
		}

		private void StartStoryboard_Completed ( object sender , object e )
		{
			StartStoryboard . Completed -= StartStoryboard_Completed ;
			AddControl ( ) ;
		}

		public override void RemoveControl ( )
		{
			if ( ApiInformation . IsEventPresent ( typeof ( HardwareButtons ) . FullName ,
													nameof(HardwareButtons . BackPressed) ) )
			{
				HardwareButtons . BackPressed -= MainPageButton_Click ;
			}
			MainPageButton . Click -= MainPageButton_Click ;
			AboutPageButton . Click -= AboutPageButton_Click ;
			ThrowExceptionButton . Click -= ThrowExceptionButton_Click ;
		}

		public override void AddControl ( )
		{
			if ( ApiInformation . IsEventPresent ( typeof ( HardwareButtons ) . FullName ,
													nameof(HardwareButtons . BackPressed) ) )
			{
				HardwareButtons . BackPressed += MainPageButton_Click ;
			}
			MainPageButton . Click += MainPageButton_Click ;
			AboutPageButton . Click += AboutPageButton_Click ;
			ThrowExceptionButton . Click += ThrowExceptionButton_Click ;
		}

		private void ThrowExceptionButton_Click ( object sender , RoutedEventArgs e )
		{
			throw new NotImplementedException ( ) ;
		}

		private void MainPageButton_Click ( object sender , object e )
		{
			SetEventArgsHandled ( e ) ;
			this . NavigateTo <MainPage> ( ) ;
		}

		private void AboutPageButton_Click ( object sender , object e ) { this . NavigateTo <AboutPage> ( ) ; }

	}

}
