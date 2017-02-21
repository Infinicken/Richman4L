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
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Buffs . AreaBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Maps . Buildings ;
using WenceyWang . Richman4L . Maps . Roads ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L .Maps
{

	public abstract class Area : Block , IAsset
	{

		private AreaRoad _position ;

		private long _positionId ;

		[NotNull]
		[ItemNotNull]
		public List <AreaBuff> Buffs { get ; set ; } = new List <AreaBuff> ( ) ;

		public abstract long MoneyCostWhenCrossed { get ; protected set ; }

		public abstract double BuildingResistance { get ; protected set ; }

		public AreaRoad Position
		{
			get { return _position ?? ( _position = ( AreaRoad ) Map . Currnet . GetRoad ( _positionId ) ) ; }
			set
			{
				_positionId = value . Id ;
				_position = value ;
			}
		}

		public override int PondingDecrease { get ; }

		public override int Flammability { get ; }

		public override int CombustibleMaterialAmount { get
			; }

		public override int ForestCoverRate { get ; set ; }

		public Building Building { get ; private set ; }

		public abstract long Price { get ; protected set ; }

		[NotNull]
		public abstract ReadOnlyCollection <BuildingType> AvailableBuildings { get ; }

		public Area ( [NotNull] XElement resource ) : base ( resource )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof ( resource ) ) ;
			}

			try
			{
				_positionId = Convert . ToInt64 ( resource . Attribute ( nameof ( Position ) ) . Value ) ;
				ForestCoverRate = Convert . ToInt32 ( resource . Attribute ( nameof ( ForestCoverRate ) ) . Value ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e ) ;
			}
		}

		public WithAssetObject Owner { get ; set ; }

		public decimal MinimumValue { get ; }

		public void GiveTo ( WithAssetObject newOwner )
		{
			if ( newOwner == null )
			{
				throw new ArgumentNullException ( nameof ( newOwner ) ) ;
			}

			Owner = newOwner ;
		}

		public void Stay ( [NotNull] Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) ) ;
			}

			Building ? . Stay ( player ) ;
		}

		public void Pass ( [NotNull] Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) ) ;
			}

			Building ? . Pass ( player ) ;
		}

		public override void StartDay ( GameDate nextDate ) { }

		public bool IsBuildingAvailable ( [NotNull] BuildingType buildingType )
			=> AvailableBuildings . Contains ( buildingType ) ;

		public void BuildBuildiing ( [NotNull] Building building )
		{
			#region Check Argument

			if ( building == null )
			{
				throw new ArgumentNullException ( nameof ( building ) ) ;
			}

			if ( ! IsBuildingAvailable ( building . Type ) )
			{
				throw new ArgumentException ( $"{nameof ( building )} is not valid for this area" , nameof ( building ) ) ;
			}
			if ( Building != null )
			{
				throw new InvalidOperationException ( "this area have building" ) ;
			}

			#endregion

			Building = building ;
		}

	}

}
