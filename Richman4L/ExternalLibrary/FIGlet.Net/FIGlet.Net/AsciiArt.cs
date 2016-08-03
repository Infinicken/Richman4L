using System;
using System . Linq;
using System . Text;

namespace WenceyWang . FIGlet
{
	public class AsciiArt
	{

		public string Text { get; private set; }

		public FigletFont Font { get; private set; }

		public string [ ] Result { get; private set; }

		public int Height => Font?.Height ?? 0;

		public int Width => Result . Max ( ( line ) => line?.Length ?? 0 );

		public override string ToString ( )
		{
			StringBuilder stringBuilder = new StringBuilder ( Height * ( Width + 1 ) );
			foreach ( string line in Result )
			{
				stringBuilder . AppendLine ( line );
			}

			return stringBuilder . ToString ( ) . TrimEnd ( );
		}

		public AsciiArt ( string text ) : this ( text , FigletFont . Defult )
		{

		}

		public AsciiArt ( string text , FigletFont font )
		{
			if ( text == null )
			{
				throw new ArgumentNullException ( nameof ( text ) );
			}

			if ( text . Contains ( Environment . NewLine ) )
			{
				throw new ArgumentException ( $"{nameof ( text )} can not contain multi line" );
			}

			Text = text;
			Font = font;
			Result = new string [ font . Height ];

			{
				StringBuilder lineBuilder = new StringBuilder ( );
				foreach ( char currentChar in Text )
				{
					lineBuilder . Append ( Font . GetCharacter ( currentChar , 0 ) );
				}
				Result [ 0 ] = lineBuilder . ToString ( );
			}

			for ( int currentLine = 1 ; currentLine < Height ; currentLine++ )
			{
				StringBuilder lineBuilder = new StringBuilder ( Width );
				foreach ( char currentChar in Text )
				{
					lineBuilder . Append ( Font . GetCharacter ( currentChar , currentLine ) );
				}
				Result [ currentLine ] = lineBuilder . ToString ( );
			}

		}

		private AsciiArt ( )
		{

		}

		public static AsciiArt GenerateArtText ( string text ) => new AsciiArt ( text );

		public static AsciiArt GenerateArtText ( string text , FigletFont font ) => new AsciiArt ( text , font );

	}
}
