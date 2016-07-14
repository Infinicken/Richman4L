using System ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Media ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{
	static class OcdModeHelper
	{
		internal static void TurnOnOcdMode ( this Panel panel , Random random = null )
		{
			Random rand = random ?? GameRandom . Current;
			foreach ( UIElement item in panel . Children )
			{
				if ( item is Panel )
				{
					( item as Panel ) . TurnOnOcdMode ( rand );
				}
				else
				{
					( ( item as ContentControl )?.Content as Panel )?.TurnOnOcdMode ( rand );

					item . RenderTransform = new CompositeTransform
					{
						TranslateX = ( rand . Next ( 10 ) - 5 ) ,
						TranslateY = ( rand . Next ( 10 ) - 5 ) ,
						Rotation = ( ( rand . NextDouble ( ) * 10d ) - 5d ) ,
					};

				}
			}
		}
	}

}

