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
using System . Reflection ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Cards
{

	public abstract class Card <T> : Card where T : Card <T>
	{

		public static List <ArgumentInfo> Arguments { get ; protected set ; }

		public sealed override List <ArgumentInfo> ArgumentsInfo => Arguments ;

	}

	public abstract class Card : GameObject , IAsset
	{

		public CardType Type { get ; private set ; }

		public abstract int PriceWhenBuy { get ; set ; }

		public abstract int PriceWhenSell { get ; set ; }

		public static List <CardType> CardTypeList { get ; } = new List <CardType> ( ) ;

		public abstract List <ArgumentInfo> ArgumentsInfo { get ; }

		private static object Locker { get ; } = new object ( ) ;

		private static bool Loaded { get ; set ; }

		public WithAssetObject Owner { get ; private set ; }

		public decimal MinimumValue { get ; }

		public void GiveTo ( WithAssetObject newOwner ) { throw new NotImplementedException ( ) ; }

		public abstract bool CanUse ( ) ;

		public abstract void Use ( ArgumentsContainer arguments ) ;

		public static Card CrateCard ( CardType cardType )
		{
			#region Check Argument

			if ( cardType == null )
			{
				throw new ArgumentNullException ( nameof(cardType) ) ;
			}
			if ( ! CardTypeList . Contains ( cardType ) )
			{
				throw new ArgumentException ( $"{nameof(cardType)} have not being registered" , nameof(cardType) ) ;
			}

			#endregion

			Card card = ( Card ) Activator . CreateInstance ( cardType . EntryType ) ;

			return card ;
		}


		[Startup ( nameof(LoadCards) )]
		public static void LoadCards ( )
		{
			lock ( Locker )
			{
				if ( Loaded )
				{
				}
			}

			//Todo:Load All internal type
		}

		public static CardType RegisCardType ( Type entryType , XElement element )
		{
			lock ( Locker )
			{
				#region Check Argument

				if ( entryType == null )
				{
					throw new ArgumentNullException ( nameof(entryType) ) ;
				}

				if ( ! typeof ( Card ) . GetTypeInfo ( ) . IsAssignableFrom ( entryType . GetTypeInfo ( ) ) )
				{
					throw new ArgumentException ( $"{nameof(entryType)} should assignable from {nameof(Card)}" ,
												nameof(entryType) ) ;
				}

				if ( entryType . GetTypeInfo ( ) . GetCustomAttributes ( typeof ( CardAttribute ) , false ) . Single ( ) == null )
				{
					throw new ArgumentException ( $"{nameof(entryType)} should have atribute {nameof(CardAttribute)}" ,
												nameof(entryType) ) ;
				}

				if ( element == null )
				{
					throw new ArgumentNullException ( nameof(element) ) ;
				}

				if ( element . Name != nameof(entryType) )
				{
					throw new ArgumentException ( $"{nameof(element)} should perform a building type" , nameof(element) ) ;
				}

				if ( CardTypeList . Any ( type => type . EntryType == entryType ) )
				{
					throw new InvalidOperationException ( $"{nameof(entryType)} have regised" ) ;
				}

				#endregion

				CardType cardType = new CardType ( entryType , element ) ;

				CardTypeList . Add ( cardType ) ;

				return cardType ;
			}
		}

		public static void BuyCard ( CardType type , Player player ) { }

	}

}
