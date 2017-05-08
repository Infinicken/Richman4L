using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;
using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Cards
{

	public class MapAreaDefineDomain : ArgumentValueDefineDomain
	{

		public MapArea Area { get ; }

		public MapAreaDefineDomain ( MapArea area ) { Area = area ; }

		public override bool IsValid ( object value )
		{
			try
			{
				return Area . IsInArea ( ( MapObject ) value ) ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

}
