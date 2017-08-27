using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Players . PayReasons
{

	public class PayMoneyForStockDelegateReason : PayMoneyReason
	{

		[NotNull]
		public StockDelegate StockDelegate { get ; }

		public override string Reason { get ; }

		public PayMoneyForStockDelegateReason ( [NotNull] StockDelegate stockDelegate , long amount , WithAssetObject target )
			: base ( amount , target )
		{
			StockDelegate = stockDelegate ?? throw new ArgumentNullException ( nameof(stockDelegate) ) ;
		}

	}

}
