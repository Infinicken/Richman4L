using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers . UnitTest
{

	[TestClass]
	public class UnitTest
	{

		[TestInitialize]
		public void RunStartup ( )
		{
			Console . OutputEncoding = new UnicodeEncoding ( ) ;
			Richman4L . Startup . RunAllTask ( ) ;
			Startup . RunAllTask ( ) . Wait ( ) ;
		}

		[TestMethod]
		public void TestMethod1 ( )
		{
			CharacterMapRenderer renderer = new CharacterMapRenderer ( ) ;

			//renderer.SetMap(map);
			renderer . SetUnit ( ConsoleSize . Large ) ;
			renderer . StartUp ( ) ;

			//System . Console . SetWindowSize ( renderer . CharacterWeith , renderer . CharacterHeight ) ;
			DateTime caluEndTime = DateTime . Now ;
			ConsoleColor currentBackgroundColor = Console . BackgroundColor ;
			ConsoleColor currentForegroundColor = Console . ForegroundColor ;
			StringBuilder stringBuilder = new StringBuilder ( ) ;
			int outCount = 0 ;
			int outBlock = 0 ;
			for ( int y = 0 ; y < renderer . CharacterHeight ; y++ )
			{
				for ( int x = 0 ; x < renderer . CharacterWeith ; x++ )
				{
					ConsoleColor targetBackgroundColor = renderer . CurrentView [ x , y ] . BackgroundColor ;
					ConsoleColor targetForegroundColor = renderer . CurrentView [ x , y ] . ForegroundColor ;
					if ( currentBackgroundColor != targetBackgroundColor ||
						currentForegroundColor != targetForegroundColor )
					{
						outCount++ ;
						Console . Write ( stringBuilder . ToString ( ) ) ;
						stringBuilder . Clear ( ) ;
						Console . BackgroundColor = currentBackgroundColor = targetBackgroundColor ;
						Console . ForegroundColor = currentForegroundColor = targetForegroundColor ;
					}
					outBlock++ ;
					stringBuilder . Append ( renderer . CurrentView [ x , y ] . Character ) ;
				}

				stringBuilder . AppendLine ( ) ;
			}

			Console . Write ( stringBuilder . ToString ( ) ) ;
			Console . ResetColor ( ) ;
		}

	}

}
