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

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L . Maps .Buildings
{

	[ Building ]
	public class MediumSimpleBuilding : MediumBuilding
	{

		public override bool EasyToDestroy { get ; }

		public override long MaintenanceFee { get ; }

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

		public override void StartDay ( GameDate nextDate ) { throw new NotImplementedException ( ) ; }

		public override void Destoy ( DestroyReason reason ) { throw new NotImplementedException ( ) ; }

	}

}
