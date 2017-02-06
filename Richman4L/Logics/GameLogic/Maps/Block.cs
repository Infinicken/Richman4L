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
using System . Collections ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L .Maps
{

	/// <summary>
	///     表示区块，区块会计算积水
	/// </summary>
	public abstract class Block : MapObject
	{

		public long Id => ( X + Y ) * ( X + Y + 1 ) / 2 + Y ;

		/// <summary>
		///     表示当前区块的积水量
		/// </summary>
		public virtual int PondingAmount { get ; set ; }

		/// <summary>
		///     表示每天能够减少的积水量
		/// </summary>
		public abstract int PondingDecrease { get ; }


		public bool IsWet => PondingAmount != 0 ;

		public bool IsFrozen => IceThickness != 0 ;

		public int IceThickness { get ; protected set ; }

		public bool IsBearSnow => SnowThickness != 0 ;

		public int SnowThickness { get ; protected set ; }

		public Block ( [NotNull] XElement resource ) : base ( resource )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof ( resource ) ) ;
			}
		}

		protected Block ( ) { }

		public override void StartDay ( GameDate nextDate ) { }

		public override void EndToday ( ) { PondingAmount += Game . Current . Weather . Precipitation ; }

	}

	public static class CantorPairing
	{

		public static long Calu ( int x , int y ) { return ( x + y ) * ( x + y + 1 ) / 2 + y ; }

	}

}
