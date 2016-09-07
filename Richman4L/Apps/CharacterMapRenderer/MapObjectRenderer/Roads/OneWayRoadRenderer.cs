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

using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Roads ;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer .Roads
{

	public class OneWayRoadRenderer : CharacterMapObjectRenderer < OneWayRoad >
	{

		public override void Update ( )
		{
			if ( Unit == ConsoleSize . Small )
			{
				switch ( Target . GetAzimuth ( Target . Exit ) )
				{
					case BlockAzimuth . None :
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '×' , ConsoleColor . Red , ConsoleColor . DarkGray ) ;
						break ;
					}
					case BlockAzimuth . Up :
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '↑' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						break ;
					}
					case BlockAzimuth . Down :
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '↓' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						break ;
					}
					case BlockAzimuth . Left :
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '←' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						break ;
					}
					case BlockAzimuth . Right :
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '→' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						break ;
					}
				}
			}
			else if ( Unit == ConsoleSize . Large )
			{
				if ( Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Up )
				{
					for ( int y = 0 ; y < 3 ; y++ )
					{
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , y ] = new ConsoleChar ( "┃ ↑ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Up &&
						Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Down )
				{
					for ( int y = 0 ; y < 3 ; y++ )
					{
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , y ] = new ConsoleChar ( "┃ ↓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Left &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Right )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						for ( int y = 0 ; y < 3 ; y++ )
						{
							CurrentView [ x , y ] = new ConsoleChar ( "━←━" [ y ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Right &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Left )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						for ( int y = 0 ; y < 3 ; y++ )
						{
							CurrentView [ x , y ] = new ConsoleChar ( "━→━" [ y ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Left &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Up )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ↓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 1 ] = new ConsoleChar ( "←←┛ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━┛" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Up &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Left )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ↑ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 1 ] = new ConsoleChar ( "→→┛ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━┛" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Right &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Up )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ↓ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┗→→" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 2 ] = new ConsoleChar ( "┗━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Up &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Right )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ↑ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┗←←" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 2 ] = new ConsoleChar ( "┗━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Left &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Down )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━┓" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 1 ] = new ConsoleChar ( "←←┓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ↑ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Down &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Left )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━┓" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 1 ] = new ConsoleChar ( "→→┓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ↓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Right &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Down )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						CurrentView [ x , 0 ] = new ConsoleChar ( "┏━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┏→→" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ↑ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
				}
				else if ( Target . GetAzimuth ( Target . Exit ) == BlockAzimuth . Down &&
						Target . GetAzimuth ( Target . Entrance ) == BlockAzimuth . Right )
				{
					for ( int x = 0 ; x < 5 ; x++ )
					{
						CurrentView [ x , 0 ] = new ConsoleChar ( "┏━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┏←←" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
						CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ↓ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
				}
			}
		}

	}

}
