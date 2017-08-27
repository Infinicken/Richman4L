using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . UnitTests . Maps
{

	//todo:几乎什么都没被测试。
	[TestClass]
	public class MapTest
	{

		[TestInitialize]
		public void RunStartup ( )
		{
			Console . OutputEncoding = new UnicodeEncoding ( ) ;
			Startup . RunAllTask ( ) . Wait ( ) ;
			Game . PeapareNew ( ) ;
		}

		//todo:Test Map Area
		//public void Test

		[TestMethod]
		public void SerializationMapTest ( )
		{
			Map map = new Map ( "Test.xml" ) ;
			Game . Current . GameRule = GameRule . GenerateEmpty ( ) ;
			Game . Current . Map = map ;
			Console . WriteLine ( map . ToXElement ( ) ) ;
		}

		[TestMethod]
		public void LoadMapTest ( )
		{
			Map map = new Map ( "Test.xml" ) ;
		}

	}

}
