using System ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . Foundation ;
using Windows . UI . Xaml . Media ;

namespace WenceyWang . Richman4L . Apps . XamlMapRenderers
{

	public static class SizeScaleExtensions
	{

		public static CompositeTransform TransformTo ( this Size source , Size target )
		{
			return new CompositeTransform
					{
						ScaleX = target . Width / source . Width ,
						ScaleY = target . Height / source . Height
					} ;
		}

	}

}
