using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Cards ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Auctions
{

	public class CardAuctionRequest : AuctionRequest
	{

		public Card Card { get ; set ; }

		public override WithAssetObject Owner => Card . Owner ;

		public CardAuctionRequest ( Card card , long startMoney , Player beneficiary = null )
			: base ( startMoney , beneficiary )
		{
			Card = card ;
		}

	}

}
