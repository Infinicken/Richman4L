using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . Stocks
{

	/// <summary>
	/// 表示购买股票的委托
	/// </summary>
	public class BuyStockDelegate : StockDelegate
	{

		public int Number { get; }

		public decimal Price { get; }

		public BuyStockDelegateState State { get; internal set; }

		public BuyStockDelegate ( [NotNull] Players . Player player , [NotNull] Stock stock , int number , decimal price )
			: base ( player , stock )
		{
			Number = number;
			Price = price;

			State = BuyStockDelegateState . Waiting;
		}

	}

}
