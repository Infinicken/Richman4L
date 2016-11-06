using System ;
using System . Collections ;
using System . Linq ;

namespace WenceyWang . Richman4L . Stocks .PriceController
{

	public struct NormalStockPriceControllerConfig
	{

		public double GovermentControlMax { get ; }

		public double GovermentControlMin { get ; }

		public double GovermentControlPower { get ; }

		public double StockMarketMovementMax { get ; }

		public double StockMarketMovementMin { get ; }

		public double StockMarketMovementPower { get ; }

		public double StockMovementMax { get ; }

		public double StockMovementMin { get ; }

		public double StockMovementPower { get ; }

		public static NormalStockPriceControllerConfig Default { get ; } = new NormalStockPriceControllerConfig ( 0.2 ,
																												- 0.2 ,
																												0.1 ,
																												0.5 ,
																												- 0.5 ,
																												0.2 ,
																												1.0 ,
																												- 1.0 ,
																												0.7 ) ;

		public NormalStockPriceControllerConfig ( double govermentControlMax ,
												double govermentControlMin ,
												double govermentControlPower ,
												double stockMarketMovementMax ,
												double stockMarketMovementMin ,
												double stockMarketMovementPower ,
												double stockMovementMax ,
												double stockMovementMin ,
												double stockMovementPower )
		{
			GovermentControlMax = govermentControlMax ;
			GovermentControlMin = govermentControlMin ;
			GovermentControlPower = govermentControlPower ;
			StockMarketMovementMax = stockMarketMovementMax ;
			StockMarketMovementMin = stockMarketMovementMin ;
			StockMarketMovementPower = stockMarketMovementPower ;
			StockMovementMax = stockMovementMax ;
			StockMovementMin = stockMovementMin ;
			StockMovementPower = stockMovementPower ;
		}

	}

}
