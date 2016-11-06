using System ;
using System . Collections ;
using System . Linq ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni .Pages
{

	/// <summary>
	///     光敏性癫痫警告页。
	/// </summary>
	public sealed partial class PhotosensitiveSeizureWarningPage : Page
	{

		public PhotosensitiveSeizureWarningPage ( )
		{
			Loaded += PhotosensitiveSeizureWarningPage_Loaded ;
			InitializeComponent ( ) ;
		}

		private void PhotosensitiveSeizureWarningPage_Loaded ( object sender , RoutedEventArgs e )
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

		public void AddControl ( ) { KnowButton . Click += KnowButton_Click ; }

		public void RemoveControl ( ) { KnowButton . Click -= KnowButton_Click ; }

		private void KnowButton_Click ( object sender , RoutedEventArgs e )
		{
			PageNavigateHelper . Navigate ( typeof ( MyWishPage ) ,
											null ,
											"DarkBlue" ,
											LeaveStoryboard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl ) ;
		}

	}

}
