using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Maps . Roads ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Buffs .RoadBuffs
{

	/// <summary>
	///     指示绑定到道路的效果
	/// </summary>
	public class RoadBuff : Buff
	{

		public Road Target { get ; set ; }

		public virtual bool BlockMoving { get ; }

		public virtual void DoWhenStay ( Player player , MoveType moveType ) { }

		public virtual void DoWhenPass ( Player player , MoveType moveType ) { }

		public override void Maturity ( )
		{
			Target ? . Buffs ? . Remove ( this ) ;
			base . Maturity ( ) ;
		}

	}

}
