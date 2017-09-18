using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

using WenceyWang . Richman4L . Logics . GameEnviroment ;
using WenceyWang . Richman4L . Logics . Interoperability . Arguments ;

namespace WenceyWang . Richman4L . Logics . Cards
{

	public abstract class StaticCard <T> : Card where T : StaticCard <T>
	{

		// Every Card Type Have It's StaticCard<T>
		// ReSharper disable once StaticMemberInGenericType
		public static List <ArgumentInfo> Arguments { get ; protected set ; }

		public sealed override List <ArgumentInfo> ArgumentsInfo => Arguments ;

		public sealed override int PriceWhenBuy
		{
			get => GameRule . GetResult <int> ( GetType ( ) ) ;
			set => throw new NotSupportedException ( ) ;
		}

		public sealed override int PriceWhenSell
		{
			get => GameRule . GetResult <int> ( GetType ( ) ) ;
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

		public long MinimumValue { get ; } //Todo：Finish this

		public bool CanGive { get ; }

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

				foreach ( TypeInfo type in typeof ( Game ) . GetTypeInfo ( ) .
															Assembly . DefinedTypes .
															Where ( type => type . GetCustomAttributes ( typeof ( CardAttribute ) , false ) . Any ( )
																			&& typeof ( Card ) . GetTypeInfo ( ) . IsAssignableFrom ( type ) ) )
				{
					RegisType ( type . AsType ( ) ) ; //Todo:resources?
				}

				Loaded = true ;
			}

			//Todo:Load All internal type
		}

	}

}
