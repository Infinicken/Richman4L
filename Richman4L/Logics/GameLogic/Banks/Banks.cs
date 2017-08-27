using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Players . PayReasons ;

namespace WenceyWang . Richman4L . Banks
{

	/// <summary>
	///     表示银行
	/// </summary>
	public sealed class Bank : WithAssetObject
	{

		/// <summary>
		///     存款利率基础值
		/// </summary>
		public double SavingInterestRateBase { get ; set ; }

		/// <summary>
		///     贷款利率基础值
		/// </summary>
		public double BorrowingInterestRateBase { get ; set ; }

		/// <summary>
		/// </summary>
		public double SavingInterestRateIncrease { get ; set ; }


		public double BorrowingInterestRateIncrease { get ; set ; }

		public static Bank Current => Game . Current . Bank ;

		public override IEnumerable <IAsset> Assets { get ; }

		private Bank ( ) { }

		//Todo:贷款

		public SavingBankProof Deposit ( Player owner , decimal money , int takeTime )
		{
			if ( owner == null )
			{
				throw new ArgumentNullException ( nameof(owner) ) ;
			}
			if ( Game . Current . Calendar . Today . Date + takeTime >= Game . Current . GameLenth )
			{
				throw new ArgumentOutOfRangeException ( nameof(takeTime) ) ;
			}

			return new SavingBankProof
					{
						Owner = owner ,
						StartDate = Game . Current . Calendar . Today ,
						EndDate = Game . Current . Calendar . Today + takeTime ,
						MoneySaved = money ,
						InterestRate = SavingInterestRateBase
					} ;
		}

		public override void StartDay ( GameDate thisDate ) { throw new NotImplementedException ( ) ; }

		public override void ReceiveTransactionRequest ( AssetTransactionAgreement request )
		{
			throw new NotImplementedException ( ) ;
		}

		public override void RequestPay ( WithAssetObject source , PayMoneyReason reason ) { }

		public override void RequestAsset ( WithAssetObject source , IAsset asset , PayMoneyReason reason ) { }

		public override void ReceiveCash ( WithAssetObject source , decimal amount , PayMoneyReason reason ) { }


		public override void ReceiveCheck ( WithAssetObject source , decimal amount , PayMoneyReason reason ) { }

		public override void ReceiveTransfer ( WithAssetObject source , decimal amount , PayMoneyReason reason ) { }

		public override void EndToday ( ) { }

		//}
		//	return asset . MinimumValue * GameRandom . Current . NextDecimalBetween ( 1.0m , 1.2m ) ;
		//{

		//public override decimal ReceiveBuyAssertRequest ( IAsset asset )

		public override void ReceivePayReason ( PayMoneyReason reason ) { throw new NotImplementedException ( ) ; }

	}

}
