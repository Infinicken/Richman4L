using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Stocks
{
	/// <summary>
	/// 表示购买股票的委托
	/// </summary>
	public class BuyStockDelegate : StockDelegate
	{
		public int Number { get; set; }

		public double Price { get; set; }

		public BuyStockDelegate ( Players . Player player , Stock stock , int number , double price ) : base ( player , stock )
		{
			Number = number;
			Price = price;
		}

	}
}
