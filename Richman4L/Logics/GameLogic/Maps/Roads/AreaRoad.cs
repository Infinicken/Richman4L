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
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Maps . Roads
{

	[MapObject ( nameof(AreaRoad) , nameof(AreaRoad) )]
	[Guid ( "6B4988D8-EBD5-471A-B22D-FFA94C997ECA" )]
	public class AreaRoad : NormalRoad
	{

		[ConsoleVisable]
		public BlockAzimuth AreaAzimuth => this . GetAzimuth ( Area ) ;

		public AreaRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				_areaId = ReadNecessaryValue <long> ( resource , nameof(Area) ) ;
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof(resource)} has wrong data or lack of data" , e ) ;
			}
		}

		public override void Stay ( Player player , MoveType moveType )
		{
			Area ? . Stay ( player ) ;
			base . Stay ( player , moveType ) ;
		}

		public override void Pass ( Player player , MoveType moveType )
		{
			Area ? . Pass ( player ) ;
			base . Pass ( player , moveType ) ;
		}

		#region Area

		private Area _area ;

		private long _areaId ;

		public Area Area
		{
			get => _area ?? ( _area = Map . Currnet . GetArea ( _areaId ) ) ;
			set
			{
				_areaId = value . Id ;
				_area = value ;
			}
		}

		#endregion

	}

}
