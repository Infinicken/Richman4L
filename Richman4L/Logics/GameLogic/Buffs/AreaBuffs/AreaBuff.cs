using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Buffs .AreaBuffs
{

	/// <summary>
	///     指示绑定到区域的效果
	/// </summary>
	public class AreaBuff : Buff
	{

		public Area Target { get ; set ; }

		public virtual bool BlockBuy => false ;

		public virtual bool BlockBuild => false ;

		public virtual bool BlockCharge => false ;

		public AreaBuff ( Area target ) { Target = target ; }

	}

}
