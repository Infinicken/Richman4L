using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . Stocks
{
	/// <summary>
	/// 为股票委托提供基类
	/// </summary>
	public abstract class StockDelegate
	{
		[NotNull]
		public Players . Player Player { get; }

		[NotNull]
		public Stock Stock { get; }

		public StockDelegate ( [NotNull] Players . Player player , [NotNull]Stock stock )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}
			if ( stock == null )
			{
				throw new ArgumentNullException ( nameof ( stock ) );
			}

			Player = player;
			Stock = stock;
		}
	}
}
