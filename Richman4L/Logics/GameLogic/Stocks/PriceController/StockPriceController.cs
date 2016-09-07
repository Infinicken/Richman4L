namespace WenceyWang . Richman4L . Stocks .PriceController
{

	/// <summary>
	///     指示股票价格的控制器
	/// </summary>
	public abstract class StockPriceController : GameObject
	{

		public Stock Target { get ; }

		protected StockPriceController ( Stock target ) { Target = target ; }

		public abstract StockPrice GetPrice ( ) ;

	}

}
