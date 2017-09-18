using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Calendars ;

namespace WenceyWang . Richman4L . Logics . Auctions
{

	/// <summary>
	///     表示拍卖请求
	/// </summary>
	public sealed class AuctionRequest : GameObject
	{

		public IAsset Asset { get ; }

		public long StartPrice { get ; }

		public WithAssetObject Beneficiary { get ; }

		public AuctionRequest ( long startPrice , WithAssetObject beneficiary , IAsset asset )
		{
			Beneficiary = beneficiary ;
			Asset = asset ;
			StartPrice = startPrice ;
		}

		public override void EndToday ( ) { }

		public override void StartDay ( GameDate nextDate ) { }

	}

}
