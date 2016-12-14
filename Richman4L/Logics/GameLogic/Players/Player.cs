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
using System . Collections . ObjectModel ;
using System . Linq ;

using WenceyWang . Richman4L . Auctions ;
using WenceyWang . Richman4L . Banks ;
using WenceyWang . Richman4L . Buffs . PlayerBuffs ;
using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Cards ;
using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Maps . Buildings ;
using WenceyWang . Richman4L . Maps . Roads ;
using WenceyWang . Richman4L . Players . Commands ;
using WenceyWang . Richman4L . Players . Events ;
using WenceyWang . Richman4L . Players . Models ;
using WenceyWang . Richman4L . Properties ;
using WenceyWang . Richman4L . Stocks ;

namespace WenceyWang . Richman4L .Players
{

	//Todo:玩家拥有的区块列表
	//Todo:重写ToString并更新Disposed之类的
	public class Player : GameObject
	{

		private long _money ;

		/// <summary>
		///     玩家所拥有的前进类型
		/// </summary>
		//public int NumberOfDice { get; protected set; } = 1;
		public List <MoveType> MoveTypeList = new List <MoveType> ( ) ;

		/// <summary>
		///     玩家的名称
		/// </summary>
		[NotNull]
		public string Name => Model . Name ;

		/// <summary>
		///     玩家的模型
		/// </summary>
		[NotNull]
		public PlayerModel Model { get ; }

		/// <summary>
		///     玩家使用的控制台
		/// </summary>
		[NotNull]
		public PlayerConsole Console { get ; private set ; }

		[NotNull]
		[ItemNotNull]
		private Dictionary <DiceType , int> diceList { get ; } = new Dictionary <DiceType , int> ( ) ;

		[NotNull]
		[ItemNotNull]
		public ReadOnlyDictionary <DiceType , int> DiceList { get ; }

		/// <summary>
		///     玩家的游戏点数
		/// </summary>
		public long GamePoint { get ; set ; } = 0 ;

		/// <summary>
		///     玩家的股票
		/// </summary>
		[NotNull]
		[ItemNotNull]
		private Dictionary <Stock , int> stocks { get ; }

		public ReadOnlyDictionary <Stock , int> Stocks { get ; }

		/// <summary>
		///     玩家的地块
		/// </summary>
		[NotNull]
		[ItemNotNull]
		public ReadOnlyCollection <Area> Areas { get ; }

		/// <summary>
		///     玩家的地块
		/// </summary>
		[NotNull]
		[ItemNotNull]
		private List <Area> areas { get ; }

		/// <summary>
		///     玩家当前的位置
		/// </summary>
		[NotNull]
		public Road Position { get ; private set ; }

		/// <summary>
		///     玩家前一个位置（用于确定玩家的方向）
		/// </summary>
		[NotNull]
		public Road PreviousPosition { get ; private set ; }

		/// <summary>
		///     玩家的增益效果
		/// </summary>
		[NotNull]
		[ItemNotNull]
		public ReadOnlyCollection <PlayerBuff> Buffs { get ; }

		/// <summary>
		///     玩家的增益效果
		/// </summary>
		[NotNull]
		[ItemNotNull]
		private List <PlayerBuff> buffs { get ; }

		public bool HaveMoveToday { get ; protected set ; }

		/// <summary>
		///     玩家的状态
		/// </summary>
		public PlayerState State { get ; protected set ; }

		/// <summary>
		///     当前状态将会持续的时间
		/// </summary>
		[CanBeNull]
		public long ? StateDuration { get ; protected set ; }


		[CanBeNull]
		public long ? StateStartDate { get ; protected set ; }

		/// <summary>
		///     指示玩家能否获得收益
		/// </summary>
		public bool CanGetCharge => ( State == PlayerState . Normal ) && this . IsBlockGetCharge ( ) ;

		/// <summary>
		///     指示玩家当前是否能移动
		/// </summary>
		public bool CanMove => ! HaveMoveToday && ( State == PlayerState . Normal ) && this . IsBlockMoving ( ) ;

		[NotNull]
		public ReadOnlyCollection <long> MoneyHistory { get ; }

		[NotNull]
		private List <long> moneyHistory { get ; }

		public long Money
		{
			get { return _money ; }
			private set
			{
				_money = value ;
				if ( _money < 0 )
				{
					Bankruptcy ( PlayerBankruptcyReason . CanNotPay ) ; //Todo:Money Not Enough?
				}
			}
		}

		public long PropertiesInMoney => Money + SavedMoney . Sum ( proof => proof . MoneyToGet ) -
										BorrowedMoney . Sum ( proof => proof . MoneyToReturn ) ;

