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

namespace WenceyWang . FoggyConsole . Controls .Renderers
{

	/// <summary>
	///     Base class for all ControlDrawers
	/// </summary>
	public abstract class ControlRenderer < T > : IControlRenderer where T : Control
	{

		/// <summary>
		///     The Control which should be drawn
		/// </summary>
		private T _control ;

		/// <summary>
		///     The Control which should be drawn
		/// </summary>
		/// <exception cref="ArgumentException">Thrown if the Control which should be set already has an other renderer assigned</exception>
		public T Control
		{
			get { return _control ; }
			set
			{
				if ( ( value . Renderer != null ) &&
					( value . Renderer != this ) )
				{
					throw new ArgumentException ( $"{nameof ( Control )} already has a Drawer assigned" , nameof ( value ) ) ;
				}

				_control = value ;
			}
		}

		public ConsoleChar [ , ] CurrentView { get ; protected set ; }

		Control IControlRenderer . Control
		{
			get { return Control ; }

			set
			{
				if ( ! ( value is T ) )
				{
					throw new ArgumentException ( $"{nameof ( Control )} has to be of {typeof ( T ) . Name}" ) ;
				}

				Control = ( T ) value ;
			}
		}

		/// <summary>
		///     Draws the Control stored in the Control-Property
		/// </summary>
		public abstract void Draw ( ) ;

	}

}
