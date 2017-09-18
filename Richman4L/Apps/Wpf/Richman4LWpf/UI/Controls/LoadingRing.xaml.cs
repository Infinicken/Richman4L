using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Globalization ;
using System . Linq ;
using System . Windows ;
using System . Windows . Controls ;
using System . Windows . Data ;
using System . Windows . Media ;

namespace WenceyWang . Richman4L . Apps . Wpf . UI . Controls
{

	public sealed partial class LoadingRing : UserControl
	{

		public double LargeRingUpFinalProgress
		{
			get => ( double ) GetValue ( LargeRingUpFinalProgressProperty ) ;
			set => SetValue ( LargeRingUpFinalProgressProperty , value ) ;
		}

		public double LargeRingDownFinalProgress
		{
			get => ( double ) GetValue ( LargeRingDownFinalProgressProperty ) ;
			set => SetValue ( LargeRingDownFinalProgressProperty , value ) ;
		}

		public double SmallRingDownFinalProgress
		{
			get => ( double ) GetValue ( SmallRingDownFinalProgressProperty ) ;
			set => SetValue ( SmallRingDownFinalProgressProperty , value ) ;
		}

		public double MediumRingDownFinalProgress
		{
			get => ( double ) GetValue ( MediumRingDownFinalProgressProperty ) ;
			set => SetValue ( MediumRingDownFinalProgressProperty , value ) ;
		}


		public double MediumRingUpFinalProgress
		{
			get => ( double ) GetValue ( MediumRingUpFinalProgressProperty ) ;
			set => SetValue ( MediumRingUpFinalProgressProperty , value ) ;
		}


		public int SmallRingUpFinalProgress
		{
			get => ( int ) GetValue ( SmallRingUpFinalProgressProperty ) ;
			set => SetValue ( SmallRingUpFinalProgressProperty , value ) ;
		}

		public double LargeRingUpInitialProgress
		{
			get => ( double ) GetValue ( LargeRingUpInitialProgressProperty ) ;
			set => SetValue ( LargeRingUpInitialProgressProperty , value ) ;
		}

		public double LargeRingDownInitialProgress
		{
			get => ( double ) GetValue ( LargeRingDownInitialProgressProperty ) ;
			set => SetValue ( LargeRingDownInitialProgressProperty , value ) ;
		}

		public double SmallRingDownInitialProgress
		{
			get => ( double ) GetValue ( SmallRingDownInitialProgressProperty ) ;
			set => SetValue ( SmallRingDownInitialProgressProperty , value ) ;
		}

		public double MediumRingDownInitialProgress
		{
			get => ( double ) GetValue ( MediumRingDownInitialProgressProperty ) ;
			set => SetValue ( MediumRingDownInitialProgressProperty , value ) ;
		}


		public double MediumRingUpInitialProgress
		{
			get => ( double ) GetValue ( MediumRingUpInitialProgressProperty ) ;
			set => SetValue ( MediumRingUpInitialProgressProperty , value ) ;
		}


		public int SmallRingUpInitialProgress
		{
			get => ( int ) GetValue ( SmallRingUpInitialProgressProperty ) ;
			set => SetValue ( SmallRingUpInitialProgressProperty , value ) ;
		}

		public LoadingRing ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty SmallRingDownFinalProgressProperty =
			DependencyProperty . Register ( nameof(SmallRingDownFinalProgress) ,
											typeof ( double ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty MediumRingDownFinalProgressProperty =
			DependencyProperty . Register ( nameof(MediumRingDownFinalProgress) ,
											typeof ( double ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty MediumRingUpFinalProgressProperty =
			DependencyProperty . Register ( nameof(MediumRingUpFinalProgress) ,
											typeof ( int ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty SmallRingUpFinalProgressProperty =
			DependencyProperty . Register ( nameof(SmallRingUpFinalProgress) ,
											typeof ( int ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty LargeRingDownFinalProgressProperty =
			DependencyProperty . Register ( nameof(LargeRingDownFinalProgress) ,
											typeof ( int ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty LargeRingUpFinalProgressProperty =
			DependencyProperty . Register ( nameof(LargeRingUpFinalProgress) ,
											typeof ( int ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty SmallRingDownInitialProgressProperty =
			DependencyProperty . Register ( nameof(SmallRingDownInitialProgress) ,
											typeof ( double ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty MediumRingDownInitialProgressProperty =
			DependencyProperty . Register ( nameof(MediumRingDownInitialProgress) ,
											typeof ( double ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty MediumRingUpInitialProgressProperty =
			DependencyProperty . Register ( nameof(MediumRingUpInitialProgress) ,
											typeof ( int ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty SmallRingUpInitialProgressProperty =
			DependencyProperty . Register ( nameof(SmallRingUpInitialProgress) ,
											typeof ( int ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty LargeRingDownInitialProgressProperty =
			DependencyProperty . Register ( nameof(LargeRingDownInitialProgress) ,
											typeof ( int ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		public static readonly DependencyProperty LargeRingUpInitialProgressProperty =
			DependencyProperty . Register ( nameof(LargeRingUpInitialProgress) ,
											typeof ( int ) ,
											typeof ( LoadingRing ) ,
											new PropertyMetadata ( 0 ) ) ;

		private void UserControl_Loaded ( object sender , RoutedEventArgs e ) { LoadingStoryBoard . Begin ( ) ; }

	}


	//90
	//68
	//46
	/// <summary>
	///     角度转换器
	/// </summary>
	internal class AngelConverter : IValueConverter
	{

		public object Convert ( object value , Type targetType , object parameter , CultureInfo culture )
		{
			double lenth = System . Convert . ToDouble ( parameter )
							* Math . PI
							* System . Convert . ToDouble ( value )
							/ 360
							/ 10 ;

			DoubleCollection collection = new DoubleCollection { lenth , double . MaxValue } ;

			return collection ;
		}

		public object ConvertBack ( object value , Type targetType , object parameter , CultureInfo culture )
		{
			throw new NotImplementedException ( ) ;
		}

	}

}
