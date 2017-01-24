using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . Interoperability . Arguments .DefineDomains
{

	public class DiceOwnerDefineDomains : ArgumentValueDefineDomain
	{

		[NotNull]
		public Player Target { get ; }

		public DiceOwnerDefineDomains ( Player target )
		{
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof ( target ) ) ;
			}

			Target = target ;
		}

		public override bool IsValid ( object value )
		{
			try
			{
				return Target . IsDiceAviliable ( ( DiceType ) value ) ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

	public class MoveTypeAbilityDefineDomains : ArgumentValueDefineDomain
	{

		[NotNull]
		public Player Target { get ; }

		public MoveTypeAbilityDefineDomains ( Player target )
		{
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof ( target ) ) ;
			}

			Target = target ;
		}

		public override bool IsValid ( object value )
		{
			try
			{
				return Target . IsMoveTypeAvilibale ( ( MoveType ) value ) ;
			}
			catch ( Exception )
			{
				return false ;
			}
		}

	}

}
