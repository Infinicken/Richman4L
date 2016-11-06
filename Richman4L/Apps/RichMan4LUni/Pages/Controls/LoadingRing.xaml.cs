using System ;
using System . Collections ;
using System . Linq ;

using Windows . UI ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Data ;
using Windows . UI . Xaml . Media ;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WenceyWang . Richman4L . Apps . Uni . Pages .Controls
{

	public sealed partial class LoadingRing : UserControl
	{

		private Brush foreGround = new SolidColorBrush ( Color . FromArgb ( 255 , 255 , 255 , 255 ) ) ;

		public Brush ForeGround
		{
			get { return foreGround ; }
			set
			{
				LargeRingUp . Stroke = value ;
				LargeRingDown . Stroke = value ;
				MiddleRingUp . Stroke = value ;
				MiddleRingDown . Stroke = value ;
				SmallRingUp . Stroke = value ;
				SmallRingDown . Stroke = value ;
				foreGround = value ;
			}
		}

		public LoadingRing ( ) { InitializeComponent ( ) ; }

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

		object IValueConverter . Convert ( object value , Type targetType , object parameter , string language )
		{
			double lenth = Convert . ToDouble ( parameter ) * Math . PI * Convert . ToDouble ( value ) / 360 / 10 ;

			DoubleCollection collection = new DoubleCollection ( ) ;

			collection . Add ( lenth ) ;

			collection . Add ( double . MaxValue ) ;

			return collection ;
		}

		object IValueConverter . ConvertBack ( object value , Type targetType , object parameter , string language )
		{
			throw new NotImplementedException ( ) ;
		}

	}

}
