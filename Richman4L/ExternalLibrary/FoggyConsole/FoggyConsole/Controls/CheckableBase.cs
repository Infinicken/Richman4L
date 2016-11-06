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
using System . Collections ;
using System . Linq ;

using WenceyWang . FoggyConsole . Controls . Events ;
using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	/// <summary>
	///     Base class for <code>Checkbox</code> and <code>RadioButton</code>
	/// </summary>
	public abstract class CheckableBase : TextualBase
	{

		private CheckState _state ;

		/// <summary>
		///     Gets or sets the state of this checkbox
		/// </summary>
		public CheckState State
		{
			get { return _state ; }
			set
			{
				if ( _state != value )
				{
					bool cancel = OnCheckedChanging ( value ) ;
					if ( ! cancel )
					{
						_state = value ;
						CheckedChanged ? . Invoke ( this , EventArgs . Empty ) ;
						Draw ( ) ;
					}
				}
			}
		}

		protected CheckableBase ( IControlRenderer renderer )
			: base ( renderer ) { IsFocusedChanged += ( sender , args ) => Draw ( ) ; }

		/// <summary>
		///     Fired if the State-Property is going to change
		/// </summary>
		public event EventHandler < CheckedChangingEventArgs > CheckedChanging ;

		/// <summary>
		///     Fired if the State-Property has been changed
		/// </summary>
		public event EventHandler CheckedChanged ;

		/// <summary>
		///     Fires the CheckedChanging-event and returns true if the process should be canceled
		/// </summary>
		/// <param name="state">The state the checkbox is going to have</param>
		/// <returns>True if the process should be canceled, otherwise false</returns>
		private bool OnCheckedChanging ( CheckState state )
		{
			CheckedChangingEventArgs args = new CheckedChangingEventArgs ( state ) ;
			CheckedChanging ? . Invoke ( this , args ) ;
			return args . Cancel ;
		}


		public override void KeyPressed ( KeyPressedEventArgs args )
		{
			if ( Enabled && ( args . KeyInfo . Key == ConsoleKey . Spacebar ) )
			{
				CheckState newState ;
				if ( State == CheckState . Checked )
				{
					newState = CheckState . Unchecked ;
				}
				else
				{
					newState = CheckState . Checked ;
				}
				State = newState ;
				args . Handled = true ;
			}
		}

	}

}
