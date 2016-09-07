using System ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L .Banks
{

	/// <summary>
	///     表示银行
	/// </summary>
	public class Bank : GameObject
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

		//Todo:贷款

		public SavingBankProof Deposit ( Player owner , long money , int takeTime )
		{
			if ( owner == null )
			{
				throw new ArgumentNullException ( nameof ( owner ) ) ;
			}
			if ( Game . Current . Calendar . Today . Date + takeTime >= Game . Current . GameLenth )
			{
				throw new ArgumentOutOfRangeException ( nameof ( takeTime ) ) ;
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

		public override void StartDay ( GameDate nextDate ) { }

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

	}

}
