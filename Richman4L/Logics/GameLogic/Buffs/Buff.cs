using System;
using WenceyWang . Richman4L . Calendars;

namespace WenceyWang . Richman4L . Buffs
{

	public abstract class Buff : GameObject
	{

		public virtual string Name { get; }

		public virtual string Introduction { get; }

		protected GameDate StartDate { get; set; }

		public int Duration { get; }

		public Buff ( ) { }

		public Buff ( int duration ) : this ( Game . Current . Calendar . Today , duration ) { }

		public Buff ( GameDate startDate , int duration )
		{
			StartDate = startDate;
			Duration = duration;
		}

		public event EventHandler MaturityEvent;

		public override void StartDay ( GameDate nextDate ) { }

		public override void EndToday ( )
		{
			if ( Game . Current . Calendar . Today == StartDate + Duration )
			{
				Maturity ( );
			}
		}

		public virtual void Maturity ( )
		{
			Game . Current . GameBuffs . Remove ( this );
			MaturityEvent?.Invoke ( this , EventArgs . Empty );
		}

	}

}
