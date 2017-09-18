using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps . Roads ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public sealed class PlayerMoveEventArgs : PlayerEventArgs
	{

		public Road OldPosition => MovePath . Route . First ( ) ;

		public Road NewPosition => MovePath . Terminal ;

		public Path MovePath { get ; }

		public ReadOnlyCollection <int> DiceResult { get ; }

		public PlayerMoveEventArgs ( Path movePath , ReadOnlyCollection <int> diceResult )
		{
			MovePath = movePath ;
			DiceResult = diceResult ;
		}

	}

}
