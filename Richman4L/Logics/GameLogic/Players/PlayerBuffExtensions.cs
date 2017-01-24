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
using System . Collections;
using System . Linq;

namespace WenceyWang . Richman4L . Players
{

	public static class PlayerBuffExtensions
	{

		public static bool IsBlockBuyArea ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			return player . Buffs . Any ( item => item . BlockBuyArea );
		}

		public static bool IsBlockBuyStock ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			return player . Buffs . Any ( item => item . BlockBuyStock );
		}


		public static bool IsBlockGetCharge ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			return player . Buffs . Any ( item => item . BlockGetCharge );
		}



		public static bool IsBlockMoving ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			return player . Buffs . Any ( item => item . BlockMoving );
		}

		public static bool IsBlockSellStock ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			return player . Buffs . Any ( item => item . BlockSellStock );
		}

		public static bool IsFreeOfCharge ( this Player player )
		{
			if ( player == null )
			{
				throw new ArgumentNullException ( nameof ( player ) );
			}

			return player . Buffs . Any ( item => item . FreeOfCharge );
		}

	}

}
