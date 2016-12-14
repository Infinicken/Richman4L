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
	public class WithInRoad : NormalRoad
	{

		private Road _inRoad ;

		private long ? _inRoadId ;

		public virtual Road InRoad
		{
			get
			{
				if ( ( _inRoad == null ) &&
					( _inRoadId == null ) )
				{
					return null ;
				}

				return _inRoad ?? ( _inRoad = Map . Currnet . GetRoad ( _inRoadId . Value ) ) ;
			}
			protected set
			{
				_inRoadId = value ? . Id ;
				_inRoad = value ;
			}
		}

		public WithInRoad ( XElement resource ) : base ( resource )
		{
			_inRoadId = Convert . ToInt64 ( resource . Attribute ( nameof ( InRoad ) ) ? . Value ) ;
		}

		public override Path Route ( Road previous , int moveCount , Path result = null )
		{
			if ( previous == InRoad )
			{
				Path current = result ?? new Path ( ) ;
				current . AddRoute ( this ) ;
				if ( BlockMoving || ( moveCount == 0 ) )
				{
					return current ;
				}

				switch ( GameRandom . Current . Next ( 0 , 2 ) )
				{
					case 0 :
					{
						return ForwardRoad . Route ( this , moveCount - 1 , result ) ;
					}
					case 1 :
					{
						return BackwardRoad . Route ( this , moveCount - 1 , result ) ;
					}
					default :
					{
						throw new NotImplementedException ( ) ;
					}
				}
			}

			return base . Route ( previous , moveCount , result ) ;
		}

	}

}
