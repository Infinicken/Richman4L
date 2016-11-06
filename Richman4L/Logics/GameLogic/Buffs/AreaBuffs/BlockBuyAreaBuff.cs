using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Buffs .AreaBuffs
{

	public class BlockBuyAreaBuff : AreaBuff
	{

		public override bool BlockBuy => true ;

		public BlockBuyAreaBuff ( Area target ) : base ( target ) { }

	}

}
