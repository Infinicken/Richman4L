using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;
using Windows . Foundation;
using Windows . Foundation . Collections;
using Windows . UI;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . ViewManagement;
using Windows . UI . Xaml . Media . Animation;
using Windows . UI . Xaml . Controls . Primitives;
using Windows . UI . Xaml . Data;
using Windows . UI . Xaml . Input;
using Windows . UI . Xaml . Media;
using Windows . UI . Xaml . Shapes;
using Windows . UI . Xaml . Navigation;


namespace WenceyWang . Richman4L . App . Logic
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

