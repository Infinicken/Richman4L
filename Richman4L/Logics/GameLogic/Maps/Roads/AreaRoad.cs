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
using System . Xml . Linq;
using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . Maps . Roads
{
	[MapObject]
	public class AreaRoad : NormalRoad
	{
		private long _areaId;

		private Area _area;

		public Area Area
		{
			get
			{
				return _area ?? ( _area = Map . Currnet . GetArea ( _areaId ) );

			}
			set
			{
				_areaId = value . Id;
				_area = value;
			}
		}

		public override void Stay ( Player player , MoveType moveType )
		{
			Area?.Stay ( player );
			base . Stay ( player , moveType );
		}

		public override void Pass ( Player player , MoveType moveType )
		{
			Area?.Pass ( player );
			base . Pass ( player , moveType );
		}
		public AreaRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				_areaId = Convert . ToInt64 ( resource . Attribute ( nameof ( Area ) ) . Value );
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e );
			}
		}
	}
}
