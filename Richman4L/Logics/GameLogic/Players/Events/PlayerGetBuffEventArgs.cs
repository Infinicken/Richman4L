using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Buffs . PlayerBuffs ;

namespace WenceyWang . Richman4L . Players . Events
{

	public class PlayerGetBuffEventArgs : PlayerEventArgs
	{

		public PlayerBuff Buff { get ; }

		public PlayerGetBuffEventArgs ( PlayerBuff buff ) { Buff = buff ; }

	}

}
