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
using System . Linq;
using System . Xml . Linq;
using System . Text;
using WenceyWang . Richman4L . Maps . Roads;

namespace WenceyWang . Richman4L . Maps
{
	[MapObject]
	public class Hospital : ReturnRoad
	{
		public static Hospital Current { get; set; }

		protected override void Dispose ( bool disposing )
		{
			Current = null;
			base . Dispose ( disposing );
		}

		public Hospital ( XElement resource ) : base ( resource )
		{
			Current = this;
		}

	}
}
