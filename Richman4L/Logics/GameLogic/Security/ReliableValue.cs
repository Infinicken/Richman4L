using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

namespace WenceyWang . Richman4L . Security
{

	public abstract class ReliableValue <T>
	{

		public abstract T Value { get ; set ; }

		public static implicit operator ReliableValue <T> ( T value )
		{
			ReliableValue <T> temp =
				( ReliableValue <T> )
				Activator . CreateInstance ( ReliableValue . ImplemrntType . MakeGenericType ( typeof ( T ) ) , value ) ;
			return temp ;
		}

		public static implicit operator T ( ReliableValue <T> value ) { return value . Value ; }

	}

	public static class ReliableValue
	{

		public static Type ImplemrntType { get ; private set ; }

		public static void RegisImplement ( Type implementType )
		{
			if ( implementType == null )
			{
				throw new ArgumentNullException ( nameof(implementType) ) ;
			}
			if ( ! typeof ( ReliableValue <object> ) . GetTypeInfo ( ) .
														IsAssignableFrom ( implementType . MakeGenericType ( typeof ( object ) ) . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( ) ;
			}
			if ( ImplemrntType != null )
			{
				throw new InvalidOperationException ( ) ;
			}

			ImplemrntType = implementType ;
		}

	}

}
