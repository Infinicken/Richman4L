using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer .MapObjectRenderer
{

	public interface ICharacterMapObjectRenderer
	{

		char [ , ] CurrentView { get ; }

		void Update ( ) ;

		void StartUp ( ) ;

		void SetTarget ( MapObject target ) ;

		MapObject Target { get ; }

	}

}