using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers . MapObjectRenderer . Roads
{

	//public sealed class WithinRoadRenderer : CharacterMapObjectRenderer <WithInRoad>
	//{

	//	public override void Update ( )
	//	{
	//		if ( Unit == ConsoleSize . Small )
	//		{
	//			#region 断头路

	//			//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
	//			//	Target . BackwardRoad == null ||
	//			//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up &&
	//			//	Target . ForwardRoad == null )
	//			//{
	//			//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╨' , ConsoleColor . White , ConsoleColor . DarkGray );
	//			//}
	//			//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
	//			//	Target . BackwardRoad == null ||
	//			//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down &&
	//			//	Target . ForwardRoad == null )
	//			//{
	//			//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╥' , ConsoleColor . White , ConsoleColor . DarkGray );
	//			//}
	//			//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
	//			//	Target . BackwardRoad == null ||
	//			//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left &&
	//			//	Target . ForwardRoad == null )
	//			//{
	//			//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╡' , ConsoleColor . White , ConsoleColor . DarkGray );
	//			//}
	//			//if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
	//			//	Target . BackwardRoad == null ||
	//			//	Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right &&
	//			//	Target . ForwardRoad == null )
	//			//{
	//			//	CurrentView [ 0 , 0 ] = new ConsoleChar ( '╞' , ConsoleColor . White , ConsoleColor . DarkGray );
	//			//}

	//			#endregion

	//			#region 连续路

	//			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
	//				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
	//				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
	//				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up )
	//			{
	//				switch ( Target . GetAzimuth ( Target . InRoad ) )
	//				{
	//					case BlockAzimuth . Left :
	//					{
	//						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╢' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						break ;
	//					}
	//					case BlockAzimuth . Right :
	//					{
	//						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╟' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						break ;
	//					}
	//				}
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
	//			{
	//				switch ( Target . GetAzimuth ( Target . InRoad ) )
	//				{
	//					case BlockAzimuth . Up :
	//					{
	//						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╧' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						break ;
	//					}
	//					case BlockAzimuth . Right :
	//					{
	//						CurrentView [ 0 , 0 ] = new ConsoleChar ( '╤' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						break ;
	//					}
	//				}
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
	//			{
	//				CurrentView [ 0 , 0 ] = new ConsoleChar ( '╝' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
	//			{
	//				CurrentView [ 0 , 0 ] = new ConsoleChar ( '╚' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
	//			{
	//				CurrentView [ 0 , 0 ] = new ConsoleChar ( '╗' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
	//			{
	//				CurrentView [ 0 , 0 ] = new ConsoleChar ( '╔' , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//			}

	//			#endregion
	//		}
	//		else if ( Unit == ConsoleSize . Large )
	//		{
	//			#region 连续路

	//			if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
	//				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
	//				Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
	//				Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up )
	//			{
	//				switch ( Target . GetAzimuth ( Target . InRoad ) )
	//				{
	//					case BlockAzimuth . Left :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "→→┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//					case BlockAzimuth . Right :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┋←←" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//				}
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
	//			{
	//				switch ( Target . GetAzimuth ( Target . InRoad ) )
	//				{
	//					case BlockAzimuth . Up :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ↓ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┅┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//					case BlockAzimuth . Down :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┅┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ↑ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//				}
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
	//			{
	//				switch ( Target . GetAzimuth ( Target . InRoad ) )
	//				{
	//					case BlockAzimuth . Right :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┛←←" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//					case BlockAzimuth . Down :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┛ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ↑ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//				}
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
	//			{
	//				switch ( Target . GetAzimuth ( Target . InRoad ) )
	//				{
	//					case BlockAzimuth . Left :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "→→┗┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//					case BlockAzimuth . Down :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ┋ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┗┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ↑ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//				}
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
	//			{
	//				switch ( Target . GetAzimuth ( Target . InRoad ) )
	//				{
	//					case BlockAzimuth . Right :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┓←←" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//					case BlockAzimuth . Up :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ↓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┓ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//				}
	//			}
	//			else if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
	//					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
	//					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
	//			{
	//				switch ( Target . GetAzimuth ( Target . InRoad ) )
	//				{
	//					case BlockAzimuth . Left :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "→→┏┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//					case BlockAzimuth . Up :
	//					{
	//						for ( int x = 0 ; x < 5 ; x++ )
	//						{
	//							CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ↓ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┏┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//							CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray ) ;
	//						}

	//						break ;
	//					}
	//				}
	//			}

	//			#endregion
	//		}
	//	}

	//}

}
