using System ;

namespace WenceyWang . Richman4L . Buffs . RoadBuffs .Event
{

	public class DogDeadEventArgs : EventArgs
	{

		public DogDeadCause Cause { get ; }

		//public Player Murderer { get; }

		public DogDeadEventArgs ( DogDeadCause cause ) { Cause = cause ; }

	}

}
