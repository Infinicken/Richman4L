using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;

namespace WenceyWang . Richman4L . Services . Directories
{

	public class User
	{

	}

	public class GameServer
	{

		public Guid Guid { get ; set ; }

		public EndPoint EndPoint { get ; set ; }

		public Version ServerVersion { get ; set ; }

	}

}
