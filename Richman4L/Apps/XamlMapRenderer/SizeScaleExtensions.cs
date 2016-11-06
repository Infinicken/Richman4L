using System ;
using System . Collections ;
using System . Linq ;

using Windows . Foundation ;
using Windows . UI . Xaml . Media ;

namespace WenceyWang . Richman4L . App .XamlMapRenderer
{

	public static class SizeScaleExtensions
	{

		public static CompositeTransform TransformTo ( this Size source , Size target )
			=> new CompositeTransform { ScaleX = target . Width / source . Width , ScaleY = target . Height / source . Height } ;

	}

}
