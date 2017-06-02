using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Stocks
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
			Player = player ?? throw new ArgumentNullException ( nameof(player) ) ;
			Stock = stock ?? throw new ArgumentNullException ( nameof(stock) ) ;
		}

	}

}
