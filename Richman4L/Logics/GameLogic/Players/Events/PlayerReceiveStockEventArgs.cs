using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Stocks ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public class PlayerReceiveStockEventArgs : PlayerEventArgs
	{

		[NotNull]
		public Stock Stock { get ; }

		public int Number { get ; }

		public PlayerReceiveStockEventArgs ( [NotNull] Stock stock , int number )
		{
			Stock = stock ?? throw new ArgumentNullException ( nameof(stock) ) ;
			Number = number ;
		}

	}

}
