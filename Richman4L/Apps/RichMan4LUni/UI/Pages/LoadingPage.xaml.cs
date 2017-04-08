using System ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Navigation ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;
using WenceyWang . Richman4L . Apps . Uni . UI . Controls ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Pages
{

	/// <summary>
	///     提供加载动画的页
	/// </summary>
	public sealed partial class LoadingPage : AnimatePage
	{

		private SayingPresenter CurrentPrenster { get ; set ; }

		private DispatcherTimer Timer { get ; set ; }

		private GameSaying CurrentSaying { get ; set ; }

		private SayingPresenter HidePrsenster { get ; set ; }

		public static Color PageColor => XamlResources . Resources . LightBlue ;

		public LoadingPageArgument Argument { get ; private set ; }

		public LoadingPage ( )
		{
			InitializeComponent ( ) ;
			Loaded += LoadingPage_Loaded ;
		}

		protected override void OnNavigatedTo ( NavigationEventArgs e )
		{
			LoadingPageArgument argument = e . Parameter as LoadingPageArgument ;
			if ( argument != null )
			{
				Argument = argument ;
			}
			else
			{
				throw new ArgumentException ( "Invalid Loading Parameter" ) ;
			}

			argument . LoadingStatusAdded += LoadingStatusAdded ;
			argument . LoadingProcessChanged += LoadingProcessChanged ;
			base . OnNavigatedTo ( e ) ;
		}

		private void LoadingProcessChanged ( object sender , EventArgs e )
		{
			LoadingProgressProgressBar . Value = Argument . LoadingProcess ;
		}

		private void LoadingStatusAdded ( object sender , LoadingStatusAddedEventArgs e )
		{
			LoadingStatus newStatus = e . NewStatus ;
			newStatus . FinishedEvent += StatusFinishedEvent ;
			newStatus . LoadingProcessChanged += StatusLoadingProcessChanged ;
			TextBlock statusTextBlock = new TextBlock ( ) ;
			statusTextBlock . FontSize = XamlResources . Resources . FontSize ;
			statusTextBlock . FontFamily = XamlResources . Resources . Font ;
		}

		private void StatusLoadingProcessChanged ( object sender , EventArgs e )
		{
			LoadingStatus status = ( LoadingStatus ) sender ;
			TextBlock statusTextBlock = GetTextBlock ( status ) ;
			if ( status . LoadingProcess <= 100 )
			{
				statusTextBlock . Text = $"{status . Name}…{status . LoadingProcess}" ;
			}
			else
			{
				statusTextBlock . Text = $"{status . Name}…OK" ;
			}
		}

		private void StatusFinishedEvent ( object sender , EventArgs e )
		{
			( ( LoadingStatus ) sender ) . FinishedEvent -= StatusFinishedEvent ;
		}

		public override void AddControl ( ) { }

		public override void RemoveControl ( ) { }

		private void LoadingPage_Loaded ( object sender , RoutedEventArgs e )
		{
			CurrentPrenster = ASayibgPresenter ;
			HidePrsenster = BSayibgPresenter ;

			Timer = new DispatcherTimer ( ) ;
			Timer . Interval = UpdateSaying ( ) ;
			Timer . Tick += TimerTick ;
			Timer . Start ( ) ;
		}

		private TimeSpan UpdateSaying ( )
		{
			CurrentSaying = GameSaying . GetSaying ( ) ;

			SayingPresenter newPresenter = HidePrsenster ;

			HidePrsenster = CurrentPrenster ;
			HidePrsenster . Hide ( ) ;

			CurrentPrenster = newPresenter ;
			CurrentPrenster . Saying = CurrentSaying ;
			CurrentPrenster . Show ( ) ;

			TimeSpan timeSpan = TimeSpan . FromSeconds ( CurrentSaying . Content . Length * 0.1 + 2 ) ;
			return timeSpan ;
		}

		private TextBlock GetTextBlock ( LoadingStatus status )
		{
			return ( TextBlock ) StatusStackPanel . Children [ Argument . LoadingStatusList . IndexOf ( status ) ] ;
		}

		private void TimerTick ( object sender , object e )
		{
			if ( Argument . TaskToWait . IsFaulted ||
				Argument . TaskToWait . IsCanceled )
			{
				throw Argument . TaskToWait . Exception ;
			}

			if ( Argument . TaskToWait . IsCompleted )
			{
				Timer . Stop ( ) ;
				Timer . Tick -= TimerTick ;
				Argument . ToDoNext ( this ) ;
			}
			else
			{
				Timer . Interval = UpdateSaying ( ) ;
			}
		}

	}

}
