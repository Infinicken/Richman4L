﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace WenceyWang . Richman4L . Logics . Tests
{

	[TestClass]
	public class GameTitleTest
	{

		[TestMethod]
		public void LoadTitleTest ( )
		{
			GameTitle . LoadTitles ( ) ;
		}

		[TestMethod]
		[Timeout ( 1000 )]
		public void GetTitleTest ( )
		{
			for ( int i = 0 ; i < 1000 ; i++ )
			{
				Console . WriteLine ( GameTitle . GetTitle ( true ) ) ;
			}
		}

		[TestMethod]
		public void SortTitleTest ( )
		{
			XDocument doc = ResourceHelper . LoadXmlDocument ( @"GameTitleResources.xml" ) ;
			List <XElement> a = doc . Root . Element ( "TitleKeys" ) . Elements ( ) . ToList ( ) ;
			a . Sort ( ( x , y ) => string . CompareOrdinal ( x . ToString ( ) , y . ToString ( ) ) ) ;
			foreach ( XElement variable in a )
			{
				Console . WriteLine ( variable ) ;
			}
		}

	}

}
