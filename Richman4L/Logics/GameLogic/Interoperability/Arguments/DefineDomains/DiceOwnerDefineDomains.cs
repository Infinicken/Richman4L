using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Interoperability . Arguments . DefineDomains
{

	public class DiceOwnerDefineDomains : ArgumentValueDefineDomain <DiceType>
	{

		[NotNull]
		public Player Target { get ; }

		public DiceOwnerDefineDomains ( Player target )
		{
			Target = target ?? throw new ArgumentNullException ( nameof(target) ) ;
		}

		public override bool IsValid ( DiceType value ) { return Target . IsDiceAviliable ( value ) ; }

	}

}
