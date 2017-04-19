/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . Foundation . Metadata ;
using Windows . Phone . UI . Input ;
using Windows . UI ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Media . Imaging ;
using Windows . UI . Xaml . Navigation ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;
using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Pages
{

	/// <summary>
	///     创建游戏页面
	/// </summary>
	public sealed partial class CreateGamePage : AnimatePage
	{

		/// <summary>
		/// </summary>
		public StartGameParameters Parameters { get ; set ; }

		public static Color PageColor => XamlResources . Resources . Lime ;

		public CreateGamePage ( ) { InitializeComponent ( ) ; }

		protected override void OnNavigatedTo ( NavigationEventArgs e )
		{
			Parameters = e . Parameter as StartGameParameters ?? new StartGameParameters ( ) ;
			if ( ApiInformation . IsEventPresent ( typeof ( HardwareButtons ) . FullName ,
													nameof(HardwareButtons . BackPressed) ) )
			{
				HardwareButtons . BackPressed += MainPageButton_Click ;
			}
		}

		private void Page_Loaded ( object sender , RoutedEventArgs e )
		{
			Image map = new Image { Source = new BitmapImage ( ) } ;

			GameMapView . Items . Add ( map ) ;

			Parameters . Map = new Map ( "Test.xml" ) ;


			StartStoryboard . Begin ( ) ;
			StartStoryboard . Completed += StartStoryboard_Completed ;
		}

		private void StartStoryboard_Completed ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( ) ;
			}
			StartStoryboard . Completed -= StartStoryboard_Completed ;
		}

		private void ConditionsToWinList_SelectionChanged ( object sender , object e )
		{
			if ( ConditionsToWinButton != null &&
				ConditionsToWinList != null &&
				Parameters != null )
			{
				ConditionsToWinButton . Content = ConditionsToWinList ? . SelectedItem ;
				if ( ConditionsToWinList . SelectedItem as string != "资产最多" )
				{
					//Todo:
					//Parameters . WinningCondition =
					//	new NumberConverter ( ) . ConvertBack ( ConditionsToWinList . SelectedItem ? . ToString ( ) ) ;
				}
			}
		}

		private void MoneyStartList_SelectionChanged ( object sender , object e )
		{
			if ( MoneyStartButton != null &&
				MoneyStartList != null &&
				Parameters != null )
			{
				MoneyStartButton . Content = MoneyStartList ? . SelectedItem ;
				Parameters . StartMoney =
					NumberConverter . ConvertBack ( MoneyStartList . SelectedItem ? . ToString ( ) ) ;
			}
		}

		private void GameTimeList_SelectionChanged ( object sender , object e )
		{
			if ( GameTimeButton != null &&
				GameTimeList != null &&
				Parameters != null )
			{
				GameTimeButton . Content = GameTimeList ? . SelectedItem ;
				switch ( GameTimeList ? . SelectedItem as string )
				{
					case "无限" :
					{
						Parameters . GameTime = long . MaxValue ;
						break ;
					}
					case "50周" :
					{
						Parameters . GameTime = 50 * 7 ;
						break ;
					}
					case "25周" :
					{
						Parameters . GameTime = 25 * 7 ;
						break ;
					}
					case "15周" :
					{
						Parameters . GameTime = 15 * 7 ;
						break ;
					}
					case "5周" :
					{
						Parameters . GameTime = 5 * 7 ;
						break ;
					}
				}
			}
		}

		private void MainPageButton_Click ( object sender , object e ) { this . NavigateTo <MainPage> ( ) ; }

		private void PlayerConfigPageButton_Click ( object sender , RoutedEventArgs e )
		{
			this . NavigateTo <PlayerConfigPage> ( Parameters ) ;
		}

		public override void RemoveControl ( )
		{
			MainPageButton . Click -= MainPageButton_Click ;
			PlayerConfigPageButton . Click -= PlayerConfigPageButton_Click ;
		}

		public override void AddControl ( )
		{
			MainPageButton . Click += MainPageButton_Click ;
			PlayerConfigPageButton . Click += PlayerConfigPageButton_Click ;
		}

	}

}
