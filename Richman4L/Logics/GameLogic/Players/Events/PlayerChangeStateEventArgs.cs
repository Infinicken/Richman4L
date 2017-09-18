using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public class PlayerChangeStateEventArgs : PlayerEventArgs
	{

		public PlayerState OldState { get ; set ; }

		public PlayerState NewState { get ; set ; }

		public long Duration { get ; set ; }

		public PlayerChangeStateEventArgs ( PlayerState oldState , PlayerState newState , long duration )
		{
			OldState = oldState ;
			NewState = newState ;
			Duration = duration ;
		}

	}

}
