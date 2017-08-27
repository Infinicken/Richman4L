using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . Foundation ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Media ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Controls
{

	public abstract class CanvasContainer : UserControl
	{

		protected override Size MeasureOverride ( Size availableSize )
		{
			FrameworkElement frameworkElement = Content as FrameworkElement ;

			if ( frameworkElement != null )
			{
				Size requireSize = new Size ( frameworkElement . Width , frameworkElement . Height ) ;
				Content . Measure ( requireSize ) ;
				double zoomRatio = Math . Min ( availableSize . Height / requireSize . Height ,
												availableSize . Width / requireSize . Width ) ;

				return new Size ( requireSize . Width * zoomRatio , requireSize . Height * zoomRatio ) ;
			}

			return availableSize ;
		}

		protected override Size ArrangeOverride ( Size finalSize )
		{
			FrameworkElement frameworkElement = Content as FrameworkElement ;
			if ( frameworkElement != null )
			{
				Content . Arrange ( new Rect ( new Point ( ( finalSize . Width - frameworkElement . Width ) / 2 ,
															( finalSize . Height - frameworkElement . Height ) / 2 ) ,
												new Size ( frameworkElement . Width , frameworkElement . Height ) ) ) ;
			}
			Content . RenderTransform = Content . DesiredSize . OrginalTransformTo ( finalSize ) ;

			return finalSize ;
		}

	}


	public static class OrginalTransformExtensions
	{

		public static CompositeTransform OrginalTransformTo ( this Size source , Size target )
		{
			double scale = Math . Min ( target . Width / source . Width , target . Height / source . Height ) ;
			return new CompositeTransform { ScaleX = scale , ScaleY = scale } ;
		}

	}

}
