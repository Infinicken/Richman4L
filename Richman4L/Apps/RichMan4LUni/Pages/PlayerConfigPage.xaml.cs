using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

using Windows . UI ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Navigation ;

using WenceyWang . Richman4L . Apps . Uni . Logic ;
using WenceyWang . Richman4L . Apps . Uni . Pages . Controls ;
using WenceyWang . Richman4L . GameEnviroment ;
using WenceyWang . Richman4L . Players . Models ;

namespace WenceyWang . Richman4L . Apps . Uni .Pages
{

	/// <summary>
	///     玩家配置页
	/// </summary>
	public sealed partial class PlayerConfigPage : AnimatePage
	{

		public StartGameParameters Parameters { get ; set ; }

		public static Color PageColor => XamlResources . Resources . Lime ;

		public PlayerConfigPage ( ) { InitializeComponent ( ) ; }

		protected override void OnNavigatedTo ( NavigationEventArgs e )
		{
			Parameters = e . Parameter as StartGameParameters ;
		}

		private void Page_Loaded ( object sender , RoutedEventArgs e )
		{
			if ( Parameters != null )
			{
				GenerateList ( ) ;
			}
			StartStoryboard . Begin ( ) ;
			StartStoryboard . Completed += StartStoryboard_Completed ;
		}

		private void StartStoryboard_Completed ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( ) ;
			}
			StartStoryboard . Completed -= StartStoryboard_Completed ;
		}

		private void CreateGamePageButton_Click ( object sender , RoutedEventArgs e )
		{
			//PageNavigateHelper . NavigateTo ( typeof ( CreateGamePage ) ,
			//								Parameters ,
			//								"LimeBrush" ,
			//								LeaveStoryboard ,
			//								BackGroundRect ,
			//								Frame ,
			//								RemoveControl ,
			//								AddControl ) ;
		}

		private void StartGameButton_Click ( object sender , RoutedEventArgs e )
		{
			LoadingPageArgument parameters = new LoadingPageArgument ( Task . Run ( ( ) =>
																					{
																						Game game = new Game ( ) ;
																						Game . Current . Start ( Parameters ) ;
																					} ) ,
																		( ) => { } ) ;

			//PageNavigateHelper . NavigateTo ( typeof ( LoadingPage ) ,
			//								parameters ,
			//								"LimeBrush" ,
			//								LeaveStoryboard ,
			//								BackGroundRect ,
			//								Frame ,
			//								RemoveControl ,
			//								AddControl ) ;
		}

		public override void RemoveControl ( )
		{
			CreateGamePageButton . Click -= CreateGamePageButton_Click ;
			StartGameButton . Click -= StartGameButton_Click ;
		}

		public override void AddControl ( )
		{
			CreateGamePageButton . Click += CreateGamePageButton_Click ;
			StartGameButton . Click += StartGameButton_Click ;
		}

		private void AddButton_Click ( object sender , RoutedEventArgs e )
		{
			List <PlayerModelProxy> modelList = PlayerModelProxy . GetPlayerModels ( ) ;


			PlayerConfigListItem toAdd = new PlayerConfigListItem ( ) ;
			toAdd . Margin = new Thickness ( 0 , 20 , 0 , 0 ) ;
			toAdd . Delete += PlayerConfigListItem_Delete ;
			toAdd . PlayerModelName = modelList . FirstOrDefault ( ) . Name ;

			PlayerConfigStackPanel . Children . Add ( toAdd ) ;
			NamePlayer ( ) ;
		}

		private void PlayerConfigListItem_Delete ( object sender , RoutedEventArgs e )
		{
			PlayerConfigStackPanel . Children . Remove ( sender as UIElement ) ;
			NamePlayer ( ) ;
		}

		private void NamePlayer ( )
		{
			int number = 1 ;
			foreach ( UIElement item in PlayerConfigStackPanel . Children )
			{
				if ( item is PlayerConfigListItem )
				{
					( item as PlayerConfigListItem ) . PlayerName = "玩家 " + number ;
					number++ ;
				}
			}
		}

		private void GenerateParameters ( )
		{
			Parameters . PlayerConfig = new List <Tuple <PlayerModelProxy , PlayerConsole>> ( ) ;
			foreach ( UIElement item in PlayerConfigStackPanel . Children )
			{
				if ( item is PlayerConfigListItem )
				{
					//Todo:PlayerConsole
					//Parameters . PlayerConfig . Add ( new Tuple<PlayerModelProxy , Players . PlayerConsole> ( ( item as PlayerConfigListItem ) . PlayerModel    ) ) );
				}
			}
		}

		private void GenerateList ( )
		{
			foreach ( Tuple <PlayerModelProxy , PlayerConsole> item in Parameters . PlayerConfig )
			{
				PlayerConfigListItem toAdd = new PlayerConfigListItem ( ) ;
				toAdd . PlayerModelName = item . Item1 . Name ;
				toAdd . Controller = item . Item2 . ToString ( ) ;
				PlayerConfigStackPanel . Children . Add ( toAdd ) ;
			}

			NamePlayer ( ) ;
		}

	}

}
