using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps . Buildings ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public class PlayerUpgradeBuildingEventArgs : PlayerEventArgs
	{

		public Building Building { get ; }

		public BuildingGrade SourceGrade { get ; }

		public BuildingGrade TargetGrade { get ; }

		public PlayerUpgradeBuildingEventArgs ( Building building , BuildingGrade sourceGrade , BuildingGrade targetGrade )
		{
			Building = building ;
			SourceGrade = sourceGrade ;
			TargetGrade = targetGrade ;
		}

	}

}
