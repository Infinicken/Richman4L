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


namespace WenceyWang . Richman4L . App . Pages . Controls
{

	/// <summary>
	/// 显示游戏格言
	/// </summary>
	public sealed partial class SayingPresenter : UserControl
	{

		private DispatcherTimer Timer { get; }

		private GameSaying saying;

		public GameSaying Saying
		{
			get { return saying; }
			set
			{
				if ( value == null )
				{
					throw new ArgumentNullException ( nameof ( value ) );
				}

				saying = value ;

				ContentTextBlock . Text = Saying . Content;

				if ( Saying . People == null )
				{
					PeopleTextBlock . Visibility = Visibility . Collapsed ;
					PeopleTextBlock . Text = string . Empty;
				}
				else
				{
					PeopleTextBlock . Visibility = Visibility .Visible ;
					PeopleTextBlock . Text = $"——{Saying . People}" ;
				}

				if ( Saying . Song == null )
				{
					if ( Saying . Book == null )
					{
						BookAndAuthorOrSongTextBlock . Visibility = Visibility . Collapsed ;
						BookAndAuthorOrSongTextBlock . Text = string . Empty;
					}
					else
					{
						BookAndAuthorOrSongTextBlock . Visibility = Visibility . Visible;
						if ( Saying . Author == null )
						{
							BookAndAuthorOrSongTextBlock . Text = $"—{Saying . Book}" ;
						}
						else
						{
							BookAndAuthorOrSongTextBlock . Text = $"—{ Saying . Book } by { Saying . Author }" ;
						}
					}
				}
				else
				{
					BookAndAuthorOrSongTextBlock . Visibility = Visibility . Visible;
					BookAndAuthorOrSongTextBlock . Text = $"——{Saying . Song}" ;
				}
			}
		}
		
		public SayingPresenter ( )
		{
			Timer = new DispatcherTimer ( );
			InitializeComponent ( );
			Loaded += SayingPresenter_Loaded;
		}

		public void ShowSaying ( )
		{
			VisualStateManager . GoToState ( this , nameof ( Show ) , true );
			Timer . Start ( );
		}

		public event EventHandler ShowOverEvent;

		private void SayingPresenter_Loaded ( object sender , RoutedEventArgs e )
		{
			VisualStateManager . GoToState ( this , nameof ( Hide ) , false );



			Timer . Interval = TimeSpan . FromSeconds ( Saying . Content . Length * 0.1 + 1.5 );

			Timer . Tick += Timer_Tick;
		}


		private void Timer_Tick ( object sender , object e )
		{
			Timer . Stop ( );
			VisualStateManager . GoToState ( this , nameof ( Hide ) , true );
			Timer . Tick -= Timer_Tick;
			ShowOverEvent?.Invoke ( this , new EventArgs ( ) );
		}
	}

}
