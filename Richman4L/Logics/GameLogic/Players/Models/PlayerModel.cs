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
using System . Xml . Linq ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Players . Models
{

	public class PlayerModel : MapObject
	{

		public string Name { get ; set ; }

		public string Introduction { get ; set ; }

		public Uri Model { get ; set ; }

		public DateTime BirthDay { get ; set ; }

		public List <PlayerSaying> SayingWhenGained { get ; } = new List <PlayerSaying> ( ) ;

		public List <PlayerSaying> SayingWhenHarmed { get ; } = new List <PlayerSaying> ( ) ;


		public List <PlayerSaying> SayingWhenMeet { get ; } = new List <PlayerSaying> ( ) ;

		public override MapSize Size => MapSize . Small ;

		public PlayerModel ( XElement saving ) : base ( saving ) { }

		public PlayerModel ( string fileName )
		{
			if ( null == fileName )
			{
				throw new ArgumentNullException ( nameof(fileName) ) ;
			}

			XDocument doc = ResourceHelper . LoadXmlDocument ( $"{nameof(Player)}. {nameof(Model)}.Resources." + fileName ) ;


			XElement modelNode = doc . Root ;

			Name = modelNode . Attribute ( nameof(Name) ) . Value ;

			Introduction = modelNode . Attribute ( nameof(Introduction) ) . Value ;

			Model = new Uri ( modelNode . Attribute ( nameof(Model) ) . Value ?? "" ) ;

			IEnumerable <PlayerSaying> tempSayingWhenGained =
				from p in modelNode . Element ( nameof(SayingWhenGained) ) . Elements ( )
				select new PlayerSaying ( p ) ;
			SayingWhenGained . AddRange ( tempSayingWhenGained ) ;

			IEnumerable <PlayerSaying> tempSayingWhenHarmed =
				from p in modelNode . Element ( nameof(SayingWhenGained) ) . Elements ( )
				select new PlayerSaying
					( p ) ;

			SayingWhenHarmed . AddRange ( tempSayingWhenHarmed ) ;

			IEnumerable <PlayerSaying> tempSayingWhenMeet =
				from p in modelNode . Element ( nameof(SayingWhenMeet) ) . Elements ( )
				select new PlayerSaying ( p ) ;
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

		public override void StartDay ( GameDate thisDate ) { }

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

	}

}
