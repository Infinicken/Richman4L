using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Banks
{
	/// <summary>
	/// 表示银行
	/// </summary>
	public class Bank : GameObject
	{
		/// <summary>
		/// 存款利率基础值
		/// </summary>
		public double SavingInterestRateBase { get; set; }

		/// <summary>
		/// 贷款利率基础值
		/// </summary>
		public double BorrowingInterestRateBase { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public double SavingInterestRateIncrease { get; set; }


		public double BorrowingInterestRateIncrease { get; set; }

		//Todo:贷款

		public SavingBankProof Deposit ( Players . Player owner , long money , int takeTime )
		{
			if ( owner == null )
			{
				throw new ArgumentNullException ( nameof ( owner ) );
			}
			if ( Game . Current . Calendar . Today . Date + takeTime >= Game . Current . GameLenth )
			{
				throw new ArgumentOutOfRangeException ( nameof ( takeTime ) );
			}
			return new SavingBankProof { Owner = owner , StartDate = Game . Current . Calendar . Today , EndDate = Game . Current . Calendar . Today + takeTime , MoneySaved = money , InterestRate = SavingInterestRateBase };
		}

		public override void StartDay ( Calendars . GameDate nextDate )
		{

		}

		public override void EndToday ( )
		{
			throw new NotImplementedException ( );
		}
	}
}
