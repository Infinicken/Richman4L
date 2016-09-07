using System ;
using System . Linq ;

namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Base class for all Drawers which can draw an <code>TextualBase</code>
	/// </summary>
	public abstract class TextualBaseRenderer < T > : ControlRenderer < T > where T : TextualBase
	{

		private readonly int _addWidth ;

		private readonly string _format ;

		/// <summary>
		///     Creates a new TextualBaseRenderer
		/// </summary>
		/// <param name="control">The control to draw</param>
		/// <param name="format">The format to use to format the objects given</param>
		/// <param name="addWidth"></param>
		/// <exception cref="ArgumentNullException">Is thrown if <paramref name="format" /> is null</exception>
		protected TextualBaseRenderer ( T control , string format , int addWidth )
			: base ( control )
		{
			if ( format == null )
			{
				throw new ArgumentNullException ( nameof ( format ) ) ;
			}

			_format = format ;
			_addWidth = addWidth ;
		}

		/// <summary>
		///     Draws the objects given in <paramref name="args" /> using the format string given in the ctor
		/// </summary>
		/// <param name="foregroundColor">The foreground color</param>
		/// <param name="backgroundColor">The background color</param>
		/// <param name="args">The objects to draw</param>
		protected void Draw ( ConsoleColor? foregroundColor , ConsoleColor? backgroundColor , params object [ ] args )
		{
			base . Draw ( ) ;

			string text = string . Format ( _format , new object [ ] { Control . Text } . Concat ( args ) . ToArray ( ) ) ;

			if ( text . Length + _addWidth > Control . Width &&
				Control . Width != 0 )
			{
				text = text . Substring ( 0 , Control . Width - _addWidth ) ;
			}

			//FogConsole . Write ( Boundary . Left , Boundary . Top , text , Boundary , foregroundColor , backgroundColor );
		}


	}

}
