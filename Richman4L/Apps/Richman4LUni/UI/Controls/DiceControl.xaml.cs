using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . Richman4L . GameEnviroment ;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WenceyWang . Richman4L . Apps . Uni . UI . Controls
{

	public sealed partial class DiceControl : CanvasContainer
	{

		public DiceWithValue Value { get ; }

		public DiceControl ( ) { InitializeComponent ( ) ; }

	}

}
