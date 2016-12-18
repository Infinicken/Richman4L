using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Banks ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . Players .PayReasons
{

	public class PayForBorrowingReason : PayReason
	{

		[NotNull]
		public BorrowingBankProof Proof { get ; }

		public PayForBorrowingReason ( [NotNull] BorrowingBankProof proof )
		{
			if ( proof == null )
			{
				throw new ArgumentNullException ( nameof ( proof ) ) ;
			}

			Proof = proof ;
		}

	}

}
