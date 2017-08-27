using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Maps . Buildings ;
using WenceyWang . Richman4L . Maps . Roads ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Maps
{

	public class PlayerOnMap : PlayerLikeBase <Road>
	{

		public Player Target { get ; set ; }

		public override Road Place { get => Target . Position ; set => throw new NotSupportedException ( ) ; }

		public override MapSize Size => MapSize . Small ;

		public override MapArea TakeUpArea => new RectangleMapArea ( Position , Size ) ;

	}

}
