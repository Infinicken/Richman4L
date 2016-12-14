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

using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	/// <summary>
	///     Base class for <code>Label</code>, <code>Button</code> and <code>Checkbox</code>.
	///     A control which is able to display a single line of text.
	/// </summary>
	public abstract class TextualBase : Control
	{

		private string _text = string . Empty ;

		/// <summary>
		///     Gets or sets the text which is drawn onto this Control.
		/// </summary>
		public string Text
		{
			get { return _text ; }
			set
			{
				if ( value == null )
				{
					throw new ArgumentNullException ( nameof ( value ) ) ;
				}

				if ( _text != value )
				{
					_text = value ;
					TextChanged ? . Invoke ( this , EventArgs . Empty ) ;
					RequestMeasure ( ) ;
				}
			}
		}

		protected TextualBase ( IControlRenderer renderer )
			: base ( renderer ) { }

		public event EventHandler TextChanged ;

	}

}
