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
using System . Threading . Tasks;
using System . Xml . Linq;
using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . Maps . Buildings
{
	[Building]
	public class SmallSimpleBuilding : SmallBuilding
	{
		public long MoneyCostWhenCrossed { get; }


		public override bool EasyToDestroy => true;

		//Todo:完善价格机制
		public override long MaintenanceFee => Grade . MaintenanceFee;

		public override void Pass ( Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( $"{nameof ( SmallSimpleBuilding )} at ({X},{Y})" );
			}
			//Todo:加入对是否收费的判断
			if ( State == BuildingState . Working && player != Owner )
			{

			}
			base . Pass ( player );
		}

		public override void Stay ( Player player )
		{

			if ( player != Owner )
			{
				if ( player . IsFreeOfCharge ( ) )
				{

				}
				else
				{
					if ( Owner . IsBlockGetCharge ( ) )
					{

					}
					else
					{
						player . PayForCross ( Position , MoneyCostWhenCrossed );
						Owner . GetFromArea ( Position , player , MoneyCostWhenCrossed );
					}
				}
			}
			base . Stay ( player );
		}

		public override void Destoy ( DestroyReason reason )
		{
			State = BuildingState . Destroyed;

		}

		public override void StartDay ( Calendars . GameDate nextDate )
		{
			CheckDisposed ( ) ;

			if ( Game . Current . Weather . Wind . Strength >= 800 )
			{
				if ( Game . Current . Weather . Wind . Strength >= 950 )
				{
					if ( Game . Current . Weather . Wind . Strength - 950 >= GameRandom . Current . Next ( 51 ) )
					{
						Destoy ( DestroyReason . Weather );
					}
				}
			}
			switch ( State )
			{
				case BuildingState . Working:
					{
						Owner?.PayForMaintainBuilding ( this , MaintenanceFee );
						break;
					}
				case BuildingState . Closed:
					{
						break;
					}
				case BuildingState . Destroyed:
					{

						break;
					}
			}
		}

		public override void EndToday ( )
		{


		}

		public override string ToString ( )
		{
			return $"{nameof ( SmallSimpleBuilding )} in {Grade} at ({X},{Y})";
		}

		public SmallSimpleBuilding ( ) : base ( ) { }

	}
}
