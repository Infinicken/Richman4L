using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Logics . Maps . Buildings ;
using WenceyWang . Richman4L . Logics . Players ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	public class PlayerOnMap : PlayerLikeBase <Block>
	{

		public Player Target { get ; set ; }

		public override Block Place { get => Target . Position ; set => throw new NotSupportedException ( ) ; }

		public override MapSize Size => MapSize . Small ;

		public override MapArea TakeUpArea => new RectangleMapArea ( Position , Size ) ;

	}

}
