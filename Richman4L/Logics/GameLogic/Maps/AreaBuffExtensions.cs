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
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps
{

	public static class AreaBuffExtensions
	{

		public static bool IsBlockBuild ( this Area area )
		{
			if ( area == null )
			{
				throw new ArgumentNullException ( nameof(area) ) ;
			}

			return area . Buffs . Any ( item => item . BlockBuild ) ;
		}

		public static bool IsBlockBuy ( this Area area )
		{
			if ( area == null )
			{
				throw new ArgumentNullException ( nameof(area) ) ;
			}

			return area . Buffs . Any ( item => item . BlockBuy ) ;
		}

		public static bool IsBlockCharge ( this Area area )
		{
			if ( area == null )
			{
				throw new ArgumentNullException ( nameof(area) ) ;
			}

			return area . Buffs . Any ( item => item . BlockCharge ) ;
		}

	}

}
