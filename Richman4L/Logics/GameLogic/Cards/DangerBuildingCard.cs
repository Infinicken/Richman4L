using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Cards
{

	[Card]
	public class DangerBuildingCard : Card
	{

		public override int PriceWhenBuy { get ; set ; }

		public override int PriceWhenSell { get ; set ; }

		public override List <ArgumentInfo> ArgumentsInfo
		{
			get
			{
				Player owner = Owner as Player ;
				ArgumentValueDefineDomain defineDomain ;
				if ( owner == null )
				{
					defineDomain = new NullDefinDomain ( ) ;
				}
				else
				{
					defineDomain = new PlayerPositionAreaDefineDomain ( owner ) ;
				}
				ArgumentInfo position = new ArgumentInfo ( "" , "" , typeof ( Area ) , defineDomain ) ;
				return new List <ArgumentInfo> { position } ;
			}
		}

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate thisDate ) { }


		public override bool CanUse ( ) { return Owner is Player ; }

		public override void Use ( ArgumentsContainer arguments ) { }

	}

}
