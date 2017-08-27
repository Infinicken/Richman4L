using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L
{

	public interface IAsset
	{

		WithAssetObject Owner { get ; }

		long MinimumValue { get ; }

		bool CanGive { get ; }

		void GiveTo ( WithAssetObject newOwner ) ;

	}

}
