/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System . Collections . ObjectModel;

using WenceyWang . Richman4L . Buffs . AreaBuffs;
using WenceyWang . Richman4L . Buffs . PlayerBuffs;
using WenceyWang . Richman4L . Buffs . RoadBuffs;
using WenceyWang . Richman4L . Buffs . StockBuffs;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . GameEnviroment
{
	/// <summary>
	/// 指示玩家所使用的控制台
	/// </summary>
	public abstract class PlayerConsole
	{

		public Player Target { get; internal set; }

		public abstract Stocks . Stock StockPicker ( );

		public abstract Player PlayerPicker ( Collection<Player> playerList );

		public abstract Road RoadPicker ( );

		public abstract Maps . Area AreaPicker ( );

		public abstract AreaBuff AreaBuffPicker ( Maps . Area area );

		public abstract PlayerBuff PlayerBuffPicker ( Player player );

		public abstract RoadBuff RoadBuffPicker ( Road road );

		public abstract StockBuff StockBuffPicker ( Stocks . Stock stock );

		public abstract void ShowDice ( DiceType diceType , int number );



		public abstract ReadOnlyCollection<Cards . CardType> CardStore ( Player player , ReadOnlyCollection<Cards . CardType> canBuy );


		public PlayerConsole ( )
		{

		}
	}
}