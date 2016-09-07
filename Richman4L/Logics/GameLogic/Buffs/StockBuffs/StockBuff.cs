using System ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Buffs .StockBuffs
{

	/// <summary>
	///     指示绑定到股票的效果(红黑卡)
	/// </summary>
	public class StockBuff : Buff
	{

		private Stock _target ;

		public Stock Target
		{
			get { return _target ; }
			private set
			{
				if ( value == null )
				{
					throw new ArgumentNullException ( nameof ( value ) ) ;
				}

				if ( _target == null )
				{
					_target = value ;
					_target . AddBuff ( this ) ;
				}
				else
				{
					throw new InvalidOperationException ( $"Can not reset {nameof ( Target )}" ) ;
				}
			}
		}

		public virtual bool BlockBuy { get ; }

		public virtual bool BlockSell { get ; }

		/// <summary>
		///     表示对股票价格的影响
		/// </summary>
		public virtual double ImpactOnPrices { get ; }

		public StockBuff ( Stock target , int duration ) : this ( target , Game . Current . Calendar . Today , duration ) { }

		/// <summary>
		///     创建新的指向股票的效果
		/// </summary>
		/// <param name="target">目标股票</param>
		/// <param name="startDate">效果开始的日期</param>
		/// <param name="duration">效果持续的时间</param>
		public StockBuff ( Stock target , GameDate startDate , int duration ) : base ( startDate , duration )
		{
			Target = target ;
		}

		protected override void Dispose ( bool disposing )
		{
			if ( ! DisposedValue )
			{
				Target ? . Buffs ? . Remove ( this ) ;
			}
			base . Dispose ( disposing ) ;
		}

	}

}
