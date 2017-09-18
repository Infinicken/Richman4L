using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . Resources ;

namespace WenceyWang . Richman4L . Logics . Banks
{

	/// <summary>
	///     贷款凭据
	/// </summary>
	public class BorrowingBankProof : BankProof
	{

		/// <summary>
		///     借出的款项数目
		/// </summary>
		public long MoneyBorrowed { get ; set ; }

		/// <summary>
		///     利息率
		/// </summary>
		public double InterestRate { get ; set ; }

		/// <summary>
		///     要归还的金额
		/// </summary>
		public long MoneyToReturn => Convert . ToInt64 ( MoneyBorrowed * ( 1 + InterestRate ) ) ;

		public override void StartDay ( GameDate thisDate )
		{
			if ( thisDate >= EndDate )
			{
				//todo
				//Owner . PayForBorrowing ( this ) ;
			}
		}


		public override string ToString ( )
		{
			return string . Format ( Resource . BorrowingBankProofToString , nameof(BorrowingBankProof) , Owner ) ;
		}

		public override void EndToday ( ) { }

	}

}
