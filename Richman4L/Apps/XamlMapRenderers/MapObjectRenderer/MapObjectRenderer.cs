using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

using Windows . Foundation ;
using Windows . UI . Xaml . Controls ;

using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Apps . XamlMapRenderers . MapObjectRenderer
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

	public abstract class MapObjectRenderer : UserControl , IMapObjectRenderer
	{

		public abstract Size Size { get ; }

		public MapPosition Position => ( ( IMapObjectRenderer ) this ) . Target . Position ;


		MapObject IMapObjectRenderer . Target
			=> ( MapObject ) GetType ( ) . GetProperty ( nameof(IMapObjectRenderer . Target) ) . GetValue ( this ) ;

		void IMapObjectRenderer . Update ( )
		{
			GetType ( ) . GetMethod ( nameof(IMapObjectRenderer . Update) ) . Invoke ( this , new object [ ] { } ) ;
		}

		void IMapObjectRenderer . StartUp ( )
		{
			GetType ( ) . GetMethod ( nameof(IMapObjectRenderer . StartUp) ) . Invoke ( this , new object [ ] { } ) ;
		}

		void IMapObjectRenderer . SetTarget ( MapObject target )
		{
			GetType ( ) . GetMethod ( nameof(IMapObjectRenderer . SetTarget) ) . Invoke ( this , new object [ ] { target } ) ;
		}

		public abstract void Show ( ) ;

		public abstract void Hide ( ) ;

	}

}