		[NotNull]
		[ItemNotNull]
		public ReadOnlyCollection <SavingBankProof> SavedMoney { get ; }

		[NotNull]
		[ItemNotNull]
		private List <SavingBankProof> savedMoney { get ; }

		[NotNull]
		[ItemNotNull]
		public ReadOnlyCollection <BorrowingBankProof> BorrowedMoney { get ; }

		[NotNull]
		[ItemNotNull]
		private List <BorrowingBankProof> borrowedMoney { get ; }

		public Player ( [NotNull] PlayerModel model , long startMoney )
		{
			if ( model == null )
			{
				throw new ArgumentNullException ( nameof ( model ) ) ;
			}
			if ( startMoney < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( startMoney ) ) ;
			}

			Model = model ;
			Money = startMoney ;
			buffs = new List <PlayerBuff> ( ) ;
			Buffs = new ReadOnlyCollection <PlayerBuff> ( buffs ) ;
			savedMoney = new List <SavingBankProof> ( ) ;
			SavedMoney = new ReadOnlyCollection <SavingBankProof> ( savedMoney ) ;
		}

		public void Pay ( long money ) { }

		public void ReceiveMoney ( long money ) { }

		[NotNull]
		public ReadOnlyCollection <PlayerCommand> GetAviliableCommands ( )
		{
			List <PlayerCommand> commands = new List <PlayerCommand> ( ) ;


			return new ReadOnlyCollection <PlayerCommand> ( commands ) ;
		}

