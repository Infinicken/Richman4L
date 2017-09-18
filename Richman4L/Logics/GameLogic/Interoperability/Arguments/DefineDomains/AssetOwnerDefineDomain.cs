using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Interoperability . Arguments . DefineDomains
{

	public class AssetOwnerDefineDomain : ArgumentValueDefineDomain <IAsset>
	{

		public WithAssetObject Owner { get ; }

		public AssetOwnerDefineDomain ( WithAssetObject owner ) { Owner = owner ; }

		public override bool IsValid ( IAsset value ) { return value . Owner == Owner ; }

	}

}
