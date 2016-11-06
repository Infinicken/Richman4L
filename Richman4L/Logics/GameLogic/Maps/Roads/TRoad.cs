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
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . Maps .Roads
{

	// ReSharper disable once InconsistentNaming
	[ MapObject ]
	public class TRoad : Road
	{

		[ CanBeNull ] private Road _firstExit ;

		[ CanBeNull ] private long? _firstExitId ;

		[ CanBeNull ] private Road _secondExit ;

		[ CanBeNull ] private long? _secondExitId ;

		[ CanBeNull ] private Road _thirdExit ;

		[ CanBeNull ] private long? _thirdExitId ;

		[ CanBeNull ]
		public virtual Road FirstExit
		{
			get
			{
				if ( ( _firstExit == null ) &&
					( _firstExitId == null ) )
				{
					return null ;
				}

				return _firstExit ?? ( _firstExit = Map . Currnet . GetRoad ( _firstExitId . Value ) ) ;
			}
			protected set
			{
				_firstExitId = value ? . Id ;
				_firstExit = value ;
			}
		}

		[ CanBeNull ]
		public virtual Road SecondExit
		{
			get
			{
				if ( ( _secondExit == null ) &&
					( _secondExitId == null ) )
				{
					return null ;
				}

				return _secondExit ?? ( _secondExit = Map . Currnet . GetRoad ( _secondExitId . Value ) ) ;
			}
			protected set
			{
				_secondExitId = value ? . Id ;
				_secondExit = value ;
			}
		}

		[ CanBeNull ]
		public virtual Road ThirdExit
		{
			get
			{
				if ( ( _thirdExit == null ) &&
					( _thirdExitId == null ) )
				{
					return null ;
				}

				return _thirdExit ?? ( _thirdExit = Map . Currnet . GetRoad ( _thirdExitId . Value ) ) ;
			}
			protected set
			{
				_thirdExitId = value ? . Id ;
				_thirdExit = value ;
			}
		}

		public TRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				_firstExitId = Convert . ToInt64 ( resource . Attribute ( nameof ( FirstExit ) ) ? . Value ) ;
				_secondExitId = Convert . ToInt64 ( resource . Attribute ( nameof ( SecondExit ) ) ? . Value ) ;
				_thirdExitId = Convert . ToInt64 ( resource . Attribute ( nameof ( ThirdExit ) ) ? . Value ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e ) ;
			}
		}

		public override Path Route ( Road previous , int moveCount , Path result = null )
		{
			if ( previous == null )
			{
				throw new ArgumentNullException ( nameof ( previous ) ) ;
			}
			if ( ! CanEnterFrom ( previous ) )
			{
				throw new ArgumentException ( @"无法通过previous进入此道路" , nameof ( previous ) ) ;
			}
			if ( moveCount < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( moveCount ) ) ;
			}

			Path current = result ?? new Path ( ) ;
			current . AddRoute ( this ) ;
			if ( BlockMoving || ( moveCount == 0 ) )
			{
				return current ;
			}

			List < Road > roadAvailable = new List < Road > { FirstExit , SecondExit , ThirdExit } ;
			roadAvailable . Remove ( previous ) ;
			roadAvailable . RemoveAll ( road => null == road ) ;
			roadAvailable . RemoveAll ( road => ! road . CanEnterFrom ( this ) ) ;
			return roadAvailable . RandomItem ( ) . Route ( this , moveCount - 1 , result ) ;
		}

		public override bool CanEnterFrom ( Road road )
			=> ( road == FirstExit ) || ( road == SecondExit ) || ( road == ThirdExit ) ;

	}

}
