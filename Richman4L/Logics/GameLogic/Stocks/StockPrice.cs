using System ;
using System . Collections ;
using System . Linq ;

namespace WenceyWang . Richman4L .Stocks
{

	/// <summary>
	///     指示股票价格
	/// </summary>
	public struct StockPrice
	{

		//todo:Is readonly must?
		/// <summary>
		/// </summary>
		/// <param name="openPrice"></param>
		/// <param name="currentPrice"></param>
		/// <param name="todaysHigh"></param>
		/// <param name="todaysLow"></param>
		/// <param name="buyVolume"></param>
		/// <param name="sellVolume"></param>
		public StockPrice ( decimal openPrice ,
							decimal currentPrice ,
							decimal todaysHigh ,
							decimal todaysLow ,
							int buyVolume ,
							int sellVolume )
		{
			OpenPrice = openPrice ;
			CurrentPrice = currentPrice ;
			TodaysHigh = todaysHigh ;
			TodaysLow = todaysLow ;
			BuyVolume = buyVolume ;
			SellVolume = sellVolume ;
		}

		/// <summary>
		///     指示开盘价
		/// </summary>
		public decimal OpenPrice { get ; }

		/// <summary>
		///     指示收盘价
		/// </summary>
		public decimal CurrentPrice { get ; }

		/// <summary>
		///     指示最高价
		/// </summary>
		public decimal TodaysHigh { get ; }

		/// <summary>
		///     指示最低价
		/// </summary>
		public decimal TodaysLow { get ; }

		/// <summary>
		///     购买量
		/// </summary>
		public int BuyVolume { get ; }

		/// <summary>
		///     售出量
		/// </summary>
		public int SellVolume { get ; }

		public bool Equals ( StockPrice other )
		{
			return OpenPrice == other . OpenPrice && CurrentPrice == other . CurrentPrice &&
					TodaysHigh == other . TodaysHigh &&
					TodaysLow == other . TodaysLow && BuyVolume == other . BuyVolume && SellVolume == other . SellVolume ;
		}

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) )
			{
				return false ;
			}

			return obj is StockPrice && Equals ( ( StockPrice ) obj ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				int hashCode = OpenPrice . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ CurrentPrice . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ TodaysHigh . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ TodaysLow . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ BuyVolume . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ SellVolume . GetHashCode ( ) ;
				return hashCode ;
			}
		}

		public static bool operator == ( StockPrice left , StockPrice right ) { return left . Equals ( right ) ; }

		public static bool operator != ( StockPrice left , StockPrice right ) { return ! left . Equals ( right ) ; }

	}

}
