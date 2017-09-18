using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Stocks ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public class PlayerTakeAwayStockEventArgs : PlayerEventArgs
	{

		[NotNull]
		public Stock Stock { get ; }

		public int Number { get ; }

		public PlayerTakeAwayStockEventArgs ( [NotNull] Stock stock , int number )
		{
			Stock = stock ?? throw new ArgumentNullException ( nameof(stock) ) ;
			Number = number ;
		}

	}

}
