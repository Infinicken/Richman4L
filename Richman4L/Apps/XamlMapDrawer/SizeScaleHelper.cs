using Windows . Foundation ;
using Windows . UI . Xaml . Media ;

namespace WenceyWang . Richman4L . App .XamlMapDrawer
{

	public static class SizeScaleHelper
	{

		public static ScaleTransform TransformTo ( this Size source , Size target ) => new ScaleTransform { ScaleX = source . Width / target . Width , ScaleY = source . Height / target . Height } ;

	}

}