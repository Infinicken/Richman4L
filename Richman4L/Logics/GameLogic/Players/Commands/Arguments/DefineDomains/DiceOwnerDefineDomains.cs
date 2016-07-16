using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . Players . Commands . Arguments . DefineDomains
{
	public class DiceOwnerDefineDomains : ArgumentValueDefineDomain
	{
		[NotNull]
		public Player Target { get; set; }

		public DiceOwnerDefineDomains ( Player target )
		{
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof ( target ) );
			}

			Target = target;
		}

		public override bool IsValid ( object value )
		{
			try
			{
				return Target . DiceList . Contains ( ( DiceType ) value );
			}
			catch ( Exception )
			{
				return false;
			}
		}

	}
}
