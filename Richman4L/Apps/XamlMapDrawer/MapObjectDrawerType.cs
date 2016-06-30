using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

using WenceyWang . Richman4L . Properties;

namespace WenceyWang . Richman4L . App . XamlMapDrawer
{
	public class MapObjectDrawerType
	{
		[NotNull]
		public Type EntryType { get; }

		[NotNull]
		public Type TargetType { get; }

		internal MapObjectDrawerType ( [NotNull] Type entryType , [NotNull] Type targetType )
		{

			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof ( entryType ) );
			}
			if ( targetType == null )
			{
				throw new ArgumentNullException ( nameof ( targetType ) );
			}


			EntryType = entryType;
			TargetType = targetType;
		}

	}
}
