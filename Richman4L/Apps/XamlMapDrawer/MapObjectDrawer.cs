using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

using Windows . Foundation;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Media . Animation;

using WenceyWang . Richman4L . Maps;

namespace WenceyWang . Richman4L . App . XamlMapDrawer
{
	public abstract class MapObjectDrawer<T> : UserControl, IMapObjectDrawer<T> where T : MapObject
	{
		public T Target { get; private set; }

		public MapObjectDrawer ( ) {
			
		}

		public abstract Size Size ( );

		public abstract void Show ( );

		public abstract void Hide ( );

		public void Update ( )
		{

		}

		public void SetTarget ( T target )
		{

		}
	}

	//public abstract class MapObjectDrawer : UserControl, IMapObjectDrawer<MapObject>
	//{
	//	public MapObject Target { get; private set; }

	//	public abstract Size Size ( );

	//	public abstract void Show ( );

	//	public abstract void Hide ( );

	//	public void Update ( )
	//	{

	//	}

	//	public void SetTarget ( MapObject target )
	//	{

	//	}
	//}

}
