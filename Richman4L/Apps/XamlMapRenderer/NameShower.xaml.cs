using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;

using Windows . Foundation;
using Windows . Foundation . Collections;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Controls . Primitives;
using Windows . UI . Xaml . Data;
using Windows . UI . Xaml . Input;
using Windows . UI . Xaml . Media;
using Windows . UI . Xaml . Navigation;


namespace WenceyWang . Richman4L . App . XamlMapRenderer
{
	public sealed partial class NameShower : UserControl
	{
		public string Text
		{
			get { return ( string ) GetValue ( TextProperty ); }
			set { SetValue ( TextProperty , value ); }
		}

		public static readonly DependencyProperty TextProperty =
			DependencyProperty . Register ( "Text" , typeof ( string ) , typeof ( NameShower ) , new PropertyMetadata ( "" ) );

		public double NameSize
		{
			get { return ( double ) GetValue ( NameSizeProperty ); }
			set { SetValue ( NameSizeProperty , value ); }
		}

		public static readonly DependencyProperty NameSizeProperty =
			DependencyProperty . Register ( "NameSize" , typeof ( double ) , typeof ( NameShower ) , new PropertyMetadata ( 24 ) );


		public NameShower ( )
		{
			this . InitializeComponent ( );		
		}

		public Size Size ( ) { return new Size ( 112 , 56 ); }

		public void Show ( ) { throw new NotImplementedException ( ); }

		public void Hide ( ) { throw new NotImplementedException ( ); }

	}
}
