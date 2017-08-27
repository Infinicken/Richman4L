using System ;
using System . Collections ;
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

		private BlockAzimuth ? _previousMainAzimuth ;

		[Own]
		public virtual List <AreaRoad> AdjacentRoads
		{
			get
			{
				if ( _adjacentRoads == null
					&& _adjacentRoadsId == null )
				{
					return null ;
				}

				return _adjacentRoads ?? ( _adjacentRoads =
												_adjacentRoadsId . Select ( roadId => Map . Currnet . GetRoad ( roadId ) as AreaRoad ) .
																	Where ( road => road != null ) . ToList ( ) ) ;
			}
		}

		[Own]
		public BlockAzimuth MainAzimuth => _previousMainAzimuth
											?? ( _previousMainAzimuth = this . GetAzimuth ( AdjacentRoads . RandomItem ( ) ) ) . Value ;

		[NotNull]
		[ItemNotNull]
		public List <AreaBuff> Buffs { get ; set ; } = new List <AreaBuff> ( ) ;

		[Own]
		public abstract long MoneyCostWhenCrossed { get ; protected set ; }

		/// <summary>
		///     建筑抗性，表示在这个地方建造建筑的难度，
		/// </summary>
		[Own]
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

			ForestCoverRate =
				ReadUnnecessaryValue ( resource , nameof(ForestCoverRate) , GameRandom . Current . RandomGameValue ( ) ) ;
		}

		public WithAssetObject Owner { get ; set ; }

		public long MinimumValue { get ; }

		public bool CanGive { get ; }

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

		/// <summary>
		///     由Player調用,在自身建造一個建築
		///     <see
		///         cref="https://onedrive.live.com/edit.aspx/Documents/RichMan4L?cid=cb060fe3721bc584&id=documents&wd=target%28%E8%AE%BE%E8%AE%A1.one%7C65029F20-EC36-470D-A8A6-CAFE5DAB8F08%2F%E6%88%91%E4%BB%AC%E5%A6%82%E4%BD%95%E5%BB%BA%E6%88%BF%E5%AD%90%7C1A21558A-DE44-409F-9F49-9DDC048D6661%2F%29" />
		/// </summary>
		/// <param name="buildingType"></param>
		public void BuildBuildiing ( [NotNull] BuildingType buildingType )
		{
			#region Check Argument

			if ( buildingType == null )
			{
				throw new ArgumentNullException ( nameof(buildingType) ) ;
			}

			if ( ! IsBuildingAvailable ( buildingType ) )
			{
				throw new ArgumentException ( $"{nameof(buildingType)} is not valid for this area" , nameof(buildingType) ) ;
			}
			if ( Building != null )
			{
				throw new InvalidOperationException ( "this area have building" ) ;
			}

			#endregion

			Building = Building . Build ( buildingType ) ;

			Building . Build ( this , Owner ) ;

			//building . Build ( position , player ) ;
			//position . BuildBuildiing ( building ) ;
		}

	}

}
