using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . Players . Commands . Arguments .DefineDomains
{

	public abstract class ArgumentValueDefineDomain
	{

		public abstract bool IsValid ( [ NotNull ] object value ) ;

	}

}
