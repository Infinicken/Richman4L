﻿using System ;
using System . Collections ;
using System . Linq ;

namespace WenceyWang . FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Draws a <code>Progressbar</code>-control
	/// </summary>
	public class ProgressBarRenderer : ControlRenderer <Progressbar>
	{

		/// <summary>
		///     The character which is used to draw the bar
		/// </summary>
		public char ProgressChar { get ; set ; } = '|' ;

		public ProgressBarRenderer ( Progressbar control ) { }

		/// <summary>
		///     Draws the Progressbar given in the Control-Property
		/// </summary>
		public override void Draw ( )
		{
			ConsoleArea result = new ConsoleArea ( Control . ActualSize , Control . ActualBackgroundColor ) ;

			if ( Control . ActualHeight == 1 )
			{
				result [ 0 , 0 ] = new ConsoleChar ( '[' , Control . ActualForegroundColor , Control . ActualBackgroundColor ) ;
				result [ Control . ActualWidth - 1 , 0 ] = new ConsoleChar ( ']' ,
																			Control . ActualForegroundColor ,
																			Control . ActualBackgroundColor ) ;
				int barWidth = Control . ActualWidth -
								2 * ( Control . Value - Control . MinValue / ( Control . MaxValue - Control . MinValue ) ) ;
				for ( int x = 0 ; x < barWidth ; x++ )
				{
					result [ x + 1 , 0 ] = new ConsoleChar ( ProgressChar ,
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

				int barWidth = Control . ActualWidth -
								2 * ( Control . Value - Control . MinValue / ( Control . MaxValue - Control . MinValue ) ) ;

				for ( int y = 0 ; y < Control . ActualHeight ; y++ )
				{
					for ( int x = 0 ; x < barWidth ; x++ )
					{
						result [ x + 1 , 0 ] = new ConsoleChar ( ProgressChar ,
																Control . ActualForegroundColor ,
																Control . ActualBackgroundColor ) ;
					}
				}
			}

			FogConsole . Draw ( Control . RenderPoint , result ) ;
		}

	}

}
