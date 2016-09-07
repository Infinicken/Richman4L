namespace WenceyWang . Richman4L .Missions
{

	public class MissionGame : Game
	{

		public Mission Mission { get ; protected set ; }

		public MissionGame ( Mission misssion ) { }

		public override void NextDay ( ) { base . NextDay ( ) ; }

	}

}
