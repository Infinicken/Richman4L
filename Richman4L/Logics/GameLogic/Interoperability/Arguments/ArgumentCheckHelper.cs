using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace WenceyWang . Richman4L . Interoperability . Arguments
{
	internal static class ArgumentCheckHelper
	{
		internal static void CheckArgument ( this List<ArgumentInfo> info , ArgumentsContainer container )
		{
			if ( info == null )
			{
				throw new ArgumentNullException ( nameof ( info ) );
			}
			if ( container == null )
			{
				throw new ArgumentNullException ( nameof ( container ) );
			}

			if ( info . Count != container . Arguments . Count )
			{
				throw new ArgumentException ( );
			}

			for ( int i = 0 ; i < info . Count ; i++ )
			{
				ArgumentInfo argumentInfo = info [ i ];
				object argument = container . Arguments [ i ];

				if ( argumentInfo . Type != argument . GetType ( ) )
				{
					throw new ArgumentException ( );
				}
				if ( !argumentInfo . DefineDomain . IsValid ( argument ) )
				{
					throw new ArgumentException ( );
				}

			}

		}
	}
}
