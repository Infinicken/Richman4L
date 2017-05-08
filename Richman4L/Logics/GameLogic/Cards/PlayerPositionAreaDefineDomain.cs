using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Cards
{

	public class PlayerPositionAreaDefineDomain : ArgumentValueDefineDomain
	{

		public Player Target { get ; set ; }

		public PlayerPositionAreaDefineDomain ( Player target ) { Target = target ; }

		public PlayerPositionAreaDefineDomain ( WithAssetObject owner , Player target ) { Target = target ; }

		public override bool IsValid ( object value ) { throw new NotImplementedException ( ) ; }

	}

}
