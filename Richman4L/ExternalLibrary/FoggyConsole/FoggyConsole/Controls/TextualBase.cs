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
    ///     Base class for <code>Label</code>, <code>Button</code> and <code>Checkbox</code>.
    ///     A control which is able to display a single line of text.
    /// </summary>
    public abstract class TextualBase : Control
    {

        private string _text = string . Empty;

        public event EventHandler TextChanged;

        /// <summary>
        ///     Gets or sets the text which is drawn onto this Control.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set
            {
                if ( value == null )
                {
                    throw new ArgumentNullException ( nameof ( value ) );
                }
                if ( value . Contains ( Environment . NewLine ) )
                {
                    throw new ArgumentException ( $"{nameof ( Text )} can't contain linefeeds or carriage returns." , nameof ( value ) );
                }

                if ( _text != value )
                {

                    // if the width is zero the control will always take as much width
                    // as needed to draw the full text, so the text-lenght directly affects the size
                    if ( Width == 0 &&
                        _text . Length != value . Length )
                    {
                        _text = value;
                        RequestMeasure ( );
                    }
                    else
                    {
                        _text = value;
                        Draw ( );
                    }
                    TextChanged ? . Invoke ( this , EventArgs . Empty ) ;
                }
            }
        }

        protected TextualBase ( string text , IControlRenderer renderer = null )
            : base ( renderer )
        {
            Text = text;
            Height = 1;
        }

    }

}
