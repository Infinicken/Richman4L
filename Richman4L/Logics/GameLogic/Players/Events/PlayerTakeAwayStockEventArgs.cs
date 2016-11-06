using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Properties ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Players .Events
{

	public class PlayerTakeAwayStockEventArgs : PlayerEventArgs
	{

		[ NotNull ]
		public Stock Stock { get ; }

		public int Number { get ; }

		public PlayerTakeAwayStockEventArgs ( [ NotNull ] Stock stock , int number )
		{
			if ( stock == null )
			{
				throw new ArgumentNullException ( nameof ( stock ) ) ;
			}

			Stock = stock ;
			Number = number ;
		}

	}

}
