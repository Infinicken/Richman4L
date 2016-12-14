/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Players . Models ;

using Environment = WenceyWang . Richman4L . GameEnviroment . Environment ;

namespace WenceyWang .Richman4L
{

	public class StartGameParameters
	{

		public long SpringLenth { get ; set ; }

		public long SummerLenth { get ; set ; }

		public long AutumnLenth { get ; set ; }

		public long WinterLenth { get ; set ; }

		public long StartMoney { get ; set ; }

		public long GameTime { get ; set ; }

		public Map Map { get ; set ; }

		public List <Tuple <PlayerModelProxy , PlayerConsole>> PlayerConfig { get ; set ; } =
			new List <Tuple <PlayerModelProxy , PlayerConsole>> ( ) ;

		public WinningCondition WinningCondition { get ; set ; }

		public Environment Enviroment { get ; set ; }

	}

}
