using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics ;

namespace WenceyWang . Richman4L . Apps . Wpf . Logic
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
