using System;
using System . Linq;
using System . Reflection;
using System . Xml . Linq;

using WenceyWang . FoggyConsole . Properties;

namespace WenceyWang . FoggyConsole . Controls
{

	public abstract class Page : ContentControl
	{
		[CanBeNull]
		private Control _content;

		public override bool CanFocus => false;

		[CanBeNull]
		public override Control Content
		{
			get { return _content; }
			set
			{
				_content = value;
				_content . Container = this;
			}
		}

		public virtual void OnNavigateTo ( )
		{

		}

		public virtual void OnNavigateOut ( )
		{

		}

		[NotNull ]
		public Frame Frame => Container as Frame;

		protected Page ( ) : base ( new PageRanderer ( ) ) { }

		protected Page ( XElement page ) : this ( )
		{
			if ( page == null )
			{
				throw new ArgumentNullException ( nameof ( page ) );
			}

			Content = CrateControle ( page . Elements ( ) . Single ( ) );
		}

		public override void Measure ( Size availableSize )
		{
			Content?.Measure ( availableSize );
			DesiredSize = Content?.DesiredSize ?? availableSize;
		}

		public override void Arrange ( Rectangle finalRect )
		{
			Content?.Arrange ( finalRect );
			base . Arrange ( finalRect );
		}

		public Control CrateControle ( XElement control )
		{
			Type controlType = Type . GetType ( typeof ( Page ) . Namespace + "." + control . Name );

			if ( controlType == null )
			{
				throw new ArgumentException ( );
			}

			Control currentControl = ( Control ) Activator . CreateInstance ( controlType );
			foreach ( XAttribute attribute in control . Attributes ( ) )
			{
				PropertyInfo property = controlType . GetProperty ( attribute . Name . LocalName );
				property . SetValue ( currentControl , Convert . ChangeType ( attribute . Value , property . PropertyType ) );
			}

			Container container = currentControl as Container;
			if ( container != null )
			{
				foreach ( XElement child in control . Elements ( ) )
				{
					Control childControl = CrateControle ( child );

					container . Chrildren . Add ( childControl );
				}
			}

			return currentControl;
		}

	}

}
