/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics . Contracts ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Buffs . StockBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Properties ;
using WenceyWang . Richman4L . Stocks . PriceController ;

namespace WenceyWang . Richman4L .Stocks
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
		public StockPrice CurrentPrice { get ; set ; }

		internal StockPrice TodayAnticipate { get ; set ; }

		[ NotNull ]
		public StockPriceController PriceController { get ; }

		/// <summary>
		///     股票何时交易
		/// </summary>
		public StockTransactDay TransactDay { get ; set ; }

		/// <summary>
		///     今天是否交易
		/// </summary>
		public bool TransactToday { get ; private set ; }


		public List < StockPrice > PriceHistory { get ; set ; } = new List < StockPrice > ( ) ;


		public List < StockBuff > Buffs { get ; set ; } = new List < StockBuff > ( ) ;

		/// <summary>
		///     今天的变动率
		/// </summary>
		public decimal ChangeNet { get ; set ; }

		/// <summary>
		///     预计明天的涨幅
		/// </summary>
		internal decimal NextDayChangeNet { get ; set ; }

		public Stock ( XElement element ) { }


		public override void StartDay ( GameDate nextDate )
		{
			if ( Buffs . Any ( buff => buff is RedBuff ) )
			{
				//Todo:ChangeToUseAnotherController
			}
			TodayAnticipate = PriceController . GetPrice ( ) ;
			CurrentPrice = new StockPrice ( TodayAnticipate . OpenPrice ,
											TodayAnticipate . OpenPrice ,
											TodayAnticipate . OpenPrice ,
											TodayAnticipate . OpenPrice ,
											0 ,
											0 ) ;
		}

		public override void EndToday ( )
		{
			ChangeNet = CurrentPrice . CurrentPrice / CurrentPrice . OpenPrice ;

			//CurrentPrice = OpenPrice * ChangeNet;

			//TodaysHigh = Math . Max ( OpenPrice , CurrentPrice ) + Math . Abs ( OpenPrice - CurrentPrice ) * GameRandom . Current . Next ( 0 , 1500 ) / 1000m;
			//TodaysLow = Math . Min ( OpenPrice , CurrentPrice ) - Math . Abs ( OpenPrice - CurrentPrice ) * GameRandom . Current . Next ( 0 , 1500 ) / 1000m;

			PriceHistory . Add ( new StockPrice ( ) ) ;
		}


		/// <summary>
		///     使这个股票退市
		/// </summary>
		/// <param name="reason">退市的原因</param>
		public void Delist ( StockDelistReason reason ) { DelistEvent ? . Invoke ( this , EventArgs . Empty ) ; }

		public event EventHandler DelistEvent ;


		public void AddTradingVolume ( int tradingValue )
		{
			Contract . Requires < ArgumentOutOfRangeException > ( tradingValue > 0 ) ;

			CurrentPrice = new StockPrice ( CurrentPrice . OpenPrice ,
											CurrentPrice . CurrentPrice ,
											CurrentPrice . TodaysHigh ,
											CurrentPrice . TodaysLow ,
											CurrentPrice . BuyVolume + tradingValue ,
											CurrentPrice . SellVolume + tradingValue ) ;
		}

		public void LowerTodaysLow ( decimal lowerPrice )
		{
			if ( lowerPrice >= CurrentPrice . TodaysLow )
			{
				throw new ArgumentException (
						$"{nameof ( lowerPrice )} should less than {nameof ( CurrentPrice )}.{nameof ( CurrentPrice . TodaysLow )}" ) ;
			}

			CurrentPrice = new StockPrice ( CurrentPrice . OpenPrice ,
											CurrentPrice . CurrentPrice ,
											CurrentPrice . TodaysHigh ,
											lowerPrice ,
											CurrentPrice . BuyVolume ,
											CurrentPrice . SellVolume ) ;
		}

		public void HigherTodaysHigh ( decimal higherPrice )
		{
			if ( higherPrice <= CurrentPrice . TodaysLow )
			{
				throw new ArgumentException (
						$"{nameof ( higherPrice )} should greater than {nameof ( CurrentPrice )}.{nameof ( CurrentPrice . TodaysHigh )}" ) ;
			}

			CurrentPrice = new StockPrice ( CurrentPrice . OpenPrice ,
											CurrentPrice . CurrentPrice ,
											higherPrice ,
											CurrentPrice . TodaysLow ,
											CurrentPrice . BuyVolume ,
											CurrentPrice . SellVolume ) ;
		}

		public void AddBuff ( StockBuff buff )
		{
			if ( buff == null )
			{
				throw new ArgumentNullException ( nameof ( buff ) ) ;
			}

			Buffs . Add ( buff ) ;
		}

		//}
		//	}
		//		base . Dispose ( disposing ) ;
		//		}
		//			Game . Current ? . StockMarket ? . Stocks ? . Remove ( this ) ;
		//		{
		//		if ( disposing )
		//	{
		//	if ( ! DisposedValue )
		//{

		//protected override void Dispose ( bool disposing )
	}

}
