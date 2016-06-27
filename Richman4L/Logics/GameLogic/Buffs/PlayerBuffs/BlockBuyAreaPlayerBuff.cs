namespace WenceyWang . Richman4L . Buffs . PlayerBuffs
{
	public class BlockBuyAreaPlayerBuff : PlayerBuff
	{
		public override bool BlockBuyArea => true ;

		public BlockBuyAreaPlayerBuff ( Players . Player target , int duration ) : base ( target , duration )
		{

		}
	}
}
