using System ;
using System . Collections ;
using System . Linq ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace WenceyWang . Richman4L .UnitTests
{

	[TestClass]
	public class StartUpTest
	{

		[TestMethod]
		public void GetTaskTest ( ) { Startup . GetAllTask ( ) ; }

		[TestMethod]
		public void RunTaskTest ( ) { Startup . GetAllTask ( ) . Wait ( ) ; }

	}

}
