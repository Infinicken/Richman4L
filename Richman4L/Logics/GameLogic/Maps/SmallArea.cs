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
using System . Collections . ObjectModel;
using System . Linq;
using System . Text;
using System . Xml . Linq;
using WenceyWang . Richman4L . Maps . Buildings;

namespace WenceyWang . Richman4L . Maps
{
	public class SmallArea : Area
	{
		public override MapSize Size => MapSize . Small ;

		public override int PondingDecrease => 100;

		public override long MoneyCostWhenCrossed { get; protected set; }

		public override double BuildingResistance { get; protected set; }

		public override long Price { get; protected set; }

		public SmallArea ( XElement resource ) : base ( resource )
		{

		}

		public override void EndToday ( )
		{
			throw new NotImplementedException ( );
		}

		

		private static ReadOnlyCollection<BuildingType> _availableBuilding;

		public override ReadOnlyCollection<BuildingType> AvailableBuildings
		{
			get
			{
				if ( Building == null )
				{
					return _availableBuilding ?? ( _availableBuilding = new ReadOnlyCollection<BuildingType> ( Building . BuildingTypes . Where ( ( type ) => type . Size == MapSize . Small ) . ToList ( ) ) );
				}
				else
				{
					return new ReadOnlyCollection<BuildingType> ( new List<BuildingType> ( ) );
				}
			}
		}


	}
}
