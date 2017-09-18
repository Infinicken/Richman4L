using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . Cards ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public class PlayerGiveCardEventArgs : PlayerEventArgs
	{

		/// <summary>
		///     卡片
		/// </summary>
		[NotNull]
		public Card Card { get ; set ; }

		/// <summary>
		///     获得卡片的玩家
		/// </summary>
		[NotNull]
		public Player Target { get ; set ; }

		public PlayerGiveCardEventArgs ( [NotNull] Card card , [NotNull] Player target )
		{
			Card = card ?? throw new ArgumentNullException ( nameof(card) ) ;
			Target = target ?? throw new ArgumentNullException ( nameof(target) ) ;
		}

	}

}
