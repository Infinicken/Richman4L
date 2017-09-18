using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel ;
using System . Diagnostics ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . Resources ;

namespace WenceyWang . Richman4L . Logics
{

	public abstract class GameObject : INotifyPropertyChanged , IEquatable <GameObject> , ISelfSerializeable
	{

		[PublicAPI]
		[Own]
		public Guid Guid { get ; }

		protected static object Locker { get ; } = new object ( ) ;

		public GameObjectType Type => TypeList . Single ( type => type . EntryType == GetType ( ) ) ;

		public static List <GameObjectType> TypeList { get ; } = new List <GameObjectType> ( ) ;

		public static Dictionary <GameObjectType , List <(PropertyInfo , PropertySerializationAttributeBase)>>
			TypeProperties { get ; } =
			new Dictionary <GameObjectType , List <(PropertyInfo , PropertySerializationAttributeBase)>> ( ) ;

		private static bool Loaded { get ; set ; }

		protected GameObject ( )
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

		XElement ISelfSerializeable . ToXElement ( ) { return ToXElement ( ) ; }

		private void GameObject_PropertyChanged ( object sender , PropertyChangedEventArgs e )
		{
			if ( GetType ( ) . GetRuntimeProperty ( e . PropertyName ) . GetCustomAttribute <OwnAttribute> ( ) != null )
			{
				Game . Current ? . UpdateGameObject ( this ) ;
			}
		}

		public virtual void EndToday ( ) { }

		public virtual void StartDay ( GameDate nextDate ) { }

		protected static GameObject Crate ( GameObjectType type , params object [ ] arguments )
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

			GameObject instance = ( GameObject ) Activator . CreateInstance ( type . EntryType , arguments ) ;

			return instance ;
		}


		[Startup]
		public static void LoadGameObjects ( )
		{
			lock ( Locker )
			{
				if ( Loaded )
				{
					return ;
				}

				foreach ( TypeInfo type in typeof ( Game ) . GetTypeInfo ( ) .
															Assembly . DefinedTypes .
															Where ( type => type . GetCustomAttributes ( typeof ( GameObjectAttribute ) , false ) . Any ( )
																			&& typeof ( GameObject ) . GetTypeInfo ( ) . IsAssignableFrom ( type ) ) )
				{
					RegisType ( new GameObjectType ( type . AsType ( ) ) ) ; //Todo:resources?
				}

				Loaded = true ;
			}

			//Todo:Load All internal type
		}

