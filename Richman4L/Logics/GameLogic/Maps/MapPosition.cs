using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel ;
using System . Globalization ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	[TypeConverter ( typeof ( MapPositionConverter ) )]
	public struct MapPosition : IEquatable <MapPosition>
	{

		public long ContorId => CantorPairing . Calu ( X , Y ) ;

		public override string ToString ( ) { return $"({X},{Y})" ; }

		public bool Equals ( MapPosition other ) { return X == other . X && Y == other . Y ; }

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) )
			{
				return false ;
			}

			return obj is MapPosition && Equals ( ( MapPosition ) obj ) ;
		}

		public class MapPositionConverter : TypeConverter
		{

			public override bool CanConvertFrom ( ITypeDescriptorContext context , Type sourceType )
			{
				if ( sourceType == typeof ( string ) )
				{
					return true ;
				}

				return base . CanConvertFrom ( context , sourceType ) ;
			}

			public override object ConvertFrom ( ITypeDescriptorContext context , CultureInfo culture , object value )
			{
				if ( value is string stringValue )
				{
					return ( MapPosition ) stringValue ;
				}

				return base . ConvertFrom ( context , culture , value ) ;
			}

			public override object ConvertTo ( ITypeDescriptorContext context ,
												CultureInfo culture ,
												object value ,
												Type destinationType )
			{
				if ( destinationType == typeof ( string ) )
				{
					return ( ( MapPosition ) value ) . ToString ( ) ;
				}

				return base . ConvertTo ( context , culture , value , destinationType ) ;
			}

		}


		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( X * 397 ) ^ Y ;
			}
		}

		public static bool operator == ( MapPosition left , MapPosition right ) { return left . Equals ( right ) ; }

		public static bool operator != ( MapPosition left , MapPosition right ) { return ! left . Equals ( right ) ; }

		public int X { get ; }

		public int Y { get ; }

		public static explicit operator MapPosition ( string mapSize )
		{
			if ( mapSize == null )
			{
				throw new ArgumentNullException ( nameof(mapSize) ) ;
			}

			string [ ] numbers = mapSize . TrimStart ( '(' ) . TrimEnd ( ')' ) . Split ( ',' ) ;

			if ( numbers . LongCount ( ) != 2 )
			{
				throw new ArgumentException ( "Formart Wrong" , nameof(mapSize) ) ; //Todo:String
			}

			return new MapPosition ( Convert . ToInt32 ( numbers . First ( ) ) , Convert . ToInt32 ( numbers . Last ( ) ) ) ;
		}


		public MapPosition ( int x , int y )
		{
			if ( x < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(x) ) ;
			}
			if ( y < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(y) ) ;
			}

			X = x ;
			Y = y ;
		}

	}

}
