using System ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Controls . Primitives ;

namespace WenceyWang . Richman4L . Apps . Uni . Pages .Controls
{

	public sealed partial class SettingSlider : UserControl
	{

		public string SettingName
		{
			get { return ( string ) GetValue ( SettingNameProperty ) ; }
			set
			{
				NameTextBlock . Text = value ;
				SetValue ( SettingNameProperty , value ) ;
			}
		}

		public double LargeChange
		{
			get { return ( double ) GetValue ( LargeChangeProperty ) ; }
			set
			{
				ValueSlider . LargeChange = value ;
				SetValue ( LargeChangeProperty , value ) ;
			}
		}


		public double Maximum
		{
			get { return ( double ) GetValue ( MaximumProperty ) ; }
			set
			{
				ValueSlider . Maximum = value ;
				SetValue ( MaximumProperty , value ) ;
			}
		}


		public double Minimum
		{
			get { return ( double ) GetValue ( MinimumProperty ) ; }
			set
			{
				ValueSlider . Minimum = value ;
				SetValue ( MinimumProperty , value ) ;
			}
		}

		public double SmallChange
		{
			get { return ( double ) GetValue ( SmallChangeProperty ) ; }
			set
			{
				ValueSlider . SmallChange = value ;
				SetValue ( SmallChangeProperty , value ) ;
			}
		}

		public double Value
		{
			get { return ( double ) GetValue ( ValueProperty ) ; }
			set
			{
				ValueSlider . Value = value ;
				SetValue ( ValueProperty , value ) ;
				ValueChanged ? . Invoke ( this , EventArgs . Empty ) ;
			}
		}

		public SettingSlider ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty SettingNameProperty =
			DependencyProperty . Register ( nameof ( SettingName ) ,
											typeof ( string ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( string . Empty ) ) ;

		public static readonly DependencyProperty LargeChangeProperty =
			DependencyProperty . Register ( nameof ( LargeChange ) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty MaximumProperty =
			DependencyProperty . Register ( nameof ( Maximum ) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty MinimumProperty =
			DependencyProperty . Register ( nameof ( Minimum ) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty SmallChangeProperty =
			DependencyProperty . Register ( nameof ( SmallChange ) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty ValueProperty =
			DependencyProperty . Register ( nameof ( Value ) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 0 ) ) ;


		public event EventHandler ValueChanged ;

		private void UserControl_Loaded ( object sender , RoutedEventArgs e )
		{
			ValueSlider . Value = Value ;
			NameTextBlock . FontSize = ValueTextBlock . FontSize = FontSize ;
			NameTextBlock . FontFamily = ValueTextBlock . FontFamily = FontFamily ;
			ValueSlider . ValueChanged += ValueSlider_ValueChanged ;
		}

		private void ValueSlider_ValueChanged ( object sender , RangeBaseValueChangedEventArgs e )
		{
			SetValue ( ValueProperty , ValueSlider . Value ) ;
			;
		}

	}

}
