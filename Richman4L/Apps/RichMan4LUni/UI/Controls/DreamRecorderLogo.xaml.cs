using System ;
using System . Collections ;
using System . Linq ;

using Windows . UI . Xaml ;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WenceyWang . Richman4L . Apps . Uni . UI .Controls
{

	public sealed partial class DreamRecorderLogo : CanvasContainer
	{

		public bool Color
		{
			get { return ( bool ) GetValue ( ColorProperty ) ; }
			set { SetValue ( ColorProperty , value ) ; }
		}


		public bool Light
		{
			get { return ( bool ) GetValue ( LightProperty ) ; }
			set { SetValue ( LightProperty , value ) ; }
		}

		public DreamRecorderLogo ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty ColorProperty =
			DependencyProperty . Register ( nameof ( Color ) ,
											typeof ( bool ) ,
											typeof ( DreamRecorderLogo ) ,
											new PropertyMetadata ( true ) ) ;

		public static readonly DependencyProperty LightProperty =
			DependencyProperty . Register ( nameof ( Light ) ,
											typeof ( bool ) ,
											typeof ( DreamRecorderLogo ) ,
											new PropertyMetadata ( true ) ) ;

	}

}
