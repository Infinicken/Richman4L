using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Security
{

	public sealed class ValueCheckFailedException : Exception
	{

		public byte [ ] ActualHashCode { get ; set ; }

		public byte [ ] ExpectedHashCode { get ; set ; }

		public ValueCheckFailedException ( byte [ ] actualHashCode , byte [ ] expectedHashCode ) :
			base ( "Hash check failed." )
		{
			ActualHashCode = actualHashCode ;
			ExpectedHashCode = expectedHashCode ;
		}

	}

}
