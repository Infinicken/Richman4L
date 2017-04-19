using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L . Buffs
{

	public abstract class Buff : GameObject
	{

		public virtual string Name { get ; protected set ; }

		public virtual string Introduction { get ; protected set ; }

		protected GameDate StartDate { get ; set ; }

		public int Duration { get ; }

		public Buff ( ) { }

		public Buff ( int duration ) : this ( Game . Current . Calendar . Today , duration ) { }

		public Buff ( GameDate startDate , int duration )
		{
			StartDate = startDate ;
			Duration = duration ;
		}

		public event EventHandler ExpiredEvent ;

		public override void StartDay ( GameDate thisDate ) { }

		public override void EndToday ( )
		{
			if ( Game . Current . Calendar . Today == StartDate + Duration )
			{
				Expire ( ) ;
			}
		}

		public virtual void Expire ( )
		{
			ExpiredEvent ? . Invoke ( this , EventArgs . Empty ) ;
			Game . Current . GameBuffs . Remove ( this ) ;
		}

	}

}
