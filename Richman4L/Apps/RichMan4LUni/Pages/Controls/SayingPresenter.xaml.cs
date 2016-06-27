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

		public GameSaying Saying { get; set; }

		public SayingPresenter ( GameSaying saying )
		{
			if ( saying == null )
			{
				throw new ArgumentNullException ( nameof ( saying ) );
			}

			Timer = new DispatcherTimer ( );
			Saying = saying;
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
			ContentTextBlock . Text = Saying . Content;
			if ( Saying . People == null )
			{
				PeopleTextBlock . Text = string . Empty;
			}
			else
			{
				PeopleTextBlock . Text = "——" + Saying . People;
			}
			if ( Saying . Song == null )
			{
				if ( Saying . Book == null )
				{
					BookAndAuthorOrSongTextBlock . Text = string . Empty;
				}
				else
				{
					if ( Saying . Author == null )
					{
						BookAndAuthorOrSongTextBlock . Text = "—" + Saying . Book;
					}
					else
					{
						BookAndAuthorOrSongTextBlock . Text = "—" + ( Saying . Book + " by " + Saying . Author );
					}
				}
			}
			else
			{
				BookAndAuthorOrSongTextBlock . Text = "——" + Saying . Song;
			}


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
