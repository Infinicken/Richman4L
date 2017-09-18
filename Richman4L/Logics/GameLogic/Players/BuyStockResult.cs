using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Players
{

	public class BuyStockResult
	{

		public BuyStockStatusCode StatusCode { get ; set ; }

		public int Number { get ; set ; }

		public long Money { get ; set ; }

	}

	public enum BuyStockStatusCode
	{

		Success ,

		MoneyNotEnough ,

		PlayerDebuff ,

		StockDebuff

	}

}