		public virtual XElement ToXElement ( SerializationMode mode = SerializationMode . Full ,
											ConsoleVision currentVision = ConsoleVision . God ,
											int depth = 50 )
		{
			XElement result = new XElement ( Type . Name ) ;

			if ( depth < 0 )
			{
				throw new Exception ( "Infin Loop?" ) ;
			}

			switch ( mode )
			{
				case SerializationMode . Full :
				{
					List <(PropertyInfo , PropertySerializationAttributeBase)> properties = TypeProperties [ Type ] ;

					foreach ( (PropertyInfo info , PropertySerializationAttributeBase attribute) property in properties )
					{
						object value = property . info . GetValue ( this ) ;

						switch ( value )
						{
							case GameObject gameObject :
							{
								XElement propertyContainer = new XElement ( property . info . Name ) ;
								XElement propertyValue = gameObject . ToXElement ( property . attribute . Rule , depth : depth - 1 ) ;
								propertyContainer . Add ( propertyValue ) ;
								result . Add ( propertyContainer ) ;
								break ;
							}
							case ISelfSerializeable selfSerializeable :
							{
								XElement propertyContainer = new XElement ( property . info . Name ) ;
								XElement propertyValue = selfSerializeable . ToXElement ( ) ;
								propertyContainer . Add ( propertyValue ) ;
								result . Add ( propertyContainer ) ;
								break ;
							}
							case IDictionary dictionary :
							{
								XElement propertyContainer = new XElement ( property . info . Name ) ;

								IDictionaryEnumerator enumerator = dictionary . GetEnumerator ( ) ;

								do
								{
									XElement pairContainer = new XElement ( "Data" ) ;

									object itemKey = enumerator . Key ;

									switch ( itemKey )
									{
										case GameObject gameObjectItem :
										{
											XElement keyContainer = new XElement ( "Key" ) ;
											XElement keyValue = gameObjectItem . ToXElement ( property . attribute . Rule , depth : depth - 1 ) ;
											keyContainer . Add ( keyValue ) ;
											pairContainer . Add ( keyContainer ) ;
											break ;
										}
										case ISelfSerializeable selfSerializeableItem :
										{
											XElement keyContainer = new XElement ( "Key" ) ;
											XElement keyValue = selfSerializeableItem . ToXElement ( ) ;
											keyContainer . Add ( keyValue ) ;
											pairContainer . Add ( keyContainer ) ;
											break ;
										}
										default :
										{
											XElement element = new XElement ( itemKey . GetType ( ) . FullName ) ;
											element . SetAttributeValue ( "Key" , itemKey ) ;
											pairContainer . Add ( element ) ;
											break ;
										}
									}

									object itemValue = enumerator . Value ;

									switch ( itemValue )
									{
										case GameObject gameObjectItem :
										{
											XElement valueContainer = new XElement ( "Value" ) ;
											XElement valueValue = gameObjectItem . ToXElement ( property . attribute . Rule , depth : depth - 1 ) ;
											valueContainer . Add ( valueValue ) ;
											pairContainer . Add ( valueContainer ) ;
											break ;
										}
										case ISelfSerializeable selfSerializeableItem :
										{
											XElement valueContainer = new XElement ( "Value" ) ;
											XElement valueValue = selfSerializeableItem . ToXElement ( ) ;
											valueContainer . Add ( valueValue ) ;
											pairContainer . Add ( valueContainer ) ;
											break ;
										}
										default :
										{
											XElement element = new XElement ( itemKey . GetType ( ) . FullName ) ;
											element . SetAttributeValue ( "Value" , itemKey ) ;
											pairContainer . Add ( element ) ;
											break ;
										}
									}

									propertyContainer . Add ( pairContainer ) ;
								}
								while ( enumerator . MoveNext ( ) ) ;

								break ;
							}
							case ICollection collection :
							{
								XElement propertyContainer = new XElement ( property . info . Name ) ;

								foreach ( object item in collection )
								{
									switch ( item )
									{
										case GameObject gameObjectItem :
										{
											XElement itemValue = gameObjectItem . ToXElement ( property . attribute . Rule , depth : depth - 1 ) ;
											propertyContainer . Add ( itemValue ) ;
											break ;
										}
										case ISelfSerializeable selfSerializeableItem :
										{
											XElement itemValue = selfSerializeableItem . ToXElement ( ) ;
											propertyContainer . Add ( itemValue ) ;
											break ;
										}
										default :
										{
											XElement element = new XElement ( item . GetType ( ) . FullName ) ;
											element . SetAttributeValue ( "Value" , item ) ;
											propertyContainer . Add ( element ) ;
											break ;
										}
									}
								}

								result . Add ( propertyContainer ) ;
								break ;
							}
							default :
							{
								result . SetAttributeValue ( property . info . Name , property . info . GetValue ( this ) ) ;
								break ;
							}
						}
					}

					break ;
				}
				case SerializationMode . Reference :
				{
					result . SetAttributeValue ( nameof(Guid) , Guid ) ;
					break ;
				}
				default :
				{
					throw new ArgumentOutOfRangeException ( nameof(mode) , mode , null ) ;
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
#if DEBUG
					Debug . Assert ( false ) ;

#endif
#if RELEASE //Todo:Finish this
//throw new Not
#endif

					//Todo:Log warning in debug or throw in Realease
				}

				if ( TypeList . Any ( type => type . Name == subType . Name ) )
				{
					throw new Exception ( "Name is Invilable" ) ; //Todo:Resources
				}


				TypeList . Add ( subType ) ;

				List <(PropertyInfo , PropertySerializationAttributeBase)> properties =
					subType . EntryType . GetRuntimeProperties ( ) .
							Where ( property => property . GetCustomAttribute <PropertySerializationAttributeBase> ( ) != null
												&& property . CanRead ) .
							Select ( property => (property , property . GetCustomAttribute <PropertySerializationAttributeBase> ( )) ) .
							ToList ( ) ;

				properties . Sort ( ( propA , propB ) => string . CompareOrdinal ( propA . Item1 . Name , propB . Item1 . Name ) ) ;

				TypeProperties . Add ( subType , properties ) ;
			}
		}

	}

}
