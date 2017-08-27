using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Maps . Buildings ;

namespace WenceyWang . Richman4L . Maps
{

	[MapObject ( nameof(SmallArea) , nameof(SmallArea) )]
	[Guid ( "33F035E3-0DA6-41BB-BEB2-67BD4214CF31" )]
	public class SmallArea : Area
	{

		public override MapSize Size => MapSize . Small ;


		public override GameValue CrossDifficulty { get ; }

		public override int PondingDecrease => 100 ;

		public override long MoneyCostWhenCrossed { get ; protected set ; }

		public override GameValue BuildingResistance { get ; protected set ; }

		public override long Price { get ; protected set ; }

		public override ReadOnlyCollection <BuildingType> AvailableBuildings
		{
			get
			{
				if ( Building == null )
				{
					return _availableBuilding ?? ( _availableBuilding =
														new ReadOnlyCollection <BuildingType> ( Building . BuildingTypes .
																											Where ( type => type . Size == MapSize . Small ) . ToList ( ) ) ) ;
				}

				return new ReadOnlyCollection <BuildingType> ( new List <BuildingType> ( ) ) ;
			}
		}

		public SmallArea ( XElement resource ) : base ( resource ) { }

		private static ReadOnlyCollection <BuildingType> _availableBuilding ;

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

	}

}
