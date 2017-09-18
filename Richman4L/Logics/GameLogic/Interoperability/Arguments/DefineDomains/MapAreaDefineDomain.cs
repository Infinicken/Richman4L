using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps ;

namespace WenceyWang . Richman4L . Logics . Interoperability . Arguments . DefineDomains
{

	public class MapAreaDefineDomain : ArgumentValueDefineDomain <MapObject>
	{

		public MapArea Area { get ; }

		public MapAreaDefineDomain ( MapArea area ) { Area = area ; }

		public override bool IsValid ( MapObject value )
		{
			try
			{
				return Area . IsInArea ( value ) ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

}
