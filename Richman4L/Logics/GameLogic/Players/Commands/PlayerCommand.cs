using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Interoperability . Arguments ;

namespace WenceyWang . Richman4L . Players . Commands
{

	/// <summary>
	///     指示玩家可以采取的指令
	/// </summary>
	public abstract class StaticPlayerCommand <T> : PlayerCommand where T : StaticPlayerCommand <T>
	{

		public static List <ArgumentInfo> Arguments { get ; protected set ; }

		public sealed override List <ArgumentInfo> ArgumentsInfo => Arguments ;


		public StaticPlayerCommand ( Player performer ) : base ( performer ) { }

	}


	/// <summary>
	///     指示玩家可以采取的指令
	/// </summary>
	public abstract class PlayerCommand : NeedRegisBase <PlayerCommandType , PlayerCommandAttribute , PlayerCommand>
	{

		public virtual bool CanPerform { get ; }

		public abstract List <ArgumentInfo> ArgumentsInfo { get ; }

		/// <summary>
		///     指令的执行者
		/// </summary>
		public Player Performer { get ; }

		protected PlayerCommand ( Player performer ) { Performer = performer ; }

		/// <summary>
		///     执行这个指令
		/// </summary>
		public abstract void Apply ( ArgumentsContainer arguments ) ;

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate ) { }

	}

	[AttributeUsage ( AttributeTargets . Class )]
	public class PlayerCommandAttribute : Attribute
	{

	}

	public class PlayerCommandType : RegisType <PlayerCommandType , PlayerCommandAttribute , PlayerCommand>
	{

		public PlayerCommandType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element ) { }

		public PlayerCommandType ( [NotNull] Type entryType , [NotNull] string name , [NotNull] string introduction ) :
			base ( entryType , name , introduction )
		{
		}

	}

}
