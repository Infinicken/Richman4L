using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Logics . Buffs . AreaBuffs
{

	public class BlockBuyAreaBuff : AreaBuff
	{

		public override bool BlockBuy => true ;

		public BlockBuyAreaBuff ( Area target , int duration ) : base ( target , duration ) { }

	}

}
