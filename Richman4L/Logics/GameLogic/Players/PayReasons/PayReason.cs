using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Players . Events ;

namespace WenceyWang . Richman4L . Players .PayReasons
{

	public class PayReason : PlayerEventArgs
	{

		public string Reason { get ; }

		public PayReason ( long money ) { }

		protected PayReason ( ) { }

	}

}
