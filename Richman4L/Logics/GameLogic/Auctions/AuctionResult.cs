using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using WenceyWang . Richman4L . Players;

namespace WenceyWang . Richman4L . Auctions
{
	/// <summary>
	/// 表示拍卖的结果
	/// </summary>
	public class AuctionResult
	{
		public long ResultMoney { get; set; }

		public Player Buyer { get; set; }


	}
}
