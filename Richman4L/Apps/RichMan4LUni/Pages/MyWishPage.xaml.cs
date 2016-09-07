using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni .Pages
{

	/// <summary>
	///     作者想说的页。
	/// </summary>
	public sealed partial class MyWishPage : Page
	{

		public MyWishPage ( )
		{
			Loaded += MyWishPage_Loaded ;
			InitializeComponent ( ) ;
		}

		private void MyWishPage_Loaded ( object sender , RoutedEventArgs e )
		{
			StartStoryboard . Completed += StartStoryboard_Completed ;
			StartStoryboard . Begin ( ) ;
		}

		private void StartStoryboard_Completed ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( ) ;
			}
			StartStoryboard . Completed -= StartStoryboard_Completed ;
			AddControl ( ) ;
		}

		private void AddControl ( ) { OKButton . Click += OKButton_Click ; }

		private void RemoveControl ( ) { OKButton . Click -= OKButton_Click ; }

		private void OKButton_Click ( object sender , RoutedEventArgs e )
		{
			AppSettings . Current . AcceptLicence = true ;
			PageNavigateHelper . Navigate ( typeof ( MainPage ) ,
											null ,
											"Cyan" ,
											LeaveStoryboard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl ) ;
		}

	}

}
