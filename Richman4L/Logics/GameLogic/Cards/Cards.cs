﻿/*
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
using System . Reflection;
using System . Xml . Linq;

namespace WenceyWang . Richman4L . Cards
{

	public abstract class Card
	{
		public CardStatus Status { get; protected set; }

		public Players . Player Owner { get; private set; }

		public CardType Type { get; private set; }

		public abstract int PriceWhenBuy { get; set; }

		public abstract int PriceWhenSell { get; set; }

		public abstract bool CanUse ( Weathers . Weather weather );

		public abstract void Use ( );

		public static Card CrateCard ( CardType cardType )
		{
			#region Check Argument

			if ( cardType == null )
			{
				throw new ArgumentNullException ( nameof ( cardType ) );
			}
			if ( !CardTypeList . Contains ( cardType ) )
			{
				throw new ArgumentException ( $"{nameof ( cardType )} have not being registered" , nameof ( cardType ) );
			}

			#endregion

			Card card = ( Card ) Activator . CreateInstance ( cardType . EntryType ) ;

			return card;
		}

		public static List<CardType> CardTypeList { get; private set; } = new List<CardType> ( );

		public static void LoadCards ( )
		{
			//Todo:Load All internal type

		}

		public static void RegisCardType ( Type cardType , XElement element )
		{
			#region Check Argument

			if ( cardType == null )
			{
				throw new ArgumentNullException ( nameof ( cardType ) );
			}
			if ( !typeof ( Card ) . IsAssignableFrom ( cardType ) )
			{
				throw new ArgumentException ( $"{nameof ( cardType )} should assignable from {nameof ( Card )}" ,
					nameof ( cardType ) );
			}
			if ( cardType . GetCustomAttributes ( typeof ( CardAttribute ) , false ) . Single ( ) == null )
			{
				throw new ArgumentException ( $"{nameof ( cardType )} should have atribute {nameof ( CardAttribute )}" ,
					nameof ( cardType ) );
			}
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) );
			}
			if ( element . Name != nameof ( cardType ) )
			{
				throw new ArgumentException ( $"{nameof ( element )} should perform a building type" , nameof ( element ) );
			}
			if ( CardTypeList . Any ( ( type ) => type . EntryType == cardType ) )
			{
				throw new InvalidOperationException ( $"{nameof ( cardType )} have regised" );
			}

			#endregion

			CardTypeList . Add ( new CardType ( cardType , element ) );

		}

		public static void BuyCard ( CardType type , Players . Player player )
		{

		}
	}



}
