using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace WenceyWang.Richman4L.Apps.Uni.UI.Controls
{

	public class SlidePanel : ContentControl
	{


		public List<Tuple<UIElement, CompositeTransform>> HideTransforms
		{
			get { return (List<Tuple<UIElement, CompositeTransform>>)GetValue(HideTransformsProperty); }
			set { SetValue(HideTransformsProperty, value); }
		}

		public static readonly DependencyProperty HideTransformsProperty =
			DependencyProperty.Register(nameof(HideTransforms), typeof(List<Tuple<UIElement, CompositeTransform>>), typeof(SlidePanel), new PropertyMetadata(new List<Tuple<UIElement, CompositeTransform>>()));


		public bool IsShow
		{
			get { return (bool)GetValue(IsShowProperty); }
			set { SetValue(IsShowProperty, value); }
		}


		public CompositeTransform HideTransform
		{
			get { return (CompositeTransform)GetValue(HideTransformProperty); }
			set { SetValue(HideTransformProperty, value); }
		}


		public bool ChangeVisability
		{
			get { return (bool)GetValue(ChangeVisabilityProperty); }
			set { SetValue(ChangeVisabilityProperty, value); }
		}


		public bool ChangeOpacity
		{
			get { return (bool)GetValue(ChangeOpacityProperty); }
			set { SetValue(ChangeOpacityProperty, value); }
		}


		public Storyboard ShowStoryBoard
		{
			get { return (Storyboard)GetValue(ShowStoryBoardProperty); }
			set { SetValue(ShowStoryBoardProperty, value); }
		}


		public Storyboard HideStoryboard
		{
			get { return (Storyboard)GetValue(HideStoryboardProperty); }
			set { SetValue(HideStoryboardProperty, value); }
		}


		private FrameworkElement content => Content as FrameworkElement;

		public static readonly DependencyProperty ShowStoryBoardProperty =
			DependencyProperty.Register(nameof(ShowStoryBoard),
											typeof(Storyboard),
											typeof(CanvasContainer),
											new PropertyMetadata(default(Storyboard)));

		public static readonly DependencyProperty HideStoryboardProperty =
			DependencyProperty.Register(nameof(HideStoryboard),
											typeof(Storyboard),
											typeof(CanvasContainer),
											new PropertyMetadata(default(Storyboard)));

		public static readonly DependencyProperty IsShowProperty =
			DependencyProperty.Register(nameof(IsShow),
											typeof(bool),
											typeof(SlidePanel),
											new PropertyMetadata(true));

		public static readonly DependencyProperty HideTransformProperty =
			DependencyProperty.Register(nameof(HideTransform),
											typeof(CompositeTransform),
											typeof(SlidePanel),
											new PropertyMetadata(default(CompositeTransform)));

		public static readonly DependencyProperty ChangeVisabilityProperty =
			DependencyProperty.Register(nameof(ChangeVisability),
											typeof(bool),
											typeof(SlidePanel),
											new PropertyMetadata(false));

		public static readonly DependencyProperty ChangeOpacityProperty =
			DependencyProperty.Register(nameof(ChangeOpacity),
											typeof(bool),
											typeof(SlidePanel),
											new PropertyMetadata(false));

		protected override Size MeasureOverride(Size availableSize)
		{
			content?.Measure(availableSize);
			return content?.DesiredSize ?? availableSize;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			content?.Arrange(new Rect(new Point(0, 0), finalSize));
			return finalSize;
		}

		public event EventHandler Showed;


		public event EventHandler Hideed;




		public void Show()
		{
			if (!IsShow)
			{
				ShowStoryBoard.Completed += ShowStoryBoard_Completed;
				ShowStoryBoard.Begin();
			}
		}

		private void ShowStoryBoard_Completed(object sender, object e)
		{
			RenderTransform = new CompositeTransform();
			foreach (Tuple<UIElement, CompositeTransform> hideTran in HideTransforms)
			{
				hideTran.Item1.RenderTransform = new CompositeTransform();
			}

			ShowStoryBoard.Completed -= ShowStoryBoard_Completed;
		}

		public void Hide()
		{
			if (!IsShow)
			{
				HideStoryboard.Completed += HideStoryboard_Completed;
				HideStoryboard.Begin();
			}
		}

		private void HideStoryboard_Completed(object sender, object e)
		{
			RenderTransform = HideTransform;
			foreach (Tuple<UIElement, CompositeTransform> hideTran in HideTransforms)
			{
				hideTran.Item1.RenderTransform = hideTran.Item2;
			}

			HideStoryboard.Completed -= HideStoryboard_Completed;
		}

	}

	public abstract class CanvasContainer : UserControl
	{

		protected override Size MeasureOverride(Size availableSize)
		{
			FrameworkElement frameworkElement = Content as FrameworkElement;
			if (frameworkElement != null)
			{
				Content.Measure(new Size(frameworkElement.Width, frameworkElement.Height));
			}
			return availableSize;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			FrameworkElement frameworkElement = Content as FrameworkElement;
			if (frameworkElement != null)
			{
				Content.Arrange(
					new Rect(
						new Point((finalSize.Width - frameworkElement.Width) / 2,
									(finalSize.Height - frameworkElement.Height) / 2),
						new Size(frameworkElement.Width, frameworkElement.Height)));
			}
			Content.RenderTransform = Content.DesiredSize.OrginalTransformTo(finalSize);

			return finalSize;
		}

	}


	public static class OrginalTransformExtensions
	{

		public static CompositeTransform OrginalTransformTo(this Size source, Size target)
		{
			double scale = Math.Min(target.Width / source.Width, target.Height / source.Height);
			return new CompositeTransform { ScaleX = scale, ScaleY = scale };
		}

	}

}
