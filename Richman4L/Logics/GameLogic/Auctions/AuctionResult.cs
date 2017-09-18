using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . GameEnviroment ;

namespace WenceyWang . Richman4L . Logics . Auctions
{

	/// <summary>
	///     表示拍卖的结果
	/// </summary>
	public class AuctionResult
	{

		public long ResultMoney { get ; set ; }

		public WithAssetObject Buyer { get ; set ; }

	}


	public class AuctionPerformer
	{

		public static AuctionPerformer Current => Game . Current . AuctionPerformer ;

		public void PerformAuction ( AuctionRequest request )
		{
			foreach ( PlayerConsole console in Game . Current . Consoles )
			{
				console . StartAuction ( request ) ;
			}
		}

	}

}
