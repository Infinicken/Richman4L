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
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players . Commands . Arguments ;
using WenceyWang . Richman4L . Players . Commands . Arguments . DefineDomains ;

namespace WenceyWang . Richman4L . Players .Commands
{

	public class PlayerMoveCommand : PlayerCommand
	{

		public override List < PlayerCommandArgumentInfo > Arguments { get ; }

		public PlayerMoveCommand ( Player performer ) : base ( performer )
		{
			PlayerCommandArgumentInfo diceType = new PlayerCommandArgumentInfo (
													"" ,
													"" ,
													ArgumentValueType . Dice ,
													new DiceOwnerDefineDomains ( Performer ) ) ;

			//PlayerCommandArgumentInfo diceNumber = new PlayerCommandArgumentInfo (
			//	"" ,
			//	"" ,
			//	ArgumentValueType . Integer ,
			//	new IntegerIntervalDefineDomain ( 1 , true , Performer . NumberOfDice , true ) );

			//Arguments = new List<PlayerCommandArgumentInfo> { diceType , diceNumber };
		}

		public override void Apply ( ArgumentsContainer arguments )
		{
/*Performer.Move(arguments.Arguments[] */
		}

	}

}
