using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . Auctions
{
	public class AreaAuctionRequest : AuctionRequest
	{

		public Maps . Area Area { get; }

		public override Player Owner => Area . Owner;

		public AreaAuctionRequest ( Maps . Area area , long startMoney , Player beneficiary = null ) : base ( startMoney , beneficiary )
		{
			Area = area;
		}

	}

}