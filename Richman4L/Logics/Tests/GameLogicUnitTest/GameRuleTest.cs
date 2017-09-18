using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

using WenceyWang . Richman4L . Logics . GameEnviroment ;
using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Logics . Tests
{

	[TestClass]
	public class GameRuleTest
	{

		[TestInitialize]
		public void RunStartup ( )
		{
			Console . OutputEncoding = new UnicodeEncoding ( ) ;
			Startup . RunAllTask ( ) . Wait ( ) ;
		}

		[TestMethod]
		public void GenerateEmptyTest ( )
		{
			GameRule emptyRule = GameRule . GenerateEmpty ( ) ;
			Console . WriteLine ( emptyRule . ToXElement ( ) ) ;
		}

		//todo:Test All Rules?
		[TestMethod]
		public void AccessExpressionTest ( )
		{
			GameRule emptyRule = GameRule . GenerateEmpty ( ) ;
			Game . PeapareNew ( ) ;
			Game . Current . GameRule = emptyRule ;
			EmptyBlock block = new EmptyBlock ( new MapPosition ( 1 , 1 ) ) ;
			GameValue c = block . Flammability ;
		}

	}

}
