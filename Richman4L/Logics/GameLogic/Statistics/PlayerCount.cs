using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Statistics
{

	public class PlayerCount : GameObject
	{

		[Reference]
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
