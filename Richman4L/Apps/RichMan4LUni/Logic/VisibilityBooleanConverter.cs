using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Data;

namespace WenceyWang . Richman4L . App . Logic
{
	public class BooleanVisibilityConverter : IValueConverter
	{
		public object Convert ( object value , Type targetType , object parameter , string language )
		{
			if ( ( bool ) value )
			{
				return Visibility . Visible;
			}
			else
			{
				return Visibility . Collapsed;
			}
		}

		public object ConvertBack ( object value , Type targetType , object parameter , string language )
		{
			if ( ( Visibility ) value == Visibility . Visible )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
