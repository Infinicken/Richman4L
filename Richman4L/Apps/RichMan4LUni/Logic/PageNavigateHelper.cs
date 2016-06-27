using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;
using Windows . Foundation;
using Windows . Foundation . Collections;
using Windows . UI;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . ViewManagement;
using Windows . UI . Xaml . Media . Animation;
using Windows . UI . Xaml . Controls . Primitives;
using Windows . UI . Xaml . Data;
using Windows . UI . Xaml . Input;
using Windows . UI . Xaml . Media;
using Windows . UI . Xaml . Shapes;
using Windows . UI . Xaml . Navigation;

namespace WenceyWang . Richman4L . App . Logic
{
    class BlankNavigationTransitionInfo : NavigationTransitionInfo
    {

        public BlankNavigationTransitionInfo ( )
        {

        }


    }

    public static class PageNavigateHelper
    {
		/// <summary>
		/// 导航到指定的页
		/// </summary>
		/// <param name="targetPageType">要导航到的页</param>
		/// <param name="parameter">要传递的参数</param>
		/// <param name="color">目标页的颜色</param>
		/// <param name="leaveStoryBoard">离开当前页时播放的动画</param>
		/// <param name="backGroundRect">当前页面的背景</param>
		/// <param name="frame">当前的Frame</param>
		/// <param name="removeControls">移除当前页面控制的方法</param>
		/// <param name="addControls">为当前页面添加控制的方法</param>
        public static void Navigate ( Type targetPageType , object parameter , string color , Storyboard leaveStoryBoard , Rectangle backGroundRect , Frame frame , Action removeControls = null , Action addControls = null )
        {
            if ( leaveStoryBoard . GetCurrentState ( ) == ClockState . Stopped )
            {
                ColorAnimationUsingKeyFrames ca = new ColorAnimationUsingKeyFrames ( );
                Storyboard . SetTargetName ( ca , "BackGroundRect" );
                Storyboard . SetTargetProperty ( ca , "(Shape.Fill).(SolidColorBrush.Color)" );
                ca . KeyFrames . Add ( new EasingColorKeyFrame { KeyTime = KeyTime . FromTimeSpan ( TimeSpan . FromSeconds ( 0.5 ) ) , Value = ( backGroundRect . Fill as SolidColorBrush ) . Color , EasingFunction = Application . Current . Resources [ "EasingFunction" ] as CubicEase } );
                ca . KeyFrames . Add ( new EasingColorKeyFrame { KeyTime = KeyTime . FromTimeSpan ( TimeSpan . FromSeconds ( 1 ) ) , Value = ( Application . Current . Resources [ color ] as SolidColorBrush ) . Color , EasingFunction = Application . Current . Resources [ "EasingFunction" ] as CubicEase } );
                leaveStoryBoard . Children . Add ( ca );
                leaveStoryBoard . Completed += ( obj , ev ) =>
                {
                    frame . Navigate ( targetPageType , parameter , new BlankNavigationTransitionInfo ( ) );
                    leaveStoryBoard . Stop ( );
                    leaveStoryBoard . Children . Remove ( ca );
                    addControls?.Invoke ( );
                };
                removeControls?.Invoke ( );
                leaveStoryBoard . Begin ( );
            }
        }



    }

}
