using System ;

namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws a <code>Button</code>-Control
	/// </summary>
	public class ButtonRenderer : TextualBaseRenderer < Button >
	{

		public ButtonRenderer ( Button control = null ) : base ( control , "[ {0} ]" , 4 ) { }

		/// <summary>
		///     Draws the <code>Button</code> given in the Control-Property.
		/// </summary>
		/// <exception cref="InvalidOperationException">Is thrown if the Control-Property isn't set.</exception>
		/// <exception cref="InvalidOperationException">Is thrown if the CalculateBoundary-Method hasn't been called.</exception>
		public override void Draw ( )
		{
			base . Draw ( Control . IsFocused ? Control . BackgroundColor : Control . ForegroundColor ,
						Control . IsFocused ? Control . ForegroundColor : Control . BackgroundColor ) ;
		}

	}

}
