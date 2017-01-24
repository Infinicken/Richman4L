using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

using Microsoft . VisualStudio . TestPlatform . UnitTestFramework ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;
using WenceyWang . Richman4L . Apps . Uni . UI . Pages ;
using WenceyWang . Richman4L . Security ;

namespace WenceyWang . Richman4L . Apps . Uni .UnitTests
{

	[TestClass]
	public class UnitTest
	{

		[TestMethod]
		public void PageColorTest ( )
		{
			IEnumerable <TypeInfo> types = typeof ( AnimatePage ) . GetTypeInfo ( ) .
																	Assembly . DefinedTypes . Where (
																		info =>
																			typeof ( AnimatePage ) . GetTypeInfo ( ) . IsAssignableFrom ( info ) &&
																			info . Name != nameof ( AnimatePage ) ) ;
			bool passed = true ;
			StringBuilder message = new StringBuilder ( ) ;
			foreach ( TypeInfo typeInfo in types )
			{
				if ( typeInfo . GetDeclaredProperty ( "PageColor" ) == null )
				{
					message . AppendLine ( $"{typeInfo . Name} have no PageColor property" ) ;
					passed = false ;
				}
			}

			Assert . IsTrue ( passed , message . ToString ( ) ) ;
		}

		[TestMethod]
		public void UniReliviableValueTest ( )
		{
			ReliableValue . RegisImplement ( typeof ( UniReliableValue <> ) ) ;

			Random random = new Random ( ) ;

			for ( int i = 0 ; i < 100 ; i++ )
			{
				int value = random . Next ( ) ;
				ReliableValue <int> checkedValue = value ;

				Assert . AreEqual ( value , ( int ) checkedValue ) ;
			}
		}

	}

}
