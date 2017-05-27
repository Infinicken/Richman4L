using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L
{

	public abstract class WinningCondition : NeedRegisTypeBase <WinningConditionType , WinningConditionAttribute ,
		WinningCondition>
	{

		public abstract bool IsWin ( Player player ) ;

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate ) { }

	}

	public class WinningConditionType : RegisterableTypeBase <WinningConditionType , WinningConditionAttribute ,
		WinningCondition>
	{

		public WinningConditionType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element )
		{
		}

		public WinningConditionType ( [NotNull] Type entryType ,
									[NotNull] string name ,
									[NotNull] string introduction ) : base ( entryType , name , introduction )
		{
		}

	}

	[AttributeUsage ( AttributeTargets . Class )]
	public class WinningConditionAttribute : Attribute
	{

	}

}
