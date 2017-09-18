using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Apps . Wpf
{

	/// <summary>
	///     Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{

		public new static App Current => Application . Current as App ;

		public MainWindow Window { get ; set ; }

		public string WindowTitle
		{
			get => Window . Title ;
			set
			{
				Window . Title = value ;
				TitleChanged ? . Invoke ( this , EventArgs . Empty ) ;
			}
		}

		[CanBeNull]
		public event EventHandler TitleChanged ;

	}

}
