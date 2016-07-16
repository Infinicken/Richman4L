using System;
using System . Collections . Generic;
using System . Threading . Tasks;

using Windows . Foundation . Metadata;
using Windows . UI . ViewManagement;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;

using WenceyWang . Richman4L . Apps . Uni . Logic;
using WenceyWang . Richman4L . Maps;

namespace WenceyWang . Richman4L . Apps . Uni . Pages
{

	/// <summary>
	/// 起始动画页
	/// </summary>
	public sealed partial class StartPage : Page
	{

		public StartPage ( ) { InitializeComponent ( ); }

		private List<Task> _taskToWait;

		private async void Page_Loaded ( object sender , RoutedEventArgs e )
		{
			if ( ApiInformation . IsMethodPresent ( "Windows.UI.ViewManagement.StatusBar" , nameof ( StatusBar . HideAsync ) ) )
			{
				await StatusBar . GetForCurrentView ( ) . HideAsync ( );
			}

			StartStoryBoard . Completed += StartStoryBoard_Completed;
			StartStoryBoard . Begin ( );
			_taskToWait = new List<Task>
						{
				//Todo:完善这个
							Task . Run ( ( ) => { GameTitle . LoadTitles ( ) ; } ) ,
							Task . Run ( ( ) => { GameSaying . LoadSayings ( ) ; } ) ,
							Task . Run ( ( ) => { MapObject . LoadMapObjects ( ) ; } ) ,
							Task . Run ( ( ) => { Players . Models . PlayerModelProxy . LoadPlayerModels ( ) ; } ) ,

							//Task . Run ( ( ) => { Maps . MapProxy . LoadMaps ( ) ; } ) ,
						};
		}

		private void StartStoryBoard_Completed ( object sender , object e )
		{
			Task . WaitAll ( _taskToWait . ToArray ( ) );

			GameTitleManager . GenerateNewTitle ( );

			if ( AppSettings . Current . AcceptLicence )
			{
				PageNavigateHelper . Navigate ( typeof ( MainPage ) ,
												null ,
												"Cyan" ,
												LeaveStoryBoard ,
												BackGroundRect ,
												Frame );
			}
			else
			{
				PageNavigateHelper . Navigate ( typeof ( LicensePage ) ,
												null ,
												"DarkBlue" ,
												LeaveStoryBoard ,
												BackGroundRect ,
												Frame );
			}
		}

	}

}
