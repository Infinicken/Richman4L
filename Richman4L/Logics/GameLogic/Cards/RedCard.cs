using System ;
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
	public class RedCard : Card <RedCard>
	{

		[GameRuleItem ( 5 )]
		public static int Duration => Game . Current . GameRule . GetResult <int> ( typeof ( RedCard ) ) ;


		public override int PriceWhenBuy
		{
			get => throw new NotImplementedException ( ) ;
			set => throw new NotImplementedException ( ) ;
		}

		public override int PriceWhenSell
		{
			get => throw new NotImplementedException ( ) ;
			set => throw new NotImplementedException ( ) ;
		}

		static RedCard ( )
		{
			ArgumentInfo stock = new ArgumentInfo ( "" , "" , typeof ( Stock ) , new StockTransactDefineDomain ( true ) ) ;

			Arguments = new List <ArgumentInfo> { stock } ;
		}

		public override bool CanUse ( ) { return Game . Current . StockMarket . State == StockMarketState . Running ; }

		public override void Use ( ArgumentsContainer arguments )
		{
			ArgumentsInfo . CheckArgument ( arguments ) ;

			RedBuff buff = new RedBuff ( ( Stock ) arguments . Arguments . Single ( ) ,
										Duration ) ;
		}

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

		public override void StartDay ( GameDate thisDate ) { throw new NotImplementedException ( ) ; }

	}

}
