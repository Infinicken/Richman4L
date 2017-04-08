using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains
{

	public class IntegerIntervalDefineDomain : ArgumentValueDefineDomain
	{

		public long LeftEndpoint { get ; }

		public bool IsLeftClosed { get ; }


		public long RightEndpoint { get ; }

		public bool IsRightClosed { get ; }

		public IntegerIntervalDefineDomain ( long leftEndpoint , bool isLeftClosed , long rightEndpoint , bool isRightClosed )
		{
			LeftEndpoint = leftEndpoint ;
			IsLeftClosed = isLeftClosed ;
			RightEndpoint = rightEndpoint ;
			IsRightClosed = isRightClosed ;
		}


		public override bool IsValid ( [NotNull] object value )
		{
			if ( value == null )
			{
				return false ;
			}

			try
			{
				long number = Convert . ToInt64 ( value ) ;
				bool valid = true ;

				if ( IsLeftClosed )
				{
					valid &= number >= LeftEndpoint ;
				}
				else
				{
					valid &= number > LeftEndpoint ;
				}

				if ( IsRightClosed )
				{
					valid &= number <= RightEndpoint ;
				}
				else
				{
					valid &= number < RightEndpoint ;
				}

				return valid ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

}
