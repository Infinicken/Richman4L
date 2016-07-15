using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . App . CharacterMapDrawer .MapObjectDrawer
{

	public interface ICharacterMapObjectDrawer
	{

		char [ , ] CurrentView { get ; }

		void Update ( ) ;

		void StartUp ( ) ;

		void SetTarget ( MapObject target ) ;

		MapObject Target { get ; }

	}

}