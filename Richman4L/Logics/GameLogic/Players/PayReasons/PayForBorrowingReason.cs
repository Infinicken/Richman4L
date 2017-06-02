using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Banks ;

namespace WenceyWang . Richman4L . Players . PayReasons
{

	public class PayForBorrowingReason : PayReason
	{

		[NotNull]
		public BorrowingBankProof Proof { get ; }

		public PayForBorrowingReason ( [NotNull] BorrowingBankProof proof )
		{
			Proof = proof ?? throw new ArgumentNullException ( nameof(proof) ) ;
		}

	}

}
