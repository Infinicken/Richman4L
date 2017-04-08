using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Auctions
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

		public void PerformAuction ( AuctionRequest request )
		{
			foreach ( PlayerConsole console in Game . Current . Consoles )
			{
				console . StartAuction ( request ) ;
			}
		}

	}

}
