namespace WenceyWang . Richman4L . Buffs . StockBuffs
{
	public class RedBuff : StockBuff
	{
		public override void StartDay ( Calendars . GameDate nextDate )
		{

			base . StartDay ( nextDate );
		}

		public RedBuff ( Stocks . Stock target , int duration ) : base ( target , duration )
		{

		}

	}

}
