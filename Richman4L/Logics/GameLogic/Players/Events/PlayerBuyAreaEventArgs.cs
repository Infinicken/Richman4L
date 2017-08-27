using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Players . Events
{

	public sealed class PlayerBuyAreaEventArgs : PlayerEventArgs
	{

		public BuyAreaResult Result { get ; set ; }

		public PlayerBuyAreaEventArgs ( BuyAreaResult result ) { Result = result ; }

	}

}
