using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics . Stocks . PriceController
{

	/// <summary>
	///     指示股票价格的控制器
	/// </summary>
	public abstract class StockPriceController
		: NeedRegisBase <StockPriceControllerType , StockPriceControllerAttribute , StockPriceController>
	{

		public Stock Target { get ; }

		protected StockPriceController ( Stock target ) { Target = target ; }

		public abstract StockPrice GetPrice ( ) ;

	}

	public sealed class StockPriceControllerAttribute : NeedRegisAttributeBase
	{

	}

	public class StockPriceControllerType
		: RegisType <StockPriceControllerType , StockPriceControllerAttribute , StockPriceController>
	{

		public StockPriceControllerType ( [NotNull] Type entryType , [NotNull] XElement element ) :
			base ( entryType , element )
		{
		}

		public StockPriceControllerType ( [NotNull] Type entryType ) : base ( entryType ) { }

	}

}
