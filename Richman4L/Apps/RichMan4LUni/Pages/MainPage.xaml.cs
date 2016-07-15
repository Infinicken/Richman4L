﻿using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

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
			;
		}

		private void MainPage_Loaded ( object sender , RoutedEventArgs e )
		{
			StartStoryBoard . Begin ( );
			StartStoryBoard . Completed += StartStoryBoard_Completed;
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
			SettingButton . Click += SettingButton_Click;
		}

		private void RemoveControl ( )
		{
			NewGameButton . Click -= NewGameButton_Click;
			SettingButton . Click -= SettingButton_Click;
		}

		private void MainPage_SizeChanged ( object sender , SizeChangedEventArgs e )
		{
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
