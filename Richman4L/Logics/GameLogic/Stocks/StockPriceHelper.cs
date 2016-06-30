using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Stocks
{

	public static class StockPriceHelper
	{

		public static long ToLongCelling ( this decimal price ) => Convert . ToInt64 ( decimal . Ceiling ( price ) );

		public static long ToLongFloor ( this decimal price ) => Convert . ToInt64 ( decimal . Floor ( price ) );

	}

}
