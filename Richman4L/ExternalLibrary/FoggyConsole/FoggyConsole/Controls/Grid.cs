using System . Collections . Generic ;

using FoggyConsole . Controls . Renderers ;

namespace FoggyConsole .Controls
{

	public class Grid : ItemsControl
	{

		public override bool CanFocus => false ;

		public override IList < Control > Items { get ; } = new List < Control > ( ) ;

		public Grid ( IControlRenderer renderer ) : base ( renderer ?? new GridRanderer ( ) ) { }

	}

}
