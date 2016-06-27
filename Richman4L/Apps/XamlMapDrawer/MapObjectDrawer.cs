using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

using Windows . Foundation ;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Media . Animation;

namespace WenceyWang . Richman4L . App . XamlMapDrawer
{
	public abstract class MapObjectDrawer : UserControl
	{


		public abstract Size Size ( ) ;

		public abstract void Show ( );

		public abstract void Hide ( );

	}
}
