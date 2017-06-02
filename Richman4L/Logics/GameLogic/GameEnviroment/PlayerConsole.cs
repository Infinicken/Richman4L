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
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Auctions ;
using WenceyWang . Richman4L . Cards ;
using WenceyWang . Richman4L . InfomationCenter ;
using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Players ;
using WenceyWang . Richman4L . Players . Commands ;
using WenceyWang . Richman4L . Players . Models ;

namespace WenceyWang . Richman4L . GameEnviroment
{

	/// <summary>
	///     骰子和它的值
	/// </summary>
	public struct DiceWithValue
	{

		public DiceType DiceType { get ; }

		public int Value { get ; }

		public DiceWithValue ( DiceType diceType , int value )
		{
			if ( ! Enum . IsDefined ( typeof ( DiceType ) , diceType ) )
			{
				throw new ArgumentOutOfRangeException ( nameof(diceType) ,
														"Value should be defined in the DiceType enum." ) ;
			}
			if ( value <= 0 ||
				value > ( int ) diceType )
			{
				throw new ArgumentOutOfRangeException ( nameof(value) ) ;
			}

			DiceType = diceType ;
			Value = value ;
		}

		public override string ToString ( ) { return $"{nameof(DiceType)}: {DiceType}, {nameof(Value)}: {Value}" ; }

	}

	/// <summary>
	///     指示玩家所使用的控制台
	/// </summary>
	public abstract class PlayerConsole
	{

		public Guid Guid { get ; set ; }

		public Player Target { get ; internal set ; }

		public abstract void ShowDices ( List <DiceWithValue> dices ) ;

		public abstract void ShowEvent ( Event @event ) ;

		public abstract void PlayerSay ( Player player , PlayerSaying saying ) ;

		public abstract void ShowFlag ( bool flaged ) ;

		public abstract void UpdateGame ( GameObject gameObject ) ;

		public abstract void UpdatePlayerCommand ( List <PlayerCommand> commands ) ;

		public abstract void ShowChatMessage ( Player source , string message ) ;

		public abstract void StartSmallGame ( SmallGameType gameType ) ;

		public abstract void ShowGameOver ( GameResult info ) ;

		public abstract void StartAuction ( AuctionRequest request ) ;

		public abstract void UpdateAuction ( AuctionRequest request , Player buyer , long priceRised ) ;

		public abstract void ShowDice ( DiceType diceType , int value ) ;

		public void RiseAuctionPrice ( AuctionRequest request , long priceRised ) { }

		public abstract void ShowAuctionResult ( AuctionRequest request , AuctionResult result ) ;

		public abstract PlayerConsoleAbility GetAbility ( ) ;

		public event EventHandler Disconntcted ;

		//Todo:这点事件得慢慢生成啊
		//public event EventHandler<>

		public void SmallGameResult ( SmallGameResult result ) { }

		public void ApplyPlayerCommand ( PlayerCommand command , ArgumentsContainer arguments ) { }

		public void SendChatMessage ( string message ) { }

	}

	public class PlayerConsoleAbility
	{

		public Version SupportVersion { get ; }

		public List <(Guid , Version)> SupportMod { get ; } = new List <(Guid , Version)> ( ) ;

		public List <MapObjectType> SupportedMapObjectTypes { get ; } = new List <MapObjectType> ( ) ;

		public List <CardType> SupportedCardTypes { get ; } = new List <CardType> ( ) ;

		public List <SmallGameType> SupportSmallGameType { get ; } = new List <SmallGameType> ( ) ;

		//public List<>

	}

}
