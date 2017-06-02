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

using System ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Threading . Tasks ;

using Microsoft . Extensions . CommandLineUtils ;
using Microsoft . Extensions . Logging ;

using WenceyWang . FIGlet ;
using WenceyWang . FoggyConsole ;
using WenceyWang . FoggyConsole . Controls ;
using WenceyWang . Richman4L . Apps . Console . Pages ;

namespace WenceyWang . Richman4L . Apps . Console
{

	public static class Program
	{

		private static ILogger Logger { get ; } = LoggerFactory . CreateLogger ( typeof ( Program ) ) ;

		public static Application CurrentApplication { get ; private set ; }

		public static Settings CurrentSetting { get ; set ; }

		public static ILoggerFactory LoggerFactory { get ; set ; } =
			new LoggerFactory ( ) . AddConsole ( ) . AddDebug ( ) ;

		/// <summary>
		///     Program.exe <-g|-- greeting|-$ <greeting>
		///         > [name
		///         <fullname>
		///             ]
		///             [-?|-h|--help]
		///             [-u|--uppercase]
		/// </summary>
		/// <param name="args"></param>
		public static void Main ( string [ ] args )
		{
			//// Program.exe <-g|--greeting|-$ <greeting>> [name <fullname>]
			//// [-?|-h|--help] [-u|--uppercase]
			//CommandLineApplication commandLineApplication =
			//  new CommandLineApplication(throwOnUnexpectedArg: false);
			//CommandArgument names = null;
			//commandLineApplication.Command("name",
			//  (target) =>
			//	names = target.Argument(
			//	  "fullname",
			//	  "Enter the full name of the person to be greeted.",
			//	  multipleValues: true));
			//CommandOption greeting = commandLineApplication.Option(
			//  "-$|-g |--greeting <greeting>",
			//  "The greeting to display. The greeting supports"
			//  + " a format string where {fullname} will be "
			//  + "substituted with the full name.",
			//  CommandOptionType.SingleValue);
			//CommandOption uppercase = commandLineApplication.Option(
			//  "-u | --uppercase", "Display the greeting in uppercase.",
			//  CommandOptionType.NoValue);
			//commandLineApplication.HelpOption("-? | -h | --help");
			//commandLineApplication.OnExecute(() =>
			//{
			//	if (greeting.HasValue())
			//	{
			//		Greet(greeting.Value(), names.Values, uppercase.HasValue());
			//	}
			//	return 0;
			//});
			//commandLineApplication.Execute(args);


			System . Console . CancelKeyPress += Console_CancelKeyPress ;

			//ConsoleArguments arguments = new ConsoleArguments();

			CommandLineApplication commandLineApplication = new CommandLineApplication ( ) ;

			//var noLogoCommand = commandLineApplication . Option ( @"-nologo|--nologo" , "Show no logo" , CommandOptionType . NoValue ,) ;

			//if (!arguments.NoLogo)
			{
				ShowLogo ( ) ;
				ShowCopyright ( ) ;
			}

			#region Check License

#if !DEBUG

			if (!File.Exists(FileNameConst.LicenseFile))
			{
				System.Console.WriteLine(@"License file not found");
				Logger.LogInformation("License file not found, will generate it.");
				GenerateNewLicenseFile();
				Exit(ProgramExitCode.LicenseNotAccepted);
			}
			else
			{
				FileStream licenseFile = File.OpenRead(FileNameConst.LicenseFile);
				StreamReader reader = new StreamReader(licenseFile);
				Logger.LogInformation("License file found, reading it.");
				string licenseFileContent = reader.ReadToEnd();
				reader.Dispose();
				if (!licenseFileContent.EndsWith("I accept this License."))
				{
					Logger.LogInformation("License check error.");
					System.Console.WriteLine(@"You should read the License.txt and accept it before use this program.");
					Exit(ProgramExitCode.LicenseNotAccepted);
				}
				else
				{
					Logger.LogInformation("License check pass.");
				}
			}

#endif

#if DEBUG
			Logger . LogInformation ( "Debug version, skip license check." ) ;
#endif

			#endregion

			#region Loading Setting

			if ( ! File . Exists ( FileNameConst . SettingFile ) /* ||
				arguments.Setup*/ )
			{
				System . Console . WriteLine ( @"Setting file not found" ) ;
				Logger . LogInformation ( "Setting file not found, will generate it." ) ;
				CurrentSetting = Settings . GenerateNew ( ) ;
			}
			else
			{
				FileStream settingFile = File . OpenRead ( FileNameConst . SettingFile ) ;
				Logger . LogInformation ( "Setting file found, loading it." ) ;
				CurrentSetting = Settings . Load ( settingFile ) ;
			}

			#endregion

			List <Task> startUpTasks = new List <Task> ( ) ;

			startUpTasks . Add ( Startup . RunAllTask ( ) ) ;

			startUpTasks . Add ( CharacterMapRenderers . Startup . RunAllTask ( ) ) ;

			CurrentApplication = new Application ( new Frame ( ) ) ;

			CurrentApplication . Run ( ) ;

			CurrentApplication . ViewRoot . NavigateTo ( new StartPage ( ) ) ;

			Task . WaitAll ( startUpTasks . ToArray ( ) ) ;
		}


		private static void Exit ( ProgramExitCode code )
		{
			if ( code == ProgramExitCode . Success )
			{
				string config = CurrentSetting ? . Save ( ) ;
				FileStream settingFile = File . OpenWrite ( FileNameConst . SettingFile ) ;
				StreamWriter writer = new StreamWriter ( settingFile ) ;
				writer . Write ( config ) ;
				writer . Dispose ( ) ;
			}

			ShowExit ( ) ;
			Environment . Exit ( ( int ) code ) ;
		}

		private static void ShowExit ( )
		{
			Logger . LogInformation ( "Exiting" ) ;
			System . Console . WriteLine ( ) ;
			System . Console . WriteLine ( @"Exiting..." ) ;
			System . Console . WriteLine ( ) ;
		}

		private static void CreateConfigFile ( ) { }


		private static void GenerateNewLicenseFile ( )
		{
			FileStream licenseFile = File . Open ( "License.txt" , FileMode . Create ) ;
			StreamWriter writer = new StreamWriter ( licenseFile ) ;
			writer . WriteLine ( GetLicense ( ) ) ;
			writer . WriteLine ( ) ;
			writer . WriteLine (
				"To accept this license, you should write \"I accept this License.\" at the end of this file." ) ;
			writer . Dispose ( ) ;
		}

		private static void Console_CancelKeyPress ( object sender , ConsoleCancelEventArgs e ) { }

		public static void ShowLogo ( )
		{
			System . Console . WriteLine ( new AsciiArt ( GameTitle . Defult . ContentWithSpace ) ) ;
		}

		public static void ShowCopyright ( )
		{
			System . Console . WriteLine ( @"Richman4L Copyright (C) 2010 - 2016 Wencey Wang" ) ;
			System . Console . WriteLine ( @"This program comes with ABSOLUTELY NO WARRANTY." ) ;
			System . Console . WriteLine (
				@"This is free software, and you are welcome to redistribute it under certain conditions; read License.txt for ditails." ) ;
		}

		public static string GetLicense ( )
		{
			Assembly assembly = typeof ( Program ) . GetTypeInfo ( ) . Assembly ;
			Stream stream =
				assembly . GetManifestResourceStream ( typeof ( Program ) . Namespace + @".License.AGPL.txt" ) ;
			StreamReader reader = new StreamReader ( stream ) ;
			string license = reader . ReadToEnd ( ) ;
			reader . Dispose ( ) ;
			return license ;
		}

	}

}
