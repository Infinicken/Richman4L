using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

using Microsoft . VisualStudio . TestPlatform . UnitTestFramework ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;
using WenceyWang . Richman4L . Apps . Uni . UI . Pages ;
using WenceyWang . Richman4L . Security ;

namespace WenceyWang . Richman4L . Apps . Uni . UnitTests
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
																			info . Name != nameof(AnimatePage) ) ;

			List <string> properties = new List <string> { "PageColor" } ;
			List <string> fields = new List <string> { "LeaveStoryboard" , "BackgroundRect" } ;

			bool passed = true ;
			StringBuilder message = new StringBuilder ( ) ;
			foreach ( TypeInfo typeInfo in types )
			{
				foreach ( string property in properties )
				{
					if ( typeInfo . GetDeclaredProperty ( property ) == null )
					{
						message . AppendLine ( $"{typeInfo . Name} have no {property} property" ) ;
						passed = false ;
					}
				}
				foreach ( string field in fields )
				{
					if ( typeInfo . GetDeclaredField ( field ) == null )
					{
						message . AppendLine ( $"{typeInfo . Name} have no {field} Field" ) ;
						passed = false ;
					}
				}
			}

			Assert . IsTrue ( passed , message . ToString ( ) ) ;
		}

		//Todo:Attack Test?
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
