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
using System . Collections ;
using System . Linq ;
using System . Text ;

namespace WenceyWang .FoggyConsole
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

		public static void Draw ( Point position , ConsoleArea area )
		{
			Draw ( new Rectangle ( position , area . Size ) , area . Content ) ;
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

	}

}
