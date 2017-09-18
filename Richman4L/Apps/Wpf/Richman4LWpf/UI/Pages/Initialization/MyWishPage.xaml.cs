using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows ;
using System . Windows . Media ;

using WenceyWang . Richman4L . Apps . Wpf . Logic ;

namespace WenceyWang . Richman4L . Apps . Wpf . UI . Pages . Initialization
{

	/// <summary>
	///     作者想说的页。
	/// </summary>
	public sealed partial class MyWishPage : AnimatePage
	{

		public static Color PageColor => XamlResources . Resources . DarkBlue ;

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

		public override void AddControl ( ) { OKButton . Click += OKButton_Click ; }

		public override void RemoveControl ( ) { OKButton . Click -= OKButton_Click ; }

		private void OKButton_Click ( object sender , RoutedEventArgs e )
		{
			AppSettings . Current . AcceptLicence = true ;
			this . NavigateTo <MainPage> ( ) ;
		}

	}

}
