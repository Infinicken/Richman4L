using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Banks ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . Players .Events
{

	public class PlayerPayForBorrowingEventArgs : PlayerPayEventArgs
	{

		[ NotNull ]
		public BorrowingBankProof Proof { get ; }

		public override long Money => Proof . MoneyToReturn ;

		public PlayerPayForBorrowingEventArgs ( [ NotNull ] BorrowingBankProof proof )
		{
			if ( proof == null )
			{
				throw new ArgumentNullException ( nameof ( proof ) ) ;
			}

			Proof = proof ;
		}

	}

}
