using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Auctions ;
using WenceyWang . Richman4L . Logics . Banks ;
using WenceyWang . Richman4L . Logics . Buffs ;
using WenceyWang . Richman4L . Logics . Calendars ;
using WenceyWang . Richman4L . Logics . GameEnviroment ;
using WenceyWang . Richman4L . Logics . Maps ;
using WenceyWang . Richman4L . Logics . Players ;
using WenceyWang . Richman4L . Logics . Players . Events ;
using WenceyWang . Richman4L . Logics . Players . Models ;
using WenceyWang . Richman4L . Logics . Resources ;
using WenceyWang . Richman4L . Logics . Stocks ;
using WenceyWang . Richman4L . Logics . Weathers ;

namespace WenceyWang . Richman4L . Logics
{

	public class Game : GameObject , IDisposable
	{

		private List <Guid> previousGameId { get ; }

		[Own]
		public ReadOnlyCollection <Guid> PreviousGameId { get ; }

		[Own]
		public GameStatus Status { get ; set ; }

		[Own]
		public WinningCondition WinningCondition { get ; set ; }

		[Own]
		public Bank Bank { get ; set ; }

		[Own]
		public GameRule GameRule { get ; set ; }

		public static Game Current { get ; private set ; }

		/// <summary>
		///     玩家使用的控制台
		/// </summary>
		[NotNull]
		public List <PlayerConsole> Consoles { get ; } = new List <PlayerConsole> ( ) ;

		/// <summary>
		///     指示游戏是否开始
		/// </summary>
		[Own]
		public bool IsStarted { get ; set ; } = false ;

		/// <summary>
		///     游戏的日历
		/// </summary>
		[Own]
		public Calendar Calendar { get ; private set ; }

		/// <summary>
		///     今天的天气
		/// </summary>
		[Own]
		public Weather Weather { get ; set ; }

		/// <summary>
		///     当前游戏的地图
		/// </summary>
		[Own]
		public Map Map { get ; internal set ; }

		/// <summary>
		///     政府对经济的态度
		/// </summary>
		[Own]
		public GovermentControl GovermentControl { get ; set ; }

		[Own ( PropertyVisability . God )]
		internal GameDate GovermentControlChanging { get ; set ; }

		/// <summary>
		/// </summary>
		[Own]
		public List <Buff> GameBuffs { get ; } = new List <Buff> ( ) ;

		[Own]
		public List <Player> GamePlayers { get ; } = new List <Player> ( ) ;

		[Own]
		public StockMarket StockMarket { get ; set ; }

		private Game ( )
		{
			if ( Current != null )
			{
				throw new InvalidOperationException ( Resource . CurrentGameExists ) ;
			}

			Status = GameStatus . NotStart ;
			Current = this ;
		}

		public void Dispose ( ) { }

		/// <summary>
		///     Clean Current State
		/// </summary>
		public static void Clean ( )
		{
			Current . Status = GameStatus . Disposed ;

			Current = new Game ( ) ;
		}

		/// <summary>
		///     Prepare state of Game singlection
		/// </summary>
		public static void PeapareNew ( )
		{
			if ( Current == null )
			{
				Current = new Game ( ) ;
			}
		}


		public virtual void NextDay ( )
		{
			#region End Today

			foreach ( Buff buff in GameBuffs )
			{
				buff . EndToday ( ) ;
			}

			foreach ( Player player in GamePlayers )
			{
				player . EndToday ( ) ;
			}

			Map . EndToday ( ) ;

			StockMarket . EndToday ( ) ;

			Calendar . EndToday ( ) ;

			#endregion

			List <Player> winners = GamePlayers . Where ( player => WinningCondition . IsWin ( player ) ) . ToList ( ) ;
			if ( winners . Any ( ) )
			{
				GameResult info = new GameResult { Winers = winners } ;
				GameOver ( info ) ;
			}
		}

		protected void StartDay ( )
		{
			#region Start Next Day

			Weather = Weather . Random ( Calendar . Today + 1 ) ;

			Calendar . StartDay ( Calendar . Today + 1 ) ;

			#region ChangeGovermentControl

			if ( GovermentControlChanging == Calendar . Today )
			{
				switch ( GameRandom . Current . Next ( 1 , 3 ) )
				{
					case 1 :
					{
						GovermentControl = GovermentControl . Negative ;
						break ;
					}
					case 2 :
					{
						GovermentControl = GovermentControl . Positive ;
						break ;
					}
					default :
					{
						break ;
					}
				}

				GovermentControlChanging = Calendar . Today + GameRandom . Current . Next ( 30 , 51 ) ;
			}

			#endregion

			StockMarket . StartDay ( Calendar . Today ) ;

			foreach ( Buff buff in GameBuffs )
			{
				buff . StartDay ( Calendar . Today ) ;
			}

			foreach ( Player player in GamePlayers )
			{
				player . StartDay ( Calendar . Today ) ;
			}

			Map . StartDay ( Calendar . Today ) ;

			#endregion
		}

		private void GameOver ( GameResult info ) { throw new NotImplementedException ( ) ; }

		public void UpdateGameObject ( GameObject gameObject )
		{
			foreach ( PlayerConsole playerConsole in Consoles )
			{
				playerConsole . UpdateGame ( gameObject ) ;
			}
		}

		public void RemovePlayer ( Player player , RemovePlayerReason reason ) { }


		public virtual void Start ( StartGameParameters parameters )
		{
			Calendar = new Calendar ( ) ;

			GameRule = parameters . EnviromentSetting ;

			StartMoney = parameters . StartMoney ;

			GameLenth = parameters . GameTime ;

			foreach ( Tuple <PlayerModelProxy , PlayerConsole> item in parameters . PlayerConfig )
			{
				Player player = new Player ( item . Item1 . Model , StartMoney ) ;
				player . BankruptcyEvent += OnPlayerBankruptcy ;
				GamePlayers . Add ( player ) ;
				break ;
			}

			Calendar = new Calendar ( ) ;

			Map = parameters . Map ;

			StockMarket = new StockMarket ( ) ;

			WinningCondition = parameters . WinningCondition ;

			Status = GameStatus . Playing ;
		}


		private void OnPlayerBankruptcy ( object sender , PlayerBankruptcyEventArgs e ) { }

		public XElement Save ( ) { throw new NotImplementedException ( ) ; }

		public static Game Load ( XElement element ) { throw new NotImplementedException ( ) ; }

		#region Starting

		public long StartMoney { get ; private set ; }

		/// <summary>
		///     游戏可以持续的时间（天）
		/// </summary>
		public long GameLenth { get ; private set ; }

		public AuctionPerformer AuctionPerformer { get ; set ; }

		#endregion

	}

	/// <summary>
	///     指示移除玩家可能的理由
	/// </summary>
	public enum RemovePlayerReason
	{

	}

}
