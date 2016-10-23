using WenceyWang . FoggyConsole;
using System;

using WenceyWang . FIGlet;
using WenceyWang . FoggyConsole . Controls;
using WenceyWang . Richman4L . Apps . Console . Fonts;

namespace WenceyWang . Richman4L . Apps . Console . Pages
{

	public class MainPage : Page
	{

		private Canvas _content;

		public override Control Content
		{
			get
			{
				return base . Content;
			}
			set { base . Content = value; }
		}

		public void UpdateContent ( )
		{
			Canvas canvas = new Canvas ( );

			FIGletLabel fLabel = new FIGletLabel
			{
				Text = "Richman4L" ,
				Font = FontsHelper . LoadFont ( "graffiti" ) ,
				ForegroundColor = ConsoleColor . Yellow ,
				BackgroundColor = ConsoleColor . DarkGreen
			};

			canvas . AddChild ( fLabel );
			canvas [ fLabel ] = new Point ( 0 , 0 );

		}

		public MainPage ( ) : base ( )
		{


		}

		public override void Arrange ( Rectangle finalRect )
		{
			base . Arrange ( finalRect );
		}

		public override void Measure ( Size availableSize )
		{

			base . Measure ( availableSize );
		}
	}

}
