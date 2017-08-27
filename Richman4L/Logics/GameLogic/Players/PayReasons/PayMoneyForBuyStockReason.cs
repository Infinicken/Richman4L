using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Players . PayReasons
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
