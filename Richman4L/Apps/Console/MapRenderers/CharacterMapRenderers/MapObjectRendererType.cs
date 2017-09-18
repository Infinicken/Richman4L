using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Apps . Console . MapRenderers
{

	public class MapObjectRendererType
	{

		[NotNull]
		public Type EntryType { get ; }

		[NotNull]
		public Type TargetType { get ; }

		internal MapObjectRendererType ( [NotNull] Type entryType , [NotNull] Type targetType )
		{
			EntryType = entryType ?? throw new ArgumentNullException ( nameof(entryType) ) ;
			TargetType = targetType ?? throw new ArgumentNullException ( nameof(targetType) ) ;
		}

	}

}
