using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Buffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Buildings ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Cards
{

	[Card]
	public class DangerBuildingCard : Card
	{

		//todo:
		[GameRuleExpression ( "1" , typeof ( int ) )]
		public override int PriceWhenBuy { get ; set ; }

		public override int PriceWhenSell { get ; set ; }

		//todo:autolazy
		public override List <ArgumentInfo> ArgumentsInfo
		{
			get
			{
				Player owner = Owner as Player ;
				ArgumentValueDefineDomain defineDomain ;
				if ( owner == null )
				{
					defineDomain = new NullDefineDomain ( ) ;
				}
				else
				{
					defineDomain = new MapAreaDefineDomain ( new ObjectChebyshevDistanceMapArea ( owner . MapObject , 2 ) ) ;
				}
				ArgumentInfo position = new ArgumentInfo ( "" , "" , typeof ( Area ) , defineDomain ) ;
				return new List <ArgumentInfo> { position } ;
			}
		}


		public override bool CanUse => Owner is Player ;

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate thisDate ) { }

		public override void Use ( ArgumentsContainer arguments )
		{
			ArgumentsInfo . CheckArgument ( arguments ) ;

//todo
		}

	}

	/// <summary>
	///     征地卡
	/// </summary>
	public class AcquireAreaCard : Card
	{

		public override int PriceWhenBuy { get ; set ; }

		public override int PriceWhenSell { get ; set ; }

		public override List <ArgumentInfo> ArgumentsInfo { get ; }

		public override bool CanUse => Owner is Player ;

		public override void Use ( ArgumentsContainer arguments ) { throw new NotImplementedException ( ) ; }

	}

	public abstract class BuildingBuff : Buff
	{

		public Building Target { get ; }

		public BuildingBuff ( int duration , Building target ) : base ( duration ) { Target = target ; }

		public BuildingBuff ( GameDate startDate , int duration , Building target ) : base ( startDate , duration )
		{
			Target = target ;
		}

	}

}
