using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . Foundation ;
using Windows . UI . Xaml ;

using WenceyWang . Richman4L . Maps ;

namespace WenceyWang . Richman4L . Apps . XamlMapRenderers . MapObjectRenderer
{

	public sealed partial class NameShower : MapObjectRenderer , IMapObjectRenderer <MapObject>
	{

		public string Text
		{
			get => ( string ) GetValue ( TextProperty ) ;
			set
			{
				SetValue ( TextProperty , value ) ;
				TextTextBlock . Text = Text ;
			}
		}

		public double TextSize
		{
			get => ( double ) GetValue ( TextSizeProperty ) ;
			set
			{
				SetValue ( TextSizeProperty , value ) ;
				TextTextBlock . FontSize = TextSize ;
			}
		}


		public override Size Size => new Size ( 112 , 56 ) ;


		public NameShower ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty TextProperty =
			DependencyProperty . Register ( "Text" , typeof ( string ) , typeof ( NameShower ) , new PropertyMetadata ( "" ) ) ;

		public static readonly DependencyProperty TextSizeProperty =
			DependencyProperty . Register ( "TextSize" ,
											typeof ( double ) ,
											typeof ( NameShower ) ,
											new PropertyMetadata ( 24 ) ) ;

		public MapObject Target { get ; private set ; }

		public void Update ( ) { }

		public void StartUp ( )
		{
			Text = Target . GetType ( ) . Name ;
			VisualStateManager . GoToState ( this , nameof(HideState) , false ) ;
		}

		public void SetTarget ( MapObject target ) { Target = target ; }

		public override void Show ( ) { VisualStateManager . GoToState ( this , nameof(ShowState) , true ) ; }

		public override void Hide ( ) { VisualStateManager . GoToState ( this , nameof(ShowState) , true ) ; }

	}

}
