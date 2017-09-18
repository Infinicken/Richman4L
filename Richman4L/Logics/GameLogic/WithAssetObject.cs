using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Players ;
using WenceyWang . Richman4L . Logics . Players . PayReasons ;

namespace WenceyWang . Richman4L . Logics
{

	public abstract class WithAssetObject : GameObject
	{

		public decimal Cash { get ; protected set ; }

		public decimal DemandDeposits { get ; protected set ; }

		public abstract IEnumerable <IAsset> Assets { get ; }

		public abstract void ReceiveTransactionRequest ( AssetTransactionAgreement request ) ;

		public abstract void RequestPay ( WithAssetObject source , PayMoneyReason reason ) ;

		public abstract void RequestAsset ( WithAssetObject source , IAsset asset , PayMoneyReason reason ) ;

		public abstract void ReceiveCash ( WithAssetObject source , decimal amount , PayMoneyReason reason ) ;

		public abstract void ReceiveCheck ( WithAssetObject source , decimal amount , PayMoneyReason reason ) ;

		public abstract void ReceiveTransfer ( WithAssetObject source , decimal amount , PayMoneyReason reason ) ;

		public abstract void ReceivePayReason ( PayMoneyReason reason ) ;

	}

}
