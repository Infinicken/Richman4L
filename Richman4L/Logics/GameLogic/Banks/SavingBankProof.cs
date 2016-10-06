using System ;

using WenceyWang . Richman4L . Calendars ;

namespace WenceyWang . Richman4L .Banks
{

	/// <summary>
	///     存款凭据
	/// </summary>
	public class SavingBankProof : BankProof
	{

		/// <summary>
		///     存款数额
		/// </summary>
		public long MoneySaved { get ; set ; }

		/// <summary>
		///     利息率
		/// </summary>
		public double InterestRate { get ; set ; }

		/// <summary>
		///     能够取出的金额
		/// </summary>
		public long MoneyToGet
		{
			get
			{
				if ( Game . Current . Calendar . Today >= EndDate )
				{
					return Convert . ToInt64 ( MoneySaved * ( 1 + InterestRate ) ) ;
				}

				return MoneySaved ;
			}
		}

		public override void StartDay ( GameDate nextDate )
		{
			if ( nextDate >= EndDate )
			{
				Owner . GetFromSaving ( this ) ;
				Dispose ( ) ;
			}
		}

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

	}

}
