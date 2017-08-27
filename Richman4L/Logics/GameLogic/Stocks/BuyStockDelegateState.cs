using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Stocks
{

	/// <summary>
	///     表示购买股票委托的结果
	/// </summary>
	public enum BuyStockDelegateState
	{

		/// <summary>
		///     委托尚未被执行。
		/// </summary>
		Waiting ,

		/// <summary>
		///     委托已经完成。
		/// </summary>
		Completed ,

		/// <summary>
		///     委托没有全部完成，由于交易量不够。
		/// </summary>
		ValueNotEnough ,

		/// <summary>
		///     委托完全没有完成，由于股票自身原因（不交易，Buff）。
		/// </summary>
		StockCannotBuy ,

		/// <summary>
		///     委托完全没有完成，由于价格。
		/// </summary>
		PriceNotSuit

	}

}
