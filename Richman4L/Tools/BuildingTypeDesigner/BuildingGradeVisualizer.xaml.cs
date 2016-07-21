using System;
using System . Collections . Generic;
using System . Linq;
using System . Reflection;
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
	/// BuildingGradeVisualizer.xaml 的交互逻辑
	/// </summary>
	public partial class BuildingGradeVisualizer : UserControl
	{




		public BuildingGrade Source
		{
			get { return ( BuildingGrade ) GetValue ( SourceProperty ); }
			set { SetValue ( SourceProperty , value ); }
		}

		public static readonly DependencyProperty SourceProperty =
			DependencyProperty . Register ( nameof ( Source ) , typeof ( BuildingGrade ) , typeof ( BuildingGradeVisualizer ) , new PropertyMetadata ( null ) );

		void Update ( )
		{
			NameTextBox . Text = Source . Name;
			PropertiesPanel . Children . Clear ( );
			AccessoreisPanel . Children . Clear ( );
			foreach ( PropertyInfo propertry in Source . GetType ( ) . GetProperties ( ) )
			{
				NameedTextbox box = new NameedTextbox ( );
				box . NameLabel = propertry . Name;
				box . Value = propertry . GetValue ( Source ) . ToString ( );
				PropertiesPanel . Children . Add ( box ) ;
			}
			foreach ( BuildingAccessory accessory in Source . Accessories )
			{
				BuildingAccessoriesVisualizer ass = new BuildingAccessoriesVisualizer ( );
				ass . Source = accessory;
				AccessoreisPanel . Children . Add ( ass ) ;
			}
		}


		public BuildingGradeVisualizer ( )
		{
			InitializeComponent ( );
		}
	}
}
