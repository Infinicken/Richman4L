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

using FoggyConsole . Controls . Renderers;

namespace FoggyConsole . Controls
{

	/// <summary>
	///     The base class for all controls
	/// </summary>
	public abstract class Control
	{

		private ConsoleColor? _backgroundColor;

		private ConsoleColor? _foregroundColor;

		private bool _isFocused;

		private IControlRenderer _renderer;

		private Size _size;

		/// <summary>
		///     The name of this Control, must be unique within its Container
		/// </summary>
		public string Name { get; set; }

		public abstract bool CanFocus { get; }

		public virtual Size Size
		{
			get
			{
				return _size;
			}
			set
			{
				if ( _size != value )
				{
					_size = value;
					RequestMeasure ( );
				}
			}
		}

		/// <summary>
		///     The width of this Control in characters
		/// </summary>
		public int Width
		{
			get { return Size . Width; }
			set
			{
				if ( value < 0 )
				{
					throw new ArgumentException ( $"{nameof ( Width )} has to be bigger than zero." );
				}

				if ( Width != value )
				{
					Size = new Size ( value , Size . Height );
				}
			}
		}

		/// <summary>
		///     The height of this Control in characters
		/// </summary>
		public int Height
		{
			get { return Size . Height; }
			set
			{
				if ( value < 0 )
				{
					throw new ArgumentException ( $"{nameof ( Height )} has to be bigger than zero." );
				}

				if ( Height != value )
				{
					Size = new Size ( Size . Width , value );
				}
			}
		}

		public Size DesiredSize { get; protected set; }

		public Rectangle RenderArea { get; protected set; }

		public Size ActualSize => RenderArea.Size;

		public int ActualWidth => ActualSize.Width;

		public int ActualHeight => ActualSize.Height;

		/// <summary>
		///     The background-color
		/// </summary>
		public ConsoleColor? BackgroundColor
		{
			get { return _backgroundColor ?? Container . BackgroundColor ?? ConsoleColor . Black; }
			set
			{
				if ( _backgroundColor != value )
				{
					_backgroundColor = value;
					Draw ( );
				}
			}
		}

		/// <summary>
		///     The foreground-color
		/// </summary>
		public ConsoleColor? ForegroundColor
		{
			get { return _foregroundColor ?? Container . ForegroundColor ?? ConsoleColor . Gray; }
			set
			{
				if ( _foregroundColor != value )
				{
					_foregroundColor = value;
					Draw ( );
				}
			}
		}

		/// <summary>
		///     True if the control is focuses, otherwise false
		/// </summary>
		public bool IsFocused
		{
			get { return _isFocused; }
			set
			{
				if ( _isFocused != value )
				{
					_isFocused = value;
					OnIsFocusedChanged ( );
				}
			}
		}

		/// <summary>
		///     Used to determine the order of controls when the user uses the TAB-key navigate between them
		/// </summary>
		public int TabIndex { get; set; }

		/// <summary>
		///     The <code>Container</code> in which this Control is placed in
		/// </summary>
		public Container Container { get; set; }

		/// <summary>
		///     An instance of a subclass of <code>ControlRenderer</code> which is able to draw this specific type of Control
		/// </summary>
		/// <exception cref="ArgumentException">
		///     Thrown if the ControlRenderer which should be set already has an other Control
		///     assigned
		/// </exception>
		public IControlRenderer Renderer
		{
			get { return _renderer; }
			set
			{
				if ( value?.Control != null &&
					value . Control != this )
				{
					throw new ArgumentException ( $"{nameof ( Renderer )} already has an other {nameof ( Control )} assigned." ,
												nameof ( value ) );
				}

				_renderer = value;
			}
		}

		/// <summary>
		///     Creates a new <code>Control</code>
		/// </summary>
		/// <param name="renderer">The <code>ControlRenderer</code> to set</param>
		/// <exception cref="ArgumentException">
		///     Thrown if the ControlRenderer which should be set already has an other Control
		///     assigned
		/// </exception>
		public Control ( IControlRenderer renderer )
		{
			Renderer = renderer;
		}

		public Page Page { get; private set; }

		public bool Enabled { get; set; }


		/// <summary>
		///     Fired if the <code>IsFocused</code>-Property has been changed
		/// </summary>
		public event EventHandler IsFocusedChanged;

		private void OnIsFocusedChanged ( ) { IsFocusedChanged?.Invoke ( this , EventArgs . Empty ); }


		public virtual void KeyPressed ( KeyPressedEventArgs args ) { }

		public virtual void Measure ( Size availableSize )
		{
			DesiredSize = Size;
		}

		public virtual void Arrange ( Rectangle finalRect )
		{
			RenderArea = finalRect;
		}

		public void Draw ( ) { Renderer . Draw ( ); }

		protected virtual void RequestMeasure ( )
		{
			Container . RequestMeasure ( );
		}

	}

}
