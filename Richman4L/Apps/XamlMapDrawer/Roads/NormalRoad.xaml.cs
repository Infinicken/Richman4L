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


namespace WenceyWang . Richman4L . App . XamlMapDrawer . Roads
{
	public sealed partial class NormalRoad : MapObjectDrawer
	{

		public NormalRoad ( ) { this . InitializeComponent ( ); }

		public override void Hide ( ) { }

		public override Size Size ( ) { return new Size ( 112 , 56 ) ; }

		public override void Show ( ) { }

	}
}
