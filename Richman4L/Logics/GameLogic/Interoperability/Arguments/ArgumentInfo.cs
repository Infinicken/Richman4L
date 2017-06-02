using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;

namespace WenceyWang . Richman4L . Interoperability . Arguments
{

	public class ArgumentInfo
	{

		public string Name { get ; }

		public string Introduction { get ; }

		public Type Type { get ; }

		public ArgumentValueDefineDomain DefineDomain { get ; }

		public ArgumentInfo ( string name ,
							string introduction ,
							Type type ,
							ArgumentValueDefineDomain defineDomain )
		{
			Name = name ?? throw new ArgumentNullException ( nameof(name) ) ;
			Introduction = introduction ?? throw new ArgumentNullException ( nameof(introduction) ) ;
			Type = type ?? throw new ArgumentNullException ( nameof(type) ) ;
			DefineDomain = defineDomain ?? throw new ArgumentNullException ( nameof(defineDomain) ) ;
		}

	}

}
