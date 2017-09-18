using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics
{

	public abstract class RegisType <TType , TAttribute , T> : GameObjectType
		where T : NeedRegisBase <TType , TAttribute , T>
		where TType : RegisType <TType , TAttribute , T>
		where TAttribute : NeedRegisAttributeBase
	{

		public RegisType ( [NotNull] Type entryType , [NotNull] XElement element ) : base ( entryType , element )
		{
			if ( ! typeof ( T ) . GetTypeInfo ( ) . IsAssignableFrom ( entryType . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( $"{nameof(entryType)} is not {nameof(T)}" ) ;
			}
			if ( element . Name != GetType ( ) . Name )
			{
				throw new ArgumentException ( $"{nameof(element)} is not {nameof(T)}" ) ;
			}
		}

		public RegisType ( [NotNull] Type entryType ) : base ( entryType )
		{
			if ( ! typeof ( T ) . GetTypeInfo ( ) . IsAssignableFrom ( entryType . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( $"{nameof(entryType)} is not {nameof(T)}" ) ;
			}
		}

	}

}
