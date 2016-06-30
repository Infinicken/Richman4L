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

using System;
using System . Collections . Generic;
using System . Collections . ObjectModel;
using System . Linq;
using System . Collections;
using System . Xml . Linq;
using System . IO;
using System . Text;
using System . Threading . Tasks;
using System . Runtime . Serialization;
using Polenter . Serialization;
using System . Runtime . CompilerServices;
using System . ComponentModel;
using System . Runtime . InteropServices;
using WenceyWang . Richman4L . Buffs;
using WenceyWang . Richman4L . Calendars;
using WenceyWang . Richman4L . Players;
using WenceyWang . Richman4L . Players . Models;
using WenceyWang . Richman4L . GameEnviroment;


namespace WenceyWang . Richman4L
{

	public class Game : IDisposable
	{

		public GameStatus Status { get; set; }

		#region Enviroment

		public GameEnviroment . Environment GameEnviroment { get; set; }

		#endregion

		public static Game Current { get; private set; } = null;

		#region Starting

		public long StartMoney { get; private set; }

		/// <summary>
		/// 游戏可以持续的时间（天）
		/// </summary>
		public long GameLenth { get; private set; }

		public long ConditionsToWin { get; private set; }

		#endregion

		/// <summary>
		/// 指示当前的玩家上下文
		/// </summary>
		public Player CurrentPlayer { get; private set; }

		/// <summary>
		/// 切换到下一个玩家的上下文
		/// </summary>
		public void NextPlayer ( )
		{
			if ( GamePlayers . IndexOf ( CurrentPlayer ) + 1 < GamePlayers . Count )
			{
				CurrentPlayer = GamePlayers [ GamePlayers . IndexOf ( CurrentPlayer ) + 1 ];
			}
			else
			{
				NextDay ( );
				CurrentPlayer = GamePlayers . First ( );
			}
		}

		/// <summary>
		/// 指示游戏是否开始
		/// </summary>
		public bool IsStarted { get; set; } = false;

		/// <summary>
		/// 游戏的日历
		/// </summary>
		public Calendar Calendar { get; private set; }

		/// <summary>
		/// 今天的天气
		/// </summary>
		public Weathers . Weather Weather { get; set; }

		/// <summary>
		/// 当前游戏的地图
		/// </summary>
		public Maps . Map Map { get; private set; }

		/// <summary>
		/// 政府对经济的态度
		/// </summary>
		public GovermentControl GovermentControl { get; set; }


		internal GameDate GovermentControlChanging { get; set; }


		public List<Buff> GameBuffs { get; private set; } = new List<Buff> ( );


		public List<Player> GamePlayers { get; private set; } = new List<Player> ( );

		public List<Player> AllPlayers { get; set; }


		public Stocks . StockMarket StockMarket { get; set; }

		public virtual void NextDay ( )
		{
			#region End Today

			foreach ( Buff buff in GameBuffs )
			{
				buff . EndToday ( );
			}

			foreach ( Player player in GamePlayers )
			{
				player . EndToday ( );
			}

			Map . EndToday ( );

			StockMarket . EndToday ( );

			Calendar . EndToday ( );

			#endregion

			#region Start Next Day

			Weather = Weathers . Weather . Random ( Calendar . Today + 1 );

			Calendar . StartDay ( Calendar . Today + 1 );

			#region ChangeGovermentControl
			if ( GovermentControlChanging == Calendar . Today )
			{
				switch ( GameRandom . Current . Next ( 1 , 3 ) )
				{
					case 1:
						{
							GovermentControl = GovermentControl . Negative;
							break;
						}
					case 2:
						{
							GovermentControl = GovermentControl . Positive;
							break;
						}
					default:
						{
							break;
						}
				}
				GovermentControlChanging = Calendar . Today + ( GameRandom . Current . Next ( 30 , 51 ) );
			}
			#endregion

			StockMarket . StartDay ( Calendar . Today );

			foreach ( Buff buff in GameBuffs )
			{
				buff . StartDay ( Calendar . Today );
			}

			foreach ( Player player in GamePlayers )
			{
				player . StartDay ( Calendar . Today );
			}

			Map . StartDay ( Calendar . Today );

			#endregion



			if ( GamePlayers . Any ( ( player ) => player . PropertiesInMoney >= ConditionsToWin ) )
			{
				GameResult info = new GameResult ( );
				GameEnviroment . GameOver ( info );
			}


		}

