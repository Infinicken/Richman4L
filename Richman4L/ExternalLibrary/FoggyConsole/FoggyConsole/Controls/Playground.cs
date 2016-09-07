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

    // TODO: don't redraw the whole thing all the time
    // TODO: add methods for easy from-drawing
    // TODO: entities?
    // TODO: make Height and Width changeable

    /// <summary>
    ///     A class which draws the contents of an two-dimentional char-array.
    ///     This can be used to draw a small game or display graphs.
    /// </summary>
    public class Playground : Control
    {

        private readonly ConsoleChar [,] _field;

        private bool _canFocus;

        /// <summary>
        ///     Gets or sets the char at (<paramref name="top" />|<paramref name="left" />).
        ///     Setting triggers an redraw if <code>Playground.AutoRedaw</code> is true.
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <returns></returns>
        /// <seealso cref="AutoRedraw" />
        public ConsoleChar this [ int top , int left ]
        {
            get
            {
                if ( top >= _field . GetLength ( 0 ) )
                {
                    throw new ArgumentOutOfRangeException ( nameof ( top ) );
                }
                if ( left >= _field . GetLength ( 1 ) )
                {
                    throw new ArgumentOutOfRangeException ( nameof ( left ) );
                }

                return _field [ top , left ];
            }
            set
            {
                if ( top >= _field . GetLength ( 0 ) )
                {
                    throw new ArgumentOutOfRangeException ( nameof ( top ) );
                }
                if ( left >= _field . GetLength ( 1 ) )
                {
                    throw new ArgumentOutOfRangeException ( nameof ( left ) );
                }

                if ( _field [ top , left ] != value )
                {
                    _field [ top , left ] = value;

                    if ( AutoRedraw )
                    {
                        Draw ( );
                    }
                }
            }
        }

        /// <summary>
        ///     True if a redraw should be triggered on every change
        /// </summary>
        /// <seealso cref="Redraw" />
        public bool AutoRedraw { get; set; }

        /// <summary>
        ///     Creates a new <code>Playground</code>
        /// </summary>
        /// <param name="height">The height of this Playground</param>
        /// <param name="width">The width of this Playground</param>
        /// <param name="renderer">
        ///     The <code>ControlRenderer</code> to use. If null a new instance of
        ///     <code>PlaygroundRenderer</code> will be used.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the <code>ControlRenderer</code> which should be set already has an other
        ///     Control assigned
        /// </exception>
        public Playground ( int height , int width , ControlRenderer<Playground> renderer = null )
            : base ( renderer )
        {
            if ( renderer == null )
            {
                Renderer = new PlaygroundRenderer ( this );
            }

            Height = height;
            Width = width;

            _field = new ConsoleChar [ height , width ];

            AutoRedraw = true;
        }

        public override bool CanFocus => _canFocus ;

        public void SetCanFocus ( bool value ) { _canFocus = value; }

    }

}
