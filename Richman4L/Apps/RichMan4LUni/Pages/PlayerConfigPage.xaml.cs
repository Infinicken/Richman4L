using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
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
	public sealed partial class PlayerConfigPage : Page
	{

		public StartGameParameters Parameters { get ; set ; }

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
			StartStoryBoard . Begin ( ) ;
			StartStoryBoard . Completed += StartStoryBoard_Completed ;
		}

		private void StartStoryBoard_Completed ( object sender , object e )
		{
			if ( AppSettings . Current . OcdMode )
			{
				MainGrid . TurnOnOcdMode ( ) ;
			}
			StartStoryBoard . Completed -= StartStoryBoard_Completed ;
		}

		private void CreateGamePageButton_Click ( object sender , RoutedEventArgs e )
		{
			PageNavigateHelper . Navigate ( typeof ( CreateGamePage ) ,
											Parameters ,
											"Lime" ,
											LeaveStoryBoard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl ) ;
		}

		private void StartGameButton_Click ( object sender , RoutedEventArgs e )
		{
			Tuple < Task , Action > parameters = new Tuple < Task , Action > ( Task . Run ( ( ) =>
																							{
																								new Game ( ) ;
																								Game . Current . Start ( Parameters ) ;
																							} ) ,
																				( ) => { } ) ;

			PageNavigateHelper . Navigate ( typeof ( LoadingPage ) ,
											Parameters ,
											"Lime" ,
											LeaveStoryBoard ,
											BackGroundRect ,
											Frame ,
											RemoveControl ,
											AddControl ) ;
		}

		private void RemoveControl ( )
		{
			CreateGamePageButton . Click -= CreateGamePageButton_Click ;
			StartGameButton . Click -= StartGameButton_Click ;
		}

		private void AddControl ( )
		{
			CreateGamePageButton . Click += CreateGamePageButton_Click ;
			StartGameButton . Click += StartGameButton_Click ;
		}

		private void AddButton_Click ( object sender , RoutedEventArgs e )
		{
			List < PlayerModelProxy > modelList = PlayerModelProxy . GetPlayerModels ( ) ;


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
			Parameters . PlayerConfig = new List < Tuple < PlayerModelProxy , PlayerConsole > > ( ) ;
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
			foreach ( Tuple < PlayerModelProxy , PlayerConsole > item in Parameters . PlayerConfig )
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
