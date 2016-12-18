using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

namespace WenceyWang . Richman4L . Players .Models
{

	public class PlayerModelProxy
	{

		private PlayerModel _model ;

		public string FileName { get ; set ; }

		public string Name { get ; set ; }

		public string Introduction { get ; set ; }

		public Uri Image { get ; set ; }

		public PlayerModel Model => _model ?? ( _model = new PlayerModel ( FileName ) ) ;


		public PlayerModelProxy ( XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}

			Name = element . Attribute ( nameof ( Name ) ) ? . Value ;
			FileName = element . Attribute ( nameof ( FileName ) ) ? . Value ;
			Image = new Uri ( element . Attribute ( nameof ( Image ) ) ? . Value ?? "" ) ;
		}

		private static List <PlayerModelProxy> _playerModels ;

		public static List <PlayerModelProxy> GetPlayerModels ( )
		{
			if ( null == _playerModels )
			{
				LoadPlayerModels ( ) ;
			}

			return _playerModels ;
		}

		[Startup ( nameof ( LoadPlayerModels ) )]
		public static void LoadPlayerModels ( )
		{
			_playerModels = new List <PlayerModelProxy> ( ) ;

			XDocument doc = ResourceHelper . LoadXmlDocument ( $"{nameof ( Players )}.{nameof ( Models )}.Resources.Index.xml" ) ;

			if ( doc . Root == null )
			{
				throw new NullReferenceException ( "Document file have no root" ) ;
			}

			foreach ( XElement item in doc . Root . Elements ( ) )
			{
				_playerModels . Add ( new PlayerModelProxy ( item ) ) ;
			}
		}

	}

}
