using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L . Stocks .PriceController
{

	public class NormalStockPriceController : StockPriceController
	{

		private NormalStockPriceControllerConfig Config { get ; } = NormalStockPriceControllerConfig . Default ;

		internal GameDate MovementChanging { get ; set ; } = Game . Current . Calendar . Today ;

		internal decimal AnticipatePrice { get ; set ; }

		internal StockPriceMovement Movement { get ; set ; }

		private StockPrice TodayPrice { get ; set ; }

		public NormalStockPriceController ( Stock target ) : base ( target ) { }

		private void ChangeMovement ( )
		{
			switch ( GameRandom . Current . Next ( 0 , 3 ) )
			{
				case 1 :
				{
					Movement = StockPriceMovement . Rise ;
					break ;
				}
				case 2 :
				{
					Movement = StockPriceMovement . Keep ;
					break ;
				}
				case 3 :
				{
					Movement = StockPriceMovement . Fall ;
					break ;
				}
			}

			ChangeAnticipate ( ) ;
		}

		public void ChangeAnticipate ( )
		{
			decimal times = 1 ;
			switch ( Movement )
			{
				case StockPriceMovement . Rise :
				{
					times +=
						Convert . ToDecimal (
							GameRandom . Current . NextDoubleBetween ( 0 , Config . StockMovementMax ) *
							Config . StockMovementPower ) ;
					break ;
				}
				case StockPriceMovement . Fall :
				{
					times +=
						Convert . ToDecimal (
							GameRandom . Current . NextDoubleBetween ( Config . StockMovementMin , 0 ) *
							Config . StockMovementPower ) ;
					break ;
				}
			}
			switch ( Game . Current . StockMarket . Movement )
			{
				case StockPriceMovement . Rise :
				{
					times +=
						Convert . ToDecimal ( GameRandom . Current . NextDoubleBetween ( 0 ,
																						Config . StockMarketMovementMax *
																						Config .
																							StockMarketMovementPower ) ) ;
					break ;
				}
				case StockPriceMovement . Fall :
				{
					times +=
						Convert . ToDecimal ( GameRandom . Current . NextDoubleBetween (
																Config . StockMarketMovementMin ,
																0 ) * Config . StockMarketMovementPower ) ;
					break ;
				}
			}
			switch ( Game . Current . GovermentControl )
			{
				case GovermentControl . Positive :
				{
					times +=
						Convert . ToDecimal ( GameRandom . Current . NextDoubleBetween ( 0 ,
																						Config . StockMarketMovementMax ) *
											Config . GovermentControlPower ) ;
					break ;
				}
				case GovermentControl . Negative :
				{
					times +=
						Convert . ToDecimal ( GameRandom . Current . NextDoubleBetween (
																Config . StockMarketMovementMin ,
																0 ) * Config . GovermentControlPower ) ;
					break ;
				}
				default :
					throw new ArgumentOutOfRangeException ( ) ;
			}

			AnticipatePrice = Target . Price . CurrentPrice * times ;
			MovementChanging += GameRandom . Current . Next ( Config . MovementMinLenth , Config . MovementMaxLenth ) ;
		}


		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate )
		{
			if ( nextDate == MovementChanging )
			{
				ChangeMovement ( ) ;
			}

			decimal currentPrice = Target . Price . CurrentPrice ;

			decimal closePrice = ( AnticipatePrice - Target . Price . CurrentPrice ) *
								( decimal )
								GameRandom . Current . NextDoubleBetween ( 1 - Config . WaveTimeBase ,
																			1 - Config . WaveTimeBase ) /
								( MovementChanging - nextDate ) ;

			decimal openPrice = currentPrice +
								( closePrice - currentPrice ) *
								( decimal )
								GameRandom . Current . NextDoubleBetween ( - Config . StockOpenPricePower ,
																			Config . StockOpenPricePower ) ;

			decimal todaysHigh = Math . Max ( closePrice , openPrice ) *
								( decimal ) GameRandom . Current . NextDoubleBetween ( 1 , Config . MaxPricePower ) ;
			decimal todayMin = Math . Min ( closePrice , openPrice ) *
								( decimal ) GameRandom . Current . NextDoubleBetween ( Config . MinPricePower , 1 ) ;

			TodayPrice = new StockPrice ( openPrice , closePrice , todaysHigh , todayMin , 0 , 0 ) ;
		}

		public override StockPrice GetPrice ( ) { return TodayPrice ; }

	}

}
