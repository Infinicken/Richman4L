namespace WenceyWang . Richman4L .Stocks
{

	/// <summary>
	///     表示出售股票委托的结果
	/// </summary>
	public enum SellStockDelegateState
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
		VolumeNotEnough ,

		/// <summary>
		///     委托完全没有完成，由于股票自身原因（不交易，Buff）。
		/// </summary>
		StockCannotSell ,

		/// <summary>
		///     委托完全没有完成，由于价格。
		/// </summary>
		PriceNotSuit

	}

}
