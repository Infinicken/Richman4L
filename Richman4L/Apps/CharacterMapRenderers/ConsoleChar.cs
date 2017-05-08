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

namespace WenceyWang . Richman4L . Apps . CharacterMapRenderers
{

	public struct ConsoleChar
	{

		public readonly char Character ;

		public readonly ConsoleColor ForegroundColor ;

		public readonly ConsoleColor BackgroundColor ;

		public bool Equals ( ConsoleChar other )
		{
			return Character == other . Character && ForegroundColor == other . ForegroundColor &&
					BackgroundColor == other . BackgroundColor ;
		}

		public static implicit operator ConsoleChar ( char character )
		{
			return new ConsoleChar ( character , ConsoleColor . Gray ) ;
		}

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) )
			{
				return false ;
			}

			return obj is ConsoleChar && Equals ( ( ConsoleChar ) obj ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				int hashCode = Character . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ ( int ) ForegroundColor ;
				hashCode = ( hashCode * 397 ) ^ ( int ) BackgroundColor ;
				return hashCode ;
			}
		}

		public static bool operator == ( ConsoleChar left , ConsoleChar right ) { return left . Equals ( right ) ; }

		public static bool operator != ( ConsoleChar left , ConsoleChar right ) { return ! left . Equals ( right ) ; }

		public override string ToString ( ) { return new string ( Character , 1 ) ; }

		public ConsoleChar ( char character ,
							ConsoleColor foregroundColor = ConsoleColor . White ,
							ConsoleColor backgroundColor = ConsoleColor . Black )
		{
			Character = character ;
			ForegroundColor = foregroundColor ;
			BackgroundColor = backgroundColor ;
		}

	}

}
