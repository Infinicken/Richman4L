﻿/*
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
using System . Xml . Linq ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Maps . Events ;
using WenceyWang . Richman4L . Maps . Roads ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L .Maps
{

	public class Map : GameObject
	{

		/// <summary>
		///     This prop should always return Game.Current.Map
		/// </summary>
		[NotNull]
		public static Map Currnet { get ; set ; }

		public Guid Guid { get ; private set ; }

		[NotNull]
		public string Name { get ; set ; }

		public MapSize Size { get ; set ; }

		[NotNull]
		[ItemNotNull]
		[ConsoleVisable]
		public List <MapObject> Objects { get ; } = new List <MapObject> ( ) ;

		[NotNull]
		[ItemNotNull]
		public List <WinningCondition> AviliableWinningConditions { get ; } = new List <WinningCondition> ( ) ;

		public List <Road> StartPoints { get ; set ; }


		[CanBeNull]
		public Block this [ int x , int y ]
		{
			get
			{
				return
					( Block ) Objects . FirstOrDefault ( mapobject => mapobject is Block &&
																	( mapobject . X == x ||
																	mapobject . X < x && mapobject . X + mapobject . Size . Width - 1 >= x ) &&
																	( mapobject . Y == y ||
																	mapobject . Y < y && mapobject . Y + mapobject . Size . Height - 1 >= y ) ) ;
			}
		}

		/// <summary>
		///     地图的排水基数
		/// </summary>
		[ConsoleVisable]
		public int PondingDecreaseBase { get ; }

		public Map ( [NotNull] XDocument document ) : this ( )
		{
			if ( document == null )
			{
				throw new ArgumentNullException ( nameof ( document ) ) ;
			}

			XElement ele = document . Root ;
			if ( ele . Name != nameof ( Map ) )
			{
				throw new ArgumentException ( $"{nameof ( document )} do not perform a {nameof ( Map )}" ) ;
			}

			try
			{
				Name = ele . Attribute ( nameof ( Name ) ) . Value ;
				Size = new MapSize ( Convert . ToInt32 ( ele . Attribute ( "SizeX" ) . Value ) ,
									Convert . ToInt32 ( ele . Attribute ( "SizeY" ) . Value ) ) ;
				Guid = Guid . Parse ( ele . Attribute ( nameof ( Guid ) ) . Value ) ;
				foreach ( XElement item in ele . Element ( nameof ( Objects ) ) ? . Elements ( ) )
				{
					Objects . Add (
						Activator . CreateInstance (
							MapObject . MapObjectTypes . Single ( type => type . Name == item . Name ) . EntryType ,
							item ) as MapObject ) ;
				}
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"Can not parse {nameof ( document )}" , e ) ;
			}

			for ( int y = 0 ; y < Size . Height ; y++ )
			{
				for ( int x = 0 ; x < Size . Width ; x++ )
				{
					if ( this [ x , y ] == null )
					{
						Objects . Add ( new EmptyBlock ( x , y ) ) ;
					}
				}
			}
		}

		public Map ( )
		{
			//todo:the line under is a test code, Current should return Game.Current.Map or something else.
			Currnet = this ;

			//todo
		}

		public Map ( [NotNull] string flieName )
			: this ( ResourceHelper . LoadXmlDocument ( @"Maps.Resources." + flieName ) ) { }

		public static long Transform ( int x , int y ) { return ( x + y ) * ( x + y + 1 ) / 2 + y ; }

		[CanBeNull]
		public Road GetRoad ( long id ) => Objects . SingleOrDefault ( road => ( road as Road ) ? . Id == id ) as Road ;

		[CanBeNull]
		public Area GetArea ( long id ) => Objects . SingleOrDefault ( area => ( area as Area ) ? . Id == id ) as Area ;


		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

		public override void StartDay ( GameDate thisDate ) { throw new NotImplementedException ( ) ; }

		[CanBeNull]
		public event EventHandler <MapAddMapObjectEventArgs> AddMapObjectEvent ;

		[CanBeNull]
		public event EventHandler <MapRemoveMapObjectEventArgs> RemoveMapObjectEvent ;

		public void RegisMapRenderer ( [NotNull] IMapRenderer mapRenderer ) { }

	}

}
