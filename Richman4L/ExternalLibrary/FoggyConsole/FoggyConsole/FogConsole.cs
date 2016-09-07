/*
* This file is part of FoggyConsole.
*
* FoggyConsole is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as
* published by the Free Software Foundation, either version 3 of
* the License, or (at your option) any later version.
*
* FoogyConsole is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with FoggyConsole.  If not, see <http://www.gnu.org/licenses/lgpl.html>.
*/

using System ;
using System . Text ;

namespace FoggyConsole
{

	/// <summary>
	///     Abstracts all calls on the <code>System.Console</code> class.
	///     Ensures that expensive operations like setting <code>Console.CursorLeft</code> or
	///     <code>Console.ForegroundColor</code> are only executed if neccessary.
	/// </summary>
	internal static class FogConsole
	{

		private static ConsoleColor CurrentForegroundColor { get ; set ; }

		private static ConsoleColor CurrentBackgroundColor { get ; set ; }

		// these variables store the last set values
		// they're used to check if the requested value needs to be set
		private static int _left ;

		private static int _top ;

		/// <summary>
		///     Writes <paramref name="content" /> at (<paramref name="left" />|<paramref name="top" />)
		///     sets the foreground color to <paramref name="foregroundColor" /> (default: <code>System.ConsoleColor.Gray</code>)
		///     and
		///     the background color to <paramref name="backgroundColor" /> (default: <code>System.ConsoleColor.Black</code>)
		/// </summary>
		/// <param name="left">Distance from the left edge of the window in characters</param>
		/// <param name="top">Distance from the top edge of the window in characters</param>
		/// <param name="content">The object to write</param>
		/// <param name="boundary">The boundary to draw in, nothing will be drawn outside this area</param>
		/// <param name="foregroundColor">The foreground color to set</param>
		/// <param name="backgroundColor">The background color to set</param>
		public static void Write ( int left ,
									int top ,
									string content ,
									Rectangle boundary ,
									ConsoleColor foregroundColor = ConsoleColor . Gray ,
									ConsoleColor backgroundColor = ConsoleColor . Black )
		{
		    {
		        int lastCharLeft = left + content . Length ;
		        int lastAllowedCharLeft = boundary . Left + boundary . Width ;

		        if ( left > lastAllowedCharLeft ) // string is completely out of view
		        {
		            return ;
		        }

		        if ( lastCharLeft > lastAllowedCharLeft ) // string is partially out of view
		        {
		            content = content . Substring ( 0 , boundary . Width - ( left - boundary . Left ) ) ;
		        }
		    }

		    // check for changed values, only set what is needed (huge performance plus)
			// Console.CursorLeft and Console.CursorTop get the other value and call
			// SetCursorPosition, which just sets both values directly.
			// That means that SetCursorPosition will always be faster,
			// up to 3.5x times as fast on my system.
			// See ConsoleBenchmark.cs for detailed results.

			if ( left != _left ||
				top != _top )
			{
				Console . SetCursorPosition ( left , top ) ;
			}
			if ( foregroundColor != CurrentForegroundColor )
			{
				Console . ForegroundColor = foregroundColor ;
			}
			if ( backgroundColor != CurrentBackgroundColor )
			{
				Console . BackgroundColor = backgroundColor ;
			}

			Console . Write ( content ) ;

			// remember the set values
			_left = left ;

			// Console.Write moves the cursor to the end of the written text,
			// so have have to adjust our saved value
			_left += content . Length ;
			_top = top ;
			CurrentForegroundColor = foregroundColor ;
			CurrentBackgroundColor = backgroundColor ;
		}

		public static void Draw ( Rectangle position , ConsoleChar [ , ] content )
		{
			StringBuilder stringBuilder = new StringBuilder ( ) ;
			for ( int y = 0 ; y < position . Height ; y++ )
			{
				Console . SetCursorPosition ( position . Left , position . Top + y ) ;
				for ( int x = 0 ; x < position . Width ; x++ )
				{
					ConsoleColor targetBackgroundColor = content [ x , y ] . BackgroundColor ;
					ConsoleColor targetForegroundColor = content [ x , y ] . ForegroundColor ;
					if ( CurrentBackgroundColor != targetBackgroundColor ||
						CurrentForegroundColor != targetForegroundColor )
					{
						Console . Write ( stringBuilder . ToString ( ) ) ;
						stringBuilder . Clear ( ) ;
						Console . BackgroundColor = CurrentBackgroundColor = targetBackgroundColor ;
						Console . ForegroundColor = CurrentForegroundColor = targetForegroundColor ;
					}
					stringBuilder . Append ( content [ x , y ] . Character ) ;
				}

				Console . Write ( stringBuilder . ToString ( ) ) ;
				stringBuilder . Clear ( ) ;
			}
		}


