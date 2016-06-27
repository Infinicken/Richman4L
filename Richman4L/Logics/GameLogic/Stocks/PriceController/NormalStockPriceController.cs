using System;

using WenceyWang . Richman4L . Calendars;

namespace WenceyWang . Richman4L . Stocks . PriceController
{
	public class NormalStockPriceController : StockPriceController
	{
		internal GameDate MovementChanging { get; set; } = Game . Current . Calendar . Today;

		internal decimal AnticipatePrice { get; set; }

		internal StockPriceMovement Movement { get; set; }

		void ChangeMovement ( )
		{
			switch ( GameRandom . Current . Next ( 0 , 3 ) )
			{
				case 1:
					{
						Movement = StockPriceMovement . Rise;
						break;
					}
				case 2:
					{
						Movement = StockPriceMovement . Keep;
						break;
					}
				case 3:
					{
						Movement = StockPriceMovement . Fall;
						break;
					}
			}
			ChangeAnticipate ( );
		}

		public void ChangeAnticipate ( )
		{
			decimal times = 1;
			switch ( Movement )
			{
				case StockPriceMovement . Rise:
					{
						times += Convert . ToDecimal ( GameRandom . Current . NextDouble ( ) * ( Convert . ToDouble ( Properties . Resources . StockMovementMax ) ) * 0.4 );
						break;
					}
				case StockPriceMovement . Fall:
					{
						times += Convert . ToDecimal ( GameRandom . Current . NextDouble ( ) * ( Convert . ToDouble ( Properties . Resources . StockMovementMin ) ) * 0.4 );
						break;
					}
			}
			switch ( Game . Current . StockMarket . Movement )
			{
				case StockPriceMovement . Rise:
					{
						times += Convert . ToDecimal ( GameRandom . Current . NextDouble ( ) * ( Convert . ToDouble ( Properties . Resources . StockMarketMovementMax ) ) * 0.4 );
						break;
					}
				case StockPriceMovement . Fall:
					{
						times += Convert . ToDecimal ( GameRandom . Current . NextDouble ( ) * ( Convert . ToDouble ( Properties . Resources . StockMarketMovementMin ) ) * 0.4 );
						break;
					}
			}
			switch ( Game . Current . GovermentControl )
			{
				case GovermentControl . Positive:
					{
						times += Convert . ToDecimal ( GameRandom . Current . NextDouble ( ) * ( Convert . ToDouble ( Properties . Resources . StockMarketMovementMax ) ) * 0.2 );
						break;
					}
				case GovermentControl . Negative:
					{
						times += Convert . ToDecimal ( GameRandom . Current . NextDouble ( ) * ( Convert . ToDouble ( Properties . Resources . StockMarketMovementMin ) ) * 0.2 );
						break;
					}
				default :
					throw new ArgumentOutOfRangeException ( ) ;
			}

			//AnticipatePrice = CurrentPrice * times;
			MovementChanging += GameRandom . Current . Next ( 15 , 30 ) ;
		}


		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate )
		{
			{
				if ( nextDate == MovementChanging )
				{
					ChangeMovement ( ) ;
				}

				//NextDayChangeNet = ( ( AnticipatePrice - CurrentPrice ) * GameRandom . Current . Next ( 700 , 1300 ) / 1000m ) / ( MovementChanging - nextDate ) / CurrentPrice;
			}

			//if ( CurrentPrice <= 0 )
			{
			}

			//TodaysHigh = OpenPrice;
			//TodaysLow = OpenPrice;
			//BuyValue = 0;
			//SellValue = 0;
		}

		public NormalStockPriceController ( Stock target ) : base ( target ) { }

		public override StockPrice GetPrice ( ) { return new StockPrice ( ) ; }

	}
}