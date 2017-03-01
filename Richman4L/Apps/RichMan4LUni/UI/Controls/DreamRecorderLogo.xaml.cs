using System ;
using System . Collections ;
using System . Linq ;

using Windows . UI . Xaml ;

namespace WenceyWang . Richman4L . Apps . Uni . UI .Controls
{

	public sealed partial class DreamRecorderLogo : CanvasContainer
	{

		public bool HaveColor
		{
			get { return ( bool ) GetValue ( HaveColorProperty ) ; }
			set { SetValue ( HaveColorProperty , value ) ; }
		}

		public bool IsLight
		{
			get { return ( bool ) GetValue ( IsLightProperty ) ; }
			set { SetValue ( IsLightProperty , value ) ; }
		}

		public bool UseColorLight => HaveColor && IsLight ;

		public bool UseColorDark => HaveColor && ! IsLight ;

		public bool UseMonoLight => ! HaveColor && IsLight ;

		public bool UseMonoDark => ! HaveColor && ! IsLight ;

		public DreamRecorderLogo ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty HaveColorProperty =
			DependencyProperty . Register ( nameof ( HaveColor ) ,
											typeof ( bool ) ,
											typeof ( DreamRecorderLogo ) ,
											new PropertyMetadata ( true ) ) ;

		public static readonly DependencyProperty IsLightProperty =
			DependencyProperty . Register ( nameof ( IsLight ) ,
											typeof ( bool ) ,
											typeof ( DreamRecorderLogo ) ,
											new PropertyMetadata ( true ) ) ;

	}

}
