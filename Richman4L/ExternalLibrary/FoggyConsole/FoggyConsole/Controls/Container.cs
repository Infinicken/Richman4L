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

namespace WenceyWang . FoggyConsole .Controls
{

	/// <summary>
	///     A <code>Control</code> which can contain other Controls.
	/// </summary>
	public abstract class Container : Control
	{

		public abstract IList <Control> Chrildren { get ; }

		public Container ( IControlRenderer renderer = null ) : base ( renderer ) { }

		public List <Control> GetAllItem ( )
		{
			List <Control> controlList = new List <Control> { this } ;
			foreach ( Control control in Chrildren )
			{
				Container container = control as Container ;
				if ( container != null )
				{
					controlList . AddRange ( container . GetAllItem ( ) ) ;
				}
				else
				{
					controlList . Add ( control ) ;
				}
			}

			return controlList ;
		}

		public virtual void AddChild ( Control control )
		{
			Chrildren . Add ( control ) ;
			control . Container = this ;
		}

	}

	public abstract class ContentControl : Container
	{

		public abstract Control Content { get ; set ; }

		public override IList <Control> Chrildren
		{
			get
			{
				List <Control> chrildren = new List <Control> ( ) ;
				if ( Content != null )
				{
					chrildren . Add ( Content ) ;
				}
				return chrildren ;
			}
		}


		protected ContentControl ( IControlRenderer renderer ) : base ( renderer ) { }

	}

	public abstract class ItemsControl : Container
	{

		public abstract IList <Control> Items { get ; }

		public override IList <Control> Chrildren => Items ;

		protected ItemsControl ( IControlRenderer renderer ) : base ( renderer ) { }

	}

}
