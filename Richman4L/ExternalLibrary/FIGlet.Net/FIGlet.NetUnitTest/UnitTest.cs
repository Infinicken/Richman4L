using System;
using Microsoft . VisualStudio . TestTools . UnitTesting;

using WenceyWang . FIGlet;

namespace FIGlet . NetUnitTest
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void NormalAsciiArtTest ( )
		{
			Random random = new Random ( );
			byte [ ] data = new byte [ 16 ];
			random . NextBytes ( data );
			AsciiArt result = new AsciiArt ( Convert . ToBase64String ( data ) );
			Console . WriteLine ( result );
		}
	}
}
