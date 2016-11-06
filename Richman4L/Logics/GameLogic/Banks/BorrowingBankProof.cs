using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L .Banks
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

		public override void StartDay ( GameDate nextDate )
		{
			if ( nextDate >= EndDate )
			{
				Owner . PayForBorrowing ( this ) ;
			}
		}


		public override string ToString ( ) { return $"{nameof ( BorrowingBankProof )} borrowed by {Owner}" ; }

		public override void EndToday ( ) { }

	}

}
