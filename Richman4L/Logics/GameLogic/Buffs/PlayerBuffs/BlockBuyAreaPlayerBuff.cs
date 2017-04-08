using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Buffs . PlayerBuffs
{

	public class BlockBuyAreaPlayerBuff : PlayerBuff
	{

		public override bool BlockBuyArea => true ;

		public BlockBuyAreaPlayerBuff ( Player target , int duration ) : base ( target , duration ) { }

	}

}
