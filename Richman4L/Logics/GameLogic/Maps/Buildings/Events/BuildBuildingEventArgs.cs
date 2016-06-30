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

using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . Maps . Buildings . Events
{
	public class BuildBuildingEventArgs : BuildingEventArgs
	{
		public Building Building { get; }

		public Area Position { get; }

		public BuildingType Type { get; }

		public Player Player { get; }

		public BuildBuildingEventArgs ( Building building , Area position , BuildingType buildingType , Player player )
		{
			#region Chenck Argument

			if ( building == null )
			{
				throw new ArgumentNullException ( nameof ( building ) );
			}
			if ( position == null )
			{
				throw new ArgumentNullException ( nameof ( position ) );
			}
			if ( buildingType == null )
			{
				throw new ArgumentNullException ( nameof ( buildingType ) );
			}
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			#endregion

			Building = building;
			Position = position;
			Type = buildingType;
			Player = player;
		}

	}
}
