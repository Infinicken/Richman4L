using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Stocks . PriceController
{
	/// <summary>
	/// 指示股票价格的控制器
	/// </summary>
	public abstract class StockPriceController : GameObject
	{
		public Stock Target { get; }

		public abstract StockPrice GetPrice ( );

		protected StockPriceController ( Stock target )
		{
			Target = target;
		}

	}
}
