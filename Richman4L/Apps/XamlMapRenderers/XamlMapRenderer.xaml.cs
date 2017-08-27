using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Threading . Tasks ;

using Windows . Foundation ;
using Windows . UI . Xaml . Controls ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Apps . XamlMapRenderers . MapObjectRenderer ;
using WenceyWang . Richman4L . Apps . XamlMapRenderers . MapObjectRenderer . Roads ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Events ;
using WenceyWang . Richman4L . Maps . Roads ;

namespace WenceyWang . Richman4L . Apps . XamlMapRenderers
{

	public sealed partial class XamlMapRenderer : UserControl , IMapRenderer
	{

		public Size ObjectRendererSize { get ; set ; } = new Size ( 72 , 36 ) ;

		public static List <MapObjectRendererType> MapObjectRendererTypeList { get ; } =
			new List <MapObjectRendererType> ( ) ;

		private static object Locker { get ; } = new object ( ) ;

		private static bool IsLoaded { get ; set ; }

		public XamlMapRenderer ( ) { InitializeComponent ( ) ; }

		public Map Target { get ; private set ; }

		public void SetMap ( Map map )
		{
			if ( Target != null )
			{
				throw new InvalidOperationException ( $"this {nameof(XamlMapRenderer)} have {nameof(Target)} now." ) ;
			}

			Target = map ;
			Target . RegisMapRenderer ( this ) ;

			Height = ObjectRendererSize . Height * Target . Size . Height ;
			Width = ObjectRendererSize . Width * Target . Size . Width * 1.5 ;


			Target . AddMapObjectEvent += Map_AddMapObjectEvent ;
			Target . RemoveMapObjectEvent += Map_RemoveMapObjectEvent ;
		}

		public void RendererCatched ( )
		{
			List <MapObject> mapObjects = new List <MapObject> ( ) ;

			for ( int y = 0 ; y < Target . Size . Height ; y++ )
			{
				for ( int x = 0 ; x < Target . Size . Width ; x++ )
				{
					MapObject mapObject = Target [ x , y ] ;
					if ( mapObjects . Contains ( mapObject ) )
					{
					}
					else
					{
						Type rendererType =
							MapObjectRendererTypeList . FirstOrDefault ( renderer => renderer . TargetType == mapObject . GetType ( ) ) ? .
														EntryType ?? MapObjectRendererTypeList . FirstOrDefault ( renderer => renderer . TargetType .
																																		GetTypeInfo ( ) . IsAssignableFrom ( mapObject . GetType ( ) . GetTypeInfo ( ) ) ) ? .
																								EntryType ;
						MapObjectRenderer . MapObjectRenderer objectRenderer =
							( MapObjectRenderer . MapObjectRenderer ) Activator . CreateInstance ( rendererType ) ;
						objectRenderer . RenderTransform =
							objectRenderer . Size . TransformTo ( new Size ( ObjectRendererSize . Width * mapObject . Size . Width ,
																			ObjectRendererSize . Height * mapObject . Size . Height ) ) ;

						objectRenderer . Width = objectRenderer . Size . Width * mapObject . Size . Width ;
						objectRenderer . Height = objectRenderer . Size . Width * mapObject . Size . Height ;

						MainCanvas . Children . Add ( objectRenderer ) ;


						Canvas . SetLeft ( objectRenderer ,
											ObjectRendererSize . Width * 0.25 + mapObject . Position . X * ObjectRendererSize . Width
											+ ( Target . Size . Width - mapObject . Position . Y ) * ObjectRendererSize . Width * 0.5 ) ;
						Canvas . SetTop ( objectRenderer , mapObject . Position . Y * ObjectRendererSize . Height ) ;

						( ( IMapObjectRenderer ) objectRenderer ) . SetTarget ( mapObject ) ;
						( ( IMapObjectRenderer ) objectRenderer ) . StartUp ( ) ;

						objectRenderer . Show ( ) ;
						mapObjects . Add ( mapObject ) ;
					}
				}
			}
		}

		private void Map_RemoveMapObjectEvent ( object sender , MapRemoveMapObjectEventArgs e ) { }

		[Startup]
		public static void RegisDefultRenderer ( )
		{
			lock ( Locker )
			{
				if ( IsLoaded )
				{
					return ;
				}

				RegisMapObjectRenderer ( typeof ( NormalRoadRenderer ) , typeof ( NormalRoad ) ) ;
				RegisMapObjectRenderer ( typeof ( SmallAreaRenderer ) , typeof ( SmallArea ) ) ;

				RegisMapObjectRenderer ( typeof ( EmptyBlockRenderer ) , typeof ( EmptyBlock ) ) ;
				RegisMapObjectRenderer ( typeof ( NameShower ) , typeof ( MapObject ) ) ;

				IsLoaded = true ;
			}
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
				MapObjectRendererTypeList . Find ( typ => typ . EntryType == mapRendererType && typ . TargetType == targetType ) ;

			if ( type != null )
			{
				return type ;
			}

			type = new MapObjectRendererType ( mapRendererType , targetType ) ;
			MapObjectRendererTypeList . Add ( type ) ;
			MapObjectRendererTypeList . Sort ( ( x , y ) => y . TargetType . GetInheritanceDepth ( typeof ( MapObject ) )
															- x . TargetType . GetInheritanceDepth ( typeof ( MapObject ) ) ) ;

			return type ;
		}


		private void Map_AddMapObjectEvent ( object sender , MapAddMapObjectEventArgs e ) { }

	}

	public static class Startup
	{

		public static Task RunAllTask ( )
		{
			List <Task> tasks = new List <Task> ( ) ;
			foreach ( TypeInfo type in typeof ( XamlMapRenderer ) . GetTypeInfo ( ) . Assembly . DefinedTypes )
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
