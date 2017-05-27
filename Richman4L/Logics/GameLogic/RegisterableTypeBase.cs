using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L
{

	public abstract class RegisterableTypeBase <TType , TAttribute , T>
		where T : NeedRegisTypeBase <TType , TAttribute , T>
		where TType : RegisterableTypeBase <TType , TAttribute , T>
		where TAttribute : Attribute
	{

		public string Introduction { get ; }

		public Guid Guid => EntryType . GetTypeInfo ( ) . GUID ;

		public string Name { get ; }

		public Type EntryType { get ; }

		protected RegisterableTypeBase ( [NotNull] Type entryType , [NotNull] XElement element )
		{
			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof(entryType) ) ;
			}
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}
			if ( ! typeof ( T ) . GetTypeInfo ( ) . IsAssignableFrom ( entryType . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( $"{nameof(entryType)} is not {nameof(T)}" ) ;
			}
			if ( element . Name != GetType ( ) . Name )
			{
				throw new ArgumentException ( $"{nameof(element)} is not {nameof(T)}" ) ;
			}

			EntryType = entryType ;

			#region Load XML

			Name = GameObject . ReadNecessaryValue <string> ( element , nameof(Name) ) ;

			Introduction = GameObject . ReadNecessaryValue <string> ( element , nameof(Introduction) ) ;

			#endregion
		}

		protected RegisterableTypeBase ( [NotNull] Type entryType , [NotNull] string name , [NotNull] string introduction )
		{
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
				throw new ArgumentException ( $"{nameof(entryType)} is not {nameof(T)}" ) ;
			}

			EntryType = entryType ;

			Name = name ;

			Introduction = introduction ;
		}

		public override string ToString ( ) { return Guid . ToString ( ) ; }

	}

}
