using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . Stocks ;

namespace WenceyWang . Richman4L . Logics . Buffs . StockBuffs
{

	public class RedBuff : StockBuff
	{

		public RedBuff ( Stock target , int duration ) : base ( target , duration ) { }

		public override void StartDay ( GameDate thisDate ) { base . StartDay ( thisDate ) ; }

	}

}
