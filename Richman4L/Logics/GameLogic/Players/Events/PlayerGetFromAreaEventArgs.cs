using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Players . Events
{

	public sealed class PlayerGetFromAreaEventArgs : PlayerGetEventArgs
	{

		public Area Area { get ; }

		public Player Player { get ; }

		public override long Money { get ; }

		public PlayerGetFromAreaEventArgs ( Area area , Player player , long money )
		{
			Area = area ;
			Player = player ;
			Money = money ;
		}

	}

}
