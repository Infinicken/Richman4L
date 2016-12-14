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
using System . Linq ;

namespace WenceyWang . Richman4L .Players
{

	//Todo:正常的命名
	/// <summary>
	///     指示玩家宣告破产的原因
	/// </summary>
	public enum PlayerBankruptcyReason
	{

		/// <summary>
		///     玩家无法支付应付款
		/// </summary>
		CanNotPay ,

		/// <summary>
		///     玩家丢失了到服务器的连接
		/// </summary>
		LostControl ,

		/// <summary>
		///     玩家触发了破产的剧情或是在游戏中死亡
		/// </summary>
		PlayerLose ,

		/// <summary>
		///     玩家无法提供被需要的股票
		/// </summary>
		OversoldStock ,

		/// <summary>
		///     玩家希望结束自己的游戏
		/// </summary>
		BySelf

	}

}
