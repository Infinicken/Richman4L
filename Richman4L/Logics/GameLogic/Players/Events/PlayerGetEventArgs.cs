namespace WenceyWang . Richman4L . Players .Events
{

	public class PlayerGetEventArgs : PlayerEventArgs
	{

		public virtual long Money { get ; }

		public PlayerGetEventArgs ( long money ) { Money = money ; }

		protected PlayerGetEventArgs ( ) { }

	}

}
