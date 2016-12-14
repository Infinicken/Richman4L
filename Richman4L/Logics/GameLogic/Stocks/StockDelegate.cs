using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L .Stocks
{

	/// <summary>
	///     为股票委托提供基类
	/// </summary>
	public abstract class StockDelegate
	{

		[NotNull]
		public Player Player { get ; }

		[NotNull]
		public Stock Stock { get ; }

		public StockDelegate ( [NotNull] Player player , [NotNull] Stock stock )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) ) ;
			}
			if ( stock == null )
			{
				throw new ArgumentNullException ( nameof ( stock ) ) ;
			}

			Player = player ;
			Stock = stock ;
		}

	}

}
