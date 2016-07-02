using System ;

using WenceyWang . Richman4L . Properties ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Players .Events
{

	public class PlayerPayForStockDelegateEventArgs : PlayerEventArgs
	{

		[NotNull]
		public StockDelegate StockDelegate { get; }

		public long Money { get; }

		public PlayerPayForStockDelegateEventArgs ( [NotNull] StockDelegate stockDelegate , long money )
		{
			if ( stockDelegate == null )
			{
				throw new ArgumentNullException ( nameof ( stockDelegate ) );
			}

			StockDelegate = stockDelegate;
			Money = money;
		}

	}

}