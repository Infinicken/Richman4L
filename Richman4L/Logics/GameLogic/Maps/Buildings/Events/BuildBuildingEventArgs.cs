using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Maps . Buildings . Events
{

	public class BuildBuildingEventArgs : BuildingEventArgs
	{

		public Building Building { get ; }


		public BuildBuildingEventArgs ( Building building )
		{
			#region Chenck Argument

			#endregion

			Building = building ?? throw new ArgumentNullException ( nameof(building) ) ;
		}

	}

}
