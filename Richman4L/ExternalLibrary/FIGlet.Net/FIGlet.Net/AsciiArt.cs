using System;
using System . Linq;
using System . Text;

namespace WenceyWang . FIGlet
{

	public class AsciiArt
	{

		public string Text { get; }

		public FIGletFont Font { get; }

		public CharacterWidth CharacterWidth { get; }

		public string [ ] Result { get; }

		public int Height => Font?.Height ?? 0;

		public int Width => Result . Max ( line => line?.Length ?? 0 );

		public AsciiArt ( string text ) : this ( text , FIGletFont . Defult ) { }

		public AsciiArt ( string text , FIGletFont font ) : this ( text , font , CharacterWidth . Fitted ) { }

		public AsciiArt ( string text , FIGletFont font , CharacterWidth width )
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
			Font = font ?? FIGletFont . Defult;
			Result = new string [ Font . Height ];

			if ( Text . Length <= 0 )
			{
				return;
			}

			switch ( width )
			{
				case CharacterWidth . Full:
					{
						for ( int currentLine = 0 ; currentLine < Height ; currentLine++ )
						{
							StringBuilder lineBuilder = new StringBuilder ( );
							foreach ( char currentChar in Text )
							{
								lineBuilder . Append ( Font . GetCharacter ( currentChar , currentLine ) );
								lineBuilder . Append ( ' ' );
							}

							Result [ currentLine ] = lineBuilder . ToString ( );
						}

						break;
					}
				case CharacterWidth . Fitted:
					{
						for ( int currentLine = 0 ; currentLine < Height ; currentLine++ )
						{
							StringBuilder lineBuilder = new StringBuilder ( );
							foreach ( char currentChar in Text )
							{
								lineBuilder . Append ( Font . GetCharacter ( currentChar , currentLine ) );
							}

							Result [ currentLine ] = lineBuilder . ToString ( );
						}

						break;
					}
				case CharacterWidth . Smush:
					{
						for ( int currentLine = 0 ; currentLine < Height ; currentLine++ )
						{
							StringBuilder lineBuilder = new StringBuilder ( );
							lineBuilder . Append ( Font . GetCharacter ( Text [ 0 ] , currentLine ) );
							char lastChar = Text [ 0 ];
							for ( int currentCharIndex = 1 ; currentCharIndex < Text . Length ; currentCharIndex++ )
							{
								char currentChar = Text [ currentCharIndex ];
								string currentCharacterLine = Font . GetCharacter ( currentChar , currentLine );
								if ( ( lastChar != ' ' ) &&
									( currentChar != ' ' ) )
								{
									if ( lineBuilder [ lineBuilder . Length - 1 ] == ' ' )
									{
										lineBuilder [ lineBuilder . Length - 1 ] = currentCharacterLine [ 0 ];
									}
									lineBuilder . Append ( currentCharacterLine . Substring ( 1 ) );
								}
								else
								{
									lineBuilder . Append ( currentCharacterLine );
								}
								lastChar = currentChar;
							}

							Result [ currentLine ] = lineBuilder . ToString ( );
						}

						break;
					}
			}
		}

		private AsciiArt ( ) { }

		public override string ToString ( )
		{
			StringBuilder stringBuilder = new StringBuilder ( Height * ( Width + 1 ) );
			foreach ( string line in Result )
			{
				stringBuilder . AppendLine ( line );
			}

			return stringBuilder . ToString ( ) . TrimEnd ( );
		}

		public static AsciiArt GenerateArtText ( string text ) => new AsciiArt ( text );

		public static AsciiArt GenerateArtText ( string text , FIGletFont font ) => new AsciiArt ( text , font );

	}

}
