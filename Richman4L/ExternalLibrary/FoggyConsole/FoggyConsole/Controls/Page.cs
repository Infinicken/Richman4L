using System ;
using System . Reflection ;
using System . Xml . Linq ;

namespace FoggyConsole .Controls
{

	public abstract class Page : ContentControl
	{

		public override bool CanFocus => false ;

		protected Page ( ) : base ( null ) { }

		protected Page ( XElement page ) : this ( )
		{
			if ( page == null )
			{
				throw new ArgumentNullException ( nameof ( page ) ) ;
			}

			foreach ( XElement control in page . Elements ( ) )
			{
			}
		}

		public Control CrateControle ( XElement control )
		{
			Type controlType = Type . GetType ( typeof ( Page ) . Namespace + "." + control . Name ) ;
			if ( controlType == null )
			{
				throw new ArgumentException ( ) ;
			}

			Control currentControl = ( Control ) Activator . CreateInstance ( controlType ) ;
			foreach ( XAttribute attribute in control . Attributes ( ) )
			{
				PropertyInfo property = controlType . GetProperty ( attribute . Name . LocalName ) ;
				property . SetValue ( currentControl , Convert . ChangeType ( attribute . Value , property . PropertyType ) ) ;
			}

			Container container = currentControl as Container ;
			if ( container != null )
			{
				foreach ( XElement child in control . Elements ( ) )
				{
					Control childControl = CrateControle ( child ) ;

					//	container . AddChild ( childControl );
				}
			}

			return currentControl ;
		}

	}

}
