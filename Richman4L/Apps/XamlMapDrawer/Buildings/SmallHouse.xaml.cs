using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;

using Windows . Foundation;
using Windows . Foundation . Collections;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Controls . Primitives;
using Windows . UI . Xaml . Data;
using Windows . UI . Xaml . Input;
using Windows . UI . Xaml . Media;
using Windows . UI . Xaml . Navigation;

using WenceyWang . Richman4L . Maps . Buildings;

namespace WenceyWang . Richman4L . App . XamlMapDrawer . Buildings
{
	public sealed partial class SmallHouse : MapObjectDrawer<SmallSimpleBuilding>
	{
		public SmallHouse ( )
		{
			this . InitializeComponent ( );
		}


		public override Size Size ( ) { return new Size ( 120 , 60 ); }

		public override void Show ( )
		{
			//todo:
		}

		public override void Hide ( )
		{
			//todo:
		}

	}
}
