using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	public class PageRanderer : ControlRenderer < Page >
	{

		public override void Draw ( ) { Control . Content . Draw ( ) ; }

	}

}