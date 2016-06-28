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
using System . IO;
using System . Xml . Linq;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . Maps
{
	public class Map : GameObject
	{
		[NotNull]
		public static Map Currnet => Game . Current . Map;

		[NotNull]
		public string Name { get; set; }

		public MapSize Size { get; set; }

		[NotNull]
		[ItemNotNull]
		public List<MapObject> Objects { get; private set; }

		[NotNull]
		public Road GetRoad ( long id ) => ( Objects . Single ( ( road ) => ( ( road as Road )?.Id == id ) ) ) as Road;

		[NotNull]
		public Area GetArea ( long id ) => ( Objects . Single ( ( area ) => ( ( area as Area )?.Id == id ) ) ) as Area;

		public Map ( [NotNull] XDocument document ) : this ( )
		{
			if ( document == null )
			{
				throw new ArgumentNullException ( nameof ( document ) );
			}
			XElement ele = document . Root;
			if ( ele . Name != nameof ( Map ) )
			{
				throw new ArgumentException ( $"{nameof ( document )} do not perform a {nameof ( Map )}" );
			}
			try
			{
				Name = ele . Attribute ( nameof ( Name ) ) . Value;
				Size = new MapSize ( Convert . ToInt32 ( ele . Attribute ( "SizeX" ) . Value ) , Convert . ToInt32 ( ele . Attribute ( "SizeY" )?.Value ) );
				foreach ( XElement item in ele . Element ( "MapObjects" )?.Elements ( ) )
				{
					Objects . Add ( Activator . CreateInstance ( MapObject . MapObjectTypes . Single ( ( type ) => type . Name == item . Name ) . EntryType , item ) as MapObject );
				}
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"Can not parse {nameof ( document )}" , e );
			}
		}

		public Map ( [NotNull] Stream stream ) : this ( XDocument . Parse ( new StreamReader ( stream ) . ReadToEnd ( ) ) ) { }

		public Map ( ) : base ( )
		{
			Objects = new List<MapObject> ( );
			//todo
		}

		public Map ( [NotNull] string flieName ) : this ( ResourceHelper . LoadXmlDocument ( @"Maps.Resources." + flieName ) ) { }


		public override void EndToday ( )
		{
			throw new NotImplementedException ( );
		}

		public override void StartDay ( Calendars . GameDate nextDate )
		{
			throw new NotImplementedException ( );
		}

		/// <summary>
		/// 销毁这个Map
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose ( bool disposing )
		{
			if ( DisposedValue )
			{
				if ( disposing )
				{
					foreach ( MapObject item in Objects )
					{
						item . Dispose ( );
					}
					Objects . Clear ( );
				}
			}
			base . Dispose ( disposing );
		}

		[CanBeNull ]
		public event EventHandler AddMapObjectEvent ;


		public void RegisMapDrawer ( IMapDrawer mapDrawer )
		{

		}

	}

}