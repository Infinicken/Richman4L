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

using Windows . Foundation . Metadata ;
using Windows . Phone . UI . Input ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Navigation ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni .Pages
{

	/// <summary>
	///     设置页
	/// </summary>
	public sealed partial class SettingPage : Page
	{

		public SettingPage ( ) { InitializeComponent ( ) ; }

		protected override void OnNavigatedTo ( NavigationEventArgs e )
		{
			if ( ApiInformation . IsEventPresent ( "Windows.Phone.UI.Input.HardwareButtons" ,
													nameof ( HardwareButtons . BackPressed ) ) )
			{
				HardwareButtons . BackPressed += MainPageButton_Click ;
			}
		}

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
			StartStoryBoard . Completed += StartStoryBoard_Completed ;
			StartStoryBoard . Begin ( ) ;
		}

		private void StartStoryBoard_Completed ( object sender , object e )
		{
			StartStoryBoard . Completed -= StartStoryBoard_Completed ;
			AddControl ( ) ;
		}

		private void RemoveControl ( )
		{
			MainPageButton . Click -= MainPageButton_Click ;
			AboutPageButton . Click += AboutPageButton_Click ;
		}

		private void AddControl ( )
		{
			MainPageButton . Click += MainPageButton_Click ;
			AboutPageButton . Click += AboutPageButton_Click ;
		}


		private void MainPageButton_Click ( object sender , object e )
		{
			BackClickEventArgs args = e as BackClickEventArgs ;
			if ( args != null )
			{
				args . Handled = true ;
			}
			PageNavigateHelper . Navigate ( typeof ( MainPage ) ,
											null ,
											"Cyan" ,
											LeaveStoryBoard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl ) ;
		}

		private void AboutPageButton_Click ( object sender , object e )
		{
			PageNavigateHelper . Navigate ( typeof ( AboutPage ) ,
											null ,
											"Blue" ,
											LeaveStoryBoard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl ) ;
		}

	}

}
