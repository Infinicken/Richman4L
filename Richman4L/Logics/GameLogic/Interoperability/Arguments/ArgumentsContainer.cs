using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Interoperability .Arguments
{

	public sealed class ArgumentsContainer
	{

		public List <object> Arguments { get ; }

		public ArgumentsContainer ( params object [ ] args ) { Arguments = new List <object> ( args ) ; }

	}

}
