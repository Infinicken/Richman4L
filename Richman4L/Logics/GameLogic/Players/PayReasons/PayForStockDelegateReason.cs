using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Players . PayReasons
{

	public class PayForStockDelegateReason : PayReason
	{

		[NotNull]
		public StockDelegate StockDelegate { get ; }

		public PayForStockDelegateReason ( [NotNull] StockDelegate stockDelegate )
		{
			StockDelegate = stockDelegate ?? throw new ArgumentNullException ( nameof(stockDelegate) ) ;
		}

	}

}
