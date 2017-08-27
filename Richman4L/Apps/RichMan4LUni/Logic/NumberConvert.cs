using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI . Xaml . Data ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{

	public class NumberConverter : IValueConverter
	{

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
