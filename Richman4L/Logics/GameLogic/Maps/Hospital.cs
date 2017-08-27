using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Maps . Roads ;

namespace WenceyWang . Richman4L . Maps
{

	[MapObject ( nameof(Hospital) , "" )]
	[Guid ( "C46422D7-6112-44E4-A64A-52E4822AD633" )]
	public class Hospital : NormalRoad
	{

		public Hospital ( XElement resource ) : base ( resource ) { }

	}

}
