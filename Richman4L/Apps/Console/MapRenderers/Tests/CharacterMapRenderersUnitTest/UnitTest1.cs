using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Apps . Console . MapRenderers . Tests
{

	[TestClass]
	public class UnitTest
	{

		[TestInitialize]
		public void RunStartup ( )
		{
			System . Console . OutputEncoding = new UnicodeEncoding ( ) ;
			Logics . Startup . RunAllTask ( ) . Wait ( ) ;
			Startup . RunAllTask ( ) . Wait ( ) ;
		}

		[TestMethod]
		public void TestMethod1 ( )
		{
			CharacterMapRenderer renderer = new CharacterMapRenderer ( ) ;

			Map map = new Map ( "Test.xml" ) ;

			renderer . SetMap ( map ) ;
			renderer . SetUnit ( ConsoleSize . Large ) ;
			renderer . StartUp ( ) ;

			//System . Console . SetWindowSize ( renderer . CharacterWeith , renderer . CharacterHeight ) ;
			DateTime caluEndTime = DateTime . Now ;
			ConsoleColor currentBackgroundColor = System . Console . BackgroundColor ;
			ConsoleColor currentForegroundColor = System . Console . ForegroundColor ;
			StringBuilder stringBuilder = new StringBuilder ( ) ;
			int outCount = 0 ;
			int outBlock = 0 ;
			for ( int y = 0 ; y < renderer . CharacterHeight ; y++ )
			{
				for ( int x = 0 ; x < renderer . CharacterWeith ; x++ )
				{
					ConsoleColor targetBackgroundColor = renderer . CurrentView [ x , y ] . BackgroundColor ;
					ConsoleColor targetForegroundColor = renderer . CurrentView [ x , y ] . ForegroundColor ;
					if ( currentBackgroundColor != targetBackgroundColor
						|| currentForegroundColor != targetForegroundColor )
					{
						outCount++ ;
						System . Console . Write ( stringBuilder . ToString ( ) ) ;
						stringBuilder . Clear ( ) ;
						System . Console . BackgroundColor = currentBackgroundColor = targetBackgroundColor ;
						System . Console . ForegroundColor = currentForegroundColor = targetForegroundColor ;
					}
					outBlock++ ;
					stringBuilder . Append ( renderer . CurrentView [ x , y ] . Character ) ;
				}

				stringBuilder . AppendLine ( ) ;
			}

			System . Console . Write ( stringBuilder . ToString ( ) ) ;
			System . Console . ResetColor ( ) ;
			System . Console . WriteLine ( outBlock ) ;
			System . Console . WriteLine ( outCount ) ;
		}

	}

}
