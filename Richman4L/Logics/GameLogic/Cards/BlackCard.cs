using System;
using System . Collections;
using System . Collections . Generic;
using System . Linq;

using WenceyWang . Richman4L . Buffs . StockBuffs;
using WenceyWang . Richman4L . Calendars;
using WenceyWang . Richman4L . Interoperability . Arguments;
using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;
using WenceyWang . Richman4L . Stocks;
using WenceyWang . Richman4L . Weathers;

namespace WenceyWang . Richman4L . Cards
{

	[Card]
	public class BlackCard : Card
	{

		public override int PriceWhenBuy
		{
			get { throw new NotImplementedException ( ); }
			set { throw new NotImplementedException ( ); }
		}

		public override int PriceWhenSell
		{
			get { throw new NotImplementedException ( ); }
			set { throw new NotImplementedException ( ); }
		}


		public override bool CanUse ( ) { return Game . Current . StockMarket . State == StockMarketState . Running; }

		public override void Use ( ArgumentsContainer arguments )
		{
			if ( arguments . Arguments . Count != 1 )
			{
				throw new ArgumentException ( );
			}

			BlackBuff buff = new BlackBuff ( ( Stock ) arguments . Arguments . Single ( ) , 3 );
		}

		public override void EndToday ( ) { throw new NotImplementedException ( ); }

		public override void StartDay ( GameDate nextDate ) { throw new NotImplementedException ( ); }

		public override List<ArgumentInfo> Arguments
		{
			get
			{
				ArgumentInfo stock = new ArgumentInfo ( "" , "" , typeof ( Stock ) , new StockTransactDefineDomain ( true ) );

				return new List<ArgumentInfo> { stock };
			}
		}

	}

}
