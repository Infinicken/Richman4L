using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Maps . Events ;
using WenceyWang . Richman4L . Maps . Roads ;

namespace WenceyWang . Richman4L . Maps
{

	public class Map : GameObject
	{

		/// <summary>
		///     This prop should always return Game.Current.Map
		/// </summary>
		[NotNull]
		public static Map Currnet => Game . Current . Map ;

		[NotNull]
		[Own]
		public string Name { get ; set ; }

		[Own]
		public Guid MapGuid { get ; }

		[Own]
		public MapSize Size { get ; set ; }

		[NotNull]
		[ItemNotNull]
		[Own]
		public List <MapObject> Objects { get ; } = new List <MapObject> ( ) ;

		[NotNull]
		[ItemNotNull]
		[Own]
		public List <WinningCondition> AviliableWinningConditions { get ; } = new List <WinningCondition> ( ) ;

		[Reference]
		public List <Road> StartPoints { get ; set ; } = new List <Road> ( ) ;


		[CanBeNull]
		public Block this [ int x , int y ]
		{
			get
			{
				return ( Block ) Objects . SingleOrDefault ( mapobject => mapobject is Block
																		&& ( mapobject . Position . X == x || mapobject . Position . X < x
																			&& mapobject . Position . X + mapobject . Size . Width - 1 >= x )
																		&& ( mapobject . Position . Y == y || mapobject . Position . Y < y
																			&& mapobject . Position . Y + mapobject . Size . Height - 1 >= y ) ) ;
			}
		}

		public List <Block> Blocks
			=> Objects . TakeWhile ( mapobject => mapobject is Block ) . Cast <Block> ( ) . ToList ( ) ;

		/// <summary>
		///     地图的排水基数
		/// </summary>
		[Own]
		public int PondingDecreaseBase { get ; }

		/// <summary>
		///     Create A map from Xml document
		/// </summary>
		/// <param name="document"></param>
		public Map ( [NotNull] XDocument document ) : this ( )
		{
			if ( document == null )
			{
				throw new ArgumentNullException ( nameof(document) ) ;
			}

			try
			{
				XElement mapSource = document . Root ;

				if ( mapSource . Name != nameof(Map) )
				{
					throw new ArgumentException ( $"{nameof(document)} do not perform a {nameof(Map)}" ) ;
				}

				Name = ReadNecessaryValue <string> ( mapSource , nameof(Name) ) ;
				Size = ReadNecessaryValue <MapSize> ( mapSource , nameof(Size) ) ;
				MapGuid = ReadNecessaryValue <Guid> ( mapSource , nameof(Guid) ) ;
				PondingDecreaseBase = ReadNecessaryValue <int> ( mapSource , nameof(PondingDecreaseBase) ) ;

				List <XElement> typeMapSource = mapSource . Element ( "MapObjectTypes" ) . Elements ( ) . ToList ( ) ;

				Dictionary <string , Type> typeMapResult = new Dictionary <string , Type> ( typeMapSource . Count ) ;

				foreach ( XElement element in typeMapSource )
				{
					string name = ReadNecessaryValue <string> ( element , nameof(Name) ) ;
					Guid guid = ReadNecessaryValue <Guid> ( element , nameof(Guid) ) ;

					typeMapResult . Add ( name , MapObject . TypeList . Single ( type => type . Guid == guid ) . EntryType ) ;
				}

				foreach ( XElement mapObjectSource in mapSource . Element ( nameof(Objects) ) . Elements ( ) )
				{
					Objects . Add ( Activator . CreateInstance ( typeMapResult [ mapObjectSource . Name . LocalName ] ,
																mapObjectSource ) as MapObject ) ;
				}
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"Can not parse {nameof(document)}" , e ) ;
			}

			for ( int y = 0 ; y < Size . Height ; y++ )
			{
				for ( int x = 0 ; x < Size . Width ; x++ )
				{
					if ( this [ x , y ] == null )
					{
						Objects . Add ( new EmptyBlock ( new MapPosition ( x , y ) ) ) ;
					}
				}
			}

			Objects . Sort ( ( x , y ) => ( int ) ( x . Position . ContorId - y . Position . ContorId ) ) ;
		}

		public Map ( ) { }

		public Map ( [NotNull] string flieName ) : this ( ResourceHelper . LoadXmlDocument ( @"Maps.Resources." + flieName ) )
		{
		}


		[CanBeNull]
		public Road GetRoad ( long id )
		{
			return Objects . SingleOrDefault ( road => ( road as Road ) ? . Id == id ) as Road ;
		}

		[CanBeNull]
		public Area GetArea ( long id )
		{
			return Objects . SingleOrDefault ( area => ( area as Area ) ? . Id == id ) as Area ;
		}


		public override void EndToday ( )
		{
			foreach ( Block block in Blocks )
			{
				block . EndToday ( ) ;
			}
		}

		public override void StartDay ( GameDate thisDate )
		{
			//todo:Finish ch

			foreach ( Block block in Blocks )
			{
				block . StartDay ( thisDate ) ;
			}
		}

		[CanBeNull]
		public event EventHandler <MapAddMapObjectEventArgs> AddMapObjectEvent ;

		[CanBeNull]
		public event EventHandler <MapRemoveMapObjectEventArgs> RemoveMapObjectEvent ;

		public void RegisMapRenderer ( [NotNull] IMapRenderer mapRenderer ) { }

	}

}
