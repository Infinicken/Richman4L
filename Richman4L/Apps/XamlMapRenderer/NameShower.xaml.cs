using System ;

using Windows . Foundation ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;

namespace WenceyWang . Richman4L . App .XamlMapRenderer
{

	public sealed partial class NameShower : UserControl
	{

		public string Text
		{
			get { return ( string ) GetValue ( TextProperty ) ; }
			set { SetValue ( TextProperty , value ) ; }
		}

		public double NameSize
		{
			get { return ( double ) GetValue ( NameSizeProperty ) ; }
			set { SetValue ( NameSizeProperty , value ) ; }
		}


		public NameShower ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty TextProperty =
			DependencyProperty . Register ( "Text" , typeof ( string ) , typeof ( NameShower ) , new PropertyMetadata ( "" ) ) ;

		public static readonly DependencyProperty NameSizeProperty =
			DependencyProperty . Register ( "NameSize" , typeof ( double ) , typeof ( NameShower ) , new PropertyMetadata ( 24 ) ) ;

		public Size Size ( ) { return new Size ( 112 , 56 ) ; }

		public void Show ( ) { throw new NotImplementedException ( ) ; }

		public void Hide ( ) { throw new NotImplementedException ( ) ; }

	}

}
