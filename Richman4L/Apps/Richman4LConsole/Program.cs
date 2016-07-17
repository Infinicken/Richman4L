using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

using WenceyWang . Richman4L . App . CharacterMapRenderer;
using WenceyWang . Richman4L . Maps;


namespace WenceyWang . Richman4L . Apps . Console
{
	class Program
	{
		static void Main ( string [ ] args )
		{

			MapObject . LoadMapObjects ( );
			CharacterMapRenderer . LoadMapObjectRenderers ( );
			Map map = new Map ( "Test.xml" );
			CharacterMapRenderer renderer = new CharacterMapRenderer ( );
			renderer . SetMap ( map );
			renderer . SetUnit ( ConsoleSize . Large );
			renderer . StartUp ( );
			//System . Console . SetWindowSize ( renderer . CharacterWeith , renderer . CharacterHeight ) ;
			for ( int y = 0 ; y < renderer . CharacterHeight ; y++ )
			{
				for ( int x = 0 ; x < renderer . CharacterWeith ; x++ )
				{
					System . Console . SetCursorPosition ( x , y );
					System . Console . BackgroundColor = ( System . ConsoleColor ) renderer . CurrentView [ x , y ] . BackgroundColor;
					System . Console . ForegroundColor = ( System . ConsoleColor ) renderer . CurrentView [ x , y ] . ForegroundColor;
					System . Console . Write ( renderer . CurrentView [ x , y ] . Character );
				}
			}

		}
	}
}
