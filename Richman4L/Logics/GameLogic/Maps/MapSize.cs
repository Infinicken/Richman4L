/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System ;
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

		public override string ToString ( ) { return $"({Width},{Height})" ; }

		public static explicit operator MapSize ( string mapSize )
		{
			if ( mapSize == null )
			{
				throw new ArgumentNullException ( nameof(mapSize) ) ;
			}

			string [ ] numbers = mapSize . Split ( ',' ) ;

			if ( numbers . LongCount ( ) != 2 )
			{
				//todo:Info?
				throw new ArgumentException ( ) ;
			}

			return new MapSize ( Convert . ToInt32 ( numbers . First ( ) ) ,
								Convert . ToInt32 ( numbers . Last ( ) ) ) ;
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

	}

	public class MapSizeConverter : TypeConverter
	{

		// Overrides the CanConvertFrom method of TypeConverter.
		// The ITypeDescriptorContext interface provides the context for the
		// conversion. Typically, this interface is used at design time to 
		// provide information about the design-time container.
		public override bool CanConvertFrom ( ITypeDescriptorContext context ,
											Type sourceType )
		{
			if ( sourceType == typeof ( string ) )
			{
				return true ;
			}

			return base . CanConvertFrom ( context , sourceType ) ;
		}

		// Overrides the ConvertFrom method of TypeConverter.
		public override object ConvertFrom ( ITypeDescriptorContext context ,
											CultureInfo culture ,
											object value )
		{
			if ( value is string stringValue )
			{
				return ( MapSize ) stringValue ;
			}

			return base . ConvertFrom ( context , culture , value ) ;
		}

		// Overrides the ConvertTo method of TypeConverter.
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
