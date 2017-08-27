using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps . Buildings
{

	/// <summary>
	///     Point out the reason that building destroyed
	/// </summary>
	public enum BuildingDestroyReason
	{

		/// <summary>
		///     Bad Weather
		/// </summary>
		Weather ,

		/// <summary>
		///     Earthquake
		/// </summary>
		RandomEvent ,

		/// <summary>
		///     Card "Destroy some building"
		/// </summary>
		Card ,

		/// <summary>
		///     Player with bomb
		/// </summary>
		PlayerBuff

	}

}
