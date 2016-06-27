using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

using Windows . UI . Xaml . Data;

namespace WenceyWang . Richman4L . App . Logic
{

	public class NumberConverter : IValueConverter
	{

		public string Convert ( long value )
		{
			return value . ToString ( "C2" );
		}

		public object Convert ( object value , Type targetType , object parameter , string language )
		{
			long temp = System . Convert . ToInt64 ( value );
			return temp . ToString ( "C2" );
		}

		public long ConvertBack ( string value )
		{
			return System . Convert . ToInt64 ( value );
		}

		public object ConvertBack ( object value , Type targetType , object parameter , string language )
		{
			return System . Convert . ToInt64 ( value );
		}

	}

}
