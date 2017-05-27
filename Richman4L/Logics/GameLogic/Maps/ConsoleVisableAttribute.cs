using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Maps
{

	[AttributeUsage ( AttributeTargets . Property )]
	public sealed class ConsoleVisableAttribute : Attribute
	{

		public PropertyVisability Visability { get ; set ; }

		public ConsoleVisableAttribute ( PropertyVisability visability = PropertyVisability . Everyone )
		{
			Visability = visability ;
		}

	}

	public enum PropertyVisability
	{

		Everyone ,

		Owner ,

		Cheater

	}

	[Flags]
	public enum PlayerPermission
	{

		PlayGame ,

		CreateGame ,

		ControlVote ,

		Cheat ,

		Debug


		//FullControl,

	}

}
