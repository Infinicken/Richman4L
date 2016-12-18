using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Players . PayReasons ;

namespace WenceyWang . Richman4L . Players .Events
{

	public class PlayerPayEventArgs : PlayerEventArgs
	{

		public virtual long Money { get ; }

		public PayReason Reason { get ; }

		public PlayerPayEventArgs ( long money , PayReason reason )
		{
			Money = money ;
			Reason = reason ;
		}

	}

}
