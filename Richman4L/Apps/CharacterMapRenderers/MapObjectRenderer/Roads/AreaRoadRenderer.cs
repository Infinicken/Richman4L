using System;
using System . Collections;
using System . Linq;
using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Maps . Roads;

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers . MapObjectRenderer .Roads
{

	public class AreaRoadRenderer : CharacterMapObjectRenderer <AreaRoad>
	{

		public override void Update ( )
		{
			if ( Unit == ConsoleSize . Small )
			{
				#region 连续路

				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up )
				{
					if ( Target . GetAzimuth ( Target . Area ) == BlockAzimuth . Left )
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╢' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
					if ( Target . GetAzimuth ( Target . Area ) == BlockAzimuth . Right )
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╟' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}

					//上下
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					if ( Target . GetAzimuth ( Target . Area ) == BlockAzimuth . Up )
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╧' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}
					if ( Target . GetAzimuth ( Target . Area ) == BlockAzimuth . Right )
					{
						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╤' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
					}

					//左右
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					CurrentView [ 0 , 0 ] = new ConsoleChar ( '╝' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					CurrentView [ 0 , 0 ] = new ConsoleChar ( '╚' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					CurrentView [ 0 , 0 ] = new ConsoleChar ( '╗' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					CurrentView [ 0 , 0 ] = new ConsoleChar ( '╔' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
				}

				#endregion
			}
			else if ( Unit == ConsoleSize . Large )
			{
				#region 连续路

				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up )
				{
					switch ( Target . GetAzimuth ( Target . Area ) )
					{
						case BlockAzimuth . Left :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "  ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
						case BlockAzimuth . Right :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┋  " [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right ||
						Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					switch ( Target . GetAzimuth ( Target . Area ) )
					{
						case BlockAzimuth . Up :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "━┛ ┗━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┅┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
						case BlockAzimuth . Down :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┅┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "━┓ ┏━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
						Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					switch ( Target . GetAzimuth ( Target . Area ) )
					{
						case BlockAzimuth . Right :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┛  " [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
						case BlockAzimuth . Down :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┛ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "━┓ ┏┛" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
						Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					switch ( Target . GetAzimuth ( Target . Area ) )
					{
						case BlockAzimuth . Left :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "  ┗┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
						case BlockAzimuth . Down :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┗┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "┗┓ ┏━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
						Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					switch ( Target . GetAzimuth ( Target . Area ) )
					{
						case BlockAzimuth . Right :
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┓  " [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						case BlockAzimuth . Up :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "━┛ ┗┓" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
					}
				}
				else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
						Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
						Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					switch ( Target . GetAzimuth ( Target . Area ) )
					{
						case BlockAzimuth . Left :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "  ┏┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
						case BlockAzimuth . Up :
						{
							for ( int x = 0 ; x < 5 ; x++ )
							{
								CurrentView [ x , 0 ] = new ConsoleChar ( "┏┛ ┗━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┏┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
								CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
							}

							break ;
						}
					}
				}

				#endregion
			}
		}

	}

}
