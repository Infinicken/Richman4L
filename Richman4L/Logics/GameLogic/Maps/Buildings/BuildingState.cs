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

namespace WenceyWang . Richman4L . Maps .Buildings
{

	/// <summary>
	///     指示建筑的状态
	/// </summary>
	public enum BuildingState
	{

		/// <summary>
		///     建筑正常工作
		/// </summary>
		Working ,

		/// <summary>
		///     建筑正在安装附件
		/// </summary>
		InstallingAccessory ,

		/// <summary>
		///     建筑正在被建造
		/// </summary>
		Building ,

		/// <summary>
		///     建筑正在被升级
		/// </summary>
		Updating ,

		/// <summary>
		///     建筑被关闭
		/// </summary>
		Closed ,

		/// <summary>
		///     建筑被摧毁
		/// </summary>
		Destroyed ,

		/// <summary>
		///     建筑正在从不维护的状态恢复
		/// </summary>
		Restoreing ,

		/// <summary>
		///     建筑正在从被摧毁的状态恢复
		/// </summary>
		Recovering ,

		/// <summary>
		///     建筑由于天气原因无法工作
		/// </summary>
		WeatherAffect ,

		/// <summary>
		///     建筑由于所在区块的原因无法工作
		/// </summary>
		AreaAffect

	}

}