		/// <summary>
		///     Draws a box using the characters given in <paramref name="charSet" />.
		///     The box will be filled with characters if <paramref name="fill" /> is true,
		///     this is a hugh performance plus if <paramref name="edgeForegroundColor" /> equals
		///     <paramref name="fillForegroundColor" /> and <paramref name="edgeBackgroundColor" /> equals
		///     <paramref name="fillBackgroundColor" />.
		/// </summary>
		/// <param name="rect">The dimensions of the box</param>
		/// <param name="charSet">The characters to use to draw the box</param>
		/// <param name="boundary">The boundary to draw in, nothing will be drawn outside this area</param>
		/// <param name="edgeForegroundColor">The foreground color of the edges</param>
		/// <param name="edgeBackgroundColor">The background color of the edges</param>
		/// <param name="fill">true if the box should be filled, otherwise false</param>
		/// <param name="fillForegroundColor">The foreground color of the fill</param>
		/// <param name="fillBackgroundColor">The background color of the fill</param>
		public static void DrawBox ( Rectangle rect ,
									LineStyle charSet ,
									Rectangle boundary ,
									ConsoleColor edgeForegroundColor = ConsoleColor . Gray ,
									ConsoleColor edgeBackgroundColor = ConsoleColor . Black ,
									bool fill = false ,
									ConsoleColor fillForegroundColor = ConsoleColor . Gray ,
									ConsoleColor fillBackgroundColor = ConsoleColor . Black )
		{
			if ( rect . Width == 0 ||
				rect . Height == 0 )
			{
				return ;
			}

			#region Corners

			string topLine = charSet . TopLeftCorner + new string ( charSet . HorizontalEdge , rect . Width - 2 ) +
							charSet . TopRightCorner ;
			string bottomLine = charSet . BottomLeftCorner + new string ( charSet . HorizontalEdge , rect . Width - 2 ) +
								charSet . BottomRightCorner ;

			if ( boundary != null &&
				topLine . Length + rect . Left > boundary . Left + boundary . Width )
			{
				int charsInside = boundary . Width - ( rect . Left - boundary . Left ) ;
				topLine = topLine . Substring ( 0 , charsInside ) ;
				bottomLine = bottomLine . Substring ( 0 , charsInside ) ;
			}

			//Write ( rect . Left , rect . Top , topLine , null , edgeForegroundColor , edgeBackgroundColor );
			int bottomLineTop = rect . Top + rect . Height - 1 ;
			if ( boundary == null ||
				bottomLineTop < boundary . Top + boundary . Height )
			{
				//	Write ( rect . Left , bottomLineTop , bottomLine , null , edgeForegroundColor , edgeBackgroundColor );
			}

			#endregion

			#region Left and right edge

			// Drawing of left and right edges is optimized to call Console.Write as few as possible.
			// This is only possible when the box should be filled and all fill-colors equals the edge-colors.
			//     Fill = true
			//         Colors same:
			//             create a string which contains the whole line (edges and fill) => draw in one part
			//         Colors different:
			//             draw the line in 3 parts
			//             TODO: draw edges with dummy chars in between + draw the actual filling afterwards (=> 2 parts instead of 3)
			//     Fill = false
			//         draw the line in 3 parts (existing characters which could be inside the box have to be preserved)

			string middleLine ;
			if ( edgeForegroundColor == fillForegroundColor &&
				edgeBackgroundColor == fillBackgroundColor )
			{
				middleLine = charSet . VerticalEdge + new string ( charSet . EmptyChar , rect . Width - 2 ) + charSet . VerticalEdge ;
			}
			else
			{
				middleLine = new string ( charSet . EmptyChar , rect . Width - 2 ) ;
			}

			if ( boundary != null &&
				middleLine . Length + rect . Left > boundary . Left + boundary . Width &&
				edgeForegroundColor == fillForegroundColor &&
				edgeBackgroundColor == fillBackgroundColor )
			{
				int charsInside = boundary . Width - ( rect . Left - boundary . Left ) ;
				middleLine = middleLine . Substring ( 0 , charsInside ) ;
			}

			int middleHeight = rect . Height - 1 ;
			if ( boundary != null &&
				rect . Top + middleHeight > boundary . Top + boundary . Height )
			{
				middleHeight = boundary . Height - ( rect . Top - boundary . Top ) ;
			}

			for ( int i = 1 ; i < middleHeight ; i++ )
			{
				if ( ! fill ||
					edgeForegroundColor != fillForegroundColor ||
					edgeBackgroundColor == fillBackgroundColor )
				{
					//Write ( rect . Left , rect . Top + i , charSet . VerticalEdge , null , edgeForegroundColor , edgeBackgroundColor );
					int left = rect . Left + rect . Width - 1 ;
					if ( boundary == null ||
						left < boundary . Left + boundary . Width )
					{
						//Write ( left , rect . Top + i , charSet . VerticalEdge , null , edgeForegroundColor , edgeBackgroundColor );
					}
				}
				if ( fill )
				{
					if ( edgeForegroundColor == fillForegroundColor &&
						edgeBackgroundColor == fillBackgroundColor )
					{
						//Write ( rect . Left , rect . Top + i , middleLine , null , edgeForegroundColor , edgeBackgroundColor );
					}
					else
					{
						//Write ( rect . Left + 1 , rect . Top + i , middleLine , null , fillForegroundColor , fillBackgroundColor );
					}
				}
			}

			#endregion
		}

	}

}
