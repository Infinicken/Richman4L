using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Buffs . StockBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L .Cards
{

	[Card]
	public class RedCard : Card <RedCard>
	{

		public override int PriceWhenBuy
		{
			get { throw new NotImplementedException ( ) ; }
			set { throw new NotImplementedException ( ) ; }
		}

		public override int PriceWhenSell
		{
			get { throw new NotImplementedException ( ) ; }
			set { throw new NotImplementedException ( ) ; }
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

			RedBuff buff = new RedBuff ( ( Stock ) arguments . Arguments . Single ( ) , 3 ) ;
		}

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

		public override void StartDay ( GameDate nextDate ) { throw new NotImplementedException ( ) ; }

	}

	[Card]
	public class DangerBuildingCard : Card
	{

		public override int PriceWhenBuy { get ; set ; }

		public override int PriceWhenSell { get ; set ; }

		public override List <ArgumentInfo> ArgumentsInfo
		{
			get
			{
				Player owner = Owner as Player ;
				ArgumentValueDefineDomain defineDomain ;
				if ( owner == null )
				{
					defineDomain = new NullDefinDomain ( ) ;
				}
				else
				{
					defineDomain = new PlayerPositionAreaDefineDomain ( owner ) ;
				}
				ArgumentInfo position = new ArgumentInfo ( "" , "" , typeof ( Area ) , defineDomain ) ;
				return new List <ArgumentInfo> { position } ;
			}
		}

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate ) { }


		public override bool CanUse ( ) { return Owner is Player ; }

		public override void Use ( ArgumentsContainer arguments ) { }

	}

	public class PlayerPositionAreaDefineDomain : ArgumentValueDefineDomain
	{

		public Player Target { get ; set ; }

		public PlayerPositionAreaDefineDomain ( Player target ) { Target = target ; }

		public PlayerPositionAreaDefineDomain ( WithAssetObject owner , Player target ) { Target = target ; }

		public override bool IsValid ( object value ) { throw new NotImplementedException ( ) ; }

	}

	public class NullDefinDomain : ArgumentValueDefineDomain
	{

		public override bool IsValid ( object value ) { return false ; }

	}

	public class MapAreaDefineDomain : ArgumentValueDefineDomain
	{

		public MapArea Area { get ; }

		public MapAreaDefineDomain ( MapArea area ) { Area = area ; }

		public override bool IsValid ( object value )
		{
			try
			{
				return Area . IsInArea ( ( MapObject ) value ) ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

}
