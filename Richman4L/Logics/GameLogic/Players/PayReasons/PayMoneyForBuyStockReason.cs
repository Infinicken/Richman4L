using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Stocks ;

namespace WenceyWang . Richman4L . Logics . Players . PayReasons
{

	public class PayMoneyForBuyStockReason : PayMoneyReason
	{

		[NotNull]
		public Stock Stock { get ; }

		public int Number { get ; }

		public override string Reason { get ; }

		public PayMoneyForBuyStockReason ( [NotNull] Stock stock , int number , long amount , WithAssetObject target ) :
			base ( amount , target )
		{
			Stock = stock ?? throw new ArgumentNullException ( nameof(stock) ) ;
			Number = number ;
		}

	}

}
