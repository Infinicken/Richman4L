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
	/// 作者想说的页。
	/// </summary>
	public sealed partial class MyWishPage : Page
	{

		public MyWishPage ( )
		{
			Loaded += MyWishPage_Loaded;
			InitializeComponent ( );
		}

		private void MyWishPage_Loaded ( object sender , RoutedEventArgs e )
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

		private void AddControl ( ) { OKButton . Click += OKButton_Click; }

		private void RemoveControl ( ) { OKButton . Click -= OKButton_Click; }

		private void OKButton_Click ( object sender , RoutedEventArgs e )
		{
			AppSettings . Current . AcceptLicence = true;
			PageNavigateHelper . Navigate ( typeof ( MainPage ) ,
											null ,
											"Cyan" ,
											LeaveStoryboard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl );
		}

	}

}
