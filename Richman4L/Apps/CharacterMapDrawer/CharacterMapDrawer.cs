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
using System . Collections . Generic;
using System . Linq;

using WenceyWang . Richman4L . App . CharacterMapDrawer . MapObjectDrawer;
using WenceyWang . Richman4L . App . CharacterMapDrawer . MapObjectDrawer . Roads;
using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Maps . Events;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . CharacterMapDrawer
{

	public class CharacterMapDrawer : IMapDrawer
	{

		public Map Target { get; private set; }

		public List<ICharacterMapObjectDrawer> MapObjectDrawerList { get; set; } =
			new List<ICharacterMapObjectDrawer> ( );

		public char [ , ] CurrentView { get; private set; }

		public void SetMap ( [NotNull] Map map )
		{
			if ( map == null )
			{
				throw new ArgumentNullException ( nameof ( map ) );
			}

			Target = map;
			Target . RegisMapDrawer ( this );

			CurrentView = new char [ map . Size . X , map . Size . Y ];

			for ( int y = 0 ; y < map . Size . Y ; y++ )
			{
				for ( int x = 0 ; x < map . Size . X ; x++ )
				{
					CurrentView [ x , y ] = ' ';
				}
			}

			map . AddMapObjectEvent += Map_AddMapObjectEvent;

			StartUp ( );
		}

		public void StartUp ( )
		{
			foreach ( MapObject mapObject in Target . Objects )
			{
				DrawObject ( mapObject );
			}

			Update ( );
		}

		void DrawObject ( MapObject mapObject )
		{
			MapObjectDrawerType drawerType =
					MapObjectDrawerTypeList . FirstOrDefault ( typ => typ . TargetType == mapObject . GetType ( ) );
			if ( drawerType != null )
			{
				ICharacterMapObjectDrawer drawer =
					( ICharacterMapObjectDrawer ) Activator . CreateInstance ( drawerType . EntryType );
				drawer . SetTarget ( mapObject );
				MapObjectDrawerList . Add ( drawer ) ;
				drawer . StartUp ( );
			}
			else
			{
				string text = mapObject . Type . Name . ToUpper ( ) + " No Drawer ";
				for ( int y = 0 ; y < mapObject . Size . Y ; y++ )
				{
					for ( int x = 0 ; x < mapObject . Size . X ; x++ )
					{
						CurrentView [ mapObject . X + x , mapObject . Y + y ] = text [ ( y * mapObject . Size . X + x ) % text . Length ];
					}
				}
			}
		}

		public void DrawerCatched ( ) { }

		private void Map_AddMapObjectEvent ( object sender , MapAddMapObjectEventArgs e )
		{
			DrawObject ( e . NewObject );
			Update ( );
		}

		public void Update ( )
		{
			foreach ( ICharacterMapObjectDrawer drawer in MapObjectDrawerList )
			{
				drawer . Update ( );
				for ( int y = 0 ; y < drawer . Target . Size . Y ; y++ )
				{
					for ( int x = 0 ; x < drawer . Target . Size . X ; x++ )
					{
						CurrentView [ drawer . Target . X + x , drawer . Target . Y + y ] = drawer . CurrentView [ x , y ];
					}
				}
			}

		}

		public static void LoadMapObjectDrawers ( )
		{
			RegisMapObjectDrawer ( typeof ( NormalRoadDrawer ) , typeof ( NormalRoad ) );
		}

		public static List<MapObjectDrawerType> MapObjectDrawerTypeList { get; set; } = new List<MapObjectDrawerType> ( );

		public static MapObjectDrawerType RegisMapObjectDrawer ( [NotNull] Type mapDrawerType , [NotNull] Type targetType )
		{
			if ( mapDrawerType == null )
			{
				throw new ArgumentNullException ( nameof ( mapDrawerType ) );
			}
			if ( targetType == null )
			{
				throw new ArgumentNullException ( nameof ( targetType ) );
			}

			MapObjectDrawerType type =
				MapObjectDrawerTypeList . FirstOrDefault ( typ => typ . EntryType == mapDrawerType && typ . TargetType == targetType );

			if ( type != null )
			{
				return type;
			}

			type = new MapObjectDrawerType ( mapDrawerType , targetType );
			MapObjectDrawerTypeList . Add ( type );
			return type;
		}

	}

}
