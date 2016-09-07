using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Buffs .StockBuffs
{

	public class BlackBuff : StockBuff
	{

		public BlackBuff ( Stock target , int duration ) : base ( target , duration ) { }

		public override void StartDay ( GameDate nextDate ) { base . StartDay ( nextDate ) ; }

	}

}
