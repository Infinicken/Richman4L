using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains
{

	public class MoveTypeAbilityDefineDomains : ArgumentValueDefineDomain <MoveType>
	{

		[NotNull]
		public Player Target { get ; }

		public MoveTypeAbilityDefineDomains ( Player target )
		{
			Target = target ?? throw new ArgumentNullException ( nameof(target) ) ;
		}

		public override bool IsValid ( MoveType value )
		{
			try
			{
				return Target . IsMoveTypeAvilibale ( value ) ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

}
