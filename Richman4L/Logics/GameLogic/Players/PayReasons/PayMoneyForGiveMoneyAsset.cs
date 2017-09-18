using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Players . PayReasons
{

	/// <summary>
	///     钱被作为资产给出的原因
	/// </summary>
	public class PayMoneyForGiveMoneyAsset : PayMoneyReason
	{

		public MoneyAsset Asset { get ; }

		public override string Reason => "Money trans as Asset" ;

		public PayMoneyForGiveMoneyAsset ( MoneyAsset asset , WithAssetObject target ) : base ( asset . Amount , target )
		{
			Asset = asset ;
		}

	}

}
