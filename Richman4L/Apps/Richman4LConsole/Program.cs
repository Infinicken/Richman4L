/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System . Collections . Generic;
using System . IO;
using System . Net;
using System . Reflection;
using System . Threading . Tasks;

using CommandLine;

using NLog;

using WenceyWang . FIGlet;
using WenceyWang . FoggyConsole;
using WenceyWang . FoggyConsole . Controls;
using WenceyWang . Richman4L . Apps . Console . Fonts;
using WenceyWang . Richman4L . Apps . Console . Pages;

namespace WenceyWang . Richman4L . Apps . Console
{

	public static class Program
	{

		private static Logger Logger { get; } = LogManager . GetCurrentClassLogger ( );

		public static Application CurrentApplication { get; private set; }

		public static Settings CurrentSetting { get; set; }

		public static void Main ( string [ ] args )
		{
			System . Console . CancelKeyPress += Console_CancelKeyPress;

			ConsoleArguments arguments = new ConsoleArguments ( );

			Parser . Default . ParseArguments ( args , arguments );

			if ( !arguments . NoLogo )
			{
				ShowLogo ( );
				ShowCopyRight ( );
			}

			if ( !File . Exists ( FileNameConst . LicenseFile ) )
			{
				System . Console . WriteLine ( @"License file not found" );
				Logger . Info ( "License file not found, will generate it." );
				GenerateNewLicenseFile ( );
				Exit ( ProgramExitCode . LicenseNotAccepted );
			}
			else
			{
				FileStream licenseFile = File . OpenRead ( FileNameConst . LicenseFile );
				StreamReader reader = new StreamReader ( licenseFile );
				Logger . Info ( "License file found, reading it." );
				string licenseFileContent = reader . ReadToEnd ( );
				reader . Close ( );
				if ( !licenseFileContent . EndsWith ( "I accept this License." ) )
				{
					Logger . Info ( "License check error." );
					System . Console . WriteLine ( @"You should read the License.txt and accept it before use this program." );
					Exit ( ProgramExitCode . LicenseNotAccepted );
				}
				else
				{
					Logger . Info ( "License check pass." );
				}
			}

			if ( !File . Exists ( FileNameConst . SettingFile ) ||
				arguments . Setup )
			{
				System . Console . WriteLine ( @"Setting file not found" );
				Logger . Info ( "Setting file not found, will generate it." );
				CurrentSetting = Settings . GenerateNew ( );
			}
			else
			{
				FileStream settingFile = File . OpenRead ( FileNameConst . SettingFile );
				Logger . Info ( "Setting file found, loading it." );
				CurrentSetting = Settings . Load ( settingFile );
			}

			List<Task> startUpTasks = new List<Task> ( );

			startUpTasks . Add ( Task . Run ( ( ) =>
											{
												Logger . Debug ( "Loading titles." );
												GameTitle . LoadTitles ( );
												Logger . Debug ( "Loading titles complete." );
											} ) );

			startUpTasks . Add ( Task . Run ( ( ) =>
											{
												Logger . Debug ( "Loading sayings." );
												GameSaying . LoadSayings ( );
												Logger . Debug ( "Loading sayings complete." );
											} ) );

			CurrentApplication = new Application ( new Frame ( ) );
			Task . WaitAll ( startUpTasks . ToArray ( ) );

			Canvas canvas = new Canvas ( );

			//StackPanel panel = new StackPanel ( );

			WebClient client = new WebClient ( );

			FIGletLabel fLabel = new FIGletLabel
			{
				Text = "Wencey Wang Present" ,
				Font = FontsHelper . LoadFont ( "invita" ) ,
				ForegroundColor = ConsoleColor . Yellow ,
				CharacterWidth = CharacterWidth . Fitted ,
				BackgroundColor = ConsoleColor . DarkGreen
			};

			canvas . AddChild ( fLabel );
			canvas [ fLabel ] = new Point ( 0 , 0 );



			Label label = new Label
			{
				Text = nameof ( Richman4L ) ,
				Align = ContentAlign . Right ,
				Size = new Size ( 40 , 1 ) ,
				ForegroundColor = ConsoleColor . White ,
				BackgroundColor = ConsoleColor . DarkBlue
			};

			Button button = new Button
			{
				Text = nameof ( Richman4L ) ,
				Size = new Size ( 18 , 1 ) ,
				ForegroundColor = ConsoleColor . White ,
				BackgroundColor = ConsoleColor . DarkBlue
			};

			canvas . AddChild ( label );
			//	panel . AddChild ( label );
			canvas [ label ] = new Point ( 0 , 0 );

			canvas . AddChild ( button );
			//	panel . AddChild ( button );
			canvas [ button ] = new Point ( 2 , 2 );

			button = new Button
			{
				Text = nameof ( Richman4L ) ,
				Size = new Size ( 15 , 1 ) ,
				ForegroundColor = ConsoleColor . White ,
				BackgroundColor = ConsoleColor . DarkBlue
			};

			button . Pressed += ( obj , e ) =>
								{
									System . Console . WriteLine ( "Pressed" );
								};


			canvas . AddChild ( button );
			canvas [ button ] = new Point ( 2 , 6 );

			MainPage page = new MainPage ( );

			page . Content = canvas;


			//		Panel applicationRoot = new Panel ( ) ;
			//		applicationRoot . Name = nameof ( applicationRoot ) ;
			//		applicationRoot . Width = CurrentSetting . ConsoleWidth ;
			//		applicationRoot . Height = CurrentSetting . ConsoleHeight ;
			//		applicationRoot . Add ( new MainPage ( ) . Container ) ;


			CurrentApplication . Run ( );

			CurrentApplication . ViewRoot . NavigateTo ( new StartPage ( ) );
		}


