using System ;
using System . Collections ;
using System . Linq ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Navigation ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;
using WenceyWang . Richman4L . Apps . Uni . Pages . Controls ;

namespace WenceyWang . Richman4L . Apps . Uni .Pages
{

	/// <summary>
	///     提供加载动画的页
	/// </summary>
	public sealed partial class LoadingPage : Page
	{

		private SayingPresenter currentPrenster ;

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

			base . OnNavigatedTo ( e ) ;
		}

		private void LoadingPage_Loaded ( object sender , RoutedEventArgs e ) { }

	}

}
