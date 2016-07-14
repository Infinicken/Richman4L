using System ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Controls . Primitives ;

namespace WenceyWang . Richman4L . Apps . Uni . Pages . Controls
{
	public sealed partial class SettingSlider : UserControl
	{
		public SettingSlider ( )
		{
			InitializeComponent ( );
		}

		public string SettingName
		{
			get { return ( string ) GetValue ( SettingNameProperty ); }
			set { NameTextBlock . Text = value; SetValue ( SettingNameProperty , value ); }
		}

		public static readonly DependencyProperty SettingNameProperty =
			DependencyProperty . Register ( nameof ( SettingName ) , typeof ( string ) , typeof ( SettingSlider ) , new PropertyMetadata ( "" ) );

		public double LargeChange
		{
			get { return ( double ) GetValue ( LargeChangeProperty ); }
			set { ValueSlider . LargeChange = value; SetValue ( LargeChangeProperty , value ); }
		}

		public static readonly DependencyProperty LargeChangeProperty =
			DependencyProperty . Register ( "LargeChange" , typeof ( double ) , typeof ( SettingSlider ) , new PropertyMetadata ( 0 ) );


		public double Maximum
		{
			get { return ( double ) GetValue ( MaximumProperty ); }
			set { ValueSlider . Maximum = value; SetValue ( MaximumProperty , value ); }
		}

		public static readonly DependencyProperty MaximumProperty =
			DependencyProperty . Register ( "Maximum" , typeof ( double ) , typeof ( SettingSlider ) , new PropertyMetadata ( 0 ) );



		public double Minimum
		{
			get { return ( double ) GetValue ( MinimumProperty ); }
			set { ValueSlider . Minimum = value; SetValue ( MinimumProperty , value ); }
		}

		public static readonly DependencyProperty MinimumProperty =
			DependencyProperty . Register ( "Minimum" , typeof ( double ) , typeof ( SettingSlider ) , new PropertyMetadata ( 0 ) );

		public double SmallChange
		{
			get { return ( double ) GetValue ( SmallChangeProperty ); }
			set { ValueSlider . SmallChange = value; SetValue ( SmallChangeProperty , value ); }
		}

		public static readonly DependencyProperty SmallChangeProperty =
			DependencyProperty . Register ( "SmallChange" , typeof ( double ) , typeof ( SettingSlider ) , new PropertyMetadata ( 0 ) );

		public double Value
		{
			get { return ( double ) GetValue ( ValueProperty ); }
			set
			{
				ValueSlider . Value = value;
				SetValue ( ValueProperty , value );
				ValueChanged?.Invoke ( this , new EventArgs ( ) );
			}
		}

		public static readonly DependencyProperty ValueProperty =
			DependencyProperty . Register ( "Value" , typeof ( double ) , typeof ( SettingSlider ) , new PropertyMetadata ( 0 ) );


		public event EventHandler ValueChanged;

		private void UserControl_Loaded ( object sender , RoutedEventArgs e )
		{
			ValueSlider . Value = Value;
			NameTextBlock . FontSize = ValueTextBlock . FontSize = FontSize;
			ValueSlider . ValueChanged += ValueSlider_ValueChanged;
		}

		private void ValueSlider_ValueChanged ( object sender , RangeBaseValueChangedEventArgs e )
		{
			SetValue ( ValueProperty , ValueSlider . Value ); ;
		}
	}
}
