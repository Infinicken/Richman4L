using System;

namespace FoggyConsole . Controls . Renderers
{

	/// <summary>
	///     Draws a <code>Label</code>-Control
	/// </summary>
	public class LabelRenderer : TextualBaseRenderer<Label>
	{

		/// <summary>
		///     Creates a new <code>LabelRenderer</code>
		/// </summary>
		/// <param name="control"></param>
		public LabelRenderer ( Label control )
			: base ( control , "{1}" , 0 ) { }

		/// <summary>
		///     Draws the <code>Label</code> given in the Control-Property.
		/// </summary>
		/// <exception cref="InvalidOperationException">Is thrown if the Control-Property isn't set.</exception>
		/// <exception cref="InvalidOperationException">Is thrown if the CalculateBoundary-Method hasn't been called.</exception>
		public override void Draw ( )
		{
			base . Draw ( );

			string text = Control . Text;
			if ( text . Length > Control . RenderArea . Width )
			{
				text = text . Substring ( 0 , Control . RenderArea. Width );
			}
			else
			{
				switch ( Control . Align )
				{
					case ContentAlign . Left:
						{
							text = text . PadRight ( Control . RenderArea. Width );
							break;
						}
					case ContentAlign . Center:
						{
							string fillStr = new string ( ' ' , ( Control . RenderArea. Width - text . Length ) / 2 );
							text = fillStr + text + fillStr;
							break;
						}
					case ContentAlign . Right:
						{
							text = text . PadLeft ( Control . RenderArea. Width );
							break;
						}
				}
			}

			base . Draw ( Control . ForegroundColor , Control . BackgroundColor , text );
		}

	}

}
