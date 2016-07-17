using WenceyWang . Richman4L . Maps;

namespace WenceyWang . Richman4L . App . CharacterMapRenderer . MapObjectRenderer
{

	public interface ICharacterMapObjectRenderer
	{

		ConsoleChar [ , ] CurrentView { get; }

		void Update ( );

		void StartUp ( );

		void SetUnit ( ConsoleSize unit );

		void SetTarget ( MapObject target );

		ConsoleSize Unit { get; }

		MapObject Target { get; }

	}

}