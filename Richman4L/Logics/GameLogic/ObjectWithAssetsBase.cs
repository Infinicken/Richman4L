using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L
{
	public abstract class AssetsOwnerBase
	{
		public abstract decimal  Cash { get; }

		public abstract decimal DemandDeposits { get ; }

		public abstract List<Area> ListOfArea;

	}
}
