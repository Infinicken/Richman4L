using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI . Xaml . Controls ;

using WenceyWang . Richman4L . Stocks ;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WenceyWang . Richman4L . Apps . Uni . UI . Controls
{

	public sealed partial class StockInfoControl : UserControl
	{

		public Stock Target { get ; set ; }

		public StockInfoControl ( ) { InitializeComponent ( ) ; }

	}

}
