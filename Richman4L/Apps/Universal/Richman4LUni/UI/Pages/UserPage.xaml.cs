using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Windows . UI ;

namespace WenceyWang . Richman4L . Apps . Uni . UI . Pages
{

	/// <summary>
	///     An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class UserPage : AnimatePage
	{

		public static Color PageColor => XamlResources . Resources . DeepRed ;

		public UserPage ( ) { InitializeComponent ( ) ; }


		public override void AddControl ( ) { }

		public override void RemoveControl ( ) { }

	}

}
