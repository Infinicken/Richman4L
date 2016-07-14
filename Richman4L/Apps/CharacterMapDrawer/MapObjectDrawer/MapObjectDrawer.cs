using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . App . CharacterMapDrawer . MapObjectDrawer
{
	public abstract class MapObjectDrawer<T> : IMapObjectDrawer<T> where T : MapObject
	{
		public abstract char [ , ] CurrentView { get; }

		public abstract void Update ( );

		public abstract void StartUp ( );

		public abstract void SetTarget ( T target );

		public T Target { get; protected set; }

	}
}
