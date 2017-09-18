using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics . Maps . Events
{

	public class MapRemoveMapObjectEventArgs : EventArgs
	{

		[NotNull]
		public MapObject PastObject { get ; }

		public MapRemoveMapObjectEventArgs ( [NotNull] MapObject pastObject )
		{
			PastObject = pastObject ?? throw new ArgumentNullException ( nameof(pastObject) ) ;
		}

	}

}
