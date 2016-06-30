using System;

using WenceyWang . Richman4L . Properties;
using WenceyWang . Richman4L . Stocks;

namespace WenceyWang . Richman4L . Players . Events
{

	public class PlayerReceiveStockEventArgs : PlayerEventArgs
	{

		[NotNull]
		Stock Stock { get; }

		int Number { get; }

		public PlayerReceiveStockEventArgs ( [NotNull] Stock stock , int number )
		{
			if ( stock == null )
			{
				throw new ArgumentNullException ( nameof ( stock ) );
			}

			Stock = stock;
			Number = number;
		}

	}

}