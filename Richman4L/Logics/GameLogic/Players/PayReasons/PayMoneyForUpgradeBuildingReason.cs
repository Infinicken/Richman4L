using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Maps . Buildings ;

namespace WenceyWang . Richman4L . Players . PayReasons
{

	public class PayMoneyForUpgradeBuildingReason : PayMoneyReason
	{

		public Building Building { get ; }

		public BuildingGrade SourceGrade { get ; }

		public BuildingGrade TargetGrade { get ; }

		public override string Reason { get ; }

		public PayMoneyForUpgradeBuildingReason ( Building building ,
												BuildingGrade sourceGrade ,
												BuildingGrade targetGrade ,
												long amount ,
												WithAssetObject target ) : base ( amount , target )
		{
			Building = building ;
			SourceGrade = sourceGrade ;
			TargetGrade = targetGrade ;
		}

	}

}
