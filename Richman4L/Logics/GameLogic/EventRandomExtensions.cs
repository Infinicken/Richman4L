using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics
{

	public static class EventRandomExtensions
	{

		public static bool InvokeEvent ( this Random random , GameValue possibility )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof(random) ) ;
			}
			if ( possibility <= 0
				|| possibility > 10000 )
			{
				throw new ArgumentOutOfRangeException ( nameof(possibility) ) ;
			}

			return random . Next ( 10000 ) <= possibility ;
		}

		public static GameValue RandomGameValue ( this Random random ) { return random . Next ( 10001 ) ; }

	}

}
