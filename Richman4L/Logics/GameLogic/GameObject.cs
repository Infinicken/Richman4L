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

	public abstract class GameObject : INotifyPropertyChanged , IEquatable <GameObject>
	{

		[PublicAPI]
		[ConsoleVisable]
		public Guid Guid { get ; protected set ; }

		protected static object Locker { get ; } = new object ( ) ;


		public GameObjectType Type { get ; set ; }

		public static List <GameObjectType> TypeList { get ; } = new List <GameObjectType> ( ) ;

		public GameObject ( )
		{
			Guid = Guid . NewGuid ( ) ;
			PropertyChanged += GameObject_PropertyChanged ;
		}

		public bool Equals ( GameObject other )
		{
			if ( ReferenceEquals ( null , other ) )
			{
				return false ;
			}
			if ( ReferenceEquals ( this , other ) )
			{
				return true ;
			}

			return Guid . Equals ( other . Guid ) ;
		}

		public event PropertyChangedEventHandler PropertyChanged ;

		private void GameObject_PropertyChanged ( object sender , PropertyChangedEventArgs e )
		{
			if ( GetType ( ) .
					GetRuntimeProperty ( e . PropertyName ) .
					GetCustomAttribute <ConsoleVisableAttribute> ( ) != null )
			{
				Game . Current ? . UpdateGameObject ( this ) ;
			}
		}

		public virtual void EndToday ( ) { }

		public virtual void StartDay ( GameDate nextDate ) { }

		protected static GameObject Crate ( GameObjectType type )
		{
			#region Check Argument

			if ( type == null )
			{
				throw new ArgumentNullException ( nameof(type) ) ;
			}
			if ( ! TypeList . Contains ( type ) )
			{
				throw new ArgumentException ( $"{nameof(type)} have not being registered" , nameof(type) ) ;
			}

			#endregion

			GameObject instance = ( GameObject ) Activator . CreateInstance ( type . EntryType ) ;

			return instance ;
		}


		public virtual XElement ToXElement ( )
		{
			TypeInfo typeInfo = GetType ( ) . GetTypeInfo ( ) ;
			XElement result = new XElement ( typeInfo . Name ) ;
			foreach (
				PropertyInfo property in
				typeInfo . DeclaredProperties . Where (
					property => property . GetCustomAttribute ( typeof ( ConsoleVisableAttribute ) ) !=
								null &&
								property . CanRead ) )
			{
				if ( typeof ( IEnumerable ) . GetTypeInfo ( ) .
											IsAssignableFrom ( property . PropertyType . GetTypeInfo ( ) ) )
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
				else if ( typeof ( GameObject ) . GetTypeInfo ( ) .
												IsAssignableFrom ( property . PropertyType . GetTypeInfo ( ) ) )
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

				//todo:String Resources
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

			return Equals ( ( GameObject ) obj ) ;
		}

		public override int GetHashCode ( ) { return Guid . GetHashCode ( ) ; }

		public static bool operator == ( GameObject left , GameObject right ) { return Equals ( left , right ) ; }

		public static bool operator != ( GameObject left , GameObject right ) { return ! Equals ( left , right ) ; }

		[NotifyPropertyChangedInvocator]
		protected void OnPropertyChanged ( [CallerMemberName] string propertyName = null )
		{
			PropertyChanged ? . Invoke ( this , new PropertyChangedEventArgs ( propertyName ) ) ;
		}

		[PublicAPI]
		protected static void RegisType ( GameObjectType subType )
		{
			lock ( Locker )
			{
				if ( subType == null )
				{
					throw new ArgumentNullException ( nameof(subType) ) ;
				}

				if ( TypeList . Any ( type => type . Name == subType . Name ) )
				{
					throw new Exception ( "Name is Invilable" ) ;
				}


				TypeList . Add ( subType ) ;
			}
		}

	}

	public class GameObjectType
	{

		public string Introduction { get ; }

		public Guid Guid => EntryType . GetTypeInfo ( ) . GUID ;

		public string Name { get ; }

		public Type EntryType { get ; }

		protected GameObjectType ( [NotNull] Type entryType , [NotNull] XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}

			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;

			#region Load XML

			Name = GameObject . ReadNecessaryValue <string> ( element , nameof(Name) ) ;

			Introduction = GameObject . ReadNecessaryValue <string> ( element , nameof(Introduction) ) ;

			#endregion
		}

		protected GameObjectType ( [NotNull] Type entryType , [NotNull] string name , [NotNull] string introduction )
		{
			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;

			Name = name ?? throw new ArgumentNullException ( nameof(name) ) ;

			Introduction = introduction ?? throw new ArgumentNullException ( nameof(introduction) ) ;
		}

	}

}
