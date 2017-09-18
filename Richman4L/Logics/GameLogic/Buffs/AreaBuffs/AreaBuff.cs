using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Logics . Buffs . AreaBuffs
{

	/// <summary>
	///     指示绑定到区域的效果
	/// </summary>
	public class AreaBuff : Buff
	{

		public Area Target { get ; }

		public virtual bool BlockBuy => false ;

		public virtual bool BlockBuild => false ;

		public virtual bool BlockCharge => false ;

		public AreaBuff ( Area target , int duration ) : base ( duration ) { Target = target ; }

		public override void Expire ( )
		{
			Target ? . Buffs ? . Remove ( this ) ;
			base . Expire ( ) ;
		}

	}

}
