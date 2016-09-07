using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Buffs . StockBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L .Stocks
{

	/// <summary>
	///     表示股票市场
	/// </summary>
	public class StockMarket : GameObject
	{

		private GameDate _movementChanging = Game . Current . Calendar . Today ;

		public List < Stock > Stocks { get ; } = new List < Stock > ( ) ;

		public StockPriceMovement Movement { get ; internal set ; }


		public decimal DelegateFeeRate { get ; set ; }

		//todo:event

		public List < StockBuff > Buffs { get ; private set ; } = new List < StockBuff > ( ) ;

		public StockPrice SynthesizePrice
		{
			get
			{
				return new StockPrice ( Stocks . Sum ( stock => stock . CurrentPrice . OpenPrice ) ,
										Stocks . Sum ( stock => stock . CurrentPrice . CurrentPrice ) ,
										Stocks . Sum ( stock => stock . CurrentPrice . TodaysHigh ) ,
										Stocks . Sum ( stock => stock . CurrentPrice . TodaysLow ) ,
										Stocks . Sum ( stock => stock . CurrentPrice . BuyVolume ) ,
										Stocks . Sum ( stock => stock . CurrentPrice . SellVolume ) ) ;
			}
		}

		[ NotNull ]
		private Dictionary < Stock , List < BuyStockDelegate > > BuyDelegateList { get ; set ; }

		[ NotNull ]
		private Dictionary < Stock , List < SellStockDelegate > > SellDelegateList { get ; set ; }


		private StockMarket ( [ NotNull ] XDocument document ) : this ( )
		{
			if ( document == null )
			{
				throw new ArgumentNullException ( nameof ( document ) ) ;
			}

			try
			{
				foreach ( XElement stock in document . Root . Elements ( ) )
				{
					Stocks . Add ( new Stock ( stock ) ) ;
				}
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( document )} has wrong data or lack of data" , e ) ;
			}

			//ToDo LoadStocks
		}

		public StockMarket ( ) { }

		public override void EndToday ( )
		{
			CheckDisposed ( ) ;

			foreach ( Stock item in Stocks )
			{
				item . EndToday ( ) ;
			}

			List < Stock > toProcess = BuyDelegateList . Keys . Union ( SellDelegateList . Keys ) . ToList ( ) ;

			foreach ( Stock stock in toProcess )
			{
				List < SellStockDelegate > sellDelegates = SellDelegateList [ stock ] ;
				List < BuyStockDelegate > buyDelegates = BuyDelegateList [ stock ] ;

				if ( stock . TransactToday )
				{
					sellDelegates . Sort ( ( x , y ) => x . Price . CompareTo ( y . Price ) ) ;
					buyDelegates . Sort ( ( x , y ) => y . Price . CompareTo ( x . Price ) ) ;

					decimal minSellPrice = sellDelegates . Min ( dele => dele . Price ) ;
					if ( minSellPrice < stock . CurrentPrice . TodaysLow )
					{
						stock . LowerTodaysLow ( sellDelegates . Min ( dele => dele . Price ) ) ;
					}

					decimal maxBuyPrice = buyDelegates . Max ( dele => dele . Price ) ;
					if ( maxBuyPrice > stock . CurrentPrice . TodaysHigh )
					{
						stock . HigherTodaysHigh ( maxBuyPrice ) ;
					}

					if ( ! stock . IsBlockSell ( ) )
					{
						int buyVolume = stock . CurrentPrice . BuyVolume ;
						if ( ! stock . IsBlockBuy ( ) )
						{
							buyVolume += BuyDelegateList [ stock ] . Sum ( dele => dele . Number ) ;
						}
						foreach ( SellStockDelegate dele in sellDelegates )
						{
							if ( dele . Price <= stock . CurrentPrice . TodaysHigh )
							{
								if ( buyVolume > dele . Number )
								{
									buyVolume -= dele . Number ;
									dele . Player . TakeAwayStock ( stock , dele . Number ) ;
									dele . Player . GetFromSellStock ( stock , dele . Number , dele . Number * dele . Price . ToLongFloor ( ) ) ;
									dele . State = SellStockDelegateState . Completed ;
								}
								else
								{
									dele . Player . TakeAwayStock ( stock , buyVolume ) ;
									dele . Player . GetFromSellStock ( stock , buyVolume , buyVolume * dele . Price . ToLongFloor ( ) ) ;
									dele . State = SellStockDelegateState . VolumeNotEnough ;
								}
							}
							else
							{
								dele . State = SellStockDelegateState . PriceNotSuit ;
							}
						}
					}

					if ( ! stock . IsBlockBuy ( ) )
					{
						int sellVolume = stock . CurrentPrice . BuyVolume ;
						if ( ! stock . IsBlockSell ( ) )
						{
							sellVolume += BuyDelegateList [ stock ] . Sum ( dele => dele . Number ) ;
						}
						foreach ( BuyStockDelegate dele in buyDelegates )
						{
							if ( dele . Price >= stock . CurrentPrice . TodaysLow )
							{
							}
						}
					}
				}
				else
				{
					foreach ( SellStockDelegate deles in sellDelegates )
					{
						deles . State = SellStockDelegateState . StockCannotSell ;
					}
					foreach ( BuyStockDelegate deles in buyDelegates )
					{
						deles . State = BuyStockDelegateState . StockCannotBuy ;
					}
				}

				foreach ( SellStockDelegate deles in sellDelegates )
				{
					deles . Player . PayForStockDelegate ( deles ,
															( deles . Price * deles . Number * DelegateFeeRate ) . ToLongCelling ( ) ) ;
				}
				foreach ( BuyStockDelegate deles in buyDelegates )
				{
					deles . Player . PayForStockDelegate ( deles ,
															( deles . Price * deles . Number * DelegateFeeRate ) . ToLongCelling ( ) ) ;
				}
			}
		}

		public override void StartDay ( GameDate date )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( nameof ( StockMarket ) ) ;
			}

			if ( date == _movementChanging )
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

				_movementChanging += GameRandom . Current . Next ( 20 , 30 ) ;
			}

			foreach ( Stock item in Stocks )
			{
				item . StartDay ( date ) ;
			}
		}

		/// <summary>
		///     提交购买股票的委托
		/// </summary>
		/// <param name="buyDelegate">要提交的委托</param>
		public void BuyStock ( [ NotNull ] BuyStockDelegate buyDelegate )
		{
			CheckDisposed ( ) ;

			if ( buyDelegate == null )
			{
				throw new ArgumentNullException ( nameof ( buyDelegate ) ) ;
			}

			if ( ! BuyDelegateList . ContainsKey ( buyDelegate . Stock ) )
			{
				BuyDelegateList . Add ( buyDelegate . Stock , new List < BuyStockDelegate > ( ) ) ;
			}
			BuyDelegateList [ buyDelegate . Stock ] . Add ( buyDelegate ) ;
		}

		/// <summary>
		///     提交销售股票的委托
		/// </summary>
		/// <param name="sellDelegate">要提交的委托</param>
		public void SellStock ( [ NotNull ] SellStockDelegate sellDelegate )
		{
			CheckDisposed ( ) ;

			if ( sellDelegate == null )
			{
				throw new ArgumentNullException ( nameof ( sellDelegate ) ) ;
			}

			if ( ! SellDelegateList . ContainsKey ( sellDelegate . Stock ) )
			{
				SellDelegateList . Add ( sellDelegate . Stock , new List < SellStockDelegate > ( ) ) ;
			}
			SellDelegateList [ sellDelegate . Stock ] . Add ( sellDelegate ) ;
		}

		public override string ToString ( )
		{
			return $"StockMarket with {Stocks . Count} stock" ;

			//Todo:Compele this;			
		}

	}

}
