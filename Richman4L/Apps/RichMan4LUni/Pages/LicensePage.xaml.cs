using System ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;

namespace WenceyWang . Richman4L . Apps . Uni .Pages
{

	/// <summary>
	///     协议页。
	/// </summary>
	public sealed partial class LicensePage : Page
	{

		public LicensePage ( )
		{
			Loaded += LicensePage_Loaded ;
			InitializeComponent ( ) ;
		}

		private void LicensePage_Loaded ( object sender , RoutedEventArgs e )
		{
			WebView . Navigate ( new Uri ( "ms-appx-web:///License/AGPL.htm" ) ) ;
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


		private void AddControl ( )
		{
			AgreeButton . Click += AgreeButton_Click ;
			DisagreeButton . Click += DisagreeButton_Click ;
		}

		private void RemoveControl ( )
		{
			AgreeButton . Click -= AgreeButton_Click ;
			DisagreeButton . Click -= DisagreeButton_Click ;
		}

		private void AgreeButton_Click ( object sender , RoutedEventArgs e )
		{
			PageNavigateHelper . Navigate ( typeof ( PhotosensitiveSeizureWarningPage ) ,
											null ,
											"DarkBlue" ,
											LeaveStoryboard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl ) ;
		}

		private void DisagreeButton_Click ( object sender , RoutedEventArgs e )
		{
			AppSettings . Current . AcceptLicence = false ;
			LeaveStoryboard . Completed += Exit ;
			LeaveStoryboard . Begin ( ) ;
		}

		private void Exit ( object sender , object e )
		{
			LeaveStoryboard . Completed -= Exit ;
			App . Current . Exit ( ) ;
		}

	}

}
