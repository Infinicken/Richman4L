using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Stocks
{
	/// <summary>
	/// 表示销售股票的委托
	/// </summary>
	public sealed class SellStockDelegate : StockDelegate
	{
		public int Number { get; set; }

		public decimal Price { get; set; }

		public SellStockDelegateState State { get; internal set; }

		public SellStockDelegate ( Players . Player player , Stock stock , int number , decimal price ) : base ( player , stock )
		{
			Number = number;
			Price = price;
			State = SellStockDelegateState . Waiting;
		}

	}
}
