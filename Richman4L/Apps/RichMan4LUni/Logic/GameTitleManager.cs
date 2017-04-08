using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{

	public static class GameTitleManager
	{

		public static void GenerateNewTitle ( )
		{
			if ( AppSettings . Current . AllowRandomTitle )
			{
				AppSettings . Current . GameTitle = GameTitle . GetTitle ( AppSettings . Current . AllowRandomTitleRoot ) ;
			}
			else
			{
				AppSettings . Current . GameTitle = GameTitle . Defult ;
			}

			App . Current . WindowTitle = AppSettings . Current . GameTitle . Content ;
		}

	}

}
