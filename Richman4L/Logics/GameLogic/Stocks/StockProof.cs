using System ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L .Stocks
{

	public class StockProof : GameObject
	{

		public GameDate Date { get ; }

		public Stock Stock { get ; }


		public Player Owner { get ; set ; }

		public long Number { get ; set ; }

		internal StockProof ( Stock stock , Player owner , long number )
		{
			Date = Game . Current . Calendar . Today ;
			Stock = stock ;
			Owner = owner ;
			Number = number ;
			Stock . DelistEvent += Stock_DelistEvent ;
		}

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate ) { }


		protected override void Dispose ( bool disposing )
		{
			if ( DisposedValue )
			{
				Stock . DelistEvent -= Stock_DelistEvent ;

				//Todo:Remove this from owner
			}
			base . Dispose ( disposing ) ;
		}

		private void Stock_DelistEvent ( object sender , EventArgs e ) { Dispose ( ) ; }

	}

}
