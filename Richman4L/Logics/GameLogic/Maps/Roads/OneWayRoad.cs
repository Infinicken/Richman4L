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

namespace WenceyWang . Richman4L . Maps .Roads
{

	[MapObject]
	public class OneWayRoad : Road
	{

		private Road _entrance ;

		private long ? _entranceId ;

		private Road _exit ;


		private long ? _exitId ;

		public virtual Road Entrance
		{
			get
			{
				if ( _entrance == null &&
					_entranceId == null )
				{
					return null ;
				}

				return _entrance ?? ( _entrance = Map . Currnet . GetRoad ( _entranceId . Value ) ) ;
			}
			set
			{
				_entranceId = value ? . Id ;
				_entrance = value ;
			}
		}

		public virtual Road Exit
		{
			get
			{
				if ( _exit == null &&
					_exitId == null )
				{
					return null ;
				}

				return _exit ?? ( _exit = Map . Currnet . GetRoad ( _exitId . Value ) ) ;
			}
			set
			{
				_exitId = value ? . Id ;
				_exit = value ;
			}
		}

		public OneWayRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				_entranceId = Convert . ToInt64 ( resource . Attribute ( nameof ( Entrance ) ) . Value ) ;
				_exitId = Convert . ToInt64 ( resource . Attribute ( nameof ( Exit ) ) . Value ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e ) ;
			}
		}


		public override bool CanEnterFrom ( Road road ) { return road == Entrance ; }

		public override Path Route ( Road previous , int moveCount , Path result = null )
		{
			if ( previous == null )
			{
				throw new ArgumentNullException ( nameof ( previous ) ) ;
			}
			if ( ! CanEnterFrom ( previous ) )
			{
				throw new ArgumentException ( $"无法通过{nameof ( previous )}进入此道路" , nameof ( previous ) ) ;
			}
			if ( moveCount < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( moveCount ) ) ;
			}

			Path current = result ?? new Path ( ) ;
			current . AddRoute ( this ) ;
			if ( BlockMoving || moveCount == 0 )
			{
				return current ;
			}

			return Exit . Route ( this , moveCount - 1 , result ) ;
		}

	}

}
