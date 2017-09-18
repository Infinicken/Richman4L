using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Globalization ;
using System . Linq ;
using System . Windows . Data ;

namespace WenceyWang . Richman4L . Apps . Wpf . Logic
{

	public class NumberConverter : IValueConverter
	{

		public object Convert ( object value , Type targetType , object parameter , CultureInfo culture )
		{
			throw new NotImplementedException ( ) ;
		}

		public object ConvertBack ( object value , Type targetType , object parameter , CultureInfo culture )
		{
			throw new NotImplementedException ( ) ;
		}

		public object Convert ( object value , Type targetType , object parameter , string language )
		{
			return System . Convert . ToInt64 ( value ) . ToString ( "C2" ) ;
		}

		public object ConvertBack ( object value , Type targetType , object parameter , string language )
		{
			return System . Convert . ToInt64 ( ( ( string ) value ) . Replace ( "$" , "" ) . Replace ( "," , "" ) ) ;
		}

		public static string Convert ( long value ) { return value . ToString ( "C2" ) ; }

		public static long ConvertBack ( string value )
		{
			return System . Convert . ToInt64 ( value . Replace ( "$" , "" ) . Replace ( "," , "" ) ) ;
		}

	}

}
