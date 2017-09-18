using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Globalization ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics
{

	/// <summary>
	///     表示可能性.
	/// </summary>
	public struct GameValue : IEquatable <GameValue>
	{

		public int Value { get ; }

		public static implicit operator int ( GameValue value ) { return value . Value ; }


		public override bool Equals ( object obj ) { return Value . Equals ( obj ) ; }

		public override int GetHashCode ( ) { return Value . GetHashCode ( ) ; }

		public static GameValue MaxValue { get ; } = 10000 ;

		public static GameValue MinValue { get ; } = 0 ;

		public override string ToString ( ) { return Value . ToString ( CultureInfo . InvariantCulture ) ; }

		public bool Equals ( GameValue other ) { return Value == other . Value ; }

		public static bool operator == ( GameValue left , GameValue right ) { return left . Equals ( right ) ; }

		public static bool operator != ( GameValue left , GameValue right ) { return ! left . Equals ( right ) ; }

		public static GameValue operator * ( GameValue left , GameValue right )
		{
			return left . Value * right . Value / MaxValue ;
		}

		public static explicit operator GameValue ( decimal value )
		{
			return new GameValue ( Convert . ToInt32 ( value * MaxValue ) ) ;
		}

		public static explicit operator GameValue ( double value )
		{
			return new GameValue ( Convert . ToInt32 ( value * MaxValue ) ) ;
		}

		private sealed class ValueEqualityComparer : IEqualityComparer <GameValue>
		{

			public bool Equals ( GameValue x , GameValue y ) { return x . Value == y . Value ; }

			public int GetHashCode ( GameValue obj ) { return obj . Value ; }

		}

		public static IEqualityComparer <GameValue> ValueComparer { get ; } = new ValueEqualityComparer ( ) ;

		public int ToInt32 ( ) { return this ; }

		public GameValue ( int value ) { Value = Math . Min ( Math . Max ( value , 0 ) , 10000 ) ; }

		public static implicit operator GameValue ( int value ) { return new GameValue ( value ) ; }

	}

}
