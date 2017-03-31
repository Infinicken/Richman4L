using System ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;

using WenceyWang . Richman4L . Players . Models ;

namespace WenceyWang . Richman4L . Apps . Uni . UI .Controls
{

	public sealed partial class PlayerConfigListItem : UserControl
	{

		public string PlayerName
		{
			get { return PlayerNameTextBlock . Text = ( string ) GetValue ( PlayerNameProperty ) ; }
			set
			{
				PlayerNameTextBlock . Text = value ;
				SetValue ( PlayerNameProperty , value ) ;
			}
		}


		public PlayerModelProxy PlayerModel
		{
			get { return PlayerModelProxy . GetPlayerModels ( ) . First ( model => model . Name == PlayerModelName ) ; }
		}


		public string PlayerModelName
		{
			get { return ( string ) ( PlayerModelNameButton . Content = ( string ) GetValue ( PlayerModelNameProperty ) ) ; }
			set
			{
				PlayerModelNameButton . Content = value ;
				SetValue ( PlayerModelNameProperty , value ) ;
			}
		}

		public string Controller
		{
			get { return ( string ) ( ControllerButton . Content = ( string ) GetValue ( ControllerProperty ) ) ; }
			set
			{
				ControllerButton . Content = value ;
				SetValue ( ControllerProperty , value ) ;
			}
		}

		public PlayerConfigListItem ( )
		{
			InitializeComponent ( ) ;
			DeleteButton . Click += DeleteButton_Click ;
			Loaded += PlayerConfigListItem_Loaded ;
			PlayerModelNameList . SelectionChanged += PlayerModelNameList_SelectionChanged ;
			ControllerList . SelectionChanged += ControllerList_SelectionChanged ;
		}

		public static readonly DependencyProperty PlayerNameProperty =
			DependencyProperty . Register ( nameof ( PlayerName ) ,
											typeof ( string ) ,
											typeof ( PlayerConfigListItem ) ,
											new PropertyMetadata ( "" ) ) ;

		public static readonly DependencyProperty PlayerModelNameProperty =
			DependencyProperty . Register ( nameof ( PlayerModelName ) ,
											typeof ( string ) ,
											typeof ( PlayerConfigListItem ) ,
											new PropertyMetadata ( "" ) ) ;

		public static readonly DependencyProperty ControllerProperty =
			DependencyProperty . Register ( nameof ( Controller ) ,
											typeof ( string ) ,
											typeof ( PlayerConfigListItem ) ,
											new PropertyMetadata ( "" ) ) ;

		private void PlayerConfigListItem_Loaded ( object sender , RoutedEventArgs e )
		{
			if ( PlayerModelNameList == null )
			{
				throw new InvalidOperationException ( ) ;
			}

			foreach ( PlayerModelProxy item in PlayerModelProxy . GetPlayerModels ( ) )
			{
				PlayerModelNameList . Items . Add ( item . Name ) ;
			}

			PlayerModelNameList . SelectedIndex = - 1 ;
			ControllerList . SelectedIndex = - 1 ;
		}

		private void PlayerModelNameList_SelectionChanged ( object sender , SelectionChangedEventArgs e )
		{
			PlayerModelName = ( string ) PlayerModelNameList . SelectedItem ;
		}

		private void ControllerList_SelectionChanged ( object sender , SelectionChangedEventArgs e )
		{
			Controller = ( string ) ControllerList . SelectedItem ;
		}

		public event RoutedEventHandler Delete ;

		private void DeleteButton_Click ( object sender , RoutedEventArgs e )
		{
			Delete ? . Invoke ( this , new RoutedEventArgs ( ) ) ;
		}

	}

}
