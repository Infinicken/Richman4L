/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System ;
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

		public PlayerCommandType ( [NotNull] Type entryType , [NotNull] XElement element ) :
			base ( entryType , element )
		{
		}

		public PlayerCommandType ( [NotNull] Type entryType ,
									[NotNull] string name ,
									[NotNull] string introduction ) : base (
			entryType ,
			name ,
			introduction )
		{
		}

	}

}
