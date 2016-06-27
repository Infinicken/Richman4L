/*
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
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . Maps
{
	[MapObject]
	public class CardStore : NormalRoad
	{


		public override void Stay ( Player player , MoveType moveType )
		{
			//Todo:MakeEnviromentBuyCard
			List<Cards . CardType> cardCanBuy = new List<Cards . CardType> ( );


			base . Stay ( player , moveType );

		}

		protected override void Dispose ( bool disposing )
		{
			base . Dispose ( disposing );
		}

		public CardStore ( XElement resource ) : base ( resource )
		{

		}
	}
}
