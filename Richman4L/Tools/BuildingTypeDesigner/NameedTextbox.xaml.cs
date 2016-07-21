using System;
using System . Collections . Generic;
using System . Linq;
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

namespace BuildingTypeDesigner
{
	/// <summary>
	/// NameedTextbox.xaml 的交互逻辑
	/// </summary>
	public partial class NameedTextbox : UserControl
	{
		public string NameLabel
		{
			get { return ( string ) GetValue ( NameLabelProperty ); }
			set
			{
				SetValue ( NameLabelProperty , value );
				NameTextBlock . Text = value;
			}
		}

		public static readonly DependencyProperty NameLabelProperty =
			DependencyProperty . Register ( nameof ( NameLabel ) , typeof ( string ) , typeof ( NameedTextbox ) , new PropertyMetadata ( string . Empty ) );

		public string Value
		{
			get { return ( string ) GetValue ( ValueProperty ); }
			set
			{
				SetValue ( ValueProperty , value );
				if ( ValueTextBox != null )
				{
					ValueTextBox . Text = value;
				}
			}
		}

		public static readonly DependencyProperty ValueProperty =
			DependencyProperty . Register ( nameof ( Value ) , typeof ( string ) , typeof ( NameedTextbox ) , new PropertyMetadata ( string . Empty ) );

		public NameedTextbox ( )
		{
			InitializeComponent ( );
			Loaded += NameedTextbox_Loaded;
		}

		private void NameedTextbox_Loaded ( object sender , RoutedEventArgs e )
		{
			ValueTextBox . TextChanged += ValueTextBox_TextChanged;
		}

		private void ValueTextBox_TextChanged ( object sender , TextChangedEventArgs e ) { Value = ValueTextBox . Text; }
	}
}
