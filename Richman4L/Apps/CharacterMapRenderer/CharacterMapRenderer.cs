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

using WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer ;
using WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer . Roads ;
using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Maps . Events;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer
{

	public class CharacterMapRenderer : IMapRenderer
	{

		public Map Target { get; private set; }

		public List<ICharacterMapObjectRenderer> MapObjectRendererList { get; set; } =
			new List<ICharacterMapObjectRenderer> ( );

		public char [ , ] CurrentView { get; private set; }

		public void SetMap ( [NotNull] Map map )
		{
			if ( map == null )
			{
				throw new ArgumentNullException ( nameof ( map ) );
			}

			Target = map;
			Target . RegisMapRenderer ( this );

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
			MapObjectRendererType rendererType =
					MapObjectRendererTypeList . FirstOrDefault ( typ => typ . TargetType == mapObject . GetType ( ) );
			if ( rendererType != null )
			{
				ICharacterMapObjectRenderer renderer =
					( ICharacterMapObjectRenderer ) Activator . CreateInstance ( rendererType . EntryType );
				renderer . SetTarget ( mapObject );
				MapObjectRendererList . Add ( renderer ) ;
				renderer . StartUp ( );
			}
			else
			{
				string text = mapObject . Type . Name . ToUpper ( ) + " No Renderer ";
				for ( int y = 0 ; y < mapObject . Size . Y ; y++ )
				{
					for ( int x = 0 ; x < mapObject . Size . X ; x++ )
					{
						CurrentView [ mapObject . X + x , mapObject . Y + y ] = text [ ( y * mapObject . Size . X + x ) % text . Length ];
					}
				}
			}
		}

		public void RendererCatched ( ) { }

		private void Map_AddMapObjectEvent ( object sender , MapAddMapObjectEventArgs e )
		{
			DrawObject ( e . NewObject );
			Update ( );
		}

		public void Update ( )
		{
			foreach ( ICharacterMapObjectRenderer renderer in MapObjectRendererList )
			{
				renderer . Update ( );
				for ( int y = 0 ; y < renderer . Target . Size . Y ; y++ )
				{
					for ( int x = 0 ; x < renderer . Target . Size . X ; x++ )
					{
						CurrentView [ renderer . Target . X + x , renderer . Target . Y + y ] = renderer . CurrentView [ x , y ];
					}
				}
			}

		}

		public static void LoadMapObjectRenderers ( )
		{
			RegisMapObjectRenderer ( typeof ( NormalRoadRenderer ) , typeof ( NormalRoad ) );
		}

		public static List<MapObjectRendererType> MapObjectRendererTypeList { get; set; } = new List<MapObjectRendererType> ( );

		public static MapObjectRendererType RegisMapObjectRenderer ( [NotNull] Type mapRendererType , [NotNull] Type targetType )
		{
			if ( mapRendererType == null )
			{
				throw new ArgumentNullException ( nameof ( mapRendererType ) );
			}
			if ( targetType == null )
			{
				throw new ArgumentNullException ( nameof ( targetType ) );
			}

			MapObjectRendererType type =
				MapObjectRendererTypeList . FirstOrDefault ( typ => typ . EntryType == mapRendererType && typ . TargetType == targetType );

			if ( type != null )
			{
				return type;
			}

			type = new MapObjectRendererType ( mapRendererType , targetType );
			MapObjectRendererTypeList . Add ( type );
			return type;
		}

	}

}
