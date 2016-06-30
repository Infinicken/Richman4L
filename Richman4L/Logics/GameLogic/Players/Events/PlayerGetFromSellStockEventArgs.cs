using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

using WenceyWang . Richman4L . Properties;
using WenceyWang . Richman4L . Stocks;

namespace WenceyWang . Richman4L . Players . Events
{

	public class PlayerGetFromSellStockEventArgs : PlayerEventArgs
	{

		[NotNull]
		Stock Stock { get; }

		int Number { get; }

		long Money { get; }

		public PlayerGetFromSellStockEventArgs ( [NotNull] Stock stock , int number , long money )
		{
			if ( stock == null )
			{
				throw new ArgumentNullException ( nameof ( stock ) );
			}

			Stock = stock;
			Number = number;
			Money = money;
		}

	}

}
