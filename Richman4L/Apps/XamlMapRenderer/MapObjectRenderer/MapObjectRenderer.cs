using Windows . Foundation ;
using Windows . UI . Xaml . Controls ;

namespace WenceyWang . Richman4L . App . XamlMapRenderer . MapObjectRenderer
{
	//public abstract class MapObjectRenderer<T> : UserControl, IMapObjectRenderer<T> where T : MapObject
	//{
	//	public T Target { get; private set; }

	//	public MapObjectRenderer ( ) {

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

	public abstract class MapObjectRenderer : UserControl
	{


		public abstract Size Size { get; }

		public abstract void Show ( );

		public abstract void Hide ( );


	}

}
