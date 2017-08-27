using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Players . Events
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
