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
using WenceyWang . Richman4L . Calendars;
using WenceyWang . Richman4L . Players;
using WenceyWang . Richman4L . Weathers;

namespace WenceyWang . Richman4L . Buffs . RoadBuffs
{
	/// <summary>
	/// 表示道路上的狗，会咬伤步行经过的人和在此停留的玩家，会被自行车，机车和汽车碾死，会因为不好的天气状况而死。
	/// </summary>
	public class Dog : RoadBuff
	{
		/// <summary>
		/// 指示狗咬经过的行人的概率的1000倍
		/// </summary>
		public int BiteWalkerPossibility => 333;

		/// <summary>
		/// 指示在此停止的人被狗咬的概率的1000倍
		/// </summary>
		public long BiteStayerPossibility => 666;

		public override void DoWhenPass ( Player player , MoveType moveType )
		{
			if ( moveType == MoveType . Walk )
			{

				//Bite

			}
			if ( moveType == MoveType . RidingBicycle || moveType == MoveType . RidingMotorcycle || moveType == MoveType . DrivingCar )
			{
				Kill ( player , moveType );
			}
			base . DoWhenPass ( player , moveType );
		}

		public override void DoWhenStay ( Player player , MoveType moveType )
		{
			base . DoWhenStay ( player , moveType );
		}

		public override void StartDay ( GameDate nextDate )
		{
			if ( Game . Current . Weather . Wind . Strength >= 800 )
			{

			}
			base . StartDay ( nextDate );
		}

		public bool IsKilled ( Weather weather )
		{
			return weather . Wind . Strength >= 800 || weather . Temperature <= 0 || weather . Temperature >= 37;
		}

		public void Bite ( Player player )
		{

		}


		public event EventHandler<Event . DogDeadEventArgs> Dead;

		public void Kill ( Weather weather )
		{

		}

		public void Kill ( Player murderer , MoveType moveType )
		{

		}

		protected override void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{

			}
			base . Dispose ( disposing );
		}
	}
}
