using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Buffs .PlayerBuffs
{

	/// <summary>
	///     指示绑定到玩家的效果(神灵)
	/// </summary>
	public abstract class PlayerBuff : Buff
	{

		public Player Target { get ; }

		public virtual bool BlockBuyStock { get ; } = false ;

		public virtual bool BlockSellStock { get ; } = false ;

		public virtual bool BlockBuyArea { get ; } = false ;

		public virtual bool BlockBuildBuilding { get ; } = false ;

		public virtual bool BlockBuildingWorking { get ; } = false ;

		public virtual bool BlockGetCharge { get ; } = false ;

		public virtual bool BlockMoving { get ; } = false ;

		public virtual bool FreeOfCharge { get ; } = false ;

		public virtual int AddDice { get ; } = 0 ;

		public virtual bool ControlDice { get ; } = false ;

		public virtual bool ValueOfDice { get ; }

		public virtual bool UpgradeBuildngs { get ; } = false ;


		public virtual bool BadLuck { get ; } = false ;

		public virtual bool GoodLuck { get ; } = false ;

		//public virtual bool 

		public PlayerBuff ( Player target , int duration ) : base ( Game . Current . Calendar . Today , duration )
		{
			Target = target ;
		}

		public override void StartDay ( GameDate nextDate )
		{
			if ( Game . Current . Calendar . Today == StartDate + Duration )
			{
				Target . LostBuff ( this ) ;
			}
			base . StartDay ( nextDate ) ;
		}

	}

}
