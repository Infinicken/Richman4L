using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Media;

using WenceyWang . Richman4L . Apps . Uni . Logic;

namespace WenceyWang . Richman4L . Apps . Uni . Pages
{

	/// <summary>
	/// 游戏的主界面
	/// </summary>
	public sealed partial class MainPage : Page
	{

		public MainPage ( )
		{
			InitializeComponent ( );
			Loaded += MainPage_Loaded;
			SizeChanged += MainPage_SizeChanged;

		}


		private void MainPage_Loaded ( object sender , RoutedEventArgs e )
		{
			Title . Text = AppSettings . Current . GameTitle . ContentWithSpace;
			if ( Windows . System . Profile . AnalyticsInfo . VersionInfo . DeviceFamily == "Windows.Mobile" )
			{
				RootGrid . Margin = new Thickness ( 0 , 0 , -Width * 0.25 , -Height * 0.25 );
				RootGrid . Width = Width * 1.25;
				RootGrid . Height = Height * 1.25;
				RootGrid . RenderTransform = new ScaleTransform { ScaleX = 1 / 1.25 , ScaleY = 1 / 1.25 };
			}
			StartStoryBoard . Completed += StartStoryBoard_Completed;
			StartStoryBoard . Begin ( );
		}

		private void StartStoryBoard_Completed ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( );
			}
			StartStoryBoard . Completed -= StartStoryBoard_Completed;
			AddControl ( );
		}

		private void AddControl ( )
		{
			NewGameButton . Click += NewGameButton_Click;
			LoadGameButton . Click += LoadGameButton_Click;
			SettingButton . Click += SettingButton_Click;
		}

		private void RemoveControl ( )
		{
			NewGameButton . Click -= NewGameButton_Click;
			LoadGameButton . Click -= LoadGameButton_Click;
			SettingButton . Click -= SettingButton_Click;
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
			if ( e . NewSize . Height < e . NewSize . Width &&
				e . NewSize . Width >= 640 )
			{
				VisualStateManager . GoToState ( this , nameof ( Wide ) , false );
			}
			else
			{
				VisualStateManager . GoToState ( this , nameof ( Mobile ) , false );
			}
		}

		private void NewGameButton_Click ( object sender , RoutedEventArgs e )
		{
			PageNavigateHelper . Navigate ( typeof ( CreateGamePage ) ,
											new StartGameParameters ( ) ,
											"Lime" ,
											LeaveStoryBoard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl );
		}

		private void LoadGameButton_Click ( object sender , RoutedEventArgs e )
		{
			PageNavigateHelper . Navigate ( typeof ( LoadGamePage ) ,
											null ,
											"Black" ,
											LeaveStoryBoard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl );
		}

		private void SettingButton_Click ( object sender , RoutedEventArgs e )
		{
			PageNavigateHelper . Navigate ( typeof ( SettingPage ) ,
											null ,
											"DeepRed" ,
											LeaveStoryBoard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl );
		}

	}

}
