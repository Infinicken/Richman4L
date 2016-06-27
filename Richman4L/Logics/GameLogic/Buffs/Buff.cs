using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Buffs
{
	public abstract class Buff : GameObject
	{
		public virtual string Name { get; }

		public virtual string Introduction { get; }

		protected Calendars . GameDate StartDate { get; set; }

		public int Duration { get;  }

		public override void StartDay ( Calendars . GameDate nextDate )
		{

		}

		public override void EndToday ( )
		{
			if ( Game . Current . Calendar . Today == StartDate + Duration )
			{
				Dispose ( );
			}
		}

		protected override void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{
				Game . Current . GameBuffs . Remove ( this );
			}
			base . Dispose ( disposing );
		}

		public Buff ( ) : base ( )
		{

		}

		public Buff ( int duration ) : this ( Game . Current . Calendar . Today , duration )
		{

		}

		public Buff ( Calendars . GameDate startDate , int duration )
		{
			StartDate = startDate;
			Duration = duration;
		}

	}
}
