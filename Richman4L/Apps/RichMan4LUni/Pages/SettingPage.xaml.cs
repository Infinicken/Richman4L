using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;

using Windows . Foundation;
using Windows . Foundation . Collections;
using Windows . Foundation . Metadata;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Controls . Primitives;
using Windows . UI . Xaml . Data;
using Windows . UI . Xaml . Input;
using Windows . UI . Xaml . Media;
using Windows . UI . Xaml . Navigation;

using WenceyWang . Richman4L . App . Logic;


namespace WenceyWang . Richman4L . App . Pages
{

	/// <summary>
	/// 设置页
	/// </summary>
	public sealed partial class SettingPage : Page
	{

		public SettingPage ( )
		{
			InitializeComponent ( );
			StartStoryBoard . Completed += StartStoryBoard_Completed;
		}

		protected override void OnNavigatedTo ( NavigationEventArgs e )
		{
			if ( ApiInformation . IsEventPresent ( "Windows.Phone.UI.Input.HardwareButtons" , nameof ( Windows . Phone . UI . Input . HardwareButtons . BackPressed ) ) )
			{
				Windows . Phone . UI . Input . HardwareButtons . BackPressed += MainPageButton_Click;
			}
		}

		private void Page_Loaded ( object sender , object e ) { StartStoryBoard . Begin ( ); }

		private void StartStoryBoard_Completed ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( );
			}
			StartStoryBoard . Completed -= StartStoryBoard_Completed;
			AddControl ( );
		}

		private void RemoveControl ( )
		{
			MainPageButton . Click -= MainPageButton_Click;
			AboutPageButton . Click += AboutPageButton_Click;
		}

		private void AddControl ( )
		{
			MainPageButton . Click += MainPageButton_Click;
			AboutPageButton . Click += AboutPageButton_Click;
		}


		private void MainPageButton_Click ( object sender , object e )
		{
			PageNavigateHelper . Navigate ( typeof ( MainPage ) ,
											null ,
											"Cyan" ,
											LeaveStoryBoard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl );
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
											AddControl );
		}

	}

}
