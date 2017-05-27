using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains
{

	public class DiceOwnerDefineDomains : ArgumentValueDefineDomain <DiceType>
	{

		[NotNull]
		public Player Target { get ; }

		public DiceOwnerDefineDomains ( Player target )
		{
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof(target) ) ;
			}

			Target = target ;
		}

		public override bool IsValid ( DiceType value ) { return Target . IsDiceAviliable ( value ) ; }

	}

}
