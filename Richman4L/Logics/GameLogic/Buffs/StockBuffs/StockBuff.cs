namespace WenceyWang . Richman4L . Buffs . StockBuffs
{
	/// <summary>
	/// 指示绑定到股票的效果(红黑卡)
	/// </summary>
	public class StockBuff : Buff
	{
		public Stocks . Stock Target { get; set; }

		public virtual bool BlockBuy { get; }

		public virtual bool BlockSell { get; }


		protected override void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{
				Target . Buffs . Remove ( this );
			}
			base . Dispose ( disposing );
		}

		public StockBuff ( Stocks . Stock target , int duration ) : this ( target , Game . Current . Calendar . Today , duration )
		{

		}

		/// <summary>
		/// 创建新的指向股票的效果
		/// </summary>
		/// <param name="target">目标股票</param>
		/// <param name="startDate">效果开始的日期</param>
		/// <param name="duration">效果持续的时间</param>
		public StockBuff ( Stocks . Stock target , Calendars . GameDate startDate , int duration ) : base ( startDate , duration )
		{
			Target = target;
		}

	}
}
