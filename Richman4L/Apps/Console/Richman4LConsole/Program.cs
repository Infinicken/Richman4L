using System ;
using System . Collections ;
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
using WenceyWang . Richman4L . Logics ;

namespace WenceyWang . Richman4L . Apps . Console
{

	public class Program
	{

		private ILogger Logger { get ; }

		public Application Application { get ; private set ; }

		public static Program Current { get ; set ; }

		public Settings Setting { get ; set ; }

		internal ILoggerFactory LoggerFactory { get ; }

		public Program ( )
		{
			LoggerFactory = new LoggerFactory ( ) . AddConsole ( ) . AddDebug ( ) ;
			Logger = LoggerFactory . CreateLogger ( typeof ( Program ) ) ;
		}

		public void Start ( )
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


			CommandLineApplication commandLineApplication = new CommandLineApplication ( ) ;

			CommandOption noLogoCommand =
				commandLineApplication . Option ( @"-nologo|--nologo" , "Show no logo" , CommandOptionType . NoValue ) ;

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

			if ( ! File . Exists ( FileNameConst . SettingFile ) )
			{
				System . Console . WriteLine ( @"Setting file not found" ) ;
				Logger . LogInformation ( "Setting file not found, will generate it." ) ;
				Setting = Settings . GenerateNew ( ) ;
			}
			else
			{
				FileStream settingFile = File . OpenRead ( FileNameConst . SettingFile ) ;
				Logger . LogInformation ( "Setting file found, loading it." ) ;
				Setting = Settings . Load ( settingFile ) ;
			}

			#endregion

			List <Task> startUpTasks = new List <Task> { Startup . RunAllTask ( ) , MapRenderers . Startup . RunAllTask ( ) } ;

			Application = new Application ( new Frame ( ) ) ;

			Application . Run ( ) ;

			Application . ViewRoot . NavigateTo ( new StartPage ( ) ) ;

			Task . WaitAll ( startUpTasks . ToArray ( ) ) ;
		}

		/// <summary>
		///     Program.exe
		///     <-g|-- greeting|-$ <greeting>
		///         > [name
		///         <fullname>
		///             ]
		///             [-?|-h|--help]
		///             [-u|--uppercase]
		/// </summary>
		/// <param name="args"></param>
		public static void Main ( string [ ] args )
		{
			Current = new Program ( ) ;
			Current . Start ( ) ;
		}


		private void Exit ( ProgramExitCode code )
		{
			if ( code == ProgramExitCode . Success )
			{
				string config = Setting ? . Save ( ) ;
				FileStream settingFile = File . OpenWrite ( FileNameConst . SettingFile ) ;
				StreamWriter writer = new StreamWriter ( settingFile ) ;
				writer . Write ( config ) ;
				writer . Dispose ( ) ;
			}

			ShowExit ( ) ;
			Application . Stop ( ) ;
			Environment . Exit ( ( int ) code ) ;
		}

		private void ShowExit ( )
		{
			Logger . LogInformation ( "Exiting" ) ;
			System . Console . WriteLine ( ) ;
			System . Console . WriteLine ( @"Exiting..." ) ;
			System . Console . WriteLine ( ) ;
		}

		private void CreateConfigFile ( ) { }


		private void GenerateNewLicenseFile ( )
		{
			FileStream licenseFile = File . Open ( FileNameConst . LicenseFile , FileMode . Create ) ;
			StreamWriter writer = new StreamWriter ( licenseFile ) ;
			writer . WriteLine ( GetLicense ( ) ) ;
			writer . WriteLine ( ) ;
			writer . WriteLine ( "To accept this license, you should write \"I accept this License.\" at the end of this file." ) ;
			writer . Dispose ( ) ;
		}

		private void Console_CancelKeyPress ( object sender , ConsoleCancelEventArgs e ) { }

		public void ShowLogo ( )
		{
			System . Console . WriteLine ( new AsciiArt ( GameTitle . Defult . ContentWithSpace ,
														width : CharacterWidth . Smush ) ) ;
		}

		public void ShowCopyright ( )
		{
			System . Console . WriteLine ( $"Richman4L Copyright (C) 2010 - {DateTime . Now . Year} Wencey Wang" ) ;
			System . Console . WriteLine ( @"This program comes with ABSOLUTELY NO WARRANTY." ) ;
			System . Console .
					WriteLine ( @"This is free software, and you are welcome to redistribute it under certain conditions; read License.txt for ditails." ) ;
		}

		public string GetLicense ( )
		{
			Assembly assembly = typeof ( Program ) . GetTypeInfo ( ) . Assembly ;
			Stream stream = assembly . GetManifestResourceStream ( typeof ( Program ) . Namespace + @".License.AGPL.txt" ) ;
			StreamReader reader = new StreamReader ( stream ) ;
			string license = reader . ReadToEnd ( ) ;
			reader . Dispose ( ) ;
			return license ;
		}

	}

}
