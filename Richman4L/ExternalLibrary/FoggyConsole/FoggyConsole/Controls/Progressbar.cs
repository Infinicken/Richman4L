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
	///     A Control which is able to display the progress of an ongoing task
	/// </summary>
	public class Progressbar : Control
	{

		private int _value;

		/// <summary>
		///     The progress which is shown, 0 is no progress, 100 is finished
		/// </summary>
		public int Value
		{
			get { return _value; }
			set
			{
				if ( value < 0 ||
					value > 100 )
				{
					throw new ArgumentOutOfRangeException ( nameof ( value ) );
				}

				if ( _value != value )
				{
					ValueChanged?.Invoke ( this , EventArgs . Empty );
					Draw ( );
					_value = value;
				}
			}
		}

		/// <summary>
		///     Creates a new Progressbar
		/// </summary>
		/// <param name="renderer">
		///     The <code>ControlRenderer</code> to use. If null a new instance of
		///     <code>ProgressbarDrawer</code> will be used.
		/// </param>
		/// <exception cref="ArgumentException">
		///     Thrown if the <code>ControlRenderer</code> which should be set already has an other
		///     Control assigned
		/// </exception>
		public Progressbar ( ControlRenderer<Progressbar> renderer = null )
			: base ( renderer )
		{
			if ( renderer == null )
			{
				Renderer = new ProgressBarRenderer ( this );
			}
			Height = 1;
		}

		/// <summary>
		///     Fired if the Value-Property has changed
		/// </summary>
		public event EventHandler ValueChanged;

		/// <summary>
		///     Fires the ValueChanged-event and requests an redraw
		/// </summary>
		private void OnValueChanged ( )
		{
		}

		public override bool CanFocus => false;

	}

}
