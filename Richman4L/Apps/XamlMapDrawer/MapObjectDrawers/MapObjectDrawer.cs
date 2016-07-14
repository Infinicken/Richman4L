using Windows . Foundation ;
using Windows . UI . Xaml . Controls ;

namespace WenceyWang . Richman4L . App . XamlMapDrawer . MapObjectDrawers
{
	//public abstract class MapObjectDrawer<T> : UserControl, IMapObjectDrawer<T> where T : MapObject
	//{
	//	public T Target { get; private set; }

	//	public MapObjectDrawer ( ) {

	//	}

	//	public abstract Size Size ( );

	//	public abstract void Show ( );

	//	public abstract void Hide ( );

	//	public void Update ( )
	//	{

	//	}

	//	public void SetTarget ( T target )
	//	{

	//	}
	//}

	public abstract class MapObjectDrawer : UserControl
	{


		public abstract Size Size { get; }

		public abstract void Show ( );

		public abstract void Hide ( );


	}

}
