using System ;

namespace FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws a <code>Button</code>-Control
	/// </summary>
	public class ButtonRenderer : ControlRenderer < Button >
	{

		/// <summary>
		///     Draws the <code>Button</code> given in the Control-Property.
		/// </summary>
		/// <exception cref="InvalidOperationException">Is thrown if the Control-Property isn't set.</exception>
		/// <exception cref="InvalidOperationException">Is thrown if the CalculateBoundary-Method hasn't been called.</exception>
		public override void Draw ( )
		{
			ConsoleArea result = new ConsoleArea ( Control . ActualSize , Control . ActualBackgroundColor ) ;

			if ( Control . ActualHeight == 1 )
			{
				result [ 0 , 0 ] = new ConsoleChar ( '[' , Control . ActualForegroundColor , Control . ActualBackgroundColor ) ;
				result [ Control . ActualWidth - 1 , 0 ] = new ConsoleChar ( ']' ,
																			Control . ActualForegroundColor ,
																			Control . ActualBackgroundColor ) ;
				int startPosition = ( Control . RenderArea . Width - Control . Text . Length ) / 2 + 1 ;
				for ( int x = 0 ; ( x < Control . ActualWidth - 2 ) && ( x < Control . Text . Length ) ; x++ )
				{
					result [ x + startPosition , 0 ] = new ConsoleChar ( Control . Text [ x ] ,
																		Control . ActualForegroundColor ,
																		Control . ActualBackgroundColor ) ;
				}
			}
			else
			{
				result [ 0 , 0 ] = new ConsoleChar ( '┌' , Control . ActualForegroundColor , Control . ActualBackgroundColor ) ;
				result [ Control . ActualWidth - 1 , 0 ] = new ConsoleChar ( '┐' ,
																			Control . ActualForegroundColor ,
																			Control . ActualBackgroundColor ) ;
				result [ 0 , Control . ActualHeight - 1 ] = new ConsoleChar ( '└' ,
																			Control . ActualForegroundColor ,
																			Control . ActualBackgroundColor ) ;
				result [ Control . ActualWidth - 1 , Control . ActualHeight - 1 ] = new ConsoleChar ( '┘' ,
																									Control . ActualForegroundColor ,
																									Control . ActualBackgroundColor ) ;

				string [ ] lines = Control . Text . Split ( Environment . NewLine . ToCharArray ( ) ) ;

				int startLine = ( Control . ActualHeight - lines . Length ) / 2 ;

				for ( int y = 0 ; ( y < lines . Length ) && ( y + startLine < Control . ActualHeight ) ; y++ )
				{
					int startPosition = ( Control . RenderArea . Width - lines [ y ] . Length ) / 2 + 1 ;

					for ( int x = 0 ; ( x < Control . ActualWidth - 2 ) && ( x < lines [ y ] . Length ) ; x++ )
					{
						result [ x + startPosition , 0 ] = new ConsoleChar ( lines [ y ] [ x ] ,
																			Control . ActualForegroundColor ,
																			Control . ActualBackgroundColor ) ;
					}
				}
			}


			FogConsole . Draw ( Control . RenderPoint , result ) ;

			//Todo:
		}

	}

}
