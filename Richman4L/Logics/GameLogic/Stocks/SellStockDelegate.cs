using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L .Stocks
{

	/// <summary>
	///     表示销售股票的委托
	/// </summary>
	public sealed class SellStockDelegate : StockDelegate
	{

		public int Number { get ; set ; }

		public decimal Price { get ; set ; }

		public SellStockDelegateState State { get ; internal set ; }

		public SellStockDelegate ( Player player , Stock stock , int number , decimal price ) : base ( player , stock )
		{
			Number = number ;
			Price = price ;
			State = SellStockDelegateState . Waiting ;
		}

	}

}
