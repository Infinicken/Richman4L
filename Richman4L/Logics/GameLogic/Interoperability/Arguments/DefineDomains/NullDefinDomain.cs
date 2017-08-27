using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains
{

	public class NullDefineDomain : ArgumentValueDefineDomain
	{

		public override bool IsValid ( object value ) { return false ; }

	}

}
