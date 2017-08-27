using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Statistics
{

	public class PlayerCount
	{

		public Player Player { get ; }

		public long Count { get ; set ; }

		public PlayerCount ( Player player )
		{
			Player = player ;
			Count = 0 ;
		}

		public void Add ( ) { Count++ ; }

	}

}
