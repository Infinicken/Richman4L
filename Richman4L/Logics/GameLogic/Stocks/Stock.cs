using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Buffs . StockBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Stocks . PriceController ;

namespace WenceyWang . Richman4L . Stocks
{

	/// <summary>
	///     表示股票
	/// </summary>
	public class Stock : GameObject
	{

		/// <summary>
		///     表示股票的名称
		/// </summary>
		public string Name { get ; protected set ; }

		/// <summary>
		///     表示当前的价格
		/// </summary>
		public StockPrice Price { get ; set ; }

		internal StockPrice TodayAnticipate { get ; set ; }

		[NotNull]
		public StockPriceController PriceController { get ; }

		/// <summary>
		///     股票何时交易
		/// </summary>
		public StockTransactDay TransactDay { get ; set ; }

		/// <summary>
		///     今天是否交易
		/// </summary>
		public bool TransactToday { get ; private set ; }


		public List <StockPrice> PriceHistory { get ; set ; } = new List <StockPrice> ( ) ;


		public List <StockBuff> Buffs { get ; set ; } = new List <StockBuff> ( ) ;

		/// <summary>
		///     今天的变动率
		/// </summary>
		public decimal ChangeNet { get ; set ; }

		/// <summary>
		///     预计明天的涨幅
		/// </summary>
		internal decimal NextDayChangeNet { get ; set ; }

		public Stock ( XElement element ) { }


		public override void StartDay ( GameDate thisDate )
		{
			PriceHistory . Add ( Price ) ;

			if ( Buffs . Any ( buff => buff is RedBuff ) )
			{
				//Todo:ChangeToUseAnotherController
			}
			PriceController . StartDay ( thisDate ) ;
			TodayAnticipate = PriceController . GetPrice ( ) ;
			Price = new StockPrice ( TodayAnticipate . OpenPrice ,
									TodayAnticipate . OpenPrice ,
									TodayAnticipate . OpenPrice ,
									TodayAnticipate . OpenPrice ,
									0 ,
									0 ) ;
		}

		public override void EndToday ( )
		{
			ChangeNet = Price . CurrentPrice / Price . OpenPrice ;

			Price = new StockPrice ( TodayAnticipate . OpenPrice ,
									TodayAnticipate . CurrentPrice ,
									TodayAnticipate . TodaysHigh ,
									TodayAnticipate . TodaysLow ,
									0 ,
									0 ) ;
		}


		/// <summary>
		///     使这个股票退市
		/// </summary>
		/// <param name="reason">退市的原因</param>
		public void Delist ( StockDelistReason reason )
		{
			DelistEvent ? . Invoke ( this , EventArgs . Empty ) ;
		}

		public event EventHandler DelistEvent ;


		public void AddTradingVolume ( int tradingValue )
		{
			Price = new StockPrice ( Price . OpenPrice ,
									Price . CurrentPrice ,
									Price . TodaysHigh ,
									Price . TodaysLow ,
									Price . BuyVolume + tradingValue ,
									Price . SellVolume + tradingValue ) ;
		}

		public void LowerTodaysLow ( decimal lowerPrice )
		{
			if ( lowerPrice >= Price . TodaysLow )
			{
				throw new ArgumentException ( string . Format ( "{0} should less than {1}.{2}" ,
																nameof(lowerPrice) ,
																nameof(Price) ,
																nameof(Price . TodaysLow) ) ) ;
			}

			Price = new StockPrice ( Price . OpenPrice ,
									Price . CurrentPrice ,
									Price . TodaysHigh ,
									lowerPrice ,
									Price . BuyVolume ,
									Price . SellVolume ) ;
		}

		public void HigherTodaysHigh ( decimal higherPrice )
		{
			if ( higherPrice <= Price . TodaysLow )
			{
				throw new ArgumentException ( string . Format ( "{0} should greater than {1}.{2}" ,
																nameof(higherPrice) ,
																nameof(Price) ,
																nameof(Price . TodaysHigh) ) ) ;
			}

			Price = new StockPrice ( Price . OpenPrice ,
									Price . CurrentPrice ,
									higherPrice ,
									Price . TodaysLow ,
									Price . BuyVolume ,
									Price . SellVolume ) ;
		}

		public void AddBuff ( StockBuff buff )
		{
			if ( buff == null )
			{
				throw new ArgumentNullException ( nameof(buff) ) ;
			}

			Buffs . Add ( buff ) ;
		}

		//protected override void Dispose ( bool disposing )
		//{
		//	if ( ! DisposedValue )
		//	{
		//		if ( disposing )
		//		{
		//			Game . Current ? . StockMarket ? . Stocks ? . Remove ( this ) ;
		//		}
		//		base . Dispose ( disposing ) ;
		//	}

		//}

	}

}
