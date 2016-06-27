using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;

using Windows . Foundation;
using Windows . Foundation . Collections;
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
	/// 光敏性癫痫警告页。
	/// </summary>
	public sealed partial class PhotosensitiveSeizureWarningPage : Page
	{

		public PhotosensitiveSeizureWarningPage ( )
		{
			Loaded += PhotosensitiveSeizureWarningPage_Loaded;
			InitializeComponent ( );
		}

		private void PhotosensitiveSeizureWarningPage_Loaded ( object sender , RoutedEventArgs e )
		{
			StartStoryboard . Completed += StartStoryboard_Completed;
			StartStoryboard . Begin ( );
		}

		private void StartStoryboard_Completed ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( );
			}
			StartStoryboard . Completed -= StartStoryboard_Completed;
			AddControl ( );
		}

		public void AddControl ( ) { KnowButton . Click += KnowButton_Click; }

		public void RemoveControl ( ) { KnowButton . Click -= KnowButton_Click; }

		private void KnowButton_Click ( object sender , RoutedEventArgs e )
		{
			PageNavigateHelper . Navigate ( typeof ( MyWishPage ) ,
											null ,
											"DarkBlue" ,
											LeaveStoryboard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl );
		}

	}

}
