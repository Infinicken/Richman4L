using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

namespace WenceyWang . Richman4L
{

	public static class TypeExtensions
	{

		public static int GetInheritanceDepth ( this Type type )
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof(type) ) ;
			}

			Type currentType = type ;
			int count = 0 ;
			while ( currentType != typeof ( object ) )
			{
				currentType = currentType . GetTypeInfo ( ) . BaseType ;
				count++ ;
			}

			return count ;
		}

		public static int GetInheritanceDepth ( this Type type , Type baseType )
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof(type) ) ;
			}
			if ( baseType == null )
			{
				throw new ArgumentNullException ( nameof(baseType) ) ;
			}

			if ( ! baseType . GetTypeInfo ( ) . IsAssignableFrom ( type . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( ) ;

				//todo:text
			}

			Type currentType = type ;
			int count = 0 ;
			while ( currentType != baseType )
			{
				currentType = currentType . GetTypeInfo ( ) . BaseType ;
				count++ ;
			}

			return count ;
		}

	}

}
