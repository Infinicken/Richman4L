using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Stocks ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public class PlayerGetFromSellStockEventArgs : PlayerGetEventArgs
	{

		[NotNull]
		public Stock Stock { get ; }

		public int Number { get ; }

		public override long Money { get ; }

		public PlayerGetFromSellStockEventArgs ( [NotNull] Stock stock , int number , long money )
		{
			Stock = stock ?? throw new ArgumentNullException ( nameof(stock) ) ;
			Number = number ;
			Money = money ;
		}

	}

}
