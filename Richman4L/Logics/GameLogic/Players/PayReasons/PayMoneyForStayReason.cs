using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Logics . Players . PayReasons
{

	public class PayMoneyForStayReason : PayMoneyReason
	{

		public Area Area { get ; }

		public override string Reason => throw new NotImplementedException ( ) ;

		public PayMoneyForStayReason ( Area area , long amount , WithAssetObject target ) : base ( amount , target )
		{
			Area = area ;
		}

	}

}
