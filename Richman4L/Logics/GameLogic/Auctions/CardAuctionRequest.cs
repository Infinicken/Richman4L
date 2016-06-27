using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . Auctions
{
	public class CardAuctionRequest : AuctionRequest
	{
		public Cards . Card Card { get; set; }

		public override Player Owner => Card . Owner;

		public CardAuctionRequest ( Cards . Card card , long startMoney , Player beneficiary = null ) : base ( startMoney , beneficiary )
		{
			Card = card;
		}

	}

}
