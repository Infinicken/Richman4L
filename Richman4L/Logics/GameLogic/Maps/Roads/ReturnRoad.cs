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
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Maps . Roads
{
	public class ReturnRoad : Road
	{
		private long _exitId;

		private Road _exit;

		public Road Exit
		{
			get
			{
				return _exit ?? ( _exit = Map . Currnet . GetRoad ( _exitId ) );
			}
			private set
			{
				_exitId = value . Id;
				_exit = value;
			}
		}

		public override Path Route ( Road previous , int moveCount , Path result = null )
		{
			if ( previous == null )
			{
				throw new ArgumentNullException ( nameof ( previous ) );
			}
			if ( !CanEnterFrom ( previous ) )
			{
				throw new ArgumentException ( @"无法通过previous进入此道路" , nameof ( previous ) );
			}
			if ( moveCount < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( moveCount ) );
			}
			Path current = result ?? new Path ( );
			current . AddRoute ( this );
			return Exit . Route ( this , moveCount - 1 , current );
		}

		protected override void Dispose ( bool disposing )
		{
			Exit = null;
			base . Dispose ( disposing );
		}

		public override bool CanEnterFrom ( Road road ) => road == Exit ;

		public ReturnRoad ( XElement resource ) : base ( resource )
		{
			try
			{
				_exitId = Convert . ToInt64 ( resource . Attribute ( nameof ( Exit ) ) . Value );
			}
			catch ( NullReferenceException e )
			{
				throw new ArgumentException ( $"{nameof ( resource )} has wrong data or lack of data" , e );
			}
		}
	}
}
