using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players . PayReasons ;

namespace WenceyWang . Richman4L . Players . Events
{

	public class PlayerPayEventArgs : PlayerEventArgs
	{

		public virtual long Money { get ; }

		public PayMoneyReason Reason { get ; }

		public PlayerPayEventArgs ( long money , PayMoneyReason reason )
		{
			Money = money ;
			Reason = reason ;
		}

	}

}
