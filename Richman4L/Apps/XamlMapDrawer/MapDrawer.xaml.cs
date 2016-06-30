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
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . XamlMapDrawer
{

	public sealed partial class MapDrawer : UserControl, IMapDrawer
	{

		[NotNull]
		public static MapObjectDrawerType RegisMapObjectDrawer ( [NotNull]Type mapDrawerType , [NotNull] Type targetType )
		{
			if ( mapDrawerType == null )
			{
				throw new ArgumentNullException ( nameof ( mapDrawerType ) );
			}
			if ( targetType == null )
			{
				throw new ArgumentNullException ( nameof ( targetType ) );
			}

			MapObjectDrawerType type = new MapObjectDrawerType ( mapDrawerType , targetType ) ;

			return type;
		}

		public static List<MapObjectDrawerType> MapObjectDrawerTypeList { get; }

		public MapDrawer ( )
		{

			this . InitializeComponent ( );

		}

		public Map Target { get; private set; } = null;

		public void SetMap ( Map map )
		{
			if ( Target != null )
			{
				throw new InvalidOperationException ( $"this {nameof ( MapDrawer )} have {nameof ( Target )} now." );
			}
			Target = map;
			Target . RegisMapDrawer ( this );
			Target . AddMapObjectEvent += Map_AddMapObjectEvent;
		}

		private void Map_AddMapObjectEvent ( object sender , EventArgs e )
		{

		}

		public void DrawerCatched ( )
		{
			foreach ( MapObject mapObject in Target . Objects )
			{

			}
		}

	}

}
