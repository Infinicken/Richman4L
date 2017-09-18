using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Buffs . PlayerBuffs ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public class PlayerLostBuffEventArgs : PlayerEventArgs
	{

		public PlayerBuff Buff { get ; }

		public PlayerLostBuffEventArgs ( PlayerBuff buff ) { Buff = buff ; }

	}

}
