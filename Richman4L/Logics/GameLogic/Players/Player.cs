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
using System . Collections . ObjectModel;
using System . Linq;
using System . Text;
using System . Xml . Linq;
using System . Runtime . Serialization;

using WenceyWang . Richman4L . Auctions;
using WenceyWang . Richman4L . Banks;
using WenceyWang . Richman4L . Buffs;
using WenceyWang . Richman4L . Buffs . PlayerBuffs;
using WenceyWang . Richman4L . Cards;
using WenceyWang . Richman4L . Maps;
using WenceyWang . Richman4L . Players . Events;
using WenceyWang . Richman4L . Players . Models;
using WenceyWang . Richman4L . Stocks;
using WenceyWang . Richman4L . GameEnviroment;
using WenceyWang . Richman4L . Maps . Roads;
using WenceyWang . Richman4L . Players . Commands;

namespace WenceyWang . Richman4L . Players
{
	//Todo:玩家拥有的区块列表
	//Todo:重写ToString并更新Disposed之类的
	public class Player : GameObject
	{

		/// <summary>
		/// 玩家的名称
		/// </summary>
		public string Name => Model . Name;

		/// <summary>
		/// 玩家的模型
		/// </summary>
		public PlayerModel Model { get; }

		/// <summary>
		/// 玩家使用的控制台
		/// </summary>
		public PlayerConsole Console { get; private set; }

		public ReadOnlyCollection<PlayerCommand> GetAviliableCommands ( )
		{
			List < PlayerCommand > commands = new List < PlayerCommand > ( ) ;







			return new ReadOnlyCollection<PlayerCommand> ( commands );
		}

		#region State

		/// <summary>
		/// 玩家的状态
		/// </summary>
		public PlayerState State { get; protected set; }

		/// <summary>
		/// 当前状态将会持续的时间
		/// </summary>
		public long? StateDuration { get; protected set; }


		public long? StateStartDate { get; protected set; }

		/// <summary>
		/// 指示玩家能否获得收益
		/// </summary>
		public bool CanGetCharge => State == PlayerState . Normal && this . IsBlockGetCharge ( );

		/// <summary>
		/// 指示玩家当前是否能移动
		/// </summary>
		public bool CanMove => !HaveMoveToday && State == PlayerState . Normal && this . IsBlockMoving ( );

		#endregion

		#region Money

		public ReadOnlyCollection<long> MoneyHistory { get; }

		private List<long> moneyHistory { get; }

		public long Money
		{
			get { return _money; }
			private set
			{
				_money = value;
				if ( _money < 0 )
				{
					Bankruptcy ( PlayerBankruptcyReason . CanNotPay );//Todo:Money Not Enough?
				}
			}
		}

		private long _money;

		public long PropertiesInMoney => Money + SavedMoney . Sum ( ( proof ) => proof . MoneyToGet ) -
										BorrowedMoney . Sum ( ( proof ) => proof . MoneyToReturn );

		public bool CanPay ( long money ) => Money >= money;

		public ReadOnlyCollection<SavingBankProof> SavedMoney { get; }

		private List<SavingBankProof> savedMoney { get; }

		public ReadOnlyCollection<BorrowingBankProof> BorrowedMoney { get; }

		private List<BorrowingBankProof> borrowedMoney { get; }

		#endregion

		public int NumberOfDice { get; protected set; } = 1;

		public long GamePoint { get; set; } = 0;

		public ReadOnlyCollection<Card> Cards { get; }

		private List<Card> cards { get; }

		public Dictionary<Stock , long> Stocks { get; }

		public ReadOnlyCollection<Area> Areas { get; }

		private List<Area> areas { get; }

		public Road Position { get; private set; }

		public Road PreviousPosition { get; private set; }

		public ReadOnlyCollection<PlayerBuff> Buffs { get; }

		private List<PlayerBuff> buffs { get; }

		public bool HaveMoveToday { get; protected set; }

		public void GetFromSaving ( SavingBankProof proof )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( proof == null )
			{
				throw new ArgumentNullException ( nameof ( proof ) );
			}
			Money += proof . MoneyToGet;
			savedMoney . Remove ( proof );
		}



		public void PayForBorrowing ( BorrowingBankProof proof )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( proof == null )
			{
				throw new ArgumentNullException ( nameof ( proof ) );
			}

