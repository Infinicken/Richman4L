using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L .Auctions
{
	/// <summary>
	/// 表示拍卖请求
	/// </summary>
	public abstract class AuctionRequest
	{

		public abstract Player Owner { get ; }

		public long StartMoney { get ; }

		public Player Beneficiary { get ; }

		protected AuctionRequest ( long startMpney , Player beneficiary )
		{
			Beneficiary = beneficiary ;
			StartMoney = startMpney ;
		}

	}
}
