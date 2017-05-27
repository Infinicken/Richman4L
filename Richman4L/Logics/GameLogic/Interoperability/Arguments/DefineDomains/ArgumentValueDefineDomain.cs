using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;
using WenceyWang . Richman4L . Players ;

namespace WenceyWang . Richman4L . Interoperability . Arguments . DefineDomains
{

	public abstract class ArgumentValueDefineDomain
	{

		public abstract bool IsValid ( [NotNull] object value ) ;

	}

	public abstract class ArgumentValueDefineDomain <T> : ArgumentValueDefineDomain
	{

		public override bool IsValid ( [NotNull] object value ) { return value is T val && IsValid ( val ) ; }

		public abstract bool IsValid ( T value ) ;

	}

	public class AssetOwnerDefineDomain : ArgumentValueDefineDomain <IAsset>
	{

		public WithAssetObject Owner { get ; }

		public AssetOwnerDefineDomain ( WithAssetObject owner ) { Owner = owner ; }

		public override bool IsValid ( IAsset value ) { return value . Owner == Owner ; }

	}

}
