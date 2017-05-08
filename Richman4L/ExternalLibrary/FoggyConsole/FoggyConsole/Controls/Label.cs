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
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole . Controls
{

	/// <summary>
	///     A control which displays one line of text
	/// </summary>
	public class Label : TextualBase
	{

		private ContentAlign _align ;

		/// <summary>
		///     The align of the text
		/// </summary>
		public ContentAlign Align
		{
			get => _align ;
			set
			{
				if ( _align != value )
				{
					_align = value ;
					Draw ( ) ;
				}
			}
		}

		public override Size Size
		{
			get
			{
				if ( base . Size == new Size ( 0 , 0 ) )
				{
					return new Size ( Text . Length , 1 ) ;
				}

				return base . Size ;
			}
			set => base . Size = value ;
		}

		public override bool CanFocus => false ;

		/// <summary>
		///     Creates a new <code>Label</code>
		/// </summary>
		/// <param name="text">The text on the Label</param>
		/// <param name="renderer">
		///     The <code>ControlRenderer</code> to use. If null a new instance of <code>LabelRenderer</code>
		///     will be used.
		/// </param>
		/// <exception cref="ArgumentException">
		///     Thrown if the <code>ControlRenderer</code> which should be set already has an other
		///     Control assigned
		/// </exception>
		public Label ( IControlRenderer renderer = null )
			: base ( renderer ?? new LabelRenderer ( ) )
		{
		}

	}

}
