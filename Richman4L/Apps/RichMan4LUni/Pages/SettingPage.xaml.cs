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
using System . Collections ;
using System . Linq ;

using Windows . Foundation . Metadata ;
using Windows . Phone . UI . Input ;
using Windows . UI ;
using Windows . UI . Xaml . Navigation ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni .Pages
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
													nameof ( HardwareButtons . BackPressed ) ) )
			{
				HardwareButtons . BackPressed -= MainPageButton_Click ;
			}
			MainPageButton . Click -= MainPageButton_Click ;
			AboutPageButton . Click += AboutPageButton_Click ;
		}

		public override void AddControl ( )
		{
			if ( ApiInformation . IsEventPresent ( typeof ( HardwareButtons ) . FullName ,
													nameof ( HardwareButtons . BackPressed ) ) )
			{
				HardwareButtons . BackPressed += MainPageButton_Click ;
			}
			MainPageButton . Click += MainPageButton_Click ;
			AboutPageButton . Click += AboutPageButton_Click ;
		}

		private void MainPageButton_Click ( object sender , object e )
		{
			SetEventArgsHandled ( e ) ;
			this . NavigateTo <MainPage> ( ) ;
		}

		private void AboutPageButton_Click ( object sender , object e ) { this . NavigateTo <AboutPage> ( ) ; }

	}

}
