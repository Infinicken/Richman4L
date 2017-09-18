using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

using WenceyWang . Richman4L . Logics . Maps . Buildings ;

namespace WenceyWang . Richman4L . Logics . Tests . Maps . Buildings
{

	[TestClass]
	public class RegisterBuiltInBuildingTypeTest
	{

		[TestMethod]
		public void RegisterSmallSimpleBuildingTypeTest ( )
		{
			Building . RegisBuildingType ( typeof ( SmallSimpleBuilding ) ,
											ResourceHelper .
												LoadXmlDocument ( $"{nameof(Maps)}.{nameof(Buildings)}.Resources.SmallSimpleBuilding.xml" ) .
												Root ) ;
		}

		//[TestMethod]
		//public void RegisterMediumSimpleBuildingTypeTest ( )
		//{
		//	Building . RegisBuildingType ( typeof ( MediumSimpleBuilding ) ,
		//		ResourceHelper . LoadXmlDocument ( $"{nameof ( Maps )}.{nameof ( Buildings )}.Resources.MediumSimpleBuilding.xml" )
		//			. Root );
		//}

	}

}
