using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows ;

namespace WenceyWang . Richman4L . Apps . Wpf
{

	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow ( )
		{
			App . Current . Window = this ;
			InitializeComponent ( ) ;
		}

	}

}
