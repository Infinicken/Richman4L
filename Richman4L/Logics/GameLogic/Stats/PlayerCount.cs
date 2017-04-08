using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Stats
{

	public class PlayerCount
	{

		public Player Player { get ; }

		public long Count { get ; internal set ; }

		public PlayerCount ( Player player )
		{
			Player = player ;
			Count = 1 ;
		}

	}

}
