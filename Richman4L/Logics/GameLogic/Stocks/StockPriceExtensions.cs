using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Stocks
{

	public static class StockPriceExtensions
	{

		public static long ToLongCelling ( this decimal price ) { return Convert . ToInt64 ( decimal . Ceiling ( price ) ) ; }

		public static long ToLongFloor ( this decimal price ) { return Convert . ToInt64 ( decimal . Floor ( price ) ) ; }

	}

}
