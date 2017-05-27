using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Stocks . PriceController
{

	/// <summary>
	///     指示股票价格的控制器
	/// </summary>
	public abstract class StockPriceController : NeedRegisTypeBase <StockPriceControllerType , Attribute ,
		StockPriceController>
	{

		public Stock Target { get ; }

		protected StockPriceController ( Stock target ) { Target = target ; }

		public abstract StockPrice GetPrice ( ) ;

	}

	public class StockPriceControllerType : RegisterableTypeBase <StockPriceControllerType , Attribute ,
		StockPriceController>
	{

		public StockPriceControllerType ( [NotNull] Type entryType , [NotNull] XElement element ) :
			base ( entryType , element )
		{
		}

		public StockPriceControllerType ( [NotNull] Type entryType ,
										[NotNull] string name ,
										[NotNull] string introduction ) : base ( entryType , name , introduction )
		{
		}

	}

}
