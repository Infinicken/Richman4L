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
using System . Xml . Linq ;

namespace WenceyWang . Richman4L . Maps .Buildings
{

	/// <summary>
	///     指示建筑的可选附件
	/// </summary>
	public class BuildingAccessory
	{

		/// <summary>
		///     隶属于的建筑等级
		/// </summary>
		public BuildingGrade BelongTo { get ; }

		/// <summary>
		///     建筑附件的名称
		/// </summary>
		public string Name { get ; }


		/// <summary>
		///     建筑附件的简介
		/// </summary>
		public string Introduction { get ; }

		/// <summary>
		///     安装建筑附件所需的资金
		/// </summary>
		public long Money { get ; }

		/// <summary>
		///     安装建筑附件所需的时间（天）
		/// </summary>
		public int InstallTime { get ; }


		internal BuildingAccessory ( XElement element , BuildingGrade belongTo )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}
			if ( element . Name != nameof ( BuildingAccessory ) )
			{
				throw new ArgumentException ( $"{nameof ( element )} do not perform a {nameof ( BuildingAccessory )}" ,
											nameof ( element ) ) ;
			}
			if ( belongTo == null )
			{
				throw new ArgumentNullException ( nameof ( belongTo ) ) ;
			}

			BelongTo = belongTo ;
			try
			{
				Name = element . Attribute ( nameof ( Name ) ) . Value ;
				Introduction = element . Attribute ( nameof ( Introduction ) ) . Value ;
				Money = Convert . ToInt64 ( element . Attribute ( nameof ( Money ) ) . Value ) ;
				InstallTime = Convert . ToInt32 ( element . Attribute ( nameof ( InstallTime ) ) . Value ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( element )} has wrong data or lack of data" , e ) ;
			}
		}

	}

}
