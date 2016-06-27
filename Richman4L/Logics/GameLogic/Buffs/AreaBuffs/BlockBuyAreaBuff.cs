namespace WenceyWang . Richman4L . Buffs . AreaBuffs
{
	public class BlockBuyAreaBuff : AreaBuff
	{
		public override bool BlockBuy => true ;

		public BlockBuyAreaBuff ( Maps . Area target ) : base ( target )
		{

		}
	}
}
