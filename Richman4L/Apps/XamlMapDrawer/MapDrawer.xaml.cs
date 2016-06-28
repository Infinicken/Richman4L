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

using WenceyWang . Richman4L . Maps;

namespace WenceyWang . Richman4L . App . XamlMapDrawer
{

	public sealed partial class MapDrawer : UserControl, IMapDrawer
	{

		public MapDrawer ( ) { this . InitializeComponent ( ); }

		public Map Map { get; private set; } = null;

		public void SetMap ( Map map )
		{
			if ( Map != null )
			{
				throw new InvalidOperationException ( $"this {nameof ( MapDrawer )} have {nameof ( Map )} now." );
			}
			Map = map;
			Map . RegisMapDrawer ( this );
			Map . AddMapObjectEvent += Map_AddMapObjectEvent;
		}

		private void Map_AddMapObjectEvent ( object sender , EventArgs e )
		{

		}

		public void DrawerCatched ( )
		{
			foreach ( MapObject mapObject in Map . Objects )
			{

			}
		}

	}

}
