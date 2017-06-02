using System ;
using System . Collections . Generic ;
using System . Linq ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace WenceyWang . Richman4L . UnitTests
{

	[TestClass]
	public class GameSayingTests
	{

		[TestMethod]
		public void LoadSayingTest ( )
		{
			GameSaying . LoadSayings ( ) ;
		}

		[TestMethod]
		public void GetSayingTest ( )
		{
			for ( int i = 0 ; i < 1000 ; i++ )
			{
				Console . WriteLine ( GameSaying . GetSaying ( ) ) ;
			}
		}

		[TestMethod]
		public void SortSayingTest ( )
		{
			GameSaying . LoadSayings ( ) ;
			GameSaying . Sayings . Sort ( ( x , y ) =>
										{
											int contentLenthDiff = x . ContentLenth -
																	y . ContentLenth ;
											if ( contentLenthDiff == 0 )
											{
												int lenthDiff =
													x . ToXElement ( ) . ToString ( ) . Length -
													y . ToXElement ( ) . ToString ( ) . Length ;
												if ( lenthDiff == 0 )
												{
													return string . CompareOrdinal ( x . Content ,
																					y . Content ) ;
												}

												return lenthDiff ;
											}

											return contentLenthDiff ;
										} ) ;
			string lastSaying = string . Empty ;
			foreach ( GameSaying saying in GameSaying . Sayings )
			{
				if ( saying . Content != lastSaying )
				{
					Console . WriteLine ( saying . ToXElement ( ) ) ;
					lastSaying = saying . Content ;
				}
			}
		}

	}

}
