using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Players
{

	public interface IUser : IEquatable <IUser>
	{

		[Own]
		string DisplayName { get ; }

		[Own ( PropertyVisability . Owner )]
		Guid Guid { get ; set ; }

	}

}
