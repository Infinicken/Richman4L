using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L
{

	public struct GameValue : IEquatable <GameValue>
	{

		public int Value { get ; }

		public static implicit operator int ( GameValue value ) { return value . Value ; }

		public override bool Equals ( object obj ) { return Value . Equals ( obj ) ; }

		public override int GetHashCode ( ) { return Value . GetHashCode ( ) ; }

		public override string ToString ( ) { return Value . ToString ( ) ; }

		public bool Equals ( GameValue other ) { return Value == other . Value ; }

		public static bool operator == ( GameValue left , GameValue right ) { return left . Equals ( right ) ; }

		public static bool operator != ( GameValue left , GameValue right ) { return ! left . Equals ( right ) ; }

		public static GameValue operator * ( GameValue left , GameValue right )
		{
			return left . Value * right . Value / 10000 ;
		}

		private sealed class ValueEqualityComparer : IEqualityComparer <GameValue>
		{

			public bool Equals ( GameValue x , GameValue y ) { return x . Value == y . Value ; }

			public int GetHashCode ( GameValue obj ) { return obj . Value ; }

		}

		public static IEqualityComparer <GameValue> ValueComparer { get ; } = new ValueEqualityComparer ( ) ;

		public GameValue ( int value ) { Value = Math . Min ( Math . Max ( value , 0 ) , 10000 ) ; }

		public static implicit operator GameValue ( int value ) { return new GameValue ( value ) ; }

	}

}
