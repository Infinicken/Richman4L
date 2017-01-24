using System;
using System . Collections;
using System . Linq;

using Windows . Foundation;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Media;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Controls
{

	public class SlidePanel : ContentControl
	{

		public bool IsShow
		{
			get { return ( bool ) GetValue ( IsShowProperty ); }
			set { SetValue ( IsShowProperty , value ); }
		}

		public static readonly DependencyProperty IsShowProperty =
			DependencyProperty . Register ( nameof ( IsShow ) ,
											typeof ( bool ) ,
											typeof ( SlidePanel ) ,
											new PropertyMetadata ( default ( bool ) ) );


		public CompositeTransform HideTransform
		{
			get { return ( CompositeTransform ) GetValue ( HideTransformProperty ); }
			set { SetValue ( HideTransformProperty , value ); }
		}

		public static readonly DependencyProperty HideTransformProperty =
			DependencyProperty . Register ( nameof ( HideTransform ) ,
											typeof ( CompositeTransform ) ,
											typeof ( SlidePanel ) ,
											new PropertyMetadata ( default ( CompositeTransform ) ) );


		public bool ChangeVisability
		{
			get { return ( bool ) GetValue ( ChangeVisabilityProperty ); }
			set { SetValue ( ChangeVisabilityProperty , value ); }
		}

		public static readonly DependencyProperty ChangeVisabilityProperty =
			DependencyProperty . Register ( nameof ( ChangeVisability ) ,
											typeof ( bool ) ,
											typeof ( SlidePanel ) ,
											new PropertyMetadata ( default ( bool ) ) );


		public bool ChangeOpacity
		{
			get { return ( bool ) GetValue ( ChangeOpacityProperty ); }
			set { SetValue ( ChangeOpacityProperty , value ); }
		}

		public static readonly DependencyProperty ChangeOpacityProperty =
			DependencyProperty . Register ( nameof ( ChangeOpacity ) ,
											typeof ( bool ) ,
											typeof ( SlidePanel ) ,
											new PropertyMetadata ( default ( bool ) ) );

		private FrameworkElement content => base . Content as FrameworkElement;

		protected override Size MeasureOverride ( Size availableSize )
		{
			content?.Measure ( availableSize );
			return content?.DesiredSize ?? availableSize;
		}

		protected override Size ArrangeOverride ( Size finalSize )
		{
			content?.Arrange ( new Rect ( new Point ( 0 , 0 ) , finalSize ) );
			return finalSize;
		}

		public void Show ( ) { }

		public void Hide ( ) { }

	}

	public abstract class CanvasContainer : UserControl
	{

		protected override Size MeasureOverride ( Size availableSize )
		{
			FrameworkElement frameworkElement = Content as FrameworkElement;
			if ( frameworkElement != null )
			{
				Content . Measure ( new Size ( frameworkElement . Width , frameworkElement . Height ) );
			}
			return availableSize;
		}

		protected override Size ArrangeOverride ( Size finalSize )
		{
			FrameworkElement frameworkElement = Content as FrameworkElement;
			if ( frameworkElement != null )
			{
				Content . Arrange (
					new Rect (
						new Point ( ( finalSize . Width - frameworkElement . Width ) / 2 ,
									( finalSize . Height - frameworkElement . Height ) / 2 ) ,
						new Size ( frameworkElement . Width , frameworkElement . Height ) ) );
			}
			Content . RenderTransform = Content . DesiredSize . OrginalTransformTo ( finalSize );

			return finalSize;
		}

	}


	public static class OrginalTransformExtensions
	{

		public static CompositeTransform OrginalTransformTo ( this Size source , Size target )
		{
			double scale = Math . Min ( target . Width / source . Width , target . Height / source . Height );
			return new CompositeTransform { ScaleX = scale , ScaleY = scale };
		}

	}

}
