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
using System . Collections ;
using System . Linq ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang .Richman4L
{

	public abstract class GameObject
	{

		protected bool IsSaving = false ;

		public long Index { get ; set ; }

		public GameObject ( ) { Index = GetHashCode ( ) ; }

		public abstract void EndToday ( ) ;

		public abstract void StartDay ( GameDate nextDate ) ;

		public static T ReadNecessaryValue <T> ( XElement element , string name )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}

			string value = element . Attribute ( name ) ? . Value ;

			if ( value == null )
			{
				throw new ArgumentException ( $"" ) ;
			}

			return ( T ) Convert . ChangeType ( value , typeof ( T ) ) ;
		}

		public static T ReadUnnecessaryValue <T> ( XElement element , string name , T defaultValue )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}

			string value = element . Attribute ( name ) ? . Value ;

			if ( value == null )
			{
				return defaultValue ;
			}

			return ( T ) Convert . ChangeType ( value , typeof ( T ) ) ;
		}

	}

}
