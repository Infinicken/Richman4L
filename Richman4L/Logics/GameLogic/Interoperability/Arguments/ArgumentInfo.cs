using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;

namespace WenceyWang . Richman4L . Interoperability .Arguments
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
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}
			if ( introduction == null )
			{
				throw new ArgumentNullException ( nameof ( introduction ) ) ;
			}
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof ( type ) ) ;
			}
			if ( defineDomain == null )
			{
				throw new ArgumentNullException ( nameof ( defineDomain ) ) ;
			}
			

			Name = name ;
			Introduction = introduction ;
			Type = type ;
			DefineDomain = defineDomain ;
		}

	}

}
