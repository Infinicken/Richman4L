using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps
{

	public abstract class MapArea
	{

		public abstract bool IsInArea ( MapObject mapObject ) ;

	}

	public class RectangleMapArea : MapArea
	{

		public int X { get ; }

		public int Y { get ; }

		public int Width { get ; }

		public int Height { get ; }

		public RectangleMapArea ( int x , int y , int width , int height )
		{
			X = x ;
			Y = y ;
			Width = width ;
			Height = height ;
		}

		public override bool IsInArea ( MapObject mapObject )
		{
			return mapObject . X >= X &&
					mapObject . X + mapObject . Size . Width <= X + Width &&
					mapObject . Y >= Y &&
					mapObject . Y + mapObject . Size . Height <= Y + Height ;
		}

	}

	public class ObjectChebyshevDistanceMapArea : MapArea
	{

		public MapObject Object { get ; }

		public int Distance { get ; }

		public override bool IsInArea ( MapObject mapObject )
		{
			return Math . Max ( Math . Abs ( Object . X - mapObject . X ) , Math . Abs ( Object . Y - mapObject . Y ) ) <
					Distance ;
		}

	}

}
