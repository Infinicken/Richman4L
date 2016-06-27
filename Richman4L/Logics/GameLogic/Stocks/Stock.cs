using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Xml . Linq;
using WenceyWang . Richman4L . Buffs;
using WenceyWang . Richman4L . Buffs . StockBuffs ;

namespace WenceyWang . Richman4L . Stocks
{
	/// <summary>
	/// 表示股票
	/// </summary>
	public class Stock : GameObject
	{
		/// <summary>
		/// 表示股票的名称
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// 表示当前的价格
		/// </summary>
		public StockPrice CurrentPrice { get; set; }

		internal StockPrice TodayAnticipate { get; set; }

		public PriceController . StockPriceController PriceController { get; }

		/// <summary>
		/// 股票何时交易
		/// </summary>
		public StockTransactDay TransactDay { get; set; }

		/// <summary>
		/// 今天是否交易
		/// </summary>
		public bool TransactToday { get; private set; }

		public List<StockPrice> PriceHistory { get; set; } = new List<StockPrice> ( );


		public List<StockBuff> Buffs { get; set; } = new List<StockBuff> ( );

		/// <summary>
		/// 今天的变动率
		/// </summary>
		public decimal ChangeNet { get; set; }

		/// <summary>
		/// 预计明天的涨幅
		/// </summary>
		internal decimal NextDayChangeNet { get; set; }


		public override void StartDay ( Calendars . GameDate nextDate )
		{
			if ( Buffs . Any ( ( buff ) => ( buff is RedBuff ) ) )
			{
				//Todo:ChangeToUseAnotherController
			}
			TodayAnticipate = PriceController . GetPrice ( );
			CurrentPrice = new StockPrice ( TodayAnticipate . OpenPrice , TodayAnticipate . OpenPrice , TodayAnticipate . OpenPrice , TodayAnticipate . OpenPrice , 0 , 0 );
		}

		public override void EndToday ( )
		{

			ChangeNet = CurrentPrice . CurrentPrice / CurrentPrice . OpenPrice;

			//CurrentPrice = OpenPrice * ChangeNet;

			//TodaysHigh = Math . Max ( OpenPrice , CurrentPrice ) + Math . Abs ( OpenPrice - CurrentPrice ) * GameRandom . Current . Next ( 0 , 1500 ) / 1000m;
			//TodaysLow = Math . Min ( OpenPrice , CurrentPrice ) - Math . Abs ( OpenPrice - CurrentPrice ) * GameRandom . Current . Next ( 0 , 1500 ) / 1000m;

			PriceHistory . Add ( new StockPrice
			{
				//OpenPrice = OpenPrice ,
				//CurrentPrice = CurrentPrice ,
				//TodaysHigh = TodaysHigh ,
				//TodaysLow = TodaysLow
			} );
		}


		/// <summary>
		/// 使这个股票退市
		/// </summary>
		/// <param name="reason">退市的原因</param>
		public void Delist ( StockDelistReason reason )
		{

			DelistEvent?.Invoke ( this , new EventArgs ( ) );
		}

		public event EventHandler DelistEvent;


		public Stock ( XElement element ) : base ( )
		{

		}

		protected override void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{
				if ( disposing )
				{
					Game . Current?.StockMarket?.Stocks?.Remove ( this );
				}
				base . Dispose ( disposing );
			}
		}

	}
}
