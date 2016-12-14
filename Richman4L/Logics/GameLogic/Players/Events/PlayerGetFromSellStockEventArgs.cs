using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Properties ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Players .Events
{

	public class PlayerGetFromSellStockEventArgs : PlayerGetEventArgs
	{

		[NotNull]
		public Stock Stock { get ; }

		public int Number { get ; }

		public override long Money { get ; }

		public PlayerGetFromSellStockEventArgs ( [NotNull] Stock stock , int number , long money )
		{
			if ( stock == null )
			{
				throw new ArgumentNullException ( nameof ( stock ) ) ;
			}

			Stock = stock ;
			Number = number ;
			Money = money ;
		}

	}

}
