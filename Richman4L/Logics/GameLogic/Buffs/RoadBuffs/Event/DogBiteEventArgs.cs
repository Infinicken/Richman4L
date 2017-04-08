using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Buffs . RoadBuffs . Event
{

	public class DogBiteEventArgs : EventArgs
	{

		public Player Victim { get ; }

		public int Days { get ; }

		public DogBiteEventArgs ( Player victim , int days )
		{
			if ( victim == null )
			{
				throw new ArgumentNullException ( nameof(victim) ) ;
			}

			Victim = victim ;
			Days = days ;
		}

	}

}
