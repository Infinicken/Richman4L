using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains
{

	public class IntegerIntervalDefineDomain : ArgumentValueDefineDomain <long>
	{

		public long LeftEndpoint { get ; }

		public bool IsLeftClosed { get ; }


		public long RightEndpoint { get ; }

		public bool IsRightClosed { get ; }

		public IntegerIntervalDefineDomain ( long leftEndpoint ,
											bool isLeftClosed ,
											long rightEndpoint ,
											bool isRightClosed )
		{
			LeftEndpoint = leftEndpoint ;
			IsLeftClosed = isLeftClosed ;
			RightEndpoint = rightEndpoint ;
			IsRightClosed = isRightClosed ;
		}


		public override bool IsValid ( long value )
		{
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
