using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows ;
using System . Windows . Media ;

namespace WenceyWang . Richman4L . Apps . Wpf . UI . Pages
{

	/// <summary>
	/// </summary>
	public sealed partial class LoadGamePage : AnimatePage
	{

		public static Color PageColor => XamlResources . Resources . Pink ;

		public LoadGamePage ( ) { InitializeComponent ( ) ; }


		private void StartGameButton_Click ( object sender , RoutedEventArgs e ) { }

		private void MainPageButton_Click ( object sender , RoutedEventArgs e ) { }

		private void Page_Loaded ( object sender , RoutedEventArgs e ) { }

		public override void AddControl ( ) { }

		public override void RemoveControl ( ) { }

	}

}
