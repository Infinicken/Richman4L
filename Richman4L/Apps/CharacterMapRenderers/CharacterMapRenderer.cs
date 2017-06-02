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
using System . Reflection ;
using System . Threading . Tasks ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Apps . CharacterMapRenderers . MapObjectRenderer ;
using WenceyWang . Richman4L . Apps . CharacterMapRenderers . MapObjectRenderer . Roads ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Events ;
using WenceyWang . Richman4L . Maps . Roads ;

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers
{

	public class CharacterMapRenderer : IMapRenderer
	{

		public ConsoleSize MapUnit { get ; private set ; } = ConsoleSize . Small ;

		public List <ICharacterMapObjectRenderer> MapObjectRendererList { get ; set ; } =
			new List <ICharacterMapObjectRenderer> ( ) ;

		public int CharacterWeith { get ; private set ; }

		public int CharacterHeight { get ; private set ; }

		public ConsoleChar [ , ] CurrentView { get ; private set ; }

		public static List <MapObjectRendererType> MapObjectRendererTypeList { get ; set ; } =
			new List <MapObjectRendererType> ( ) ;

		public Map Target { get ; private set ; }

		public void SetMap ( [NotNull] Map map )
		{
			Target = map ?? throw new ArgumentNullException ( nameof(map) ) ;
			Target . RegisMapRenderer ( this ) ;
		}

		public void RendererCatched ( ) { }

		public void SetUnit ( ConsoleSize unit ) { MapUnit = unit ; }

		public void StartUp ( )
		{
			CharacterWeith = Target . Size . Width * MapUnit . Width ;
			CharacterHeight = Target . Size . Height * MapUnit . Height ;

			CurrentView = new ConsoleChar[ CharacterWeith , CharacterHeight ] ;

			for ( int y = 0 ; y < CharacterHeight ; y++ )
			{
				for ( int x = 0 ; x < CharacterWeith ; x++ )
				{
					CurrentView [ x , y ] = new ConsoleChar ( ' ' , ConsoleColor . White , ConsoleColor . DarkGreen ) ;
				}
			}

			Target . AddMapObjectEvent += Map_AddMapObjectEvent ;

			foreach ( MapObject mapObject in Target . Objects )
			{
				DrawObject ( mapObject ) ;
			}

			Update ( ) ;
		}

		public void Update ( )
		{
			foreach ( ICharacterMapObjectRenderer renderer in MapObjectRendererList )
			{
				renderer . Update ( ) ;
				for ( int y = 0 ; y < renderer . Target . Size . Height * MapUnit . Height ; y++ )
				{
					for ( int x = 0 ; x < renderer . Target . Size . Width * MapUnit . Width ; x++ )
					{
						CurrentView [
							renderer . Target . X * MapUnit . Width + x ,
							renderer . Target . Y * MapUnit . Height + y ] = renderer . CurrentView [ x , y ] ;
					}
				}
			}
		}

		private void DrawObject ( MapObject mapObject )
		{
			Type rendererType = MapObjectRendererTypeList . FirstOrDefault (
																renderer => renderer . TargetType ==
																			mapObject . GetType ( ) ) ? .
															EntryType ??
								MapObjectRendererTypeList . FirstOrDefault (
																renderer =>
																	renderer . TargetType . GetTypeInfo ( ) .
																				IsAssignableFrom (
																					mapObject . GetType ( ) .
																								GetTypeInfo ( ) ) ) ? .
															EntryType ;
			ICharacterMapObjectRenderer objectRenderer =
				( ICharacterMapObjectRenderer ) Activator . CreateInstance ( rendererType ) ;
			objectRenderer . SetTarget ( mapObject ) ;
			MapObjectRendererList . Add ( objectRenderer ) ;
			objectRenderer . SetUnit ( MapUnit ) ;
			objectRenderer . StartUp ( ) ;
		}

		private void Map_AddMapObjectEvent ( object sender , MapAddMapObjectEventArgs e )
		{
			DrawObject ( e . NewObject ) ;
			Update ( ) ;
		}

		[Startup]
		public static void LoadMapObjectRenderers ( )
		{
			RegisMapObjectRenderer ( typeof ( NormalRoadRenderer ) , typeof ( NormalRoad ) ) ;
			RegisMapObjectRenderer ( typeof ( AreaRoadRenderer ) , typeof ( AreaRoad ) ) ;
			RegisMapObjectRenderer ( typeof ( SmallAreaRenderer ) , typeof ( SmallArea ) ) ;
			RegisMapObjectRenderer ( typeof ( EmptyBlockRenderer ) , typeof ( EmptyBlock ) ) ;
			RegisMapObjectRenderer ( typeof ( NameShower ) , typeof ( MapObject ) ) ;
		}

		public static MapObjectRendererType RegisMapObjectRenderer ( [NotNull] Type mapRendererType ,
																	[NotNull] Type targetType )
		{
			if ( mapRendererType == null )
			{
				throw new ArgumentNullException ( nameof(mapRendererType) ) ;
			}
			if ( targetType == null )
			{
				throw new ArgumentNullException ( nameof(targetType) ) ;
			}

			MapObjectRendererType type =
				MapObjectRendererTypeList . FirstOrDefault (
					typ => typ . EntryType == mapRendererType && typ . TargetType == targetType ) ;

			if ( type != null )
			{
				return type ;
			}

			type = new MapObjectRendererType ( mapRendererType , targetType ) ;
			MapObjectRendererTypeList . Add ( type ) ;
			MapObjectRendererTypeList . Sort (
				( x , y ) =>
					y . TargetType . GetInheritanceDepth ( typeof ( MapObject ) ) -
					x . TargetType . GetInheritanceDepth ( typeof ( MapObject ) ) ) ;


			return type ;
		}

	}

	public static class Startup
	{

		public static Task RunAllTask ( )
		{
			List <Task> tasks = new List <Task> ( ) ;
			foreach ( TypeInfo type in
				typeof ( CharacterMapRenderer ) . GetTypeInfo ( ) . Assembly . DefinedTypes )
			{
				foreach ( MethodInfo method in type . DeclaredMethods )
				{
					if ( method . GetCustomAttributes ( typeof ( StartupAttribute ) ) . Any ( ) )
					{
						tasks . Add ( Task . Run ( ( ) => method . Invoke ( null , new object [ ] { } ) ) ) ;
					}
				}
			}

			return Task . WhenAll ( tasks ) ;
		}

	}

}
