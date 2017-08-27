using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Maps . Buildings ;

namespace WenceyWang . Richman4L . Players . PayReasons
{

	public sealed class PayMoneyForMaintainBuildingReason : PayMoneyReason
	{

		public Building Building { get ; }

		public override string Reason { get ; }

		public PayMoneyForMaintainBuildingReason ( Building building , long amount , WithAssetObject target ) :
			base ( amount , target )
		{
			Building = building ;
		}

	}

}
