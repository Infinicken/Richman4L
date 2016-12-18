using System ;
using System . Collections ;
using System . Linq ;

using Windows . UI . Xaml . Media . Animation ;

using WenceyWang . Richman4L . Apps . Uni . Pages ;
using WenceyWang . Richman4L . Apps . Uni . XamlResources ;

namespace WenceyWang . Richman4L . Apps . Uni .Logic
{

	internal class BlankNavigationTransitionInfo : NavigationTransitionInfo
	{

	}

	public static class PageNavigateHelper
	{

		public static void NavigateTo <T> ( this AnimatePage page , object parameter = null ) where T : AnimatePage
		{
			ColorAnimationUsingKeyFrames ca = new ColorAnimationUsingKeyFrames ( ) ;
			Storyboard . SetTargetName ( ca , "BackGroundRect" ) ;
			Storyboard . SetTargetProperty ( ca , "(Shape.Fill).(SolidColorBrush.Color)" ) ;
			ca . KeyFrames . Add ( new EasingColorKeyFrame
									{
										KeyTime = KeyTime . FromTimeSpan ( TimeSpan . FromSeconds ( 0.5 ) ) ,
										Value = AnimatePage . GetPageColor ( page ) ,
										EasingFunction = Resources . EasingFunction
									} ) ;

			ca . KeyFrames . Add ( new EasingColorKeyFrame
									{
										KeyTime = KeyTime . FromTimeSpan ( TimeSpan . FromSeconds ( 1 ) ) ,
										Value = AnimatePage . GetPageColor <T> ( ) ,
										EasingFunction = Resources . EasingFunction
									} ) ;

			page . GetLeaveStoryboard . Children . Add ( ca ) ;
			page . GetLeaveStoryboard . Completed += ( obj , ev ) =>
													{
														page . Frame . Navigate ( typeof ( T ) , parameter , new BlankNavigationTransitionInfo ( ) ) ;
														page . GetLeaveStoryboard . Stop ( ) ;
														page . GetLeaveStoryboard . Children . Remove ( ca ) ;
														page . AddControl ( ) ;
													} ;
			page . RemoveControl ( ) ;
			page . GetLeaveStoryboard . Begin ( ) ;
		}

	}

}
