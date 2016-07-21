using System;
using System . Collections . Generic;
using System . Linq;
using System . Reflection ;
using System . Text;
using System . Threading . Tasks;
using System . Windows;
using System . Windows . Controls;
using System . Windows . Data;
using System . Windows . Documents;
using System . Windows . Input;
using System . Windows . Media;
using System . Windows . Media . Imaging;
using System . Windows . Navigation;
using System . Windows . Shapes;

using WenceyWang . Richman4L . Maps . Buildings;

namespace BuildingTypeDesigner
{
	/// <summary>
	/// BuildingAccessoriesVisualizer.xaml 的交互逻辑
	/// </summary>
	public partial class BuildingAccessoriesVisualizer : UserControl
	{
		public BuildingAccessory Source
		{
			get { return ( BuildingAccessory ) GetValue ( SourceProperty ); }
			set { SetValue ( SourceProperty , value ); }
		}


		public static readonly DependencyProperty SourceProperty =
			DependencyProperty . Register ( nameof ( Source ) , typeof ( BuildingAccessory ) , typeof ( BuildingAccessoriesVisualizer ) , new PropertyMetadata ( null ) );

		void Update ( )
		{
			NameTextBox . Text = Source . Name;
			foreach ( PropertyInfo propertry in Source . GetType ( ) . GetProperties ( ) )
			{
				NameedTextbox box = new NameedTextbox ( );
				box . NameLabel = propertry . Name;
				box . Value = propertry . GetValue ( Source ) . ToString ( );
				PropertiesPanel . Children . Add ( box );
			}
		}

		public BuildingAccessoriesVisualizer ( )
		{
			InitializeComponent ( );
		}
	}
}
