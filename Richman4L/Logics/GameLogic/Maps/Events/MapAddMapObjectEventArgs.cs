using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Logics . Maps . Events
{

	public class MapAddMapObjectEventArgs : EventArgs
	{

		[NotNull]
		public MapObject NewObject { get ; }

		public MapAddMapObjectEventArgs ( [NotNull] MapObject newObject )
		{
			NewObject = newObject ?? throw new ArgumentNullException ( nameof(newObject) ) ;
		}

	}

}
