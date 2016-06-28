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
using System . Collections . ObjectModel;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Xml . Linq;

using WenceyWang . Richman4L . Buffs . AreaBuffs;
using WenceyWang . Richman4L . Maps . Buildings;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . Maps
{
	public abstract class Area : Block
	{
		public long Id { get; private set; }

		[NotNull]
		[ItemNotNull]
		public List<AreaBuff> Buffs { get; set; } = new List<AreaBuff> ( );

		public abstract long MoneyCostWhenCrossed { get; protected set; }

		public abstract double BuildingResistance { get; protected set; }

		private long _positionId;

		private AreaRoad _position;

		public AreaRoad Position { get { return _position ?? ( _position = ( AreaRoad ) Map . Currnet . GetRoad ( _positionId ) ); } set { _positionId = value . Id; _position = value; } }

		public Players . Player Owner { get; set; }

		public Building Building { get; private set; }

		public abstract long Price { get; protected set; }

		public void Stay ( [NotNull] Players . Player player )
		{
			CheckDisposed ( );

			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			Building?.Stay ( player );
		}

		public void Pass ( [NotNull] Players . Player player )
		{
			CheckDisposed ( );

			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			Building?.Pass ( player );
		}

		public override void StartDay ( Calendars . GameDate nextDate )
		{
		}

		public bool IsBuildingAvailable ( [NotNull] BuildingType buildingType ) => AvailableBuildings . Contains ( buildingType );

		[NotNull]
		public abstract ReadOnlyCollection<BuildingType> AvailableBuildings { get; }

		public void BuildBuildiing ( [NotNull] Building building )
		{
			CheckDisposed ( );

			if ( building == null )
			{
				throw new ArgumentNullException ( nameof ( building ) );
			}

			if ( !IsBuildingAvailable ( building . Type ) )
			{
				throw new ArgumentException ( $"{nameof ( building )} is not vaild for this area" , nameof ( building ) );
			}
			if ( Building != null )
			{
				throw new InvalidOperationException ( "this area have building" );
			}
			Building = building;
		}

		public Area ( [NotNull] XElement resource ) : base ( resource )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof ( resource ) );
			}

			try
			{
				Id = Convert . ToInt64 ( resource . Attribute ( nameof ( Id ) ) . Value );
				_positionId = Convert . ToInt64 ( resource . Attribute ( nameof ( Position ) ) . Value );
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e );
			}
		}

	}
}
