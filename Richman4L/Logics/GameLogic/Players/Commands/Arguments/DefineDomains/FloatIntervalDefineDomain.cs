using System ;

using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . Players . Commands . Arguments .DefineDomains
{

	public class FloatIntervalDefineDomain : ArgumentValueDefineDomain
	{

		public double LeftEndpoint { get ; }

		public bool IsLeftClosed { get ; }


		public double RightEndpoint { get ; }

		public bool IsRightClosed { get ; }

		public FloatIntervalDefineDomain ( double leftEndpoint , bool isLeftClosed , double rightEndpoint , bool isRightClosed )
		{
			LeftEndpoint = leftEndpoint ;
			IsLeftClosed = isLeftClosed ;
			RightEndpoint = rightEndpoint ;
			IsRightClosed = isRightClosed ;
		}


		public override bool IsValid ( [ NotNull ] object value )
		{
			if ( value == null )
			{
				return false ;
			}

			try
			{
				double number = Convert . ToDouble ( value ) ;
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
