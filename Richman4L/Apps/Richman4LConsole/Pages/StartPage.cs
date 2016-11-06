using System ;
using System . Collections ;
using System . Linq ;
using System . Threading ;
using System . Threading . Tasks ;

using WenceyWang . FoggyConsole ;
using WenceyWang . FoggyConsole . Controls ;
using WenceyWang . Richman4L . Apps . Console . Fonts ;

namespace WenceyWang . Richman4L . Apps . Console .Pages
{

	public sealed class StartPage : Page
	{

		public FIGletLabel Label { get ; set ; }

		public StartPage ( )
		{
			Label = new FIGletLabel ( ) ;

			Canvas canvas = new Canvas ( ) ;

			canvas . AddChild ( Label ) ;

			Content = canvas ;
		}

		public void UpdatePosition ( ) { }

		public override void OnNavigateTo ( ) { ShowAnimate ( ) ; }

		private void ShowAnimate ( )
		{
			Task animateTask = Task . Run ( ( ) =>
											{
												Thread . Sleep ( TimeSpan . FromSeconds ( 0.5 ) ) ;
												Label . Font = FontsHelper . LoadFont ( "invita" ) ;
												Label . ForegroundColor = ConsoleColor . Gray ;
												Label . BackgroundColor = ConsoleColor . Black ;
												Label . Text = "Wencey Wang Present" ;
												Thread . Sleep ( TimeSpan . FromSeconds ( 0.5 ) ) ;
												Label . ForegroundColor = ConsoleColor . White ;
												Thread . Sleep ( TimeSpan . FromSeconds ( 2 ) ) ;
												Label . ForegroundColor = ConsoleColor . Gray ;
												Thread . Sleep ( TimeSpan . FromSeconds ( 0.5 ) ) ;
												Label . ForegroundColor = ConsoleColor . Black ;
												Label . Text = "Dream Recorder" ;
												Thread . Sleep ( TimeSpan . FromSeconds ( 0.5 ) ) ;
												Label . ForegroundColor = ConsoleColor . Gray ;
												Thread . Sleep ( TimeSpan . FromSeconds ( 0.5 ) ) ;
												Label . ForegroundColor = ConsoleColor . White ;
												Thread . Sleep ( TimeSpan . FromSeconds ( 2 ) ) ;
												Label . ForegroundColor = ConsoleColor . Gray ;
												Thread . Sleep ( TimeSpan . FromSeconds ( 0.5 ) ) ;
												Label . ForegroundColor = ConsoleColor . Black ;
											} ) ;

			animateTask . Wait ( ) ;

			Frame . NavigateTo ( new MainPage ( ) ) ;
		}

		public override void Arrange ( Rectangle finalRect ) { base . Arrange ( finalRect ) ; }

		public override void Measure ( Size availableSize )
		{
			base . Measure ( availableSize ) ;

			( ( Canvas ) Content ) [ Label ] = new Point ( ( availableSize . Width - Label . Width ) / 2 ,
															( availableSize . Height - Label . Height ) / 2 ) ;
		}

	}

}
