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
using System . Collections . Generic ;
using System . ComponentModel ;
using System . Linq ;
using System . Reflection ;
using System . Runtime . CompilerServices ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L
{

	public abstract class GameObject : INotifyPropertyChanged
	{

		[ConsoleVisable]
		public Guid Guid { get ; }

		public GameObject ( )
		{
			Guid = Guid . NewGuid ( ) ;
			PropertyChanged += GameObject_PropertyChanged ;
		}

		public event PropertyChangedEventHandler PropertyChanged ;

		private void GameObject_PropertyChanged ( object sender , PropertyChangedEventArgs e )
		{
			if ( GetType ( ) .
					GetTypeInfo ( ) .
					GetDeclaredProperty ( e . PropertyName ) .
					GetCustomAttribute <ConsoleVisableAttribute> ( ) != null )
			{
				Game . Current . UpdateGameObject ( this ) ;
			}
		}

		public void RequestUpdate ( ) { }

		public abstract void EndToday ( ) ;

		public abstract void StartDay ( GameDate nextDate ) ;

		public virtual XElement ToXElement ( )
		{
			TypeInfo typeInfo = GetType ( ) . GetTypeInfo ( ) ;
			XElement result = new XElement ( typeInfo . Name ) ;
			foreach (
				PropertyInfo property in
				typeInfo . DeclaredProperties . Where (
					property => property . GetCustomAttribute ( typeof ( ConsoleVisableAttribute ) ) != null &&
								property . CanRead ) )
			{
				if ( typeof ( IEnumerable ) . GetTypeInfo ( ) . IsAssignableFrom ( property . PropertyType . GetTypeInfo ( ) ) )
				{
					XElement propertyContainer = new XElement ( property . Name ) ;

					IEnumerable enumerable = ( IEnumerable ) property . GetValue ( this ) ;
					foreach ( object item in enumerable )
					{
						if ( item is GameObject gameObject )
						{
							propertyContainer . Add ( gameObject . ToXElement ( ) ) ;
						}
						else
						{
							XElement element = new XElement ( item . GetType ( ) . Name ) ;
							element . SetAttributeValue ( "Value" , item ) ;
							propertyContainer . Add ( element ) ;
						}
					}
				}
				else if ( typeof ( GameObject ) . GetTypeInfo ( ) . IsAssignableFrom ( property . PropertyType . GetTypeInfo ( ) ) )
				{
					XElement propertyContainer = new XElement ( property . Name ) ;
					XElement propertyValue = ( ( GameObject ) property . GetValue ( this ) ) . ToXElement ( ) ;
					propertyContainer . Add ( propertyValue ) ;
					result . Add ( propertyContainer ) ;
				}
				else
				{
					result . SetAttributeValue ( property . Name , property . GetValue ( this ) ) ;
				}
			}

			return result ;
		}

		public static T ReadNecessaryValue <T> ( XElement element , string name )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof(name) ) ;
			}

			string value = element . Attribute ( name ) ? . Value ;

			if ( value == null )
			{
				throw new ArgumentException ( $"" ) ;
			}

			TypeConverter typeConverter = TypeDescriptor . GetConverter ( typeof ( T ) ) ;
			return ( T ) typeConverter . ConvertFromString ( value ) ;
		}

		public static T ReadUnnecessaryValue <T> ( XElement element , string name , T defaultValue )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof(name) ) ;
			}

			string value = element . Attribute ( name ) ? . Value ;

			if ( value == null )
			{
				return defaultValue ;
			}

			TypeConverter typeConverter = TypeDescriptor . GetConverter ( typeof ( T ) ) ;
			return ( T ) typeConverter . ConvertFromString ( value ) ;
		}

		[NotifyPropertyChangedInvocator]
		protected void OnPropertyChanged ( [CallerMemberName] string propertyName = null )
		{
			PropertyChanged ? . Invoke ( this , new PropertyChangedEventArgs ( propertyName ) ) ;
		}

	}

}
