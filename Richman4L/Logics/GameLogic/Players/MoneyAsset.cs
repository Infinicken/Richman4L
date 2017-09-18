using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Players . PayReasons ;

namespace WenceyWang . Richman4L . Logics . Players
{

	/// <summary>
	///     钱被作为资产给出
	/// </summary>
	public class MoneyAsset : IAsset
	{

		public long Amount { get ; }

		public WithAssetObject Owner { get ; private set ; }

		public long MinimumValue => Amount ;

		public bool CanGive { get ; }

		public void GiveTo ( WithAssetObject newOwner )
		{
			newOwner . ReceivePayReason ( new PayMoneyForGiveMoneyAsset ( this , Owner ) ) ;
			Owner = newOwner ;
		}

	}

}
