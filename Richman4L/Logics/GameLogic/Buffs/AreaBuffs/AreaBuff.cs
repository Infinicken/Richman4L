namespace WenceyWang . Richman4L . Buffs . AreaBuffs
{
	/// <summary>
	/// 指示绑定到区域的效果
	/// </summary>
	public class AreaBuff : Buff
	{
		public Maps . Area Target { get; set; }

		public virtual bool BlockBuy => false ;

		public virtual bool BlockBuild => false ;

		public virtual bool BlockCharge => false ;

		public AreaBuff (Maps.Area target ) : base ( )
		{
			Target = target;
		}

	}
}
