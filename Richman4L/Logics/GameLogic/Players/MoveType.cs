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

using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Players
{
	/// <summary>
	/// 指示玩家的移动类型
	/// </summary>
	public enum MoveType
	{
		/// <summary>
		/// 步行，使用一颗骰子
		/// </summary>
		Walk = 1,

		/// <summary>
		/// 骑自行车，使用两颗骰子
		/// </summary>
		RidingBicycle = 2,

		/// <summary>
		/// 骑机车，使用三颗骰子
		/// </summary>
		RidingMotorcycle=3,

		/// <summary>
		/// 驾驶汽车，使用四颗骰子
		/// </summary>
		DrivingCar = 4,

	}
}
