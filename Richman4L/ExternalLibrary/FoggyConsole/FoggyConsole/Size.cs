/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System ;
using System . Collections . Generic ;
using System . Globalization ;
using System . Linq ;

namespace WenceyWang . FoggyConsole
{

	public struct Size
	{

		public static readonly Size Empty = new Size ( ) ;

		public Size ( Point point )
		{
			Width = point . X ;
			Height = point . Y ;
		}

		public Size ( int width , int height )
		{
			Width = width ;
			Height = height ;
		}


		public static Size operator + ( Size size1 , Size size2 ) { return Add ( size1 , size2 ) ; }

		public static Size operator - ( Size size1 , Size size2 ) { return Subtract ( size1 , size2 ) ; }

		public static bool operator == ( Size size1 , Size size2 )
		{
			return size1 . Width == size2 . Width && size1 . Height == size2 . Height ;
		}

		public static bool operator != ( Size size1 , Size size2 ) { return ! ( size1 == size2 ) ; }

		public static explicit operator Point ( Size size ) { return new Point ( size . Width , size . Height ) ; }

		public bool IsEmpty => Width == 0 && Height == 0 ;

		public int Width { get ; }

		public int Height { get ; }

		public static Size Add ( Size size1 , Size size2 )
		{
			return new Size ( size1 . Width + size2 . Width , size1 . Height + size2 . Height ) ;
		}

		public static Size Subtract ( Size size1 , Size size2 )
		{
			return new Size ( size1 . Width - size2 . Width , size1 . Height - size2 . Height ) ;
		}


		public override bool Equals ( object obj )
		{
			if ( ! ( obj is Size ) )
			{
				return false ;
			}

			Size comp = ( Size ) obj ;

			// Note value types can't have derived classes, so we don't need to
			// check the types of the objects here.  -- Microsoft, 2/21/2001
			return comp . Width == Width &&
					comp . Height == Height ;
		}

		public override int GetHashCode ( ) { return Width ^ Height ; }

		public override string ToString ( )
		{
			return "{Width=" + Width . ToString ( CultureInfo . CurrentCulture ) + ", Height=" +
					Height . ToString ( CultureInfo . CurrentCulture ) + "}" ;
		}

	}

}