		[CanBeNull]
		public void GetBuff ( [NotNull] PlayerBuff buff )
		{
			if ( buff == null )
			{
				throw new ArgumentNullException ( nameof ( buff ) ) ;
			}

			buffs . Add ( buff ) ;
			GetBuffEvent ? . Invoke ( this , new PlayerGetBuffEventArgs ( buff ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerGetBuffEventArgs> GetBuffEvent ;

		public void RemoveBuff ( [NotNull] PlayerBuff buff )
		{
			if ( buff == null )
			{
				throw new ArgumentNullException ( nameof ( buff ) ) ;
			}
			if ( ! buffs . Contains ( buff ) )
			{
				throw new ArgumentException ( $"{nameof ( buff )} is not for this player" , nameof ( buff ) ) ;
			}

			buffs . Remove ( buff ) ;

			LostBuffEvent ? . Invoke ( this , new PlayerLostBuffEventArgs ( buff ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerLostBuffEventArgs> LostBuffEvent ;

		/// <summary>
		///     在指定位置建造指定类型的建筑建造建筑
		/// </summary>
		/// <param name="position">要建造建筑的位置</param>
		/// <param name="buildingType">要建筑的类型</param>
		public void BuildBuilding ( [NotNull] Area position , [NotNull] BuildingType buildingType )
		{
			#region Check Arguments and State

			if ( position == null )
			{
				throw new ArgumentNullException ( nameof ( position ) ) ;
			}
			if ( buildingType == null )
			{
				throw new ArgumentNullException ( nameof ( buildingType ) ) ;
			}
			if ( position . Owner != this )
			{
				throw new ArgumentException ( $"{nameof ( position )} should owned by player." , nameof ( position ) ) ;
			}
			if ( ! Building . BuildingTypes . Contains ( buildingType ) )
			{
				throw new ArgumentException ( $"{nameof ( buildingType )} have not been regis." , nameof ( buildingType ) ) ;
			}
			if ( ! position . IsBuildingAvailable ( buildingType ) )
			{
				throw new ArgumentException ( $"{nameof ( buildingType )} can not build in {nameof ( position )}." ,
											nameof ( buildingType ) ) ;
			}

			#endregion

			Building . Build ( position , buildingType , this ) ;
			BuildBuildingEvent ? . Invoke ( this , new EventArgs ( ) ) ;
		}

		[CanBeNull]
		public event EventHandler BuildBuildingEvent ;


		public void ChangeState ( PlayerState state , int duration )
		{
			if ( duration < 1 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( duration ) ) ;
			}

			PlayerState oldState = State ;
			State = state ;
			StateStartDate = Game . Current . Calendar . Today . Date ;
			StateDuration = duration ;
			ChangeStateEvent ? . Invoke ( this , new PlayerChangeStateEventArgs ( oldState , State , duration ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerChangeStateEventArgs> ChangeStateEvent ;

		public override void StartDay ( GameDate nextDate ) { HaveMoveToday = false ; }

		public override void EndToday ( )
		{
			#region Change State

			if ( ( State != PlayerState . Normal ) &&
				( StateStartDate != null ) &&
				( StateDuration != null ) )
			{
				if ( StateStartDate + StateDuration >= Game . Current . Calendar . Today . Date + 1 )
				{
					State = PlayerState . Normal ;
				}
			}

			#endregion

			moneyHistory . Add ( Money ) ;
		}

		/// <summary>
		///     宣告破产
		/// </summary>
		/// <param name="reason">破产的原因</param>
		public void Bankruptcy ( PlayerBankruptcyReason reason )
		{
			foreach ( PlayerBuff item in Buffs )
			{
				item . Maturity ( ) ;
			}

			buffs . Clear ( ) ;

			State = PlayerState . Bankrupt ;

			foreach ( AreaAuctionRequest request in Areas . Select ( item => new AreaAuctionRequest ( item , item . Price ) ) )
			{
				Game . Current . GameEnviroment . PerformAuction ( request ) ;
			}
			foreach ( Card item in Cards )
			{
				Game . Current . GameEnviroment . PerformAuction ( new CardAuctionRequest ( item , item . PriceWhenSell * 100 ) ) ;
			}

			BankruptcyEvent ? . Invoke ( this , new PlayerBankruptcyEventArgs ( reason ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerBankruptcyEventArgs> BankruptcyEvent ;


		[NotNull]
		public override string ToString ( ) => Name ;

		public bool CanPay ( long money ) => Money >= money ;

		/// <summary>
		///     移动
		/// </summary>
		/// <param name="moveType">移动类型</param>
		/// <param name="diceType">使用的骰子</param>
		public virtual void Move ( MoveType moveType , DiceType diceType )
		{
			if ( ! MoveTypeList . Contains ( moveType ) )
			{
				throw new ArgumentOutOfRangeException ( nameof ( moveType ) ) ;
			}

			//Todo:Check if player can use this dice

			if ( CanMove )
			{
				HaveMoveToday = true ;
				ReadOnlyCollection <int> diceResult = Game . Current . GameEnviroment . GetDice ( ( int ) moveType , diceType ) ;
				Path route = Position . Route ( PreviousPosition , diceResult . Sum ( ) ) ;
				foreach ( Road item in route . Route )
				{
					Position . Pass ( this , moveType ) ;
					PreviousPosition = Position ;
					Position = item ;
				}

				Position . Stay ( this , moveType ) ;
				MoveEvent ? . Invoke ( this , new PlayerMoveEventArgs ( route , diceResult ) ) ;
			}
			else
			{
				MoveEvent ? . Invoke ( this ,
										new PlayerMoveEventArgs ( new Path ( ) , new ReadOnlyCollection <int> ( new List <int> ( ) ) ) ) ;
			}
		}

		[CanBeNull]
		public event EventHandler <PlayerMoveEventArgs> MoveEvent ;

		/// <summary>
		///     购买某个区域
		/// </summary>
		/// <param name="toBuy">要购买的区域</param>
		/// <returns></returns>
		public BuyAreaResult BuyArea ( [NotNull] Area toBuy )
		{
			if ( toBuy == null )
			{
				throw new ArgumentNullException ( nameof ( toBuy ) ) ;
			}


			BuyAreaResult result = BuyAreaResult . Crate ( toBuy ) ;

			if ( ! toBuy . IsBlockBuy ( ) )
			{
				if ( ! this . IsBlockBuyArea ( ) )
				{
					if ( toBuy . Owner == null )
					{
						if ( Money >= toBuy . Price )
						{
							Money -= toBuy . Price ;
							result . Area = toBuy ;
							toBuy . Owner = this ;
							result . StatusCode = BuyAreaStatusCode . Success ;
							result . CostMoney = toBuy . Price ;
						}
						else
						{
							result . StatusCode = BuyAreaStatusCode . MoneyNotEnough ;
						}
					}
					else
					{
						result . StatusCode = BuyAreaStatusCode . NotBuyable ;
					}
				}
				else
				{
					result . StatusCode = BuyAreaStatusCode . PlayerDebuff ;
				}
			}
			else
			{
				result . StatusCode = BuyAreaStatusCode . AreaDebuff ;
			}
			BuyAreaEvent ? . Invoke ( this , new PlayerBuyAreaEventArgs ( result ) ) ;
			return result ;
		}

		[CanBeNull]
		public event EventHandler <PlayerBuyAreaEventArgs> BuyAreaEvent ;

		/// <summary>
		///     支付建造建筑所需的费用
		/// </summary>
		/// <param name="building">要支付建造费用的建筑</param>
		/// <param name="money">要支付的数额</param>
		public void PayForBuildBuilding ( Building building , long money )
		{
			if ( building == null )
			{
				throw new ArgumentNullException ( nameof ( building ) ) ;
			}
			if ( money < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( money ) ) ;
			}

			Money -= money ;
			PayForBuildBuildingEvent ? . Invoke ( this , new PlayerPayForBuildBuildingEventArgs ( building , money ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerPayForBuildBuildingEventArgs> PayForBuildBuildingEvent ;

		public void PayForUpgradeBuiding ( [NotNull] Building building , long money )
		{
			//Todo:
		}

		/// <summary>
		///     支付建筑的维持费
		/// </summary>
		/// <param name="building">要支付维持费的建筑</param>
		/// <param name="money">要支付的数额</param>
		public void PayForMaintainBuilding ( [NotNull] Building building , long money )
		{
			if ( building == null )
			{
				throw new ArgumentNullException ( nameof ( building ) ) ;
			}
			if ( money < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( money ) ) ;
			}

			Money -= money ;
			PayForMaintainBuildingEvent ? . Invoke ( this , new PlayerPayForMaintainBuildingEventArgs ( building , money ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerPayForMaintainBuildingEventArgs> PayForMaintainBuildingEvent ;

		#region ReceiveStock

		public void ReceiveStock ( [NotNull] Stock stock , int number )
		{
			if ( stock == null )
			{
				throw new ArgumentNullException ( nameof ( stock ) ) ;
			}

			if ( Stocks . ContainsKey ( stock ) )
			{
				stocks [ stock ] += number ;
			}
			else
			{
				stocks . Add ( stock , number ) ;
			}
			ReceiveStockEvent ? . Invoke ( this , new PlayerReceiveStockEventArgs ( stock , number ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerReceiveStockEventArgs> ReceiveStockEvent ;

		#endregion

		#region TakeAwayStock

		public void TakeAwayStock ( [NotNull] Stock stock , int number )
		{
			if ( stock == null )
			{
				throw new ArgumentNullException ( nameof ( stock ) ) ;
			}

			if ( Stocks . ContainsKey ( stock ) )
			{
				if ( Stocks [ stock ] > number )
				{
					stocks [ stock ] -= number ;
				}
				else
				{
					if ( Stocks [ stock ] == number )
					{
						stocks . Remove ( stock ) ;
					}
					else
					{
						if ( Stocks [ stock ] < number )
						{
							Bankruptcy ( PlayerBankruptcyReason . OversoldStock ) ;
						}
					}
				}
			}
			else
			{
				Bankruptcy ( PlayerBankruptcyReason . OversoldStock ) ;
			}

			TakeAwayStockEvent ? . Invoke ( this , new PlayerTakeAwayStockEventArgs ( stock , number ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerTakeAwayStockEventArgs> TakeAwayStockEvent ;

		#endregion

		#region Cards

		/// <summary>
		///     玩家的卡片
		/// </summary>
		[NotNull]
		[ItemNotNull]
		public ReadOnlyCollection <Card> Cards { get ; }

		[NotNull]
		[ItemNotNull]
		private List <Card> cards { get ; }

		/// <summary>
		///     将某张卡片给某个玩家
		/// </summary>
		/// <param name="target"></param>
		public void GiveCard ( [NotNull] Card card , [NotNull] Player target )
		{
			#region Check Argument

			if ( card == null )
			{
				throw new ArgumentNullException ( nameof ( card ) ) ;
			}

			if ( ! Cards . Contains ( card ) )
			{
				throw new ArgumentException ( $"this player do not have {nameof ( card )}" , nameof ( card ) ) ;
			}
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof ( target ) ) ;
			}
			if ( target == this )
			{
				throw new ArgumentException ( $"{nameof ( target )} can not be self" , nameof ( target ) ) ;
			}

			#endregion

			cards . Remove ( card ) ;

			target . ReceiveCard ( card , this ) ;

			GiveCardEvent ? . Invoke ( this , new PlayerGiveCardEventArgs ( card , target ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerGiveCardEventArgs> GiveCardEvent ;

		public void ReceiveCard ( [NotNull] Card card , [NotNull] Player source )
		{
			#region Check Argument

			if ( card == null )
			{
				throw new ArgumentNullException ( nameof ( card ) ) ;
			}

			if ( Cards . Contains ( card ) )
			{
				throw new ArgumentException ( $"this player have {nameof ( card )}" , nameof ( card ) ) ;
			}
			if ( source == null )
			{
				throw new ArgumentNullException ( nameof ( source ) ) ;
			}
			if ( source == this )
			{
				throw new ArgumentException ( $"{nameof ( source )} can not be self" , nameof ( source ) ) ;
			}

			#endregion

			cards . Add ( card ) ;
			ReceiveCardEvent ? . Invoke ( this , new PlayerReceiveCardEventArgs ( card , source ) ) ;
		}

		[CanBeNull]
		public event EventHandler <PlayerReceiveCardEventArgs> ReceiveCardEvent ;

		#endregion
	}

}