		#region Initialize

		public virtual void Start ( StartGameParameters parameters )
		{

			Calendar = new Calendar ( );

			GameEnviroment = parameters . Enviroment;

			StartMoney = parameters . StartMoney;

			GameLenth = parameters . GameTime;

			foreach ( Tuple<PlayerModelProxy , PlayerConsole> item in parameters . PlayerConfig )
			{

				{
					Player player = new Player ( item . Item1 . Model , StartMoney );
					player . GetFromAreaEvent += OnPlayerGetFromArea;
					player . PayForMaintainBuildingEvent += OnPlayerPayForMaintainBuilding;
					player . PayForCrossEvent += OnPlayerPayForCross;
					player . MoveEvent += OnPlayerMove;
					player . BankruptcyEvent += OnPlayerBankruptcy;
					GamePlayers . Add ( player );
					break;
				}
			}

			Calendar = new Calendar ( );

			Map = parameters . Map;

			StockMarket = new Stocks . StockMarket ( );

			ConditionsToWin = parameters . ConditionsToWin;

			Status = GameStatus . Playing;
		}

		private void OnPlayerBankruptcy ( object sender , Players . Events . PlayerBankruptcyEventArgs e )
		{

		}

		private void OnPlayerMove ( object sender , Players . Events . PlayerMoveEventArgs e )
		{
			throw new NotImplementedException ( );
		}

		private void OnPlayerPayForCross ( object sender , Players . Events . PlayerPayForCrossEventArgs e )
		{
		}

		private void OnPlayerPayForMaintainBuilding ( object sender , Players . Events . PlayerPayForMaintainBuildingEventArgs e )
		{
		}

		private void OnPlayerGetFromArea ( object sender , Players . Events . PlayerGetFromAreaEventArgs e )
		{
		}

		public Game ( )
		{
			if ( Current != null )
			{
				throw new InvalidOperationException ( "已存在当前游戏" );
			}
			Status = GameStatus . NotStart;
			Current = this;
		}

		/// <summary>
		/// 序列化当前的游戏
		/// </summary>
		/// <param name="stream"></param>
		public void Save ( MemoryStream stream )
		{
			if ( stream == null )
			{
				throw new ArgumentNullException ( nameof ( stream ) );
			}
			SharpSerializer serialier = new SharpSerializer ( new SharpSerializerBinarySettings { Mode = BinarySerializationMode . SizeOptimized } );

			serialier . Serialize ( this , stream );
		}

		/// <summary>
		/// 从指定的内存流反序列化游戏
		/// </summary>
		/// <param name="stream">反序列化的内存流</param>
		/// <returns></returns>
		public static Game Load ( MemoryStream stream )
		{
			if ( stream == null )
			{
				throw new ArgumentNullException ( nameof ( stream ) );
			}

			SharpSerializer serialier = new SharpSerializer ( new SharpSerializerBinarySettings { Mode = BinarySerializationMode . SizeOptimized } );
			return Current = serialier . Deserialize ( stream ) as Game;
		}

		#endregion

		#region IDisposable Support

		protected bool DisposedValue = false; // To detect redundant calls


		protected virtual void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{
				if ( disposing )
				{
					Current = null;
					foreach ( Buff item in GameBuffs )
					{
						item . Dispose ( );
					}
					Calendar . Dispose ( );
					foreach ( Player item in GamePlayers )
					{
						item . Dispose ( );
					}
					Map . Dispose ( );

					GameObject . GameObjectList . Clear ( );
					// TODO: dispose managed state (managed objects).
				}
				CurrentPlayer = null;
				GameEnviroment = null;
				GameBuffs . Clear ( );
				GameBuffs = null;
				GamePlayers . Clear ( );
				GamePlayers = null;

				Map = null;

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				DisposedValue = true;
				GC . Collect ( );
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~Game() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose ( )
		{
			Dispose ( true );
		}

		#endregion
	}
}
