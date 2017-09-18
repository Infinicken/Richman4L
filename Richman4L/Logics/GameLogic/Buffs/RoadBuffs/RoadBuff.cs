using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . Maps . Roads ;
using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Buffs . RoadBuffs
{

	/// <summary>
	///     指示绑定到道路的效果
	/// </summary>
	public class RoadBuff : Buff
	{

		public Road Target { get ; set ; }

		public virtual bool BlockMoving { get ; }

		public RoadBuff ( int duration ) : base ( duration ) { }

		public RoadBuff ( GameDate startDate , int duration ) : base ( startDate , duration ) { }

		public virtual void DoWhenStay ( Player player , MoveType moveType ) { }

		public virtual void DoWhenPass ( Player player , MoveType moveType ) { }

		public override void Expire ( )
		{
			base . Expire ( ) ;
			Target ? . Buffs ? . Remove ( this ) ;
		}

	}

}
