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

namespace WenceyWang . Richman4L . Maps . Roads
{

	[MapObject ( nameof(NormalRoad) , nameof(NormalRoad) )]
	[Guid ( "C4D64F21-315F-4E82-A8A2-DF0F1B2603CE" )]
	public class NormalRoad : Road
	{

		public NormalRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				XElement entrances = resource . Element ( nameof(Entrances) ) ;

				foreach ( XElement road in entrances . Elements ( ) )
				{
					_entrancesId . Add ( ReadNecessaryValue <long> ( road , nameof(Id) ) ) ;
				}

				XElement exits = resource . Element ( nameof(Exits) ) ;

				foreach ( XElement road in exits . Elements ( ) )
				{
					_exitsId . Add ( ReadNecessaryValue <long> ( road , nameof(Id) ) ) ;
				}
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof(resource)} has wrong data or lack of data" , e ) ;
			}
		}


		public override Path Route ( Road previous , int moveCount , Path result = null )
		{
			if ( previous == null )
			{
				throw new ArgumentNullException ( nameof(previous) ) ;
			}
			if ( ! CanEnterFrom ( previous ) )
			{
				throw new ArgumentException ( $"无法通过{nameof(previous)}进入此道路" , nameof(previous) ) ;
			}
			if ( moveCount < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof(moveCount) ) ;
			}
			if ( ! Exits . Any ( ) )
			{
				throw new InvalidOperationException ( "没有可用的出口" ) ;
			}

			Path current = result ?? new Path ( ) ;
			current . AddRoute ( this ) ;
			if ( BlockMoving || moveCount == 0 )
			{
				return current ;
			}

			List <Road> exits = Exits . Where ( road => road != previous ) . ToList ( ) ;
			if ( exits . Count == 0 )
			{
				return previous . Route ( this , moveCount - 1 , result ) ;
			}

			return exits . RandomItem ( ) . Route ( this , moveCount - 1 , result ) ;
		}

		public override bool CanEnterFrom ( Road road ) { return Entrances . Contains ( road ) ; }

		#region Entrances

		private List <Road> _entrances ;

		private readonly List <long> _entrancesId = new List <long> ( ) ;

		public virtual List <Road> Entrances
		{
			get
			{
				if ( _entrances == null &&
					_entrancesId == null )
				{
					return null ;
				}

				return _entrances ??
						( _entrances = _entrancesId . Select ( roadId => Map . Currnet . GetRoad ( roadId ) ) . ToList ( ) ) ;
			}
		}

		#endregion

		#region Console Attribute

		[ConsoleVisable]
		public bool UpEntrance => Entrances . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Up ) ;

		[ConsoleVisable]
		public bool DownEntrance => Entrances . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Down ) ;

		[ConsoleVisable]
		public bool LeftEntrance => Entrances . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Left ) ;

		[ConsoleVisable]
		public bool RightEntrance => Entrances . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Right ) ;

		[ConsoleVisable]
		public bool UpExit => Exits . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Up ) ;

		[ConsoleVisable]
		public bool DownExit => Exits . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Down ) ;

		[ConsoleVisable]
		public bool LeftExit => Exits . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Left ) ;

		[ConsoleVisable]
		public bool RightExit => Exits . Any ( road => this . GetAzimuth ( road ) == BlockAzimuth . Right ) ;

		#endregion

		#region Exits

		private List <Road> _exits ;

		private readonly List <long> _exitsId = new List <long> ( ) ;

		public virtual List <Road> Exits
		{
			get
			{
				if ( _exits == null &&
					_exitsId == null )
				{
					return null ;
				}

				return _exits ?? ( _exits = _exitsId . Select ( roadId => Map . Currnet . GetRoad ( roadId ) ) . ToList ( ) ) ;
			}
		}

		#endregion

	}

}
