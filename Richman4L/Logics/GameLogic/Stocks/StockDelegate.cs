using System ;
using System . Collections ;
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


		public int Number { get ; set ; }

		public decimal Price { get ; set ; }

		public StockDelegate ( [NotNull] Player player , [NotNull] Stock stock , int number , decimal price )
		{
			if ( number <= 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(number) ) ;
			}
			if ( price <= 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(price) ) ;
			}

			Player = player ?? throw new ArgumentNullException ( nameof(player) ) ;
			Stock = stock ?? throw new ArgumentNullException ( nameof(stock) ) ;
			Number = number ;
			Price = price ;
		}

	}

}
