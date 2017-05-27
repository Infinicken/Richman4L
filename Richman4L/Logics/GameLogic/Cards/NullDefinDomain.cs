using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;

namespace WenceyWang . Richman4L . Cards
{

	public class NullDefineDomain : ArgumentValueDefineDomain
	{

		public override bool IsValid ( object value ) { return false ; }

	}

}
