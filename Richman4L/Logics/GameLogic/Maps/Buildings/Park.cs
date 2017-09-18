using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Calendars ;

namespace WenceyWang . Richman4L . Logics . Maps . Buildings
{

	public class Park : Building
	{

		public override bool IsEasyToDestroy => true ;

		public override long MaintenanceFee { get ; }

		public override int NoncombustiblePartRatio { get ; }


		public override long MinimumValue { get ; }

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate thisDate ) { }

		public override void Destoy ( BuildingDestroyReason reason ) { }

	}

}
