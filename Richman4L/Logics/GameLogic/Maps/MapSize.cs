using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel ;
using System . Globalization ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps
{

	/// <summary>
	///     指示地图或地图元素的尺寸
	/// </summary>
	[TypeConverter ( typeof ( MapSizeConverter ) )]
	public struct MapSize
	{

		/// <summary>
		///     宽度
		/// </summary>
		public readonly int Width ;

		/// <summary>
		///     高度
		/// </summary>
		public readonly int Height ;

		/// <summary>
		///     小地图元素尺寸，1*1
		/// </summary>
		public static readonly MapSize Small = new MapSize ( 1 , 1 ) ;

		/// <summary>
		///     长条地图元素尺寸，1*2
		/// </summary>
		public static readonly MapSize Long = new MapSize ( 1 , 2 ) ;

		/// <summary>
		///     宽地图元素尺寸，2*1
		/// </summary>
		public static readonly MapSize Wide = new MapSize ( 2 , 1 ) ;

		/// <summary>
		///     中等地图元素尺寸，2*2
		/// </summary>
		public static readonly MapSize Medium = new MapSize ( 2 , 2 ) ;

		/// <summary>
		///     大地图元素尺寸，4*4
		/// </summary>
		public static readonly MapSize Large = new MapSize ( 4 , 4 ) ;

		public static bool operator == ( MapSize size1 , MapSize size2 )
		{
			return size1 . Width == size2 . Width && size1 . Height == size2 . Height ;
		}

		public static bool operator != ( MapSize size1 , MapSize size2 )
		{
			return size1 . Width != size2 . Width || size1 . Height != size2 . Height ;
		}

		public override bool Equals ( object obj )
		{
			if ( ! ( obj is MapSize ) )
			{
				return false ;
			}

			return this == ( MapSize ) obj ;
		}

		public bool Equals ( MapSize other ) { return Width == other . Width && Height == other . Height ; }

		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( Width * 397 ) ^ Height ;
			}
		}

		public override string ToString ( ) { return $"[{Width},{Height}]" ; }

		public static explicit operator MapSize ( string mapSize )
		{
			if ( mapSize == null )
			{
				throw new ArgumentNullException ( nameof(mapSize) ) ;
			}

			string [ ] numbers = mapSize . TrimStart ( '[' ) . TrimEnd ( ']' ) . Split ( ',' ) ;

			if ( numbers . LongCount ( ) != 2 )
			{
				//todo:Info?
				throw new ArgumentException ( ) ;
			}

			return new MapSize ( Convert . ToInt32 ( numbers . First ( ) ) , Convert . ToInt32 ( numbers . Last ( ) ) ) ;
		}

		/// <summary>
		///     创建新的MapSize
		/// </summary>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		public MapSize ( int width , int height )
		{
			Width = width ;
			Height = height ;
		}

		public class MapSizeConverter : TypeConverter
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
					return ( MapSize ) stringValue ;
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
					return ( ( MapSize ) value ) . ToString ( ) ;
				}

				return base . ConvertTo ( context , culture , value , destinationType ) ;
			}

		}

	}

}
