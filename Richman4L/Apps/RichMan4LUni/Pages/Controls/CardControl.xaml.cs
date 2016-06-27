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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WenceyWang . Richman4L . App . Pages . Controls
{
    public sealed partial class CardControl : UserControl
    {
        public CardControl ( )
        {
	        InitializeComponent ( );
        }

        public event EventHandler UseCard;

        public string Title
        {
            get
            {
                return TitleTextBlock?.Text;
            }
            set
            {
                if ( TitleTextBlock != null )
                {
                    TitleTextBlock . Text = value;
                }
            }
        }
        public string Text
        {
            get
            {
                return TextTextBlock?.Text;
            }
            set
            {
                if ( TextTextBlock != null )
                {
                    TextTextBlock . Text = value;
                }
            }
        }

        public ImageSource Image
        {
            get
            {
                return ImageImage . Source;
            }
            set
            {
                if ( TextTextBlock != null )
                {
                    ImageImage . Source = value;
                }
            }
        }

        private void UseButton_Click ( object sender , RoutedEventArgs e )
        {
            UseCard?.Invoke ( this , new EventArgs ( ) );
        }

        private void UserControl_Loaded ( object sender , RoutedEventArgs e )
        {

        }
    }
}
