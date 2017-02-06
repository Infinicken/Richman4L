using System ;
using System . Collections ;
using System . Linq ;

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
		public decimal MoneySaved { get ; set ; }

		/// <summary>
		///     利息率
		/// </summary>
		public double InterestRate { get ; set ; }

		/// <summary>
		///     当前能够取出的金额
		/// </summary>
		public decimal MoneyToGet
		{
			get
			{
				if ( Game . Current . Calendar . Today >= EndDate )
				{
					return Convert . ToDecimal ( MoneySaved * ( decimal ) ( 1 + InterestRate ) ) ;
				}

				return MoneySaved ;
			}
		}

		public override void StartDay ( GameDate nextDate )
		{
			if ( nextDate >= EndDate )
			{
//todo
				//Owner . GetFromSaving ( this ) ;
			}
		}

		public override void EndToday ( ) { throw new NotImplementedException ( ) ; }

	}

}
