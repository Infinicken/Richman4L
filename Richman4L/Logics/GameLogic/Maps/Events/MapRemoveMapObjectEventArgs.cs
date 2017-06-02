using System ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . Maps . Events
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
