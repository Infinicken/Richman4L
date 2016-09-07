namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws an <code>Playground</code>
	/// </summary>
	public class PlaygroundRenderer : ControlRenderer < Playground >
	{

		/// <summary>
		/// </summary>
		/// <param name="control"></param>
		public PlaygroundRenderer ( Playground control )
			: base ( control ) { }

		/// <summary>
		///     Draws all characters within the given playground
		/// </summary>
		public override void Draw ( )
		{
			base . Draw ( ) ;

			for ( int y = 0 ; y < Control . Height ; y++ )
			{
				for ( int x = 0 ; x < Control . Width ; x++ )
				{
					//FogConsole . Write ( Boundary . Left ,
					//				Boundary . Top + y ,
					//				Control [ y , x ] ,
					//				Boundary ,
					//				Control . ForegroundColor , Control . BackgroundColor );
				}
			}
		}

	}

}