			Money -= proof . MoneyToReturn;
			borrowedMoney . Remove ( proof );
		}

		public void GetBuff ( PlayerBuff buff )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( buff == null )
			{
				throw new ArgumentNullException ( nameof ( buff ) );
			}
			buffs . Add ( buff );
			GetBuffEvent?.Invoke ( this , new PlayerGetBuffEventArgs ( buff ) );
		}

		public event EventHandler<PlayerGetBuffEventArgs> GetBuffEvent;

		public void LostBuff ( PlayerBuff buff )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( buff == null )
			{
				throw new ArgumentNullException ( nameof ( buff ) );
			}
			if ( !buffs . Contains ( buff ) )
			{
				throw new ArgumentException ( $"{nameof ( buff )} is not for this player" , nameof ( buff ) );
			}
			else
			{
				buffs . Remove ( buff );
			}
			LostBuffEvent?.Invoke ( this , new PlayerLostBuffEventArgs ( buff ) );
		}

		public event EventHandler<PlayerLostBuffEventArgs> LostBuffEvent;

		#region Move

		/// <summary>
		/// 移动
		/// </summary>
		/// <param name="moveType">移动类型</param>
		/// <param name="diceType">使用的骰子</param>
		public virtual void Move ( MoveType moveType , DiceType diceType )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( ( int ) moveType > NumberOfDice )
			{
				throw new ArgumentOutOfRangeException ( nameof ( moveType ) );
			}
			//Todo:Check if player can use this dice

			if ( CanMove )
			{
				HaveMoveToday = true;
				ReadOnlyCollection<int> diceResult = Game . Current . GameEnviroment . GetDice ( ( int ) moveType , diceType );
				Path route = Position . Route ( PreviousPosition , diceResult . Sum ( ) );
				foreach ( Road item in route . Route )
				{
					Position . Pass ( this , moveType );
					PreviousPosition = Position;
					Position = item;
				}
				Position . Stay ( this , moveType );
				MoveEvent?.Invoke ( this , new PlayerMoveEventArgs ( route , diceResult ) );
			}
			else
			{
				MoveEvent?.Invoke ( this ,
					new PlayerMoveEventArgs ( new Path ( ) , new ReadOnlyCollection<int> ( new List<int> ( ) ) ) );
			}
		}

		public event EventHandler<PlayerMoveEventArgs> MoveEvent;

		#endregion

		/// <summary>
		/// 购买某个区域
		/// </summary>
		/// <param name="toBuy">要购买的区域</param>
		/// <returns></returns>
		public BuyAreaResult BuyArea ( Area toBuy )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( toBuy == null )
			{
				throw new ArgumentNullException ( nameof ( toBuy ) );
			}


			BuyAreaResult result = new BuyAreaResult
			{
				Area = null ,
				Money = 0 ,
			};


			if ( !toBuy . IsBlockBuy ( ) )
			{
				if ( !this . IsBlockBuyArea ( ) )
				{
					if ( toBuy . Owner == null )
					{
						if ( Money >= toBuy . Price )
						{
							Money -= toBuy . Price;
							result . Area = toBuy;
							toBuy . Owner = this;
							result . StatusCode = BuyAreaStatusCode . Success;
							result . Money = toBuy . Price;
						}
						else
						{
							result . StatusCode = BuyAreaStatusCode . MoneyNotEnough;
						}
					}
					else
					{
						result . StatusCode = BuyAreaStatusCode . NotBuyable;
					}
				}
				else
				{
					result . StatusCode = BuyAreaStatusCode . PlayerDebuff;
				}
			}
			else
			{
				result . StatusCode = BuyAreaStatusCode . AreaDebuff;
			}
			BuyAreaEvent?.Invoke ( this , new PlayerBuyAreaEventArgs ( result ) );
			return result;
		}

		public event EventHandler<PlayerBuyAreaEventArgs> BuyAreaEvent;

		/// <summary>
		/// 在指定位置建造指定类型的建筑建造建筑
		/// </summary>
		/// <param name="position">要建造建筑的位置</param>
		/// <param name="buildingType">要建筑的类型</param>
		public void BuildBuilding ( Area position , Maps . Buildings . BuildingType buildingType )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( position == null )
			{
				throw new ArgumentNullException ( nameof ( position ) );
			}
			if ( buildingType == null )
			{
				throw new ArgumentNullException ( nameof ( buildingType ) );
			}
			if ( position . Owner != this )
			{
				throw new ArgumentException ( $"{nameof ( position )} should owned by player." , nameof ( position ) );
			}
			if ( !Maps . Buildings . Building . BuildingTypes . Contains ( buildingType ) )
			{
				throw new ArgumentException ( $"{nameof ( buildingType )} have not been regis." , nameof ( buildingType ) );
			}
			if ( !position . IsBuildingAvailable ( buildingType ) )
			{
				throw new ArgumentException ( $"{nameof ( buildingType )} can not build in {nameof ( position )}." ,
					nameof ( buildingType ) );
			}
			Maps . Buildings . Building . Build ( position , buildingType , this );
		}

		public BuyStockResult BuyStock ( Stock toBuy , long number )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}

			if ( toBuy == null )
			{
				throw new ArgumentNullException ( nameof ( toBuy ) );
			}

			BuyStockResult result = new BuyStockResult
			{
				Money = 0 ,
				Number = 0
			};

			if ( !this . IsBlockBuyStock ( ) )
			{
				if ( !toBuy . IsBlockBuy ( ) )
				{

					Money -= result . Money;
					if ( result . Number == number )
					{
						result . StatusCode = BuyStockStatusCode . Success;
					}
					else
					{
						result . StatusCode = BuyStockStatusCode . MoneyNotEnough;
					}
				}
				else
				{
					result . StatusCode = BuyStockStatusCode . StockDebuff;
				}
			}
			else
			{
				result . StatusCode = BuyStockStatusCode . PlayerDebuff;
			}
			if ( Stocks . ContainsKey ( toBuy ) )
			{
				Stocks [ toBuy ] += result . Number;
			}
			else
			{
				Stocks . Add ( toBuy , result . Number );
			}
			BuyStockEvent?.Invoke ( this , new PlayerBuyStockEventArgs ( result ) );
			return result;
		}

		public event EventHandler<PlayerBuyStockEventArgs> BuyStockEvent;


		public void ChangeState ( PlayerState state , long duration )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( duration < 1 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( duration ) );
			}
			PlayerState oldState = State;
			State = state;
			StateStartDate = Game . Current . Calendar . Today . Date;
			StateDuration = duration;
			ChangeStateEvent?.Invoke ( this , new PlayerChangeStateEventArgs ( oldState , State , duration ) );
		}

		public event EventHandler<PlayerChangeStateEventArgs> ChangeStateEvent;

		#region Pay For Buildings

		/// <summary>
		/// 支付建造建筑所需的费用
		/// </summary>
		/// <param name="building">要支付建造费用的建筑</param>
		/// <param name="money">要支付的数额</param>
		public void PayForBuildBuilding ( Maps . Buildings . Building building , long money )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( $"{nameof ( Player )}" );
			}
			if ( building == null )
			{
				throw new ArgumentNullException ( nameof ( building ) );
			}
			if ( money < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( money ) );
			}
			Money -= money;
			PayForBuildBuildingEvent?.Invoke ( this , new PlayerPayForBuildBuildingEventArgs ( building , money ) );
		}

		public event EventHandler<PlayerPayForBuildBuildingEventArgs> PayForBuildBuildingEvent;

		public void PayForUpgradeBuiding ( Maps . Buildings . Building building , long money )
		{

		}

		/// <summary>
		/// 支付建筑的维持费
		/// </summary>
		/// <param name="building">要支付维持费的建筑</param>
		/// <param name="money">要支付的数额</param>
		public void PayForMaintainBuilding ( Maps . Buildings . Building building , long money )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( building == null )
			{
				throw new ArgumentNullException ( nameof ( building ) );
			}
			if ( money < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( money ) );
			}

			Money -= money;
			PayForMaintainBuildingEvent?.Invoke ( this , new PlayerPayForMaintainBuildingEventArgs ( building , money ) );
		}

		public event EventHandler<PlayerPayForMaintainBuildingEventArgs> PayForMaintainBuildingEvent;

		#endregion

		/// <summary>
		/// 支付过路费
		/// </summary>
		/// <param name="area">收取过路费的区块</param>
		/// <param name="money">支付的数额</param>
		public void PayForCross ( Area area , long money )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( area == null )
			{
				throw new ArgumentNullException ( nameof ( area ) );
			}
			if ( money < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( money ) );
			}

			Money -= money;
			Game . Current . GameEnviroment . PlayerSay ( this , Model . GetSayingWhenHarmed ( area . Owner . Model ) );
			PayForCrossEvent?.Invoke ( this , new PlayerPayForCrossEventArgs ( area , money ) );
		}

		public event EventHandler<PlayerPayForCrossEventArgs> PayForCrossEvent;

		/// <summary>
		/// 从区块获得收益
		/// </summary>
		/// <param name="area">带来收益的区块</param>
		/// <param name="player">带来收益的玩家，如没有，则为null</param>
		/// <param name="money">收益的数额</param>
		public void GetFromArea ( Area area , Player player , long money )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}
			if ( area == null )
			{
				throw new ArgumentNullException ( nameof ( area ) );
			}
			if ( money < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( money ) );
			}

			Money += money;
			Game . Current . GameEnviroment . PlayerSay ( this , Model . GetSayingWhenGained ( player?.Model ) );
			GetFromAreaEvent?.Invoke ( this , new PlayerGetFromAreaEventArgs ( area , player , money ) );
		}

		public event EventHandler<PlayerGetFromAreaEventArgs> GetFromAreaEvent;

		public override void StartDay ( Calendars . GameDate nextDate )
		{
			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}


			HaveMoveToday = false;
		}

		public override void EndToday ( )
		{

			#region Check Disposed

			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}

			#endregion

			#region Change State

			if ( State != PlayerState . Normal && StateStartDate != null && StateDuration != null )
			{
				if ( StateStartDate + StateDuration >= Game . Current . Calendar . Today . Date + 1 )
				{
					State = PlayerState . Normal;
				}
			}

			#endregion

			moneyHistory . Add ( Money );


		}

		/// <summary>
		/// 将某张卡片给某个玩家
		/// </summary>
		/// <param name="target"></param>
		public void GiveCard ( Card card , Player target )
		{

			#region Check Disposed

			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}

			#endregion

			#region Check Argument

			if ( card == null )
			{
				throw new ArgumentNullException ( nameof ( card ) );
			}
			if ( target == null )
			{
				throw new ArgumentNullException ( nameof ( target ) );
			}
			if ( target == this )
			{
				throw new ArgumentException ( $"{nameof ( target )} can not be self" , nameof ( target ) );
			}

			#endregion


		}

		/// <summary>
		/// 宣告破产
		/// </summary>
		/// <param name="reason">破产的原因</param>
		public void Bankruptcy ( PlayerBankruptcyReason reason )
		{
			#region Check Disposed

			if ( DisposedValue )
			{
				throw new ObjectDisposedException ( ToString ( ) );
			}

			#endregion

			foreach ( PlayerBuff item in Buffs )
			{
				item . Dispose ( );
			}
			buffs . Clear ( );

			State = PlayerState . Bankrupt;

			foreach ( AreaAuctionRequest request in Areas . Select ( item => new AreaAuctionRequest ( item , item . Price ) ) )
			{
				Game . Current . GameEnviroment . PerformAuction ( request );
			}
			foreach ( Card item in Cards )
			{
				Game . Current . GameEnviroment . PerformAuction ( new CardAuctionRequest ( item , item . PriceWhenSell * 100 ) );
			}
			BankruptcyEvent?.Invoke ( this , new PlayerBankruptcyEventArgs ( reason ) );

		}

		public event EventHandler<PlayerBankruptcyEventArgs> BankruptcyEvent;

		protected override void Dispose ( bool disposing )
		{
			if ( !DisposedValue )
			{
				if ( disposing )
				{
					Game . Current . GamePlayers . Remove ( this );
				}

				base . Dispose ( disposing );
			}
		}

		public override string ToString ( ) => Name;

		public Player ( PlayerModel model , long startMoney ) : base ( )
		{
			if ( model == null )
			{
				throw new ArgumentNullException ( nameof ( model ) );
			}
			if ( startMoney < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( startMoney ) );
			}
			Model = model;
			Money = startMoney;
			buffs = new List<PlayerBuff> ( );
			Buffs = new ReadOnlyCollection<PlayerBuff> ( buffs );
			savedMoney = new List<SavingBankProof> ( );
			SavedMoney = new ReadOnlyCollection<SavingBankProof> ( savedMoney );

		}

	}
}