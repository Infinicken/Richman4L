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

using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole . Controls
{

	/// <summary>
	///     A
	///     <code>Container</code>
	///     which has a border.
	/// </summary>
	public class Groupbox : ItemsControl
	{

		private LineStyle _boarderStyle = LineStyle . SingleLinesSet ;


		private string _header = string . Empty ;

		public LineStyle BoarderStyle
		{
			get => _boarderStyle ;
			set
			{
				if ( _boarderStyle != value )
				{
					_boarderStyle = value ;
					Draw ( ) ;
				}
			}
		}


		/// <summary>
		///     A description of the contents inside this Groupbox for the user
		/// </summary>
		public string Header
		{
			get => _header ;
			set
			{
				if ( value . Contains ( Environment . NewLine ) )
				{
					throw new ArgumentException ( $"{nameof(Header)} can't contain linefeeds or carriage returns." ) ;
				}

				if ( _header != value )
				{
					_header = value ;
					Draw ( ) ;
				}
			}
		}

		public override bool CanFocus => false ;

		public override IList <Control> Items { get ; }

		/// <summary>
		///     Creates a new
		///     <code>Groupbox</code>
		/// </summary>
		/// <param name="renderer">
		///     The
		///     <code>ControlRenderer</code>
		///     to use. If null a new instance of
		///     <code>GroupBoxRenderer</code>
		///     will be used.
		/// </param>
		/// <exception cref="ArgumentException">
		///     Thrown if the
		///     <code>ControlRenderer</code>
		///     which should be set already has an other
		///     Control assigned
		/// </exception>
		public Groupbox ( GroupBoxRenderer renderer = null ) : base ( renderer )
		{
			if ( renderer == null )
			{
				Renderer = new GroupBoxRenderer ( this ) ;
			}
			Header = string . Empty ;
		}

	}

}
