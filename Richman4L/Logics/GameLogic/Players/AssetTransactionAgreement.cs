using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Players
{

	public sealed class AssetTransactionAgreement
	{

		public WithAssetObject PartyA { get ; set ; }

		public IAsset PartyAProvide { get ; set ; }

		public WithAssetObject PartyB { get ; set ; }

		public IAsset PartyBProvide { get ; set ; }


		/// <summary>
		///     被用于希望卖东西
		/// </summary>
		/// <param name="partyA"></param>
		/// <param name="partyAProvide"></param>
		/// <param name="partyB"></param>
		public AssetTransactionAgreement ( WithAssetObject partyA , IAsset partyAProvide , WithAssetObject partyB )
		{
			PartyA = partyA ;
			PartyAProvide = partyAProvide ;
			PartyB = partyB ;
		}

		/// <summary>
		///     被用于希望买东西
		/// </summary>
		/// <param name="partyA"></param>
		/// <param name="partyB"></param>
		/// <param name="partyBProvide"></param>
		public AssetTransactionAgreement ( WithAssetObject partyA , WithAssetObject partyB , IAsset partyBProvide )
		{
			PartyA = partyA ;
			PartyB = partyB ;
			PartyBProvide = partyBProvide ;
		}

	}

}
