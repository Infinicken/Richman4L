using System ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

namespace WenceyWang .FIGlet
{

    public class FigletFont
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

        public static FigletFont Defult
        {
            get
            {
                FigletFont defult = null ;

                lock ( DefultFont )
                {
                    DefultFont ? . TryGetTarget ( out defult ) ;
                    if ( defult == null )
                    {
                        Stream stream = Assembly . GetExecutingAssembly ( ) .
                                                   GetManifestResourceStream ( typeof ( FigletFont ) . Namespace + "." +
                                                                               @"Fonts.standard.flf" ) ;
                        defult = new FigletFont ( stream ) ;
                        stream ? . Close ( ) ;
                        DefultFont . SetTarget ( defult ) ;
                    }
                }
                return defult ;
            }
        }

        public FigletFont ( Stream fontStream )
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

        private static readonly WeakReference < FigletFont > DefultFont = new WeakReference < FigletFont > ( null ) ;

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
            else
            {
                return Lines [ Convert . ToByte ( sourceChar ) ] [ line ] ;
            }
        }

        //private void LoadLines ( List<string> fontLines )
        //{
        //	Lines = fontLines;
        //	string configString = Lines . First ( );
        //	string [ ] configArray = configString . Split ( ' ' );
        //	Signature = configArray . First ( ) . Remove ( configArray . First ( ) . Length - 1 );
        //	if ( Signature == "flf2a" )
        //	{
        //HardBlank = configArray . First ( ) . Last ( ) . ToString ( );
        //Height = configArray . GetIntValue ( 1 );
        //BaseLine = configArray . GetIntValue ( 2 );
        //MaxLength = configArray . GetIntValue ( 3 );
        //OldLayout = configArray . GetIntValue ( 4 );
        //CommentLines = configArray . GetIntValue ( 5 );
        //PrintDirection = configArray . GetIntValue ( 6 );
        //FullLayout = configArray . GetIntValue ( 7 );

        //CodeTagCount = configArray . GetIntValue ( 8 );
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
