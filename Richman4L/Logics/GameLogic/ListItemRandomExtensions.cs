using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L
{

	public static class ListItemRandomExtensions
	{

		public static T RandomItem <T> ( this IList <T> list , Random random = null )
		{
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof(list) ) ;
			}
			if ( list . Count == 0 )
			{
				throw new InvalidOperationException ( "Sequence contains no elements" ) ;
			}

			random = random ?? GameRandom . Current ;
			return list [ random . Next ( list . Count ) ] ;
		}

		public static T RandomItem <T> ( this Random random , IList <T> list )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof(random) ) ;
			}
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof(list) ) ;
			}
			if ( list . Count == 0 )
			{
				throw new InvalidOperationException ( "Sequence contains no elements" ) ;
			}

			return list [ random . Next ( list . Count ) ] ;
		}

		/// <summary>
		///     从列表中重复地随机挑选一些项。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="count"></param>
		/// <param name="random"></param>
		/// <returns></returns>
		public static List <T> RandomChoose <T> ( this IList <T> list , int count , Random random = null )
		{
			if ( list == null )
			{
				throw new ArgumentNullException ( nameof(list) ) ;
			}
			if ( count <= 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(count) ) ;
			}
			if ( list . Count == 0 )
			{
				throw new InvalidOperationException ( "Sequence contains no elements" ) ;
			}

			List <T> result = new List <T> ( count ) ;
			random = random ?? GameRandom . Current ;

			for ( int i = 0 ; i < count ; i++ )
			{
				result . Add ( list . RandomItem ( random ) ) ;
			}

			return result ;
		}

	}

}
