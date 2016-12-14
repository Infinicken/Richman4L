using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang .Richman4L
{

	public static class ListItemRandomExtensions
	{

		public static T RandomItem <T> ( this IList <T> list , Random random = null )
		{
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof ( list ) ) ;
			}

			random = random ?? GameRandom . Current ;
			return list [ random . Next ( list . Count ) ] ;
		}

		public static T RandomItem <T> ( this Random random , IList <T> list )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof ( list ) ) ;
			}

			return list [ random . Next ( list . Count ) ] ;
		}

	}

}
