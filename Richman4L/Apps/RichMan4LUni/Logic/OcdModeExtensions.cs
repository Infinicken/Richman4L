using System ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Media ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{

	internal static class OcdModeExtensions
	{

		internal static void TurnOnOcdMode ( this Panel panel , Random random = null )
		{
			if ( panel == null )
			{
				throw new ArgumentNullException ( nameof(panel) ) ;
			}

			Random rand = random ?? GameRandom . Current ;
			foreach ( UIElement item in panel . Children )
			{
				if ( item is Panel )
				{
					( item as Panel ) . TurnOnOcdMode ( rand ) ;
				}
				else
				{
					( ( item as ContentControl ) ? . Content as Panel ) ? . TurnOnOcdMode ( rand ) ;

					item . RenderTransform = new CompositeTransform
											{
												TranslateX = rand . Next ( 10 ) - 5 ,
												TranslateY = rand . Next ( 10 ) - 5 ,
												Rotation = rand . NextDoubleBetween ( - 5 , 5 ) ,
												ScaleX = rand . NextDoubleBetween ( 0.75 , 1.25 ) ,
												ScaleY = rand . NextDoubleBetween ( 0.75 , 1.25 )
											} ;
				}
			}
		}

	}

}
