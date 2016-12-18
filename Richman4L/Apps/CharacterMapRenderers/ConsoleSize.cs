using System ;
using System . Collections ;
using System . Linq ;

namespace WenceyWang . Richman4L . Apps .CharacterMapRenderers
{

	public struct ConsoleSize
	{

		/// <summary>
		///     横向字符数
		/// </summary>
		public readonly int Width ;

		/// <summary>
		///     纵向字符数
		/// </summary>
		public readonly int Height ;

		public static readonly ConsoleSize Small = new ConsoleSize ( 1 , 1 ) ;

		public static readonly ConsoleSize Large = new ConsoleSize ( 5 , 3 ) ;

		public bool Equals ( ConsoleSize other ) { return Width == other . Width && Height == other . Height ; }

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) )
			{
				return false ;
			}

			return obj is ConsoleSize && Equals ( ( ConsoleSize ) obj ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( Width * 397 ) ^ Height ;
			}
		}

		public static bool operator == ( ConsoleSize left , ConsoleSize right ) { return left . Equals ( right ) ; }

		public static bool operator != ( ConsoleSize left , ConsoleSize right ) { return ! left . Equals ( right ) ; }

		public ConsoleSize ( int width , int height )
		{
			Width = width ;
			Height = height ;
		}

	}

}
