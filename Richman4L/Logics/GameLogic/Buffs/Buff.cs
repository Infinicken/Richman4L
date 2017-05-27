using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L . Buffs
{

	public abstract class Buff : NeedRegisTypeBase <BuffType , BuffAttribute , Buff>
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

	[AttributeUsage ( AttributeTargets . Class )]
	public class BuffAttribute : Attribute
	{

	}

	public class BuffType : RegisterableTypeBase <BuffType , BuffAttribute , Buff>
	{

		public BuffType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element ) { }

		public BuffType ( [NotNull] Type entryType , [NotNull] string name , [NotNull] string introduction ) : base (
			entryType ,
			name ,
			introduction )
		{
		}

	}

}
