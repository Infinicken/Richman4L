using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Logics . Players . PayReasons
{

	public sealed class PayMoneyForCrossReason : PayMoneyReason
	{

		public Area Area { get ; }

		public override string Reason { get ; }

		public PayMoneyForCrossReason ( Area area , long amount , WithAssetObject target ) : base ( amount , target )
		{
			Area = area ;
		}

	}

}
