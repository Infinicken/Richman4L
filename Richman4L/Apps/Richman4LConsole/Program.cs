using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

using WenceyWang . FIGlet;
using WenceyWang . Richman4L . App . CharacterMapRenderer;
using WenceyWang . Richman4L . Maps;

using ConsoleColor = System . ConsoleColor;

namespace WenceyWang . Richman4L . Apps . Console
{

	public static class Program
	{

		public static void Main ( string [ ] args )
		{
			GameTitle . LoadTitles ( );
			System . Console . Clear ( );

			GameTitle title = GameTitle . GetTitle ( true );
			System . Console . SetCursorPosition ( 0 , 10 );
			System . Console . WriteLine ( new AsciiArt ( title . TitleRoot ) );
			System . Console . WriteLine ( new AsciiArt ( "4" ) );
			System . Console . WriteLine ( new AsciiArt ( title . TitleKey ) );

			DateTime startTime = DateTime . Now;
			System . Console . OutputEncoding = new UnicodeEncoding ( );
			MapObject . LoadMapObjects ( );
			CharacterMapRenderer . LoadMapObjectRenderers ( );
			Map map = new Map ( "Test.xml" );
			DateTime loadEndTime = DateTime . Now;
			CharacterMapRenderer renderer = new CharacterMapRenderer ( );
			renderer . SetMap ( map );
			renderer . SetUnit ( ConsoleSize . Large );
			renderer . StartUp ( );
			System . Console . SetCursorPosition ( 0 , 0 );

			//System . Console . SetWindowSize ( renderer . CharacterWeith , renderer . CharacterHeight ) ;
			DateTime caluEndTime = DateTime . Now;
			ConsoleColor currentBackgroundColor = System . Console . BackgroundColor;
			ConsoleColor currentForegroundColor = System . Console . ForegroundColor;
			StringBuilder stringBuilder = new StringBuilder ( );
			int outCount = 0;
			int outBlock = 0;
			for ( int y = 0 ; y < renderer . CharacterHeight ; y++ )
			{
				for ( int x = 0 ; x < renderer . CharacterWeith ; x++ )
				{
					ConsoleColor targetBackgroundColor = ( ConsoleColor ) renderer . CurrentView [ x , y ] . BackgroundColor;
					ConsoleColor targetForegroundColor = ( ConsoleColor ) renderer . CurrentView [ x , y ] . ForegroundColor;
					if ( currentBackgroundColor != targetBackgroundColor ||
						currentForegroundColor != targetForegroundColor )
					{
						outCount++;
						System . Console . Write ( stringBuilder . ToString ( ) );
						stringBuilder . Clear ( );
						System . Console . BackgroundColor = currentBackgroundColor = targetBackgroundColor;
						System . Console . ForegroundColor = currentForegroundColor = targetForegroundColor;
					}
					outBlock++;
					stringBuilder . Append ( renderer . CurrentView [ x , y ] . Character );
				}
				stringBuilder . AppendLine ( );
			}

			System . Console . Write ( stringBuilder . ToString ( ) );
			System . Console . ResetColor ( );

			//System . Console . WriteLine ( );
			System . Console . WriteLine ( $"outCount:{outCount}" );
			System . Console . WriteLine ( $"outBlock:{outBlock}" );
			System . Console . WriteLine ( $"loadTime:{loadEndTime - startTime}" );
			System . Console . WriteLine ( $"caluTime:{caluEndTime - loadEndTime}" );
			System . Console . WriteLine ( $"outTime:{DateTime . Now - caluEndTime}" );
		}

	}

}
