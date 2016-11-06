using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L . Buffs .StockBuffs
{

	public class RedBuff : StockBuff
	{

		public RedBuff ( Stock target , int duration ) : base ( target , duration ) { }

		public override void StartDay ( GameDate nextDate ) { base . StartDay ( nextDate ) ; }

	}

}
