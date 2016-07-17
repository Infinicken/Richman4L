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

using System;

using Microsoft . VisualStudio . TestTools . UnitTesting;

using WenceyWang . Richman4L . App . CharacterMapRenderer;
using WenceyWang . Richman4L . Maps;

namespace WenceyWang . Richman4L . UnitTests . Maps
{

	[TestClass]
	public class MapTest
	{

		[TestMethod]
		public void LoadMapTest ( )
		{
			MapObject . LoadMapObjects ( );
			CharacterMapRenderer . LoadMapObjectRenderers ( );
			Map map = new Map ( "Test.xml" );
			CharacterMapRenderer renderer = new CharacterMapRenderer ( );
			renderer . SetMap ( map );
			renderer . SetUnit ( ConsoleSize . Large );
			renderer . StartUp ( );
			for ( int y = 0 ; y < renderer . CharacterHeight ; y++ )
			{
				for ( int x = 0 ; x < renderer . CharacterWeith ; x++ )
				{
					Console . BackgroundColor = ( System . ConsoleColor ) renderer . CurrentView [ x , y ] . BackgroundColor;
					Console . ForegroundColor = ( System . ConsoleColor ) renderer . CurrentView [ x , y ] . ForegroundColor;
					Console . Write ( renderer . CurrentView [ x , y ] . Character );
				}
				Console . WriteLine ( );
			}
		}

	}

}
