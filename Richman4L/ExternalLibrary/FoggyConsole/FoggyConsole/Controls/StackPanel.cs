using System ;
using System . Collections . Generic ;

using FoggyConsole . Controls . Renderers ;

namespace FoggyConsole .Controls
{

	public class StackPanel : ItemsControl
	{

		public override bool CanFocus => false ;

		public override IList < Control > Items { get ; } = new List < Control > ( ) ;

		public StackPanel ( IControlRenderer renderer ) : base ( renderer ?? new StackPanelRanderer ( ) ) { }

		public override void Arrange ( Rectangle finalRect )
		{
			int currentHeight = 0 ;
			for ( int i = 0 ; ( i < Items . Count ) && ( currentHeight < finalRect . Height ) ; i++ )
			{
				Control control = Items [ i ] ;
				control . Arrange ( new Rectangle ( finalRect . LeftTopPoint . Offset ( 0 , currentHeight ) ,
													new Size ( Math . Min ( finalRect . Width , control . Width ) ,
																Math . Min ( Math . Max ( finalRect . Height - currentHeight , 0 ) , control . Height ) ) ) ) ;
			}

			base . Arrange ( finalRect ) ;
		}

		public override void Measure ( Size availableSize )
		{
			foreach ( Control control in Items )
			{
				control . Measure ( new Size ( Math . Min ( availableSize . Width , control . Width ) , control . Height ) ) ;
			}

			base . Measure ( availableSize ) ;
		}

	}

}
