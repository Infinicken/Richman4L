using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace WenceyWang . Richman4L .UnitTests
{

	[ TestClass ]
	public class GameSayingTests
	{

		[ TestMethod ]
		public void LoadSayingTest ( )
		{
			GameSaying . LoadSayings ( ) ;
		}

		[ TestMethod ]
		public void GetSayingTest ( )
		{
			for ( int i = 0 ; i < 1000 ; i++ )
			{
				Console . WriteLine ( GameSaying . GetSaying ( ) ) ;
			}
		}

		[ TestMethod ]
		public void SortSayingTest ( )
		{
			XDocument doc = ResourceHelper . LoadXmlDocument ( @"GameSayingResources.xml" ) ;
			List < XElement > sayingList = doc . Root . Elements ( ) . ToList ( ) ;
			sayingList . Sort ( ( x , y ) =>
								{
									int contentLenthDiff = x . Attribute ( "Content" ) . ToString ( ) . Length -
															y . Attribute ( "Content" ) . ToString ( ) . Length ;
									if ( contentLenthDiff == 0 )
									{
										int lenthDiff = x . ToString ( ) . Length - y . ToString ( ) . Length ;
										if ( lenthDiff == 0 )
										{
											return string . CompareOrdinal ( x . Attribute ( "Content" ) . ToString ( ) ,
																			y . Attribute ( "Content" ) . ToString ( ) ) ;
										}
										else
										{
											return lenthDiff ;
										}
									}
									else
									{
										return contentLenthDiff ;
									}
								} ) ;
			string lastSaying = "" ;
			foreach ( XElement saying in sayingList )
			{
				if ( saying . Attribute ( "Content" ) . ToString ( ) != lastSaying )
				{
					Console . WriteLine ( saying ) ;
					lastSaying = saying . Attribute ( "Content" ) . ToString ( ) ;
				}
			}
		}

	}

}
