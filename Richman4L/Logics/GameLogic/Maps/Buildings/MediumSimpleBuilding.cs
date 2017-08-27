using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . GameEnviroment ;

namespace WenceyWang . Richman4L . Maps . Buildings
{

	[Building]
	public class MediumSimpleBuilding : Building
	{

		public override bool IsEasyToDestroy { get ; }

		public override long MaintenanceFee { get ; }

		public override int NoncombustiblePartRatio => throw new NotImplementedException ( ) ;

		[GameRuleExpression ( "" , typeof ( decimal ) )]
		public override long MinimumValue { get ; }

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

		public override void StartDay ( GameDate thisDate ) { throw new NotImplementedException ( ) ; }

		public override void Destoy ( BuildingDestroyReason reason ) { throw new NotImplementedException ( ) ; }

	}

}
