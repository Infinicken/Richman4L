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

using System;

using FoggyConsole . Controls . Events;
using FoggyConsole . Controls . Renderers;

namespace FoggyConsole . Controls
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

        private bool _enabled;

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
        public Button ( string text = "" , ControlRenderer<Button> renderer = null )
            : base ( text , renderer )
        {
            if ( renderer == null )
            {
                Renderer = new ButtonRenderer ( this );
            }

            IsFocusedChanged += ( sender , args ) => Draw ( );
        }

        /// <summary>
        ///     Fired if the button is focused and the user presses the space bar
        /// </summary>
        public event EventHandler Pressed;

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if ( value != _enabled )
                {

                    _enabled = value;

                }
            }
        }

        public override void KeyPressed ( KeyPressedEventArgs args )
        {
            if (args.KeyInfo  . Key == ConsoleKey . Spacebar )
            {
                args . Handled = true;
                Pressed?.Invoke ( this , EventArgs . Empty );
            }
        }



        public override bool CanFocus => Enabled;


    }

}
