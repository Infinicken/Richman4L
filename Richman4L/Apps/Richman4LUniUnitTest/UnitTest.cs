using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

using Microsoft . VisualStudio . TestPlatform . UnitTestFramework ;

using WenceyWang . Richman4L . Apps . Uni . Pages ;

namespace WenceyWang . Richman4L . Apps . Uni .UnitTests
{

	[TestClass]
	public class UnitTest
	{

		[TestMethod]
		public void TestMethod ( )
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

	}

}
