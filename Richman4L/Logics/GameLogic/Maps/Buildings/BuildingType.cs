﻿/*
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
using System . Collections . Generic;
using System . Collections . ObjectModel;
using System . Linq;
using System . Text;
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Maps . Buildings
{
	/// <summary>
	/// 指示建筑类型
	/// </summary>
	public sealed class BuildingType
	{
		/// <summary>
		/// 建筑类型的名称
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// 建筑类型的简介
		/// </summary>
		public string Introduction { get; }

		/// <summary>
		/// 建筑的尺寸
		/// </summary>
		public MapSize Size { get; }

		/// <summary>
		/// 建筑的入口类型
		/// </summary>
		public Type EntryType { get; }

		/// <summary>
		/// 建筑的初始等级
		/// </summary>
		public BuildingGrade EntryGrade { get; }

		/// <summary>
		/// 建筑的等级
		/// </summary>
		public ReadOnlyCollection<BuildingGrade> Grades { get; }

		public override string ToString ( ) => $"{Name} sized {Size}";

		internal BuildingType ( Type entryType , XElement element )
		{

			EntryType = entryType;

			#region Load XML
			try
			{
				Name = element . Attribute ( nameof ( Name ) ) . Value;
				Introduction = element . Attribute ( nameof ( Introduction ) ) . Value;
				Size = new MapSize ( Convert . ToInt32 ( element . Attribute ( nameof ( Size ) + nameof ( MapSize . X ) ) . Value ) , Convert . ToInt32 ( element . Attribute ( nameof ( Size ) + nameof ( MapSize . Y ) ) . Value ) );
				List<BuildingGrade> grades = new List<BuildingGrade> ( );
				Grades = new ReadOnlyCollection<BuildingGrade> ( grades );
				foreach ( XElement grade in element . Element ( nameof ( Grades ) ) . Elements ( ) )
				{
					grades . Add ( new BuildingGrade ( grade , this ) );
				}
				EntryGrade = Grades . Single ( ( grade ) => grade . Id == 1 );
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( element )} has wrong data or lack of data" , e );
			}

			#endregion
		}
	}
}
