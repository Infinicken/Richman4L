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

using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Maps
{
	/// <summary>
	/// 指示地图或地图元素的尺寸
	/// </summary>
	public struct MapSize
	{
		/// <summary>
		/// 尺寸的X值
		/// </summary>
		public int X { get; }

		/// <summary>
		/// 尺寸的Y值
		/// </summary>
		public int Y { get; }

		/// <summary>
		/// 小地图元素尺寸
		/// </summary>
		public static readonly MapSize Small = new MapSize ( 1 , 1 );

		/// <summary>
		/// 长条地图元素尺寸
		/// </summary>
		public static readonly MapSize Long = new MapSize ( 1 , 2 );

		/// <summary>
		/// 宽地图元素尺寸
		/// </summary>
		public static readonly MapSize Wide = new MapSize ( 2 , 1 );

		/// <summary>
		/// 中等地图元素尺寸
		/// </summary>
		public static readonly MapSize Medium = new MapSize ( 2 , 2 );

		/// <summary>
		/// 大地图元素尺寸
		/// </summary>
		public static readonly MapSize Large = new MapSize ( 4 , 4 );

		public static bool operator == ( MapSize size1 , MapSize size2 )
		{
			return size1 . X == size2 . X && size1 . Y == size2 . Y;
		}

		public static bool operator != ( MapSize size1 , MapSize size2 )
		{
			return size1 . X != size2 . X || size1 . Y != size2 . Y;
		}

		public override bool Equals ( object obj )
		{
			if ( !( obj is MapSize ) )
			{
				return false;
			}
			return this == ( MapSize ) obj;
		}

		public bool Equals ( MapSize other )
		{
			return X == other . X && Y == other . Y;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( X * 397 ) ^ Y;
			}
		}

		public override string ToString ( ) => $"({X},{Y})";

		/// <summary>
		/// 创建新的MapSize
		/// </summary>
		/// <param name="x">尺寸的X值</param>
		/// <param name="y">尺寸的Y值</param>
		public MapSize ( int x , int y )
		{
			X = x;
			Y = y;
		}


	}
}
