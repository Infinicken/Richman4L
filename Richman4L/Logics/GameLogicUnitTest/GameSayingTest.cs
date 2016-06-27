using System;
using System . Collections . Generic;
using System . Diagnostics;
using System . Xml . Linq;
using System . Linq;
using Microsoft . VisualStudio . TestTools . UnitTesting;

namespace WenceyWang . Richman4L . UnitTests
{
	[TestClass]
	public class GameSayingTest
	{

		[TestMethod]
		public void LoadSayingTest ( )
		{
			GameSaying . LoadSayings ( );
		}

		[TestMethod]
		public void GetSayingTest ( )
		{
			for ( int i = 0 ; i < 1000 ; i++ )
			{
				Debug . WriteLine ( GameSaying . GetSaying ( ) );
			}
		}

		[TestMethod]
		public void SortSayingTest ( )
		{
			XDocument doc = ResourceHelper . LoadXmlDocument ( @"GameSayingResources.xml" );
			List<XElement> a = doc . Root . Elements ( ) . ToList ( );
			a . Sort ( ( x , y ) =>
			{
				int c = x . Attribute ( "Content" ) . ToString ( ) . Length - y . Attribute ( "Content" ) . ToString ( ) . Length;
				if ( c == 0 )
				{
					int aC = x . ToString ( ) . Length - y . ToString ( ) . Length;
					if ( aC == 0 )
					{
						return string . CompareOrdinal ( x . Attribute ( "Content" ) . ToString ( ) , y . Attribute ( "Content" ) . ToString ( ) );
					}
					else
					{
						return aC;
					}
				}
				else
				{
					return c;
				}
			} );
			foreach ( XElement variable in a )
			{
				Debug . WriteLine ( variable );
			}
		}
	}
}
