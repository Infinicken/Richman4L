using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Windows ;
using System . Windows . Controls ;

using WenceyWang . Richman4L . Maps . Buildings ;

namespace WenceyWang . Richman4L . Tools . BuildingTypeDesigner
{

	/// <summary>
	///     BuildingGradeVisualizer.xaml 的交互逻辑
	/// </summary>
	public partial class BuildingGradeVisualizer : UserControl
	{

		public BuildingGrade Source
		{
			get => ( BuildingGrade ) GetValue ( SourceProperty ) ;
			set => SetValue ( SourceProperty , value ) ;
		}


		public BuildingGradeVisualizer ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty SourceProperty =
			DependencyProperty . Register ( nameof(Source) ,
											typeof ( BuildingGrade ) ,
											typeof ( BuildingGradeVisualizer ) ,
											new PropertyMetadata ( null ) ) ;

		private void Update ( )
		{
			NameTextBox . Text = Source . Name ;
			PropertiesPanel . Children . Clear ( ) ;
			AccessoreisPanel . Children . Clear ( ) ;
			foreach ( PropertyInfo propertry in Source . GetType ( ) . GetProperties ( ) )
			{
				NameedTextbox box = new NameedTextbox ( ) ;
				box . NameLabel = propertry . Name ;
				box . Value = propertry . GetValue ( Source ) . ToString ( ) ;
				PropertiesPanel . Children . Add ( box ) ;
			}
			foreach ( BuildingAccessory accessory in Source . Accessories )
			{
				BuildingAccessoriesVisualizer ass = new BuildingAccessoriesVisualizer ( ) ;
				ass . Source = accessory ;
				AccessoreisPanel . Children . Add ( ass ) ;
			}
		}

	}

}
