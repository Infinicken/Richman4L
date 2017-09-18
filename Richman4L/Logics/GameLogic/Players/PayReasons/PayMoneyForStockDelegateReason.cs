using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Stocks ;

namespace WenceyWang . Richman4L . Logics . Players . PayReasons
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
