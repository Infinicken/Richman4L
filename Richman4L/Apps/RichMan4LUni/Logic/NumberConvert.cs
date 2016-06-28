/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

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
			return System . Convert . ToInt64 ( value ) . ToString ( "C2" );
		}

		public long ConvertBack ( string value )
		{
			return System . Convert . ToInt64 ( value . Replace ( "$" , "" ) . Replace ( "," , "" ) );
		}

		public object ConvertBack ( object value , Type targetType , object parameter , string language )
		{
			return System . Convert . ToInt64 ( ( ( string ) value ) . Replace ( "$" , "" ) . Replace ( "," , "" ) );
		}

	}

}
