using System;
using System . Collections;
using System . Collections . Generic ;
using System . Linq;
using System . Reflection;

using Microsoft . VisualStudio . TestPlatform . UnitTestFramework;

using WenceyWang . Richman4L . Apps . Uni . Pages;

namespace WenceyWang . Richman4L . Apps . Uni . UnitTests
{

	[TestClass]
	public class UnitTest
	{

		[TestMethod]
		public void TestMethod ( )
		{
			IEnumerable <TypeInfo> types= typeof ( AnimatePage ) . GetTypeInfo ( ) .
									Assembly . DefinedTypes . Where ( info => typeof ( AnimatePage ) . GetTypeInfo ( ) . IsAssignableFrom ( info ) );

			foreach ( TypeInfo typeInfo in types )
			{
						
				typeInfo . GetDeclaredProperty ( "PageColor" ) . GetValue ( null ) ;
			}
		}

	}

}
