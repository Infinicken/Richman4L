﻿/*
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

using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer . Roads
{

	public sealed class WithinRoadRenderer : CharacterMapObjectRenderer<WithInRoad>
	{

		public override void Update ( )
		{
			if ( Unit == ConsoleSize . Small )
			{
				#region 断头路

				//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				//	Target . BackwardRoad == null ||
				//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up &&
				//	Target . ForwardRoad == null )
				//{
				//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╨' , ConsoleColor . White , ConsoleColor . DarkGray );
				//}
				//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				//	Target . BackwardRoad == null ||
				//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down &&
				//	Target . ForwardRoad == null )
				//{
				//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╥' , ConsoleColor . White , ConsoleColor . DarkGray );
				//}
				//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				//	Target . BackwardRoad == null ||
				//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left &&
				//	Target . ForwardRoad == null )
				//{
				//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╡' , ConsoleColor . White , ConsoleColor . DarkGray );
				//}
				//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				//	Target . BackwardRoad == null ||
				//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right &&
				//	Target . ForwardRoad == null )
				//{
				//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╞' , ConsoleColor . White , ConsoleColor . DarkGray );
				//}

				#endregion

				#region 连续路

				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up )
				{
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Left )
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╢' , ConsoleColor . White , ConsoleColor . DarkGray );
					}
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Right )
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╟' , ConsoleColor . White , ConsoleColor . DarkGray );
					}

					//上下
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Up )
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╧' , ConsoleColor . White , ConsoleColor . DarkGray );
					}
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Right )
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╤' , ConsoleColor . White , ConsoleColor . DarkGray );
					}

					//左右
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					CurrentView [ 0 , 0 ] = new ConsoleChar ( '╝' , ConsoleColor . White , ConsoleColor . DarkGray );

					//左上
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					CurrentView [ 0 , 0 ] = new ConsoleChar ( '╚' , ConsoleColor . White , ConsoleColor . DarkGray );

					//右上
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					CurrentView [ 0 , 0 ] = new ConsoleChar ( '╗' , ConsoleColor . White , ConsoleColor . DarkGray );

					//左下
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					CurrentView [ 0 , 0 ] = new ConsoleChar ( '╔' , ConsoleColor . White , ConsoleColor . DarkGray );

					//右下
				}

				#endregion
			}
			else if ( Unit == ConsoleSize . Large )
			{
				#region 断头路

				//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
				//	Target . BackwardRoad == null ||
				//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up &&
				//	Target . ForwardRoad == null )
				//{
				//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╨' , ConsoleColor . White , ConsoleColor . DarkGray );
				//}
				//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
				//	Target . BackwardRoad == null ||
				//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down &&
				//	Target . ForwardRoad == null )
				//{
				//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╥' , ConsoleColor . White , ConsoleColor . DarkGray );
				//}
				//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
				//	Target . BackwardRoad == null ||
				//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left &&
				//	Target . ForwardRoad == null )
				//{
				//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╡' , ConsoleColor . White , ConsoleColor . DarkGray );
				//}
				//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
				//	Target . BackwardRoad == null ||
				//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right &&
				//	Target . ForwardRoad == null )
				//{
				//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╞' , ConsoleColor . White , ConsoleColor . DarkGray );
				//}

				#endregion

				#region 连续路

				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up )
				{

					switch ( Target . GetAzimuth ( Target . InRoad ) )
					{
						case BlockAzimuth . Left :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "→→┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
						case BlockAzimuth . Right :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┋←←" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
					}
					//上下
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					switch ( Target . GetAzimuth ( Target . InRoad ) )
					{
						case BlockAzimuth . Up :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ↓ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┅┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
						case BlockAzimuth . Down :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┅┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ↑ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
					}
					//左右
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					switch ( Target . GetAzimuth ( Target . InRoad ) )
					{
						case BlockAzimuth . Right :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┛←←" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
						case BlockAzimuth . Down :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┛ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ↑ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
					}
					//左上
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					switch ( Target . GetAzimuth ( Target . InRoad ) )
					{
						case BlockAzimuth . Left :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "→→┗┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
						case BlockAzimuth . Down :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┗┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ↑ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
					}
					//右上
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					switch ( Target . GetAzimuth ( Target . InRoad ) )
					{
						case BlockAzimuth . Right :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┓←←" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
						case BlockAzimuth . Up :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ↓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
					}
					//左下
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					 Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					 Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					 Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					switch ( Target . GetAzimuth ( Target . InRoad ) )
					{
						case BlockAzimuth . Left :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 1 ] = new ConsoleChar ( "→→┏┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
						case BlockAzimuth . Up :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ↓ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
								CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┏┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
								CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
							}

							break ;
					}
					//右下
				}

				#endregion

			}
		}

	}

}