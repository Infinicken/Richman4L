using System ;
using System . Collections ;
using System . Linq ;

using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	public class PageRanderer : ControlRenderer < Page >
	{

		public override void Draw ( ) { Control . Content ? . Draw ( ) ; }

	}

}
