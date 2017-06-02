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

using WenceyWang . Richman4L . Interoperability . Arguments ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Cards
{

	public abstract class StaticCard <T> : Card where T : StaticCard <T>
	{

		public static List <ArgumentInfo> Arguments { get ; protected set ; }

		public sealed override List <ArgumentInfo> ArgumentsInfo => Arguments ;

		public sealed override int PriceWhenBuy
		{
			get => Game . Current . GameRule . GetResult <int> ( GetType ( ) ) ;
			set => throw new NotSupportedException ( ) ;
		}

		public sealed override int PriceWhenSell
		{
			get => Game . Current . GameRule . GetResult <int> ( GetType ( ) ) ;
			set => throw new NotSupportedException ( ) ;
		}

	}

	public abstract class Card : NeedRegisBase <CardType , CardAttribute , Card> , IAsset
	{

		public abstract int PriceWhenBuy { get ; set ; }

		public abstract int PriceWhenSell { get ; set ; }


		public abstract List <ArgumentInfo> ArgumentsInfo { get ; }


		private static bool Loaded { get ; set ; }

		public abstract bool CanUse { get ; }

		public WithAssetObject Owner { get ; private set ; }

		public decimal MinimumValue { get ; } //Todo：Finish this

		public void GiveTo ( WithAssetObject newOwner ) { Owner = newOwner ; }

		public abstract void Use ( ArgumentsContainer arguments ) ;


		[Startup]
		public static void LoadCards ( )
		{
			lock ( Locker )
			{
				if ( Loaded )
				{
					return ;
				}

				foreach (
					TypeInfo type in
					typeof ( Game ) . GetTypeInfo ( ) .
									Assembly . DefinedTypes .
									Where ( type => type . GetCustomAttributes ( typeof ( CardAttribute ) , false ) .
															Any ( ) &&
													typeof ( Card ) . GetTypeInfo ( ) . IsAssignableFrom ( type ) ) )
				{
					RegisType ( type . AsType ( ) , type . Name , "" ) ; //Todo:resources?
				}

				Loaded = true ;
			}

			//Todo:Load All internal type
		}


		public static void BuyCard ( CardType type , Player player ) { }

	}

}
