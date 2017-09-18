using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Apps . Console . MapRenderers . MapObjectRenderer
{

	public interface ICharacterMapObjectRenderer
	{

		ConsoleChar [ , ] CurrentView { get ; }

		ConsoleSize Unit { get ; }

		MapObject Target { get ; }

		void Update ( ) ;

		void StartUp ( ) ;

		void SetUnit ( ConsoleSize unit ) ;

		void SetTarget ( MapObject target ) ;

	}

}
