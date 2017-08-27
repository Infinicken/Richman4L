using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace WenceyWang . FIGlet . UnitTest
{

	[TestClass]
	public class UnitTest
	{

		[TestMethod]
		public void RandomAsciiArtTest ( )
		{
			Random random = new Random ( ) ;
			Stopwatch watch = new Stopwatch ( ) ;
			byte [ ] data = new byte[ 16 ] ;
			Array values = Enum . GetValues ( typeof ( CharacterWidth ) ) ;
			for ( int i = 0 ; i < 1000 ; i++ )
			{
				random . NextBytes ( data ) ;
				string str = Convert . ToBase64String ( data ) ;
				Console . WriteLine ( str ) ;
				foreach ( CharacterWidth characterWidth in values )
				{
					watch . Start ( ) ;
					AsciiArt result = new AsciiArt ( str , FIGletFont . Defult , characterWidth ) ;
					watch . Stop ( ) ;
					Console . WriteLine ( result ) ;
				}

				Console . WriteLine ( ) ;
			}

			Console . WriteLine ( watch . Elapsed ) ;
		}

		[TestMethod]
		public void TypeSomethingAsciiArtTest ( )
		{
			Stopwatch watch = Stopwatch . StartNew ( ) ;

			foreach ( CharacterWidth characterWidth in Enum . GetValues ( typeof ( CharacterWidth ) ) )
			{
				Console . WriteLine ( Enum . GetName ( typeof ( CharacterWidth ) , characterWidth ) ) ;
				watch . Start ( ) ;
				AsciiArt result = new AsciiArt ( "Type Something" , FIGletFont . Defult , characterWidth ) ;
				watch . Stop ( ) ;
				Console . WriteLine ( result ) ;
				Console . WriteLine ( ) ;
			}

			Console . WriteLine ( watch . Elapsed ) ;
		}

	}

}
