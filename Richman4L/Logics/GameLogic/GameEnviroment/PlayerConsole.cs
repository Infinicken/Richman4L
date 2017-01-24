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
using System . Collections . ObjectModel ;
using System . Linq ;

using WenceyWang . Richman4L . Cards ;
using WenceyWang . Richman4L . InfomationCenter ;
using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Players . Models ;

namespace WenceyWang . Richman4L .GameEnviroment
{

	/// <summary>
	///     指示玩家所使用的控制台
	/// </summary>
	public abstract class PlayerConsole
	{

		public Player Target { get ; internal set ; }

		public abstract object Picker ( ArgumentInfo info ) ;

		public abstract void ShowDice ( DiceType diceType , int number ) ;

		public abstract void ShowEvent ( Event @event ) ;

		public abstract void PlayerSay ( Player player , PlayerSaying saying ) ;

		public abstract void ShowFlag ( bool flaged ) ;


		public abstract ReadOnlyCollection <CardType> CardStore ( Player player , ReadOnlyCollection <CardType> canBuy ) ;

	}

}
