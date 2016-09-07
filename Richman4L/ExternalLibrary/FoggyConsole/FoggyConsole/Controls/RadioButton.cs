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
using System . Collections . Generic;
using System . Linq;

using FoggyConsole . Controls . Events;
using FoggyConsole . Controls . Renderers;

namespace FoggyConsole . Controls
{

    /// <summary>
    ///     A checkbox-like control of which only one in a group can be checked at at the same time
    /// </summary>
    public class RadioButton : CheckableBase
    {

        /// <summary>
        ///     The group this RadioButton belongs to
        /// </summary>
        public string ComboboxGroup { get; set; }


        /// <summary>
        ///     Creates a new RadioButton
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <param name="renderer">
        ///     The <code>ControlRenderer</code> to use. If null a new instance of
        ///     <code>RadioButtonRenderer</code> will be used.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the <code>ControlRenderer</code> which should be set already has an other
        ///     Control assigned
        /// </exception>
        public RadioButton ( string text , ControlRenderer<RadioButton> renderer = null )
            : base ( text , renderer )
        {
            if ( renderer == null )
            {
                Renderer = new RadioButtonRenderer ( this );
            }
            State = CheckState . Unchecked;
            CheckedChanging += OnCheckedChanging;
        }

        private void OnCheckedChanging ( object sender , CheckedChangingEventArgs checkedChangingEventArgs )
        {
            IEnumerable<RadioButton> groupBoxes = ( Page . Container as ItemsControl ) . Items . OfType<RadioButton> ( )
                                                                . Where ( cb => cb . ComboboxGroup == ComboboxGroup );

            foreach ( RadioButton cb in groupBoxes )
            {
                if ( cb != this &&
                    cb . State == CheckState . Checked )
                {
                    cb . State = CheckState . Unchecked;
                }
            }
        }

        public override bool CanFocus => Enabled;

    }

}
