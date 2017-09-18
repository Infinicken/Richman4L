using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	public static class BlockAzimuthEtensions
	{

		public static BlockAzimuth GetAzimuth ( this Block thisBlock , Block anotherBlock )
		{
			if ( thisBlock == null )
			{
				throw new ArgumentNullException ( nameof(thisBlock) ) ;
			}

			if ( anotherBlock == null )
			{
				return BlockAzimuth . None ;
			}

			if ( thisBlock . Position . X >= anotherBlock . Position . X
				&& thisBlock . Position . X < anotherBlock . Position . X + anotherBlock . Size . Width
				&& thisBlock . Position . Y == anotherBlock . Position . Y - thisBlock . Size . Height )
			{
				return BlockAzimuth . Down ;
			}
			if ( thisBlock . Position . X >= anotherBlock . Position . X
				&& thisBlock . Position . X < anotherBlock . Position . X + anotherBlock . Size . Width
				&& thisBlock . Position . Y == anotherBlock . Position . Y + anotherBlock . Size . Height )
			{
				return BlockAzimuth . Up ;
			}
			if ( thisBlock . Position . Y >= anotherBlock . Position . Y
				&& thisBlock . Position . Y < anotherBlock . Position . Y + anotherBlock . Size . Height
				&& thisBlock . Position . X == anotherBlock . Position . X + anotherBlock . Size . Width )
			{
				return BlockAzimuth . Left ;
			}
			if ( thisBlock . Position . Y >= anotherBlock . Position . Y
				&& thisBlock . Position . Y < anotherBlock . Position . Y + anotherBlock . Size . Height
				&& thisBlock . Position . X == anotherBlock . Position . X - thisBlock . Size . Width )
			{
				return BlockAzimuth . Right ;
			}

			return BlockAzimuth . None ;
		}

	}

}
