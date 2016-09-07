namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws a <code>Progressbar</code>-control
	/// </summary>
	public class ProgressBarRenderer : ControlRenderer < Progressbar >
	{

		/// <summary>
		///     The character which is used to draw the bar
		/// </summary>
		public char ProgressChar { get ; set ; } = '|' ;

		public ProgressBarRenderer ( Progressbar control )
			: base ( control ) { }

		/// <summary>
		///     Draws the Progressbar given in the Control-Property
		/// </summary>
		public override void Draw ( )
		{
			base . Draw ( ) ;

			int totalWidth = Control . Width - 2 ;
			int barWidth = ( int ) ( totalWidth * ( Control . Value / 100f ) ) ;
			string str = $"[{new string ( ProgressChar , barWidth )}{new string ( ' ' , totalWidth - barWidth )}]" ;

			//FogConsole . Write ( Boundary . Left , Boundary . Top , str , Boundary , Control . ForegroundColor , Control . BackgroundColor );
		}

	}

}
