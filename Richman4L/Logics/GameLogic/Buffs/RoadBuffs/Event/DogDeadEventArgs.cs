using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Buffs . RoadBuffs . Event
{

	public class DogDeadEventArgs : EventArgs
	{

		public DogDeadCause Cause { get ; }

		//public Player Murderer { get; }

		public DogDeadEventArgs ( DogDeadCause cause ) { Cause = cause ; }

	}

}
