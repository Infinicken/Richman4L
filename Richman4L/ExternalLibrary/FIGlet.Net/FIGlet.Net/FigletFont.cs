using System ;
using System . Collections ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

namespace WenceyWang .FIGlet
{

	public class FIGletFont
	{

		public string Signature { get ; private set ; }

		public char HardBlank { get ; }

		public int Height { get ; }

		public int BaseLine { get ; private set ; }

		public int MaxLength { get ; private set ; }

		public int OldLayout { get ; private set ; }

		public int CommentLines { get ; }

		public int PrintDirection { get ; private set ; }

		public int FullLayout { get ; private set ; }

		public int CodeTagCount { get ; private set ; }

		public string [ ] [ ] Lines { get ; }

		public string Commit { get ; private set ; }

		public static FIGletFont Defult
		{
			get
			{
				FIGletFont defult = null ;

				lock ( DefultFont )
				{
					DefultFont ? . TryGetTarget ( out defult ) ;
					if ( defult == null )
					{
						Stream stream = Assembly . GetExecutingAssembly ( ) .
													GetManifestResourceStream ( typeof ( FIGletFont ) . Namespace + "." +
																				@"Fonts.standard.flf" ) ;
						defult = new FIGletFont ( stream ) ;
						stream ? . Close ( ) ;
						DefultFont . SetTarget ( defult ) ;
					}
				}
				return defult ;
			}
		}

		public FIGletFont ( Stream fontStream )
		{
			using ( StreamReader reader = new StreamReader ( fontStream ) )
			{
				string [ ] configs = reader . ReadLine ( ) . Split ( ' ' ) ;
				if ( ! configs [ 0 ] . StartsWith ( @"flf2a" ) )
				{
					throw new ArgumentException ( $"{nameof ( fontStream )} missing signature" , nameof ( fontStream ) ) ;
				}

				Signature = @"flf2a" ;
				HardBlank = configs [ 0 ] . Last ( ) ;
				try
				{
					Height = Convert . ToInt32 ( configs [ 1 ] ) ;
					BaseLine = Convert . ToInt32 ( configs [ 2 ] ) ;
					MaxLength = Convert . ToInt32 ( configs [ 3 ] ) ;
					OldLayout = Convert . ToInt32 ( configs [ 4 ] ) ;
					CommentLines = Convert . ToInt32 ( configs [ 5 ] ) ;
					PrintDirection = Convert . ToInt32 ( configs [ 6 ] ) ;
					FullLayout = Convert . ToInt32 ( configs [ 7 ] ) ;
					CodeTagCount = Convert . ToInt32 ( configs [ 8 ] ) ;
				}
				catch ( IndexOutOfRangeException )
				{
				}

				StringBuilder commentBuilder = new StringBuilder ( ) ;
				for ( int lineCount = 0 ; lineCount < CommentLines ; lineCount++ )
				{
					commentBuilder . AppendLine ( reader . ReadLine ( ) ) ;
				}

				Commit = commentBuilder . ToString ( ) ;

				Lines = new string[ 256 ] [ ] ;

				int currentChar = 32 ;

				while ( ! reader . EndOfStream )
				{
					int charIndex ;
					string currentLine = reader . ReadLine ( ) ?? string . Empty ;
					if ( int . TryParse ( currentLine , out charIndex ) )
					{
						currentChar = charIndex ;
					}

					Lines [ currentChar ] = new string[ Height ] ;

					int currentLineIndex = 0 ;
					while ( currentLineIndex < Height )
					{
						Lines [ currentChar ] [ currentLineIndex ] = currentLine . TrimEnd ( '@' ) .
																					Replace ( HardBlank , ' ' ) ;

						if ( currentLine . EndsWith ( @"@@" ) )
						{
							break ;
						}

						currentLine = reader . ReadLine ( ) ?? string . Empty ;
						currentLineIndex++ ;
					}

					currentChar++ ;
				}
			}
		}

		private static readonly object Locker = new object ( ) ;

		private static readonly WeakReference < FIGletFont > DefultFont = new WeakReference < FIGletFont > ( null ) ;

		public string GetCharacter ( char sourceChar , int line )
		{
			if ( ( line < 0 ) ||
				( line >= Height ) )
			{
				throw new ArgumentOutOfRangeException ( nameof ( line ) ) ;
			}

			if ( Lines [ Convert . ToByte ( sourceChar ) ] == null )
			{
				return string . Empty ;
			}

			return Lines [ Convert . ToByte ( sourceChar ) ] [ line ] ;
		}

		//CodeTagCount = configArray . GetIntValue ( 8 );
		//FullLayout = configArray . GetIntValue ( 7 );
		//PrintDirection = configArray . GetIntValue ( 6 );
		//CommentLines = configArray . GetIntValue ( 5 );
		//OldLayout = configArray . GetIntValue ( 4 );
		//MaxLength = configArray . GetIntValue ( 3 );
		//BaseLine = configArray . GetIntValue ( 2 );
		//Height = configArray . GetIntValue ( 1 );
		//HardBlank = configArray . First ( ) . Last ( ) . ToString ( );
		//	{
		//	if ( Signature == "flf2a" )
		//	Signature = configArray . First ( ) . Remove ( configArray . First ( ) . Length - 1 );
		//	string [ ] configArray = configString . Split ( ' ' );
		//	string configString = Lines . First ( );
		//	Lines = fontLines;
		//{

		//private void LoadLines ( List<string> fontLines )
		//	}
		//}


		//private void LoadFont ( Stream fontStream )
		//{
		//	List<string> fontData = new List<string> ( );

		//	using ( StreamReader reader = new StreamReader ( fontStream ) )
		//	{
		//		while ( !reader . EndOfStream )
		//		{
		//			fontData . Add ( reader . ReadLine ( ) );
		//		}
		//	}

		//	LoadLines ( fontData );
		//}
	}

}
