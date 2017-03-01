using System ;
using System . Collections ;
using System . Linq ;

using Windows . UI ;
using Windows . UI . Xaml ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni . UI .Pages
{

	/// <summary>
	///     游戏的主界面
	/// </summary>
	public sealed partial class MainPage : AnimatePage
	{

		public static Color PageColor => XamlResources . Resources . Cyan ;

		public MainPage ( )
		{
			InitializeComponent ( ) ;
			Loaded += MainPage_Loaded ;
			SizeChanged += MainPage_SizeChanged ;
		}


		private void MainPage_Loaded ( object sender , RoutedEventArgs e )
		{
			Title . Text = AppSettings . Current . GameTitle . ContentWithSpace ;

			//if ( Windows . System . Profile . AnalyticsInfo . VersionInfo . DeviceFamily == "Windows.Mobile" )
			//{
			//	RootGrid . Margin = new Thickness ( 0 , 0 , -Width * 0.25 , -Height * 0.25 );
			//	RootGrid . Width = Width * 1.25;
			//	RootGrid . Height = Height * 1.25;
			//	RootGrid . RenderTransform = new ScaleTransform { ScaleX = 1 / 1.25 , ScaleY = 1 / 1.25 };
			//}
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

		public override void AddControl ( )
		{
			NewGameButton . Click += NewGameButton_Click ;
			LoadGameButton . Click += LoadGameButton_Click ;
			SettingButton . Click += SettingButton_Click ;
		}

		public override void RemoveControl ( )
		{
			NewGameButton . Click -= NewGameButton_Click ;
			LoadGameButton . Click -= LoadGameButton_Click ;
			SettingButton . Click -= SettingButton_Click ;
		}

		private void MainPage_SizeChanged ( object sender , SizeChangedEventArgs e )
		{
			//if ( Windows . System . Profile . AnalyticsInfo . VersionInfo . DeviceFamily == "Windows.Mobile" )
			//{
			//	RootGrid . Margin = new Thickness ( 0 , 0 , -e . NewSize . Width * 0.25 , -e . NewSize . Height * 0.25 );
			//	RootGrid . Width = e . NewSize . Width * 1.25;
			//	RootGrid . Height = e . NewSize . Height * 1.25;
			//	RootGrid . RenderTransform = new ScaleTransform { ScaleX = 1 / 1.25 , ScaleY = 1 / 1.25 };
			//}
			if ( e . NewSize . Height < e . NewSize . Width )
			{
				VisualStateManager . GoToState ( this , nameof ( Wide ) , false ) ;
			}
			else
			{
				VisualStateManager . GoToState ( this , nameof ( Narrow ) , false ) ;
			}
		}

		private void NewGameButton_Click ( object sender , RoutedEventArgs e )
		{
			this . NavigateTo <CreateGamePage> ( new StartGameParameters ( ) ) ;
		}

		private void LoadGameButton_Click ( object sender , RoutedEventArgs e ) { this . NavigateTo <LoadGamePage> ( ) ; }

		private void SettingButton_Click ( object sender , RoutedEventArgs e ) { this . NavigateTo <SettingPage> ( ) ; }

	}

}
