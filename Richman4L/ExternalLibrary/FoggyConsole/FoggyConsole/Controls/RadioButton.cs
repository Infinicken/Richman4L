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
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . FoggyConsole . Controls . Events ;
using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	/// <summary>
	///     A checkbox-like control of which only one in a group can be checked at at the same time
	/// </summary>
	public class RadioButton : CheckableBase
	{

		/// <summary>
		///     The group this RadioButton belongs to
		/// </summary>
		public string ComboBoxGroup { get ; set ; }

		public override bool CanFocus => Enabled ;

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
		public RadioButton ( ControlRenderer <RadioButton> renderer = null )
			: base ( renderer ?? new RadioButtonRenderer ( ) )
		{
			State = CheckState . Unchecked ;
			CheckedChanging += OnCheckedChanging ;
		}

		private void OnCheckedChanging ( object sender , CheckedChangingEventArgs checkedChangingEventArgs )
		{
			IEnumerable <RadioButton> radioButtons = ( Page . Container as ItemsControl ) ? . Items ? . OfType <RadioButton>
																							( )
																							? . Where ( cb => cb . ComboBoxGroup == ComboBoxGroup ) ;
			if ( radioButtons != null )
			{
				foreach ( RadioButton radioButton in radioButtons )
				{
					if ( ( radioButton != this ) &&
						( radioButton . State != CheckState . Unchecked ) )
					{
						radioButton . State = CheckState . Unchecked ;
					}
				}
			}
		}

	}

}
