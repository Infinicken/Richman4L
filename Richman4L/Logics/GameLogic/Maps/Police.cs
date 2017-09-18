using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Logics . Maps . Roads ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	[MapObject]
	[Guid ( "778AA9A2-1432-4A03-A0AF-7D8003166280" )]
	public class Police : NormalRoad
	{

		public Police ( XElement resource ) : base ( resource ) { }

	}

}
