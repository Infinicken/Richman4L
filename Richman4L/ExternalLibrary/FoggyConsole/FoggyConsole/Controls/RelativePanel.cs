using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	public class RelativePanel : ItemsControl
	{

		public override bool CanFocus => false ;

		public override IList < Control > Items { get ; } = new List < Control > ( ) ;

		public RelativePanel ( IControlRenderer renderer ) : base ( renderer ?? new RelativePanelRanderer ( ) ) { }

		public override void Arrange ( Rectangle finalRect ) { base . Arrange ( finalRect ) ; }

		public override void Measure ( Size availableSize )
		{
			foreach ( Control control in Items )
			{
				control . Measure ( availableSize ) ;
			}

			base . Measure ( availableSize ) ;
		}

	}

	public class RelativePanelRanderer : ControlRenderer < RelativePanel >
	{

		public override void Draw ( )
		{
			foreach ( Control control in Control . Items )
			{
				Control . Draw ( ) ;
			}
		}

	}

}
