/*
This file is part of FoggyConsole.

FoggyConsole is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as
published by the Free Software Foundation, either version 3 of
the License, or (at your option) any later version.

FoogyConsole is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with FoggyConsole.  If not, see <http://www.gnu.org/licenses/lgpl.html>.
*/

using System ;

using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	/// <summary>
	///     A <code>Control</code> that can be triggered when focused.
	///     The standard look is:
	///     <example>[ Button Name ]</example>
	///     (drawn by <code>ButtonRenderer</code>).
	///     If Width is zero, the button will use as much space as required.
	/// </summary>
	public class Button : TextualBase
	{

		public override bool CanFocus => Enabled ;

		/// <summary>
		///     Creates a new <code>Button</code>
		/// </summary>
		/// <param name="text">The text which is drawn onto the Button.</param>
		/// <param name="renderer">
		///     The <code>ControlRenderer</code> to use. If null a new instance of <code>ButtonRenderer</code>
		///     will be used.
		/// </param>
		/// <exception cref="ArgumentException">
		///     Thrown if the <code>ControlRenderer</code> which should be set already has an other
		///     Control assigned
		/// </exception>
		public Button ( ControlRenderer < Button > renderer = null )
			: base ( renderer ?? new ButtonRenderer ( ) ) { }

		/// <summary>
		///     Fired if the button is focused and the user presses the space bar
		/// </summary>
		public event EventHandler Pressed ;

		public override void KeyPressed ( KeyPressedEventArgs args )
		{
			if ( args . KeyInfo . Key == ConsoleKey . Spacebar )
			{
				args . Handled = true ;
				Pressed ? . Invoke ( this , EventArgs . Empty ) ;
			}
		}

	}

}
