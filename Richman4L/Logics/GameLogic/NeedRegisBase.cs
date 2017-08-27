using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L
{

	public abstract class NeedRegisBase <TType , TAttribute , T> : GameObject
		where TType : RegisType <TType , TAttribute , T>
		where TAttribute : Attribute
		where T : NeedRegisBase <TType , TAttribute , T>
	{

		public new TType Type => base . Type as TType ;

		public new static IEnumerable <TType> TypeList => GameObject . TypeList . OfType <TType> ( ) ;

		protected static T Crate ( TType type )
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

			T instance = ( T ) GameObject . Crate ( type ) ;

			return instance ;
		}

		protected static void RegisType <TSub> ( TSub subType ) where TSub : TType
		{
			lock ( Locker )
			{
				GameObject . RegisType ( subType ) ;
			}
		}

		[PublicAPI]
		protected static TType RegisType ( Type entryType , [NotNull] string name , [NotNull] string introduction )
		{
			lock ( Locker )
			{
				#region Check Argument

				if ( entryType == null )
				{
					throw new ArgumentNullException ( nameof(entryType) ) ;
				}
				if ( name == null )
				{
					throw new ArgumentNullException ( nameof(name) ) ;
				}
				if ( introduction == null )
				{
					throw new ArgumentNullException ( nameof(introduction) ) ;
				}

				if ( ! typeof ( T ) . GetTypeInfo ( ) . IsAssignableFrom ( entryType . GetTypeInfo ( ) ) )
				{
					throw new ArgumentException ( $"{nameof(entryType)} should assignable from {nameof(T)}" , nameof(entryType) ) ;
				}

				if ( entryType . GetTypeInfo ( ) . GetCustomAttributes ( typeof ( TAttribute ) , false ) . Single ( ) == null )
				{
					throw new ArgumentException ( $"{nameof(entryType)} should have atribute {nameof(TAttribute)}" ,
												nameof(entryType) ) ;
				}

				if ( TypeList . Any ( type => type . EntryType == entryType ) )
				{
					throw new InvalidOperationException ( $"{nameof(entryType)} have regised" ) ;
				}

				#endregion

				TType instance = ( TType ) Activator . CreateInstance ( typeof ( TType ) , entryType , name , introduction ) ;

				GameObject . RegisType ( instance ) ;

				return instance ;
			}
		}

		protected static TType RegisType ( Type entryType , XElement element )
		{
			lock ( Locker )
			{
				#region Check Argument

				if ( entryType == null )
				{
					throw new ArgumentNullException ( nameof(entryType) ) ;
				}

				if ( ! typeof ( T ) . GetTypeInfo ( ) . IsAssignableFrom ( entryType . GetTypeInfo ( ) ) )
				{
					throw new ArgumentException ( $"{nameof(entryType)} should assignable from {nameof(T)}" , nameof(entryType) ) ;
				}

				if ( entryType . GetTypeInfo ( ) . GetCustomAttributes ( typeof ( TAttribute ) , false ) . Single ( ) == null )
				{
					throw new ArgumentException ( $"{nameof(entryType)} should have atribute {nameof(TAttribute)}" ,
												nameof(entryType) ) ;
				}

				if ( element == null )
				{
					throw new ArgumentNullException ( nameof(element) ) ;
				}

				if ( element . Name != nameof(entryType) )
				{
					throw new ArgumentException ( $"{nameof(element)} should perform a {typeof ( TType ) . Name}" , nameof(element) ) ;
				}

				if ( TypeList . Any ( type => type . EntryType == entryType ) )
				{
					throw new InvalidOperationException ( $"{nameof(entryType)} have regised" ) ;
				}

				#endregion

				TType instance = ( TType ) Activator . CreateInstance ( typeof ( TType ) , entryType , element ) ;

				GameObject . RegisType ( instance ) ;

				return instance ;
			}
		}

		//Todo:
		public static void LoadAll ( ) { }

	}

}
