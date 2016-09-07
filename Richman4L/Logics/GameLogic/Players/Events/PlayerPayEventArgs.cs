namespace WenceyWang . Richman4L . Players .Events
{

	public class PlayerPayEventArgs : PlayerEventArgs
	{

		public virtual long Money { get ; }

		public PlayerPayEventArgs ( long money ) { Money = money ; }

		protected PlayerPayEventArgs ( ) { }

	}

}
