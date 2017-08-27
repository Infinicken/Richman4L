using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Players . Events
{

	public class PlayerBankruptcyEventArgs : PlayerEventArgs
	{

		public PlayerBankruptcyReason Reason { get ; }

		public PlayerBankruptcyEventArgs ( PlayerBankruptcyReason reason ) { Reason = reason ; }

	}

}
