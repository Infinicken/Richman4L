using System;

using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer . Roads
{

	public sealed class WithinRoadRenderer : CharacterMapObjectRenderer<WithInRoad>
	{

		public override ConsoleChar [ , ] CurrentView { get; protected set; }

		public override void Update ( ) { }

		public override void StartUp ( )
		{
			CurrentView = new ConsoleChar [ Unit . Width , Unit . Height ];

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

					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Left )
					{
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
					}
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Right )
					{
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
					}
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Down )
					{
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 0 ] = new ConsoleChar ( "━━━━━" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┅┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ↑ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
					}
					//左右
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Right )
					{
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
					}
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Down )
					{
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 0 ] = new ConsoleChar ( "┛ ┋ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 1 ] = new ConsoleChar ( "┅┅┛ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 2 ] = new ConsoleChar ( "┓ ↑ ┃" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
					}
					//左上
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Up ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Up &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Left )
					{
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
					}
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Down )
					{
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
					}
					//右上
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Left &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Left )
				{
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Right )
					{
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
					}
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Up )
					{						
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
					}
					//左下
				}
				if ( Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Right &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Down ||
					Target . GetAzimuth ( Target . ForwardRoad ) == BlockAzimuth . Down &&
					Target . GetAzimuth ( Target . BackwardRoad ) == BlockAzimuth . Right )
				{
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Left )
					{
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
					}
					if ( Target . GetAzimuth ( Target . InRoad ) == BlockAzimuth . Up )
					{
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 0 ] = new ConsoleChar ( "┃ ↓ ┗" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 1 ] = new ConsoleChar ( "┃ ┏┅┅" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
						for ( int x = 0 ; x < 5 ; x++ )
						{
							CurrentView [ x , 2 ] = new ConsoleChar ( "┃ ┋ ┏" [ x ] , ConsoleColor . White , ConsoleColor . DarkGray );
						}
					}
					//右下
				}
				else
				{

				}

				#endregion

			}


		}

		public override void SetUnit ( ConsoleSize unit ) { Unit = unit; }

		public override void SetTarget ( [NotNull] WithInRoad target )
		{
			if ( Target == null )
			{
				Target = target;
			}
			else
			{
				throw new InvalidOperationException ( );
			}
		}

	}

}