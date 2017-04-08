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
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . GameEnviroment
{

	public class SmallGameResult
	{

		public Guid Id { get ; }

		public SmallGameType Type { get ; }

		public int GamePoint { get ; set ; }

		public override string ToString ( )
		{
			return $"{nameof(Id)}: {Id}, {nameof(Type)}: {Type}, {nameof(GamePoint)}: {GamePoint}" ;
		}

	}

	public class StartSmallGameRequest
	{

		public Guid Id { get ; }

		public SmallGameType Type { get ; }

		public override string ToString ( ) { return $"{nameof(Id)}: {Id}, {nameof(Type)}: {Type}" ; }

	}

	public sealed class SmallGameType
	{

		public Guid Guid => EntryType . GetTypeInfo ( ) . GUID ;

		public string Name { get ; }

		public string Introduction { get ; }

		public Type EntryType { get ; }

		internal SmallGameType ( [NotNull] Type entryType , [NotNull] XElement element )
		{
			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof(entryType) ) ;
			}
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}

			EntryType = entryType ;

			#region Load XML

			Name = GameObject . ReadUnnecessaryValue ( element , nameof(Name) , string . Empty ) ;

			Introduction = GameObject . ReadUnnecessaryValue ( element , nameof(Introduction) , string . Empty ) ;

			#endregion
		}

		public override string ToString ( ) { return Guid . ToString ( ) ; }

	}

}
