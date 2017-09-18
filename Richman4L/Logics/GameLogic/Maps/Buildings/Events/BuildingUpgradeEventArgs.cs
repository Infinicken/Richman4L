using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Maps . Buildings . Events
{

	public class BuildingUpgradeEventArgs : BuildingEventArgs
	{

		public BuildingGrade SourceGrade { get ; }

		public BuildingGrade TargetGrade { get ; }

		public BuildingUpgradeEventArgs ( BuildingGrade sourceGrade , BuildingGrade targetGrade )
		{
			SourceGrade = sourceGrade ;
			TargetGrade = targetGrade ;
		}

	}

}
