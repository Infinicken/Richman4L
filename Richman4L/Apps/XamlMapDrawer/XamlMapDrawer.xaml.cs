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

using WenceyWang . Richman4L . App . XamlMapDrawer . MapObjectDrawers ;
using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . XamlMapDrawer
{

	public sealed partial class XamlMapDrawer : UserControl, IMapDrawer
	{


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

			MapObjectDrawerType type = MapObjectDrawerTypeList . Find ( typ => typ . EntryType == mapDrawerType && typ . TargetType == targetType );

			if ( type != null )
			{
				return type;
			}

			type = new MapObjectDrawerType ( mapDrawerType , targetType );
			MapObjectDrawerTypeList . Add ( type );
			return type;
		}

		public Size ObjectDrawerSize { get; set; }

		public static List<MapObjectDrawerType> MapObjectDrawerTypeList { get; }

		public XamlMapDrawer ( )
		{

			this . InitializeComponent ( );

		}

		public Map Target { get; private set; } = null;

		public void SetMap ( Map map )
		{
			if ( Target != null )
			{
				throw new InvalidOperationException ( $"this {nameof ( XamlMapDrawer )} have {nameof ( Target )} now." );
			}
			Target = map;
			Target . RegisMapDrawer ( this );





			foreach ( MapObject mapObject in Target . Objects )
			{
				Type drawerType = MapObjectDrawerTypeList . FirstOrDefault ( ( drawer ) => drawer . TargetType == mapObject . GetType ( ) ) . EntryType;
				MapObjectDrawer objectDrawer = ( MapObjectDrawer ) Activator . CreateInstance ( drawerType );
				objectDrawer . RenderTransform = objectDrawer . Size . TransformTo ( ObjectDrawerSize );

			}




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