		private static void Exit ( ProgramExitCode code )
		{
			if ( code == ProgramExitCode . Success )
			{
				string config = CurrentSetting?.Save ( );
				FileStream settingFile = File . OpenWrite ( FileNameConst . SettingFile );
				StreamWriter writer = new StreamWriter ( settingFile );
				writer . Write ( config );
				writer . Close ( );
			}

			ShowExit ( );
			Environment . Exit ( ( int ) ProgramExitCode . LicenseNotAccepted );
		}

		private static void ShowExit ( )
		{
			Logger . Info ( "Exiting" );
			System . Console . WriteLine ( );
			System . Console . WriteLine ( @"Exiting..." );
			System . Console . WriteLine ( );
		}

		private static void CreateConfigFile ( ) { }


		private static void GenerateNewLicenseFile ( )
		{
			FileStream licenseFile = File . Open ( "License.txt" , FileMode . Create );
			StreamWriter writer = new StreamWriter ( licenseFile );
			writer . WriteLine ( GetLicense ( ) );
			writer . WriteLine ( );
			writer . WriteLine ( "To accept this license, you should write \"I accept this License.\" at the end of this file." );
			writer . Close ( );
		}

		private static void Console_CancelKeyPress ( object sender , ConsoleCancelEventArgs e ) { }

		public static void ShowLogo ( )
		{
			System . Console . WriteLine ( new AsciiArt ( GameTitle . Defult . ContentWithSpace ) );
		}

		public static void ShowCopyRight ( )
		{
			System . Console . WriteLine ( @"Richman4L Copyright (C) 2010 - 2016 Wencey Wang" );
			System . Console . WriteLine ( @"This program comes with ABSOLUTELY NO WARRANTY." );
			System . Console . WriteLine (
						@"This is free software, and you are welcome to redistribute it under certain conditions; read License.txt for ditails." );
		}

		public static string GetLicense ( )
		{
			Assembly assembly = Assembly . GetExecutingAssembly ( );
			Stream stream = assembly . GetManifestResourceStream ( typeof ( Program ) . Namespace + @".License.AGPL.txt" );
			StreamReader reader = new StreamReader ( stream );
			string license = reader . ReadToEnd ( );
			reader . Close ( );
			return license;
		}

	}

}
