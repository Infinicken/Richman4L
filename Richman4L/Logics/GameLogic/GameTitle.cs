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
using System . Text;
using System . Threading . Tasks;
using System . Xml . Linq;

namespace WenceyWang . Richman4L
{
	public struct GameTitle
	{
		public static GameTitle Defult => new GameTitle ( "Richman" , "L" );

		public string TitleRoot { get; }

		public string TitleKey { get; }

		public string Content => $"{TitleRoot}4{TitleKey}";

		public override string ToString ( ) => Content;

		public static implicit operator GameTitle ( string text )
		{
			string [ ] temp = text . Split ( '4' );
			return new GameTitle ( temp . First ( ) , temp . Last ( ) );
		}

		private GameTitle ( string titleRoot , string titleKey )
		{
			TitleRoot = titleRoot;
			TitleKey = titleKey;
		}

		internal static List<string> TitleRoots;

		internal static List<string> TitleKeys;

		internal static bool Loaded = false;

		public static GameTitle GetTitle ( bool randomTitleRoot )
		{
			if ( !Loaded )
			{
				LoadTitles ( );
			}

			if ( randomTitleRoot )
			{
				return new GameTitle ( TitleRoots . RandomItem ( GameRandom . Current ) ,
										TitleKeys . RandomItem ( GameRandom . Current ) );
			}
			else
			{
				return new GameTitle ( "Richman" , TitleKeys . RandomItem ( GameRandom . Current ) );
			}
		}

		public bool Equals ( GameTitle other )
		{
			return string . Equals ( TitleRoot , other . TitleRoot ) && string . Equals ( TitleKey , other . TitleKey );
		}

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) ) { return false; }
			return obj is GameTitle && Equals ( ( GameTitle ) obj );
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( ( TitleRoot?.GetHashCode ( ) ?? 0 ) * 397 ) ^ ( TitleKey?.GetHashCode ( ) ?? 0 );
			}
		}

		public static bool operator == ( GameTitle left , GameTitle right )
		{
			return left . Equals ( right );
		}

		public static bool operator != ( GameTitle left , GameTitle right )
		{
			return !left . Equals ( right );
		}

		private static readonly object locker = new object ( );

		public static void LoadTitles ( )
		{
			lock ( locker )
			{
				Loaded = true;
				TitleRoots = new List<string> ( );
				TitleKeys = new List<string> ( );

				XDocument doc = ResourceHelper . LoadXmlDocument ( $"{ nameof ( GameTitle )}Resources.xml" );

				foreach ( XElement item in doc . Root . Element ( nameof ( TitleRoots ) ) . Elements ( ) )
				{
					TitleRoots . Add ( item . Attribute ( "Content" ) . Value );
				}
				foreach ( XElement item in doc . Root . Element ( nameof ( TitleKeys ) ) . Elements ( ) )
				{
					TitleKeys . Add ( item . Attribute ( "Content" ) . Value );
				}
			}

		}
	}
}
