using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

namespace WenceyWang . Richman4L . Logics . Players . Models
{

	//Todo:Totally over write

	public class PlayerModel
	{

		[Own]
		public List <Character> Characters { get ; set ; }


		[Own]
		public string Name { get ; set ; }

		[Own]
		public string Introduction { get ; set ; }

		[Own]
		public DateTime BirthDay { get ; set ; }

		[Own]
		public List <PlayerSaying> SayingWhenGained { get ; } = new List <PlayerSaying> ( ) ;

		[Own]
		public List <PlayerSaying> SayingWhenHarmed { get ; } = new List <PlayerSaying> ( ) ;

		[Own]
		public GameValue LuckyDegree { get ; }

		[Own]
		public GameValue Resistance { get ; }

		[Own]
		public List <PlayerSaying> SayingWhenMeet { get ; } = new List <PlayerSaying> ( ) ;


		public PlayerModel ( string fileName )
		{
			if ( null == fileName )
			{
				throw new ArgumentNullException ( nameof(fileName) ) ;
			}


			XDocument doc = ResourceHelper . LoadXmlDocument ( $"{nameof(Player)}.Model.Resources." + fileName ) ;


			XElement modelNode = doc . Root ;

			Name = GameObject . ReadNecessaryValue <string> ( modelNode , nameof(Name) ) ;

			Introduction = GameObject . ReadNecessaryValue <string> ( modelNode , nameof(Introduction) ) ;

			IEnumerable <PlayerSaying> tempSayingWhenGained =
				modelNode . Element ( nameof(SayingWhenGained) ) . Elements ( ) . Select ( p => new PlayerSaying ( p ) ) ;
			SayingWhenGained . AddRange ( tempSayingWhenGained ) ;

			IEnumerable <PlayerSaying> tempSayingWhenHarmed =
				modelNode . Element ( nameof(SayingWhenGained) ) . Elements ( ) . Select ( p => new PlayerSaying ( p ) ) ;

			SayingWhenHarmed . AddRange ( tempSayingWhenHarmed ) ;

			IEnumerable <PlayerSaying> tempSayingWhenMeet =
				modelNode . Element ( nameof(SayingWhenMeet) ) . Elements ( ) . Select ( p => new PlayerSaying ( p ) ) ;
			SayingWhenMeet . AddRange ( tempSayingWhenMeet ) ;
		}

		public PlayerSaying GetSayingWhenGained ( PlayerModel harmed )
		{
			while ( true )
			{
				List <PlayerSaying> temp =
					new List <PlayerSaying> ( SayingWhenGained . Where ( saying => saying . Player == harmed ? . Name ) ) ;

				if ( temp . Count != 0 )
				{
					return temp [ GameRandom . Current . Next ( 0 , temp . Count ) ] ;
				}

				harmed = null ;
			}
		}

		public PlayerSaying GetSayingWhenHarmed ( PlayerModel gained )
		{
			while ( true )
			{
				List <PlayerSaying> temp =
					new List <PlayerSaying> ( SayingWhenHarmed . Where ( saying => saying . Player == gained ? . Name ) ) ;

				if ( temp . Count != 0 )
				{
					return temp [ GameRandom . Current . Next ( 0 , temp . Count ) ] ;
				}

				gained = null ;
			}
		}

		public PlayerSaying GetSayingWhenMeet ( PlayerModel player )
		{
			while ( true )
			{
				List <PlayerSaying> temp =
					new List <PlayerSaying> ( SayingWhenMeet . Where ( saying => saying . Player == player ? . Name ) ) ;

				if ( temp . Count != 0 )
				{
					return temp [ GameRandom . Current . Next ( 0 , temp . Count ) ] ;
				}

				if ( player == null )
				{
					throw new InvalidOperationException ( $"{nameof(PlayerModel)} have no saying " ) ;
				}

				player = null ;
			}
		}

	}

	public class Character
	{

	}

}
