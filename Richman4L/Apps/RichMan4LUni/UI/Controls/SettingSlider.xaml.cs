using System ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Controls . Primitives ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Controls
{

	public sealed partial class SettingSlider : UserControl
	{

		public string SettingName
		{
			get => ( string ) GetValue ( SettingNameProperty ) ;
			set => SetValue ( SettingNameProperty , value ) ;
		}

		public double LargeChange
		{
			get => ( double ) GetValue ( LargeChangeProperty ) ;
			set => SetValue ( LargeChangeProperty , value ) ;
		}

		public double Maximum
		{
			get => ( double ) GetValue ( MaximumProperty ) ;
			set => SetValue ( MaximumProperty , value ) ;
		}

		public double Minimum
		{
			get => ( double ) GetValue ( MinimumProperty ) ;
			set => SetValue ( MinimumProperty , value ) ;
		}

		public double SmallChange
		{
			get => ( double ) GetValue ( SmallChangeProperty ) ;
			set => SetValue ( SmallChangeProperty , value ) ;
		}

		public double Value { get => ( double ) GetValue ( ValueProperty ) ; set => SetValue ( ValueProperty , value ) ; }

		public SettingSlider ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty SettingNameProperty =
			DependencyProperty . Register ( nameof(SettingName) ,
											typeof ( string ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( string . Empty ) ) ;

		public static readonly DependencyProperty LargeChangeProperty =
			DependencyProperty . Register ( nameof(LargeChange) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 20 ) ) ;

		public static readonly DependencyProperty MaximumProperty =
			DependencyProperty . Register ( nameof(Maximum) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 100 ) ) ;

		public static readonly DependencyProperty MinimumProperty =
			DependencyProperty . Register ( nameof(Minimum) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty SmallChangeProperty =
			DependencyProperty . Register ( nameof(SmallChange) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 1 ) ) ;

		public static readonly DependencyProperty ValueProperty =
			DependencyProperty . Register ( nameof(Value) ,
											typeof ( double ) ,
											typeof ( SettingSlider ) ,
											new PropertyMetadata ( 0 ) ) ;


		public event RangeBaseValueChangedEventHandler ValueChanged ;

		private void UserControl_Loaded ( object sender , RoutedEventArgs e )
		{
			ValueSlider . ValueChanged += ValueSlider_ValueChanged ;
		}

		private void ValueSlider_ValueChanged ( object sender , RangeBaseValueChangedEventArgs e )
		{
			ValueChanged ? . Invoke ( this , e ) ;
		}

	}

}
