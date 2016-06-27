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
using System . Threading;
using System . Threading . Tasks;
using System . Xml . Linq;

namespace WenceyWang . Richman4L
{
	public class GameSaying
	{
		public string Content { get; }

		public string People { get; }

		public string Book { get; }

		public string Author { get; }

		public string Song { get; }

		public override string ToString ( ) => Content;

		private GameSaying ( XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) );
			}
			if ( element . Name != nameof ( GameSaying ) )
			{
				throw new ArgumentException ( $"{nameof ( element )} do not perform a {nameof ( GameSaying )}" );
			}
			Content = element . Attribute ( nameof ( Content ) )?.Value;
			People = element . Attribute ( nameof ( People ) )?.Value;
			Book = element . Attribute ( nameof ( Book ) )?.Value;
			Author = element . Attribute ( nameof ( Author ) )?.Value;
			Song = element . Attribute ( nameof ( Song ) )?.Value;
		}

		internal static List<GameSaying> Sayings;

		internal static bool Loaded = false;


		public static GameSaying GetSaying ( )
		{
			if ( !Loaded )
			{
				LoadSayings ( );
			}
			return Sayings . RandomItem ( GameRandom . Current );
		}

		private static readonly object locker = new object ( );

		public static void LoadSayings ( )
		{
			lock ( locker )
			{
				Loaded = true;
				Sayings = new List<GameSaying> ( );

				XDocument doc = ResourceHelper . LoadXmlDocument ( $"{nameof ( GameSaying )}Resources.xml" );

				foreach ( XElement item in doc . Root . Elements ( ) )
				{
					Sayings . Add ( new GameSaying ( item ) );
				}
			}
		}
	}
}
