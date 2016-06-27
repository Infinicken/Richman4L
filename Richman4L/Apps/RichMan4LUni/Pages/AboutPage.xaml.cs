using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;
using Windows . Foundation;
using Windows . Foundation . Collections;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Controls . Primitives;
using Windows . UI . Xaml . Data;
using Windows . UI . Xaml . Input;
using Windows . UI . Xaml . Media;
using Windows . UI . Xaml . Navigation;
using WenceyWang . Richman4L . App . Logic;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace WenceyWang . Richman4L . App . Pages
{
    /// <summary>
    /// 关于页。
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        public AboutPage ( )
        {
	        InitializeComponent ( );
	        StartStoryBoard . Completed += StartStoryBoard_Completed;
        }

        private void StartStoryBoard_Completed ( object sender , object e )
        {
            if ( AppSettings . Current . OcdMode )
            {
                MainGrid . TurnOnOcdMode ( );
            }
            StartStoryBoard . Completed -= StartStoryBoard_Completed;
        }

        protected override void OnNavigatedTo ( NavigationEventArgs e )
        {
        }

        private void Page_Loaded ( object sender , RoutedEventArgs e )
        {
            StartStoryBoard . Begin ( );
        }


        private void TextBlock_Tapped ( object sender , TappedRoutedEventArgs e )
        {

        }


        private void SettingPageButton_Click ( object sender , RoutedEventArgs e )
        {
            PageNavigateHelper . Navigate ( typeof ( SettingPage ) , null , "DeepRed" , LeaveStoryBoard , BackGroundRect , Frame , RemoveControl , AddControl );
        }

        private void RemoveControl ( )
        {
            SettingPageButton . Click -= SettingPageButton_Click;
        }

        private void AddControl ( )
        {
            SettingPageButton . Click += SettingPageButton_Click;
        }
    }
}
