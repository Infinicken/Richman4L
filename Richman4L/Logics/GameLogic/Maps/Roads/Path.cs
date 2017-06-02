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
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L . Maps . Roads
{

	/// <summary>
	///     指示游戏中由一些道路顺次连接构成的路径
	/// </summary>
	public sealed class Path : MapObject
	{

		/// <summary>
		///     指示这个路径的末尾
		/// </summary>
		public Road Terminal => Route . Last ( ) ;

		/// <summary>
		///     指示这个路径末尾之前的路径
		/// </summary>
		public Road Penultimate => Route [ Route . Count - 2 ] ;


		/// <summary>
		///     指示整个路径
		/// </summary>
		public List <Road> Route { get ; } = new List <Road> ( ) ;

		public override int X { get { return Route . Min ( road => road . X ) ; } protected set { } }

		public override int Y { get { return Route . Min ( road => road . Y ) ; } protected set { } }

		public override MapSize Size => new MapSize (
			Route . Max ( road => road . X ) - Route . Min ( road => road . X ) ,
			Route . Max ( road => road . Y ) - Route . Min ( road => road . Y ) ) ;


		/// <summary>
		///     延长这个路径
		/// </summary>
		/// <param name="road">新增的路段</param>
		public void AddRoute ( Road road )
		{
			if ( road == null )
			{
				throw new ArgumentNullException ( nameof(road) ) ;
			}
			if ( ! road . CanEnterFrom ( Terminal ) )
			{
				throw new ArgumentException ( $"{nameof(road)} can not enter from {nameof(Terminal)}" ) ;
			}

			Route . Add ( road ) ;
		}

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

		public override void StartDay ( GameDate thisDate ) { throw new NotImplementedException ( ) ; }

	}

}
