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
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Maps . Roads
{
	[MapObject]
	public class NormalRoad : Road
	{
		private long? _forwardRoadId;

		private Road _forwardRoad;

		public virtual Road ForwardRoad
		{
			get
			{
				if ( _forwardRoad == null && _forwardRoad == null )
				{
					return null;
				}
				return _forwardRoad ?? ( _forwardRoad = Map . Currnet . GetRoad ( _forwardRoadId . Value ) );
			}
			protected set
			{
				_forwardRoadId = value?.Id;
				_forwardRoad = value;
			}
		}

		private long? _backwardRoadId;

		private Road _backwardRoad;

		public virtual Road BackwardRoad
		{
			get
			{
				if ( _backwardRoad == null && _backwardRoad == null )
				{
					return null;
				}
				return _backwardRoad ?? ( _backwardRoad = Map . Currnet . GetRoad ( _backwardRoadId . Value ) );
			}
			protected set
			{
				_backwardRoadId = value?.Id;
				_backwardRoad = value;
			}
		}


		public override Path Route ( Road previous , int moveCount , Path result = null )
		{
			if ( previous == null )
			{
				throw new ArgumentNullException ( nameof ( previous ) );
			}
			if ( !CanEnterFrom ( previous ) )
			{
				throw new ArgumentException ( $"无法通过{nameof ( previous )}进入此道路" , nameof ( previous ) );
			}
			if ( moveCount < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( moveCount ) );
			}
			Path current = result ?? new Path ( );
			current . AddRoute ( this );
			if ( BlockMoving || moveCount == 0 )
			{
				return current;
			}
			else
			{
				if ( BackwardRoad == previous )
				{
					if ( ForwardRoad . CanEnterFrom ( this ) )
					{
						return ForwardRoad . Route ( this , moveCount - 1 , current );
					}
					else
					{
						return BackwardRoad . Route ( this , moveCount - 1 , current );
					}
				}
				else
				{
					if ( BackwardRoad . CanEnterFrom ( this ) )
					{
						return BackwardRoad . Route ( this , moveCount - 1 , current );
					}
					else
					{
						return ForwardRoad . Route ( this , moveCount - 1 , current );
					}
				}
			}
		}

		protected override void Dispose ( bool disposing )
		{
			ForwardRoad = null;
			BackwardRoad = null;
			base . Dispose ( disposing );
		}

		public override bool CanEnterFrom ( Road road ) => road == ForwardRoad || road == BackwardRoad;

		public NormalRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				_forwardRoadId = Convert . ToInt64 ( resource . Attribute ( nameof ( ForwardRoad ) ) . Value );
				_backwardRoadId = Convert . ToInt64 ( resource . Attribute ( nameof ( BackwardRoad ) ) . Value );
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e );
			}

		}

	}
}
