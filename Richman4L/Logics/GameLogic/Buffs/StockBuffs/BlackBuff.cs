namespace WenceyWang . Richman4L . Buffs .StockBuffs
{

	public class BlackBuff : StockBuff
	{
		public override void StartDay ( Calendars . GameDate nextDate )
		{

			base . StartDay ( nextDate );
		}

		public BlackBuff ( Stocks . Stock target , int duration ) : base ( target , duration )
		{

		}

	}

}