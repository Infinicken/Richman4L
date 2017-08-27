using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps
{

	[AttributeUsage ( AttributeTargets . Class )]
	public sealed class MapObjectAttribute : Attribute
	{

		public string Name { get ; }

		public string Introduction { get ; }

		public MapObjectAttribute ( string name , string introduction )
		{
			Name = name ;
			Introduction = introduction ;
		}

	}

}
