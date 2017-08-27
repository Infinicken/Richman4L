using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Buffs . StockBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Cards
{

	[Card]
	public class RedCard : StaticCard <RedCard>
	{

		[GameRuleValue ( 5 )]
		public static int Duration => GameRule . GetResult <int> ( typeof ( RedCard ) ) ;

		public override bool CanUse => Game . Current . StockMarket . State == StockMarketState . Running ;

		static RedCard ( )
		{
			ArgumentInfo stock = new ArgumentInfo ( "" , "" , typeof ( Stock ) , new StockTransactDefineDomain ( true ) ) ;

			Arguments = new List <ArgumentInfo> { stock } ;
		}

		public override void Use ( ArgumentsContainer arguments )
		{
			ArgumentsInfo . CheckArgument ( arguments ) ;

			RedBuff buff = new RedBuff ( ( Stock ) arguments . Arguments . Single ( ) , Duration ) ;
		}

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

		public override void StartDay ( GameDate thisDate ) { throw new NotImplementedException ( ) ; }

	}

}
