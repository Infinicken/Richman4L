/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System ;
using System . Text ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

using WenceyWang . Richman4L . App . CharacterMapRenderer ;
using WenceyWang . Richman4L . Maps ;

using ConsoleColor = System . ConsoleColor ;

namespace WenceyWang . Richman4L . UnitTests .Maps
{

	[ TestClass ]
	public class MapTest
	{

		[ TestMethod ]
		public void LoadMapTest ( )
		{
			DateTime startTime = DateTime . Now ;

			//Console . Clear ( );
			Console . OutputEncoding = new UnicodeEncoding ( ) ;
			MapObject . LoadMapObjects ( ) ;
			CharacterMapRenderer . LoadMapObjectRenderers ( ) ;
			Map map = new Map ( "Test.xml" ) ;
			DateTime loadEndTime = DateTime . Now ;
			CharacterMapRenderer renderer = new CharacterMapRenderer ( ) ;
			renderer . SetMap ( map ) ;
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
					ConsoleColor targetBackgroundColor = ( ConsoleColor ) renderer . CurrentView [ x , y ] . BackgroundColor ;
					ConsoleColor targetForegroundColor = ( ConsoleColor ) renderer . CurrentView [ x , y ] . ForegroundColor ;
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

			//System . Console . WriteLine ( );
			Console . WriteLine ( $"outCount:{outCount}" ) ;
			Console . WriteLine ( $"outBlock:{outBlock}" ) ;
			Console . WriteLine ( $"loadTime:{loadEndTime - startTime}" ) ;
			Console . WriteLine ( $"caluTime:{caluEndTime - loadEndTime}" ) ;
			Console . WriteLine ( $"outTime:{DateTime . Now - caluEndTime}" ) ;
		}

	}

}
