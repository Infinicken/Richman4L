using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Auctions
{

	/// <summary>
	///     表示拍卖请求
	/// </summary>
	public abstract class AuctionRequest
	{

		public Guid Id { get ; } = Guid . NewGuid ( ) ;

		public abstract WithAssetObject Owner { get ; }

		public long StartMoney { get ; }

		public WithAssetObject Beneficiary { get ; }

		protected AuctionRequest ( long startMpney , WithAssetObject beneficiary )
		{
			Beneficiary = beneficiary ;
			StartMoney = startMpney ;
		}

	}

}
