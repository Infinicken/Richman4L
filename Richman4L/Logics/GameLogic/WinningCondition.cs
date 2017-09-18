using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics
{

	public abstract class WinningCondition
		: NeedRegisBase <WinningConditionType , WinningConditionAttribute , WinningCondition>
	{

		public abstract bool IsWin ( Player player ) ;

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate ) { }

	}

	public class WinningConditionType : RegisType <WinningConditionType , WinningConditionAttribute , WinningCondition>
	{

		public WinningConditionType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element )
		{
		}

		public WinningConditionType ( [NotNull] Type entryType ) : base ( entryType ) { }

	}

	[AttributeUsage ( AttributeTargets . Class )]
	public class WinningConditionAttribute : NeedRegisAttributeBase
	{

	}

}
