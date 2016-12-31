using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L .Auctions
{

	/// <summary>
	///     表示拍卖请求
	/// </summary>
	public abstract class AuctionRequest
	{

		public abstract WithAssetObject Owner { get ; }

		public long StartMoney { get ; }

		public Player Beneficiary { get ; }

		protected AuctionRequest ( long startMpney , Player beneficiary )
		{
			Beneficiary = beneficiary ;
			StartMoney = startMpney ;
		}

	}

}
