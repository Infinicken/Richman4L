using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Stocks
{

	public class StockProof : GameObject , IAsset
	{

		public GameDate Date { get ; }

		public Stock Stock { get ; }

		public long Number { get ; set ; }


		internal StockProof ( Stock stock , Player owner , long number )
		{
			Date = Game . Current . Calendar . Today ;
			Stock = stock ;
			Owner = owner ;
			Number = number ;
			Stock . DelistEvent += Stock_DelistEvent ;
		}


		public WithAssetObject Owner { get ; set ; }

		public long MinimumValue => ( long ) Math . Floor ( Stock . Price . TodaysLow * Number ) ;

		public bool CanGive { get ; }

		public void GiveTo ( WithAssetObject newOwner ) { Owner = newOwner ; }

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate thisDate ) { }


		private void Stock_DelistEvent ( object sender , EventArgs e ) { throw new NotImplementedException ( ) ; }

	}

}
