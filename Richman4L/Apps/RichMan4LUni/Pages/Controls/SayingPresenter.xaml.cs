using System ;
using System . Collections ;
using System . Linq ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;

namespace WenceyWang . Richman4L . Apps . Uni . Pages .Controls
{

	/// <summary>
	///     显示游戏格言
	/// </summary>
	public sealed partial class SayingPresenter : UserControl
	{

		public GameSaying Saying
		{
			get { return ( GameSaying ) GetValue ( SayingProperty ) ; }
			set
			{
				if ( value == null )
				{
					throw new ArgumentNullException ( nameof ( value ) ) ;
				}

				SetValue ( SayingProperty , value ) ;

				ContentTextBlock . Text = Saying . Content ;

				if ( Saying . People == null )
				{
					PeopleTextBlock . Visibility = Visibility . Collapsed ;
					PeopleTextBlock . Text = string . Empty ;
				}
				else
				{
					PeopleTextBlock . Visibility = Visibility . Visible ;
					PeopleTextBlock . Text = $"——{Saying . People}" ;
				}

				if ( Saying . Song == null )
				{
					if ( Saying . Book == null )
					{
						BookAndAuthorOrSongTextBlock . Visibility = Visibility . Collapsed ;
						BookAndAuthorOrSongTextBlock . Text = string . Empty ;
					}
					else
					{
						BookAndAuthorOrSongTextBlock . Visibility = Visibility . Visible ;
						if ( Saying . Author == null )
						{
							BookAndAuthorOrSongTextBlock . Text = $"—{Saying . Book}" ;
						}
						else
						{
							BookAndAuthorOrSongTextBlock . Text = $"—{Saying . Book} by {Saying . Author}" ;
						}
					}
				}
				else
				{
					BookAndAuthorOrSongTextBlock . Visibility = Visibility . Visible ;
					BookAndAuthorOrSongTextBlock . Text = $"——{Saying . Song}" ;
				}
			}
		}

		public SayingPresenter ( )
		{
			InitializeComponent ( ) ;
			Loaded += SayingPresenter_Loaded ;
		}


		public static readonly DependencyProperty SayingProperty =
			DependencyProperty . Register ( nameof ( Saying ) ,
											typeof ( GameSaying ) ,
											typeof ( SayingPresenter ) ,
											new PropertyMetadata ( default ( GameSaying ) ) ) ;

		public void Hide ( ) { VisualStateManager . GoToState ( this , nameof ( HideState ) , true ) ; }

		public void Show ( ) { VisualStateManager . GoToState ( this , nameof ( ShowState ) , true ) ; }

		public void ShowSaying ( ) { VisualStateManager . GoToState ( this , nameof ( ShowState ) , true ) ; }

		public event EventHandler ShowOverEvent ;

		private void SayingPresenter_Loaded ( object sender , RoutedEventArgs e )
		{
			VisualStateManager . GoToState ( this , nameof ( HideState ) , false ) ;
		}

	}

}
