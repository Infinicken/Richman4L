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
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Navigation ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni . UI .Pages
{

	/// <summary>
	///     关于页。
	/// </summary>
	public sealed partial class AboutPage : AnimatePage
	{

		public static Color PageColor => XamlResources . Resources . Blue ;

		public AboutPage ( )
		{
			InitializeComponent ( ) ;
			StartStoryboard . Completed += StartStoryboardCompleted ;
		}

		protected override void OnNavigatedTo ( NavigationEventArgs e ) { }

		private void Page_Loaded ( object sender , RoutedEventArgs e ) { StartStoryboard . Begin ( ) ; }

		private void StartStoryboardCompleted ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( ) ;
			}
			StartStoryboard . Completed -= StartStoryboardCompleted ;
		}


		private void SettingPageButton_Click ( object sender , object e )
		{
			SetEventArgsHandled ( e ) ;
			this . NavigateTo <SettingPage> ( ) ;
		}

		public override void RemoveControl ( )
		{
			if ( ApiInformation . IsEventPresent ( "Windows.Phone.UI.Input.HardwareButtons" ,
													nameof ( HardwareButtons . BackPressed ) ) )
			{
				HardwareButtons . BackPressed -= SettingPageButton_Click ;
			}
			SettingPageButton . Click -= SettingPageButton_Click ;
		}

		public override void AddControl ( )
		{
			if ( ApiInformation . IsEventPresent ( "Windows.Phone.UI.Input.HardwareButtons" ,
													nameof ( HardwareButtons . BackPressed ) ) )
			{
				HardwareButtons . BackPressed += SettingPageButton_Click ;
			}
			SettingPageButton . Click += SettingPageButton_Click ;
		}

	}

}
