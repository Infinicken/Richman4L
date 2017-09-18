using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI ;
using Windows . UI . Xaml ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Pages . Initialization
{

	/// <summary>
	///     光敏性癫痫警告页。
	/// </summary>
	public sealed partial class PhotosensitiveSeizureWarningPage : AnimatePage
	{

		public static Color PageColor => XamlResources . Resources . DarkBlue ;

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

		public override void AddControl ( ) { KnowButton . Click += KnowButton_Click ; }

		public override void RemoveControl ( ) { KnowButton . Click -= KnowButton_Click ; }

		private void KnowButton_Click ( object sender , RoutedEventArgs e )
		{
			this . NavigateTo <MyWishPage> ( ) ;

			//PageNavigateHelper . NavigateTo ( typeof ( MyWishPage ) ,
			//								null ,
			//								"DarkBlueBrush" ,
			//								LeaveStoryboard ,
			//								BackgroundRect ,
			//								Frame ,
			//								RemoveControl ,
			//								AddControl ) ;
		}

	}

}
