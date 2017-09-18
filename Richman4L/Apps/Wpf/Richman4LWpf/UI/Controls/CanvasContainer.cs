using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows ;
using System . Windows . Controls ;
using System . Windows . Markup ;
using System . Windows . Media ;

namespace WenceyWang . Richman4L . Apps . Wpf . UI . Controls
{

	public class CompositeTransformExtension : MarkupExtension
	{

		private RotateTransform _rotate = new RotateTransform ( ) ;

		private ScaleTransform _scale = new ScaleTransform ( ) ;

		private SkewTransform _skew = new SkewTransform ( ) ;

		private TranslateTransform _translate = new TranslateTransform ( ) ;

		public double CenterX
		{
			get => _scale . CenterX ;
			set
			{
				_scale . CenterX = value ;
				_skew . CenterX = value ;
				_rotate . CenterX = value ;
			}
		}

		public double CenterY
		{
			get => _scale . CenterY ;
			set
			{
				_scale . CenterY = value ;
				_skew . CenterY = value ;
				_rotate . CenterY = value ;
			}
		}

		public double ScaleX { get => _scale . ScaleX ; set => _scale . ScaleX = value ; }

		public double ScaleY { get => _scale . ScaleY ; set => _scale . ScaleY = value ; }

		public double SkewX { get => _skew . AngleX ; set => _skew . AngleX = value ; }

		public double SkewY { get => _skew . AngleY ; set => _skew . AngleY = value ; }

		public double Rotation { get => _rotate . Angle ; set => _rotate . Angle = value ; }

		public double TranslateX { get => _translate . X ; set => _translate . X = value ; }

		public double TranslateY { get => _translate . Y ; set => _translate . Y = value ; }

		public override object ProvideValue ( IServiceProvider serviceProvider )
		{
			TransformGroup group = new TransformGroup ( ) ;

			group . Children . Add ( _scale ) ;
			group . Children . Add ( _skew ) ;
			group . Children . Add ( _rotate ) ;
			group . Children . Add ( _translate ) ;

			return group ;
		}

	}

	public abstract class CanvasContainer : UserControl
	{

		protected override Size MeasureOverride ( Size availableSize )
		{
			if ( Content is FrameworkElement frameworkElement )
			{
				Size requireSize = new Size ( frameworkElement . Width , frameworkElement . Height ) ;
				frameworkElement . Measure ( requireSize ) ;
				double zoomRatio = Math . Min ( availableSize . Height / requireSize . Height ,
												availableSize . Width / requireSize . Width ) ;

				return new Size ( requireSize . Width * zoomRatio , requireSize . Height * zoomRatio ) ;
			}

			return availableSize ;
		}

		protected override Size ArrangeOverride ( Size finalSize )
		{
			if ( Content is FrameworkElement frameworkElement )
			{
				frameworkElement . Arrange ( new Rect ( new Point ( ( finalSize . Width - frameworkElement . Width ) / 2 ,
																	( finalSize . Height - frameworkElement . Height ) / 2 ) ,
														new Size ( frameworkElement . Width , frameworkElement . Height ) ) ) ;
				frameworkElement . RenderTransform = frameworkElement . DesiredSize . OrginalTransformTo ( finalSize ) ;
			}

			return finalSize ;
		}

	}


	public static class OrginalTransformExtensions
	{

		public static CompositeTransform OrginalTransformTo ( this Size source , Size target )
		{
			Matrix .
			double scale = Math . Min ( target . Width / source . Width , target . Height / source . Height ) ;
			return new CompositeTransform { ScaleX = scale , ScaleY = scale } ;
		}

	}

}
