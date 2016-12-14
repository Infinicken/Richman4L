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

using WenceyWang . Richman4L . Buffs . AreaBuffs ;
using WenceyWang . Richman4L . Buffs . PlayerBuffs ;
using WenceyWang . Richman4L . Buffs . RoadBuffs ;
using WenceyWang . Richman4L . Buffs . StockBuffs ;
using WenceyWang . Richman4L . Cards ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Roads ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L .GameEnviroment
{

	/// <summary>
	///     指示玩家所使用的控制台
	/// </summary>
	public abstract class PlayerConsole
	{

		public Player Target { get ; internal set ; }


		public abstract Stock StockPicker ( ) ;

		public abstract Player PlayerPicker ( Collection <Player> playerList ) ;

		public abstract Road RoadPicker ( ) ;

		public abstract Area AreaPicker ( ) ;

		public abstract AreaBuff AreaBuffPicker ( Area area ) ;

		public abstract PlayerBuff PlayerBuffPicker ( Player player ) ;

		public abstract RoadBuff RoadBuffPicker ( Road road ) ;

		public abstract StockBuff StockBuffPicker ( Stock stock ) ;

		public abstract void ShowDice ( DiceType diceType , int number ) ;


		public abstract ReadOnlyCollection <CardType> CardStore ( Player player , ReadOnlyCollection <CardType> canBuy ) ;

	}

}
