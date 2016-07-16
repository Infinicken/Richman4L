using Windows . Foundation ;
using Windows . UI . Xaml . Media ;

namespace WenceyWang . Richman4L . App .XamlMapRenderer
{

	public static class SizeScaleExtensions
	{

		public static CompositeTransform TransformTo ( this Size source , Size target ) => new CompositeTransform { ScaleX = source . Width / target . Width , ScaleY = source . Height / target . Height } ;

	}

}