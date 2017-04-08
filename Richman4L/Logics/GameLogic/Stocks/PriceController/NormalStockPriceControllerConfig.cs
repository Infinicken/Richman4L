using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Stocks . PriceController
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

		public double StockOpenPricePower { get ; }

		public double MaxPricePower { get ; }

		public double MinPricePower { get ; }

		public int MovementMaxLenth { get ; }

		public int MovementMinLenth { get ; }

		public double WaveTimeBase { get ; }

		public static NormalStockPriceControllerConfig Default { get ; } = new NormalStockPriceControllerConfig ( 0.2 ,
																												- 0.2 ,
																												0.1 ,
																												0.5 ,
																												- 0.5 ,
																												0.2 ,
																												1.0 ,
																												- 1.0 ,
																												0.7 ,
																												0.3 ,
																												1.3 ,
																												0.7 ,
																												7 ,
																												60 ,
																												0.3 ) ;

		public NormalStockPriceControllerConfig ( double govermentControlMax ,
												double govermentControlMin ,
												double govermentControlPower ,
												double stockMarketMovementMax ,
												double stockMarketMovementMin ,
												double stockMarketMovementPower ,
												double stockMovementMax ,
												double stockMovementMin ,
												double stockMovementPower ,
												double stockOpenPricePower ,
												double maxPricePower ,
												double minPricePower ,
												int movementMaxLenth ,
												int movementMinLenth ,
												double waveTimeBase )
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
			StockOpenPricePower = stockOpenPricePower ;
			MaxPricePower = maxPricePower ;
			MinPricePower = minPricePower ;
			MovementMaxLenth = movementMaxLenth ;
			MovementMinLenth = movementMinLenth ;
			WaveTimeBase = waveTimeBase ;
		}

	}

}
