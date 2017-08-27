using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps
{

	public interface IMapObjectRenderer <T> : IMapObjectRenderer where T : MapObject
	{

		new T Target { get ; }

		//void Update ( );

		//void StartUp ( );

		void SetTarget ( T target ) ;

	}

	public interface IMapObjectRenderer
	{

		MapObject Target { get ; }

		void Update ( ) ;

		void StartUp ( ) ;

		void SetTarget ( MapObject target ) ;

	}

}
