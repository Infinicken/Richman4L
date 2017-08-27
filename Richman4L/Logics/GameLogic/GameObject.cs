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
using WenceyWang . Richman4L . Resources ;

namespace WenceyWang . Richman4L
{

	public abstract class GameObject : INotifyPropertyChanged , IEquatable <GameObject>
	{

		[PublicAPI]
		[Own]
		public Guid Guid { get ; }

		protected static object Locker { get ; } = new object ( ) ;

		public GameObjectType Type => TypeList . Single ( type => type . EntryType == GetType ( ) ) ;

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
			if ( GetType ( ) . GetRuntimeProperty ( e . PropertyName ) . GetCustomAttribute <OwnAttribute> ( ) != null )
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
			Type type = GetType ( ) ;

			XElement result = new XElement ( type . FullName ) ;

			List <PropertyInfo> properties = type . GetRuntimeProperties ( ) .
													Where ( property => property . GetCustomAttribute ( typeof ( OwnAttribute ) ) != null
																		&& property . CanRead ) . ToList ( ) ;

			properties . Sort ( ( propA , propB ) => string . CompareOrdinal ( propA . Name , propB . Name ) ) ;

			foreach ( PropertyInfo property in properties )
			{
				if ( typeof ( ICollection ) . GetTypeInfo ( ) . IsAssignableFrom ( property . PropertyType . GetTypeInfo ( ) ) )
				{
					XElement propertyContainer = new XElement ( property . Name ) ;

					ICollection enumerable = ( ICollection ) property . GetValue ( this ) ;
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

					result . Add ( propertyContainer ) ;
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
				throw new ArgumentException ( string . Format ( Resource . NecessaryValueNotFound , element , name ) ) ;
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

				if ( TypeList . Contains ( subType ) )
				{
					//Todo:Log warning in debug or throw in Realease
				}

				if ( TypeList . Any ( type => type . Name == subType . Name ) )
				{
					throw new Exception ( "Name is Invilable" ) ; //Todo:Resources
				}


				TypeList . Add ( subType ) ;
			}
		}

	}

}
