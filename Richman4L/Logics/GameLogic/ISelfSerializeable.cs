using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics
{

	public interface ISelfSerializeable
	{

		[NotNull]
		XElement ToXElement ( ) ;

	}

}
