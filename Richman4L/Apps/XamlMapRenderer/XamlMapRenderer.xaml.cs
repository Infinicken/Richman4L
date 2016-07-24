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

using WenceyWang . Richman4L . App . XamlMapRenderer . MapObjectRenderer ;
using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . XamlMapRenderer
{

	public sealed partial class XamlMapRenderer : UserControl, IMapRenderer
	{


		public static MapObjectRendererType RegisMapObjectRenderer ( [NotNull]Type mapRendererType , [NotNull] Type targetType )
		{
			if ( mapRendererType == null )
			{
				throw new ArgumentNullException ( nameof ( mapRendererType ) );
			}
			if ( targetType == null )
			{
				throw new ArgumentNullException ( nameof ( targetType ) );
			}

			MapObjectRendererType type = MapObjectRendererTypeList . Find ( typ => typ . EntryType == mapRendererType && typ . TargetType == targetType );

			if ( type != null )
			{
				return type;
			}

			type = new MapObjectRendererType ( mapRendererType , targetType );
			MapObjectRendererTypeList . Add ( type );
			return type;
		}

		public Size ObjectRendererSize { get; set; }

		public static List<MapObjectRendererType> MapObjectRendererTypeList { get; }

		public XamlMapRenderer ( )
		{
			InitializeComponent ( );

		}

		public Map Target { get; private set; } = null;

		public void SetMap ( Map map )
		{
			if ( Target != null )
			{
				throw new InvalidOperationException ( $"this {nameof ( XamlMapRenderer )} have {nameof ( Target )} now." );
			}
			Target = map;
			Target . RegisMapRenderer ( this );





			foreach ( MapObject mapObject in Target . Objects )
			{
				Type rendererType = MapObjectRendererTypeList . FirstOrDefault ( ( renderer ) => renderer . TargetType == mapObject . GetType ( ) ) . EntryType;
				MapObjectRenderer . MapObjectRenderer objectRenderer = ( MapObjectRenderer . MapObjectRenderer ) Activator . CreateInstance ( rendererType );
				objectRenderer . RenderTransform = objectRenderer . Size . TransformTo ( ObjectRendererSize );

			}




			Target . AddMapObjectEvent += Map_AddMapObjectEvent;
		}

		private void Map_AddMapObjectEvent ( object sender , EventArgs e )
		{

		}

		public void RendererCatched ( )
		{
			foreach ( MapObject mapObject in Target . Objects )
			{

			}
		}

	}

}
