using System ;
using System . Collections ;
using System . Linq ;
using System . Reflection ;
using System . Windows ;
using System . Windows . Controls ;

using WenceyWang . Richman4L . Maps . Buildings ;

namespace BuildingTypeDesigner
{

	/// <summary>
	///     BuildingAccessoriesVisualizer.xaml 的交互逻辑
	/// </summary>
	public partial class BuildingAccessoriesVisualizer : UserControl
	{

		public BuildingAccessory Source
		{
			get { return ( BuildingAccessory ) GetValue ( SourceProperty ) ; }
			set { SetValue ( SourceProperty , value ) ; }
		}

		public BuildingAccessoriesVisualizer ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty SourceProperty =
			DependencyProperty . Register ( nameof ( Source ) ,
											typeof ( BuildingAccessory ) ,
											typeof ( BuildingAccessoriesVisualizer ) ,
											new PropertyMetadata ( null ) ) ;

		private void Update ( )
		{
			NameTextBox . Text = Source . Name ;
			foreach ( PropertyInfo propertry in Source . GetType ( ) . GetProperties ( ) )
			{
				NameedTextbox box = new NameedTextbox ( ) ;
				box . NameLabel = propertry . Name ;
				box . Value = propertry . GetValue ( Source ) . ToString ( ) ;
				PropertiesPanel . Children . Add ( box ) ;
			}
		}

	}

}
