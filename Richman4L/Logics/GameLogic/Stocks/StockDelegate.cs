using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Stocks
{
	/// <summary>
	/// 为股票委托提供基类
	/// </summary>
	public abstract class StockDelegate
	{
		public Players . Player Player { get; }

		public Stock Stock { get; }

		public StockDelegate ( Players . Player player , Stock stock )
		{
			Player = player;
			Stock = stock;
		}
	}
}
