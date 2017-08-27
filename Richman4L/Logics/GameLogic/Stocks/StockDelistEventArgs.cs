using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Stocks
{

	public class StockDelistEventArgs : EventArgs
	{

		public StockDelistReason Reason { get ; set ; }

		public StockDelistEventArgs ( StockDelistReason reason ) { Reason = reason ; }

	}

}
