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
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Buffs . AreaBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Maps . Buildings ;
using WenceyWang . Richman4L . Maps . Roads ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Maps
{

	public abstract class Area : Block , IAsset
	{

		private readonly List <long> _adjacentRoadsId = new List <long> ( ) ;

		private List <AreaRoad> _adjacentRoads ;

		private BlockAzimuth ? previousMainAzimuth ;

		[ConsoleVisable]
		public virtual List <AreaRoad> AdjacentRoads
		{
			get
			{
				if ( _adjacentRoads == null &&
					_adjacentRoadsId == null )
				{
					return null ;
				}

				return _adjacentRoads ??
						( _adjacentRoads =
							_adjacentRoadsId . Select ( roadId => Map . Currnet . GetRoad ( roadId ) as AreaRoad ) .
												Where ( road => road != null ) .
												ToList ( ) ) ;
			}
		}

		[ConsoleVisable]
		public BlockAzimuth MainAzimuth => previousMainAzimuth ??
											( previousMainAzimuth =
												this . GetAzimuth ( AdjacentRoads . RandomItem ( ) ) ) . Value ;

		[NotNull]
		[ItemNotNull]
		public List <AreaBuff> Buffs { get ; set ; } = new List <AreaBuff> ( ) ;

		[ConsoleVisable]
		public abstract long MoneyCostWhenCrossed { get ; protected set ; }

		/// <summary>
		///     建筑抗性，表示在这个地方建造建筑的难度，
		/// </summary>
		[ConsoleVisable]
		public abstract GameValue BuildingResistance { get ; protected set ; }

		public override int PondingDecrease { get ; }

		public override GameValue Flammability { get ; }

		public override int CombustibleMaterialAmount { get ; }

		public sealed override GameValue ForestCoverRate { get ; set ; }

		public Building Building { get ; private set ; }

		public abstract long Price { get ; protected set ; }

		[NotNull]
		public abstract ReadOnlyCollection <BuildingType> AvailableBuildings { get ; }

		public Area ( [NotNull] XElement resource ) : base ( resource )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof(resource) ) ;
			}

			XElement adjacentRoads = resource . Element ( nameof(AdjacentRoads) ) ;

			foreach ( XElement road in adjacentRoads . Elements ( ) )
			{
				_adjacentRoadsId . Add ( ReadNecessaryValue <long> ( road , nameof(Id) ) ) ;
			}

			ForestCoverRate = ReadUnnecessaryValue ( resource ,
													nameof(ForestCoverRate) ,
													GameRandom . Current . RandomGameValue ( ) ) ;
		}

		public WithAssetObject Owner { get ; set ; }

		public decimal MinimumValue { get ; }

		public void GiveTo ( WithAssetObject newOwner )
		{
			Owner = newOwner ?? throw new ArgumentNullException ( nameof(newOwner) ) ;
		}

		public void Stay ( [NotNull] Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			Building ? . Stay ( player ) ;
		}

		public void Pass ( [NotNull] Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof(player) ) ;
			}

			Building ? . Pass ( player ) ;
		}

		public override void StartDay ( GameDate thisDate ) { }

		public bool IsBuildingAvailable ( [NotNull] BuildingType buildingType )
		{
			return AvailableBuildings . Contains ( buildingType ) ;
		}

		public void BuildBuildiing ( [NotNull] Building building )
		{
			#region Check Argument

			if ( building == null )
			{
				throw new ArgumentNullException ( nameof(building) ) ;
			}

			if ( ! IsBuildingAvailable ( building . Type ) )
			{
				throw new ArgumentException ( $"{nameof(building)} is not valid for this area" , nameof(building) ) ;
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
