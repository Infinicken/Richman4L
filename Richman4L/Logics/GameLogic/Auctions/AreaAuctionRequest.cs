using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Auctions
{

	public class AreaAuctionRequest : AuctionRequest
	{

		public Area Area { get ; }

		public override WithAssetObject Owner => Area . Owner ;

		public AreaAuctionRequest ( Area area , long startMoney , Player beneficiary = null )
			: base ( startMoney , beneficiary )
		{
			Area = area ;
		}

	}

}
