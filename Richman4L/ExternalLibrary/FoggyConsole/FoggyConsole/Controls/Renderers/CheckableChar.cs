using System ;
using System . Collections ;
using System . Linq ;

namespace WenceyWang . FoggyConsole . Controls .Renderers
{

	public struct CheckableChar : IEquatable <CheckableChar>
	{

		public char Checked { get ; set ; }

		public char Unchecked { get ; set ; }

		public char Indeterminate { get ; set ; }

		public static CheckableChar Defult => new CheckableChar ( 'X' , ' ' , '?' ) ;

		public CheckableChar ( char @checked , char @unchecked , char indeterminate )
		{
			Checked = @checked ;
			Unchecked = @unchecked ;
			Indeterminate = indeterminate ;
		}

		public char GetStateChar ( CheckState state )
		{
			switch ( state )
			{
				case CheckState . Checked :
				{
					return Checked ;
				}
				case CheckState . Unchecked :
				{
					return Unchecked ;
				}
				case CheckState . Indeterminate :
				{
					return Indeterminate ;
				}
				default :
				{
					throw new ArgumentOutOfRangeException ( nameof ( state ) , state , null ) ;
				}
			}
		}

		public bool Equals ( CheckableChar other )
		{
			return Checked == other . Checked && Unchecked == other . Unchecked &&
					Indeterminate == other . Indeterminate ;
		}

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) )
			{
				return false ;
			}

			return obj is CheckableChar && Equals ( ( CheckableChar ) obj ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				int hashCode = Checked . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ Unchecked . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ Indeterminate . GetHashCode ( ) ;
				return hashCode ;
			}
		}

		public static bool operator == ( CheckableChar left , CheckableChar right ) { return left . Equals ( right ) ; }

		public static bool operator != ( CheckableChar left , CheckableChar right ) { return ! left . Equals ( right ) ; }

	}

}
