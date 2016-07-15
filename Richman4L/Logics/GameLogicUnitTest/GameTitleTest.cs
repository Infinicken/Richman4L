using System;
using System . Collections . Generic;
using System . Diagnostics;
using System . IO;
using System . Linq;
using System . Xml . Linq;

using Microsoft . VisualStudio . TestTools . UnitTesting;

namespace WenceyWang . Richman4L . UnitTests
{
	[TestClass]
	public class GameTitleTest
	{

		[TestMethod]
		public void LoadTitleTest ( )
		{
			GameTitle . LoadTitles ( );
		}

		[TestMethod]
		[Timeout ( 1000 )]
		public void GetTitleTest ( )
		{
			for ( int i = 0 ; i < 1000 ; i++ )
			{
				Debug . WriteLine ( GameTitle . GetTitle (true ) );
			}
		}

		[TestMethod]
		public void SortTitleTest ( )
		{
			XDocument doc = ResourceHelper . LoadXmlDocument ( @"GameTitleResources.xml" );
			List<XElement> a = doc . Root . Element ( "TitleKeys" ) . Elements ( ) . ToList ( );
			a . Sort ( ( x , y ) => string . CompareOrdinal ( x . ToString ( ) , y . ToString ( ) ) );
			foreach ( XElement variable in a )
			{
				Debug . WriteLine ( variable );
			}
		}



	}
}
