using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Banks ;

namespace WenceyWang . Richman4L . Logics . Players . PayReasons
{

	[PayMoneyReason]
	public sealed class PayMoneyForBorrowingReason : PayMoneyReason
	{

		[NotNull]
		public BorrowingBankProof Proof { get ; }

		public override string Reason => throw new NotImplementedException ( ) ;

		public PayMoneyForBorrowingReason ( [CanBeNull] BorrowingBankProof proof ) :
			base ( proof ? . MoneyToReturn ?? throw new ArgumentNullException ( nameof(proof) ) ,
					proof ? . Owner ?? throw new ArgumentNullException ( nameof(proof) ) )
		{
			Proof = proof ?? throw new ArgumentNullException ( nameof(proof) ) ;
		}

	}

}
