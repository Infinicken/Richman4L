using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Services . Games
{

	public class Program
	{

		/// <summary>
		///     用户具有的权限
		/// </summary>
		[Flags]
		public enum UserPermission
		{

			PlayGame = 0b0000_0001 ,

			CreateGame = 0b0000_0010 ,

			ControlVote = 0b0000_0100 ,

			CustomizeRule = 0b0000_1000 ,

			Cheat = 0b0001_0000 ,

			Debug = 0b0010_0000 ,

			UseCommand = 0b0100_0000

		}

		public static void Main ( string [ ] args ) { Console . WriteLine ( "Hello World!" ) ; }

	}

}
