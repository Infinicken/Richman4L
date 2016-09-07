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
using System . Security;

using FoggyConsole . Controls . Renderers;

namespace FoggyConsole . Controls
{

    public class PasswordBox : TextualBase
    {

        private char _passwordChar = '*';

        private bool _passwordMode;

        private int _cursorPosition;

        public SecureString Content { get; set; }


        /// <summary>
        ///     The position of the cursor within the textbox
        /// </summary>
        public int CursorPosition
        {
            get { return _cursorPosition; }
            private set
            {
                _cursorPosition = value;
                Draw ( );
            }
        }

        /// <summary>
        ///     The char as which all characters should be rendered if <code>PasswordMode</code> is true
        /// </summary>
        /// <seealso cref="PasswordMode" />
        public char PasswordChar
        {
            get { return _passwordChar; }
            set
            {
                if ( _passwordChar != value )
                {
                    _passwordChar = value;
                    Draw ( );
                }
            }
        }

        /// <summary>
        ///     True if all characters should be rendered as <code>PasswordChar</code>
        /// </summary>
        /// <seealso cref="PasswordChar" />
        public bool PasswordMode
        {
            get { return _passwordMode; }
            set
            {
                if ( _passwordMode != value )
                {
                    _passwordMode = value;
                    Draw ( );
                }
            }
        }

        public override bool CanFocus => Enabled;


        public PasswordBox ( string text , IControlRenderer renderer = null ) : base ( text , renderer ) { }

    }

    /// <summary>
    ///     A control which provides single line editing and text input
    /// </summary>
    public class Textbox : TextualBase
    {

        private int _cursorPosition;


        /// <summary>
        ///     The position of the cursor within the textbox
        /// </summary>
        public int CursorPosition
        {
            get { return _cursorPosition; }
            private set
            {
                _cursorPosition = value;
                Draw ( );
            }
        }

        public override bool CanFocus { get; }

        /// <summary>
        ///     Creates a new textbox
        /// </summary>
        /// <param name="renderer">
        ///     The <code>ControlRenderer</code> to use. If null a new instance of <code>TextboxRenderer</code>
        ///     will be used.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the <code>ControlRenderer</code> which should be set already has an other
        ///     Control assigned
        /// </exception>
        public Textbox ( IControlRenderer renderer = null )
            : base ( "" , renderer )
        {
            if ( renderer == null )
            {
                Renderer = new TextboxRenderer ( this );
            }
            IsFocusedChanged += OnFocusChanged;
        }


        /// <summary>
        /// </summary>
        public event EventHandler EnterPressed;

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        protected void OnFocusChanged ( object sender , EventArgs eventArgs )
        {
            Draw ( );
        }

        public override void KeyPressed ( KeyPressedEventArgs args )
        {
            if ( !Enabled )
            {
                return;
            }

            switch ( args . KeyInfo . Key )
            {
                case ConsoleKey . Tab:
                case ConsoleKey . Escape:
                    {
                        break;
                    }
                case ConsoleKey . Enter:
                    {
                        args . Handled = true;
                        EnterPressed?.Invoke ( this , EventArgs . Empty );
                        break;
                    }
                case ConsoleKey . RightArrow:
                    {
                        args . Handled = true;
                        if ( CursorPosition < Text . Length )
                        {
                            CursorPosition++;
                        }
                        break;
                    }
                case ConsoleKey . LeftArrow:
                    {
                        args . Handled = true;
                        if ( CursorPosition > 0 )
                        {
                            CursorPosition--;
                        }
                        break;
                    }
                case ConsoleKey . Backspace:
                    {
                        args . Handled = true;
                        if ( Text . Length != 0 )
                        {
                            if ( CursorPosition > 0 )
                            {
                                Text = Text . Remove ( CursorPosition - 1 );
                                CursorPosition--;
                            }
                        }
                        break;
                    }
                default:
                    {
                        args . Handled = true;
                        char newChar = args . KeyInfo . KeyChar;
                        Text = Text . Insert ( CursorPosition , new string ( newChar , 1 ) );
                        CursorPosition++;
                        break;
                    }
            }

        }

    }

}
