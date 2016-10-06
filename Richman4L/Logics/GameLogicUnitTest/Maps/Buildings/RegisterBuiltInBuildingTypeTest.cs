using Microsoft . VisualStudio . TestTools . UnitTesting ;

using WenceyWang . Richman4L . Maps . Buildings ;

namespace WenceyWang . Richman4L . UnitTests . Maps .Buildings
{

	[ TestClass ]
	public class RegisterBuiltInBuildingTypeTest
	{

		[ TestMethod ]
		public void RegisterSmallSimpleBuildingTypeTest ( )
		{
			Building . RegisBuildingType ( typeof ( SmallSimpleBuilding ) ,
											ResourceHelper . LoadXmlDocument (
																$"{nameof ( Maps )}.{nameof ( Buildings )}.Resources.SmallSimpleBuilding.xml" )
															. Root ) ;
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
