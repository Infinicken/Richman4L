using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . Buffs . RoadBuffs . Event
{
	public class DogDeadEventArgs : EventArgs
	{

		public DogDeadCause Cause { get; }

		//public Player Murderer { get; }

		public DogDeadEventArgs ( DogDeadCause cause )
		{
			Cause = cause;
		}

	}
}
