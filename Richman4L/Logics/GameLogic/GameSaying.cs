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

namespace WenceyWang . Richman4L
{

	//Todo:Add Custom Saying?
	public class GameSaying : IEquatable <GameSaying>
	{

		public string Content { get ; }

		public string People { get ; }

		public string Book { get ; }

		public Guid Guid { get ; }

		public string Author { get ; }

		public string Song { get ; }

		public int ContentLenth => Content . Length ;

		public int ActualLength
			=>
				Content . Length + ( People ? . Length ?? 0 ) + ( Book ? . Length ?? 0 ) + ( Author ? . Length ?? 0 ) +
				( Song ? . Length ?? 0 ) ;

		internal static List <GameSaying> Sayings { get ; set ; }

		private static bool Loaded { get ; set ; }

		private static object Locker { get ; } = new object ( ) ;

		private GameSaying ( XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}
			if ( element . Name != nameof(GameSaying) )
			{
				throw new ArgumentException ( string . Format ( "{0} do not perform a {1}" ,
																nameof(element) ,
																nameof(GameSaying) ) ) ;
			}

			Content = element . Attribute ( nameof(Content) ) ? . Value ;
			People = element . Attribute ( nameof(People) ) ? . Value ;
			Book = element . Attribute ( nameof(Book) ) ? . Value ;
			Author = element . Attribute ( nameof(Author) ) ? . Value ;
			Song = element . Attribute ( nameof(Song) ) ? . Value ;
#if DEBUG
			if ( element . Attribute ( nameof(Guid) ) ? . Value == null )
			{
				Guid = Guid . NewGuid ( ) ;
			}
			else
			{
#endif
				Guid = Guid . Parse ( element . Attribute ( nameof(Guid) ) ? . Value ) ;
#if DEBUG
			}
#endif
		}

		public bool Equals ( GameSaying other )
		{
			if ( ReferenceEquals ( null , other ) )
			{
				return false ;
			}
			if ( ReferenceEquals ( this , other ) )
			{
				return true ;
			}

			return string . Equals ( Content , other . Content ) && string . Equals ( People , other . People ) &&
					string . Equals ( Book , other . Book ) && Guid . Equals ( other . Guid ) &&
					string . Equals ( Author , other . Author ) && string . Equals ( Song , other . Song ) ;
		}

		public override string ToString ( ) { return Content ; }

		public XElement ToXElement ( )
		{
			XElement result = new XElement ( nameof(GameSaying) ) ;

			result . SetAttributeValue ( nameof(Content) , Content ) ;
			result . SetAttributeValue ( nameof(People) , People ) ;
			result . SetAttributeValue ( nameof(Book) , Book ) ;
			result . SetAttributeValue ( nameof(Author) , Author ) ;
			result . SetAttributeValue ( nameof(Song) , Song ) ;
			result . SetAttributeValue ( nameof(Guid) , Guid . ToString ( ) ) ;

			return result ;
		}

		public static GameSaying GetSaying ( Guid guid )
		{
			if ( ! Loaded )
			{
				LoadSayings ( ) ;
			}
			return Sayings . FirstOrDefault ( saying => saying . Guid == guid ) ;
		}

		public static GameSaying GetSaying ( )
		{
			if ( ! Loaded )
			{
				LoadSayings ( ) ;
			}
			return Sayings . RandomItem ( GameRandom . Current ) ;
		}

		public static void RegisSaying ( GameSaying newSaying )
		{
			lock ( Locker )
			{
				if ( newSaying == null )
				{
					throw new ArgumentNullException ( nameof(newSaying) ) ;
				}

				if ( Sayings . Contains ( newSaying ) )
				{
					return ;
				}

				if ( Sayings . Any ( saying => newSaying . Guid == saying . Guid ) )
				{
					throw new ArgumentException ( $"{nameof(newSaying)} have same {nameof(Guid)} with others" ,
												nameof(newSaying) ) ;
				}

				Sayings . Add ( newSaying ) ;
			}
		}

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) )
			{
				return false ;
			}
			if ( ReferenceEquals ( this , obj ) )
			{
				return true ;
			}
			if ( obj . GetType ( ) != GetType ( ) )
			{
				return false ;
			}

			return Equals ( ( GameSaying ) obj ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				int hashCode = Content ? . GetHashCode ( ) ?? 0 ;
				hashCode = ( hashCode * 397 ) ^ ( People ? . GetHashCode ( ) ?? 0 ) ;
				hashCode = ( hashCode * 397 ) ^ ( Book ? . GetHashCode ( ) ?? 0 ) ;
				hashCode = ( hashCode * 397 ) ^ Guid . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ ( Author ? . GetHashCode ( ) ?? 0 ) ;
				hashCode = ( hashCode * 397 ) ^ ( Song ? . GetHashCode ( ) ?? 0 ) ;
				return hashCode ;
			}
		}

		public static bool operator == ( GameSaying left , GameSaying right ) { return Equals ( left , right ) ; }

		public static bool operator != ( GameSaying left , GameSaying right ) { return ! Equals ( left , right ) ; }

		[Startup ( nameof(LoadSayings) )]
		public static void LoadSayings ( )
		{
			lock ( Locker )
			{
				if ( Loaded )
				{
					return ;
				}

				Sayings = new List <GameSaying> ( ) ;

				XDocument doc = ResourceHelper . LoadXmlDocument ( $"{nameof(GameSaying)}Resources.xml" ) ;

				foreach ( XElement item in doc . Root . Elements ( ) )
				{
					RegisSaying ( new GameSaying ( item ) ) ;
				}

				Loaded = true ;
			}
		}

	}

}
