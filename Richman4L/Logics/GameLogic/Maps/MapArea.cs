using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Maps
{

	public abstract class MapArea
	{

		public abstract bool IsInArea ( MapObject mapObject ) ;

		public abstract bool IsInArea ( MapPosition position ) ;

	}


	public delegate double MapObjectDistance ( MapObject obj1 , MapObject obj2 ) ;

	public delegate double MapDistance ( MapObject obj , MapPosition position ) ;


	public class RectangleMapArea : MapArea
	{

		public MapPosition Position { get ; set ; }

		public MapSize Size { get ; }


		public RectangleMapArea ( MapPosition position , MapSize size )
		{
			Position = position ;
			Size = size ;
		}

		public override bool IsInArea ( MapObject mapObject )
		{
			return mapObject . Position . X >= Position . X
					&& mapObject . Position . X + mapObject . Size . Width <= Position . X + Size . Width
					&& mapObject . Position . Y >= Position . Y
					&& mapObject . Position . Y + mapObject . Size . Height <= Position . Y + Size . Height ;
		}

		public override bool IsInArea ( MapPosition position )
		{
			return position . X >= Position . X && position . X <= Position . X + Size . Width && position . Y >= Position . Y
					&& position . Y <= Position . Y + Size . Height ;
		}

	}

	public static class MapDistanceProvider
	{

		public static double ChebyshevDistance ( MapObject obj1 , MapObject obj2 )
		{
			return
				Math . Max ( Math . Min ( Math . Max ( Math . Abs ( obj1 . Position . X + obj1 . Size . Width
																	- obj2 . Position . X ) ,
														0 ) ,
										Math . Max ( Math . Abs ( obj1 . Position . X - ( obj2 . Position . X + obj2 . Size . Width ) ) , 0 ) ) ,
							Math . Min ( Math . Max ( Math . Abs ( obj1 . Position . Y + obj1 . Size . Height - obj2 . Position . Y ) , 0 ) ,
										Math . Max ( Math . Abs ( obj1 . Position . Y - ( obj2 . Position . Y + obj2 . Size . Height ) ) , 0 ) ) ) ;
		}


		public static double ChebyshevDistance ( MapObject obj , MapPosition position )
		{
			return Math . Max ( Math . Min ( Math . Max ( Math . Abs ( obj . Position . X + obj . Size . Width - position . X ) ,
														0 ) ,
											Math . Max ( Math . Abs ( obj . Position . X - position . X ) , 0 ) ) ,
								Math . Min ( Math . Max ( Math . Abs ( obj . Position . Y + obj . Size . Height - position . Y ) , 0 ) ,
											Math . Max ( Math . Abs ( obj . Position . Y - position . Y ) , 0 ) ) ) ;
		}

		//public static double ManhattanDistance(MapObject obj1, MapObject obj2)

		//{
		//	return obj1.Position.X
		//}

		//public static 

	}

	public class ObjectChebyshevDistanceMapArea : MapArea
	{

		public MapObject Center { get ; }

		public int Distance { get ; }

		public ObjectChebyshevDistanceMapArea ( [NotNull] MapObject center , int distance )
		{
			if ( distance <= 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(distance) ) ;
			}

			Center = center ?? throw new ArgumentNullException ( nameof(center) ) ;
			Distance = distance ;
		}

		public override bool IsInArea ( MapObject mapObject )
		{
			return MapDistanceProvider . ChebyshevDistance ( Center , mapObject ) < Distance ;
		}

		public override bool IsInArea ( MapPosition position )
		{
			return MapDistanceProvider . ChebyshevDistance ( Center , position ) < Distance ;
		}

	}

}
