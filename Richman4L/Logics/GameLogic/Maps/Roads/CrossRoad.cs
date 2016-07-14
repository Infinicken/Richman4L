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

using System;
using System . Collections . Generic;
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Maps . Roads
{
	[MapObject]
	public class CrossRoad : Road
	{
		private long? _firstExitId;

		private Road _firstExit;

		public virtual Road FirstExit
		{
			get
			{
				if ( _firstExit == null && _firstExit == null )
				{
					return null;
				}
				return _firstExit ?? ( _firstExit = Map . Currnet . GetRoad ( _firstExitId . Value ) );
			}
			protected set
			{
				_firstExitId = value?.Id;
				_firstExit = value;
			}
		}

		private long? _secondExitId;

		private Road _secondExit;

		public virtual Road SecondExit
		{
			get
			{
				if ( _secondExit == null && _secondExit == null )
				{
					return null;
				}
				return _secondExit ?? ( _secondExit = Map . Currnet . GetRoad ( _secondExitId . Value ) );
			}
			protected set
			{
				_secondExitId = value?.Id;
				_secondExit = value;
			}
		}

		private long? _thirdExitId;

		private Road _thirdExit;

		public virtual Road ThirdExit
		{
			get
			{
				if ( _thirdExit == null && _thirdExit == null )
				{
					return null;
				}
				return _thirdExit ?? ( _thirdExit = Map . Currnet . GetRoad ( _thirdExitId . Value ) );
			}
			protected set
			{
				_thirdExitId = value?.Id;
				_thirdExit = value;
			}
		}

		private long? _forthExitId;

		private Road _forthExit;

		public virtual Road ForthExit
		{
			get
			{
				if ( _forthExit == null && _forthExit == null )
				{
					return null;
				}
				return _forthExit ?? ( _forthExit = Map . Currnet . GetRoad ( _forthExitId . Value ) );
			}
			protected set
			{
				_forthExitId = value?.Id;
				_forthExit = value;
			}
		}


		public override bool CanEnterFrom ( Road road ) => road == FirstExit || road == SecondExit || road == ThirdExit || road == ForthExit;

		public override Path Route ( Road previous , int moveCount , Path result = null )
		{
			if ( previous == null )
			{
				throw new ArgumentNullException ( nameof ( previous ) );
			}
			if ( !CanEnterFrom ( previous ) )
			{
				throw new ArgumentException ( @"无法通过previous进入此道路" , nameof ( previous ) );
			}
			if ( moveCount < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( moveCount ) );
			}
			Path current = result ?? new Path ( );
			current . AddRoute ( this );
			if ( !BlockMoving && moveCount != 0 )
			{
				List<Road> roadAvailable = new List<Road> { FirstExit , SecondExit , ThirdExit , ForthExit };
				roadAvailable . Remove ( previous );
				roadAvailable . RemoveAll ( ( road ) => null == road );
				roadAvailable . RemoveAll ( ( road ) => !road . CanEnterFrom ( this ) );
				return roadAvailable . RandomItem ( ) . Route ( this , moveCount - 1 , result );
			}
			else
			{
				return current;
			}
		}

		public CrossRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				_firstExitId = Convert . ToInt64 ( resource . Attribute ( nameof ( FirstExit ) ) . Value );
				_secondExitId = Convert . ToInt64 ( resource . Attribute ( nameof ( SecondExit ) ) . Value );
				_thirdExitId = Convert . ToInt64 ( resource . Attribute ( nameof ( ThirdExit ) ) . Value );
				_forthExitId = Convert . ToInt64 ( resource . Attribute ( nameof ( ForthExit ) ) . Value );
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e );
			}
		}

		//public override MapObjectType Type =>RegisMapObjectType()

	}
}