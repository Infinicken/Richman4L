using System . Collections . Generic ;
using System . ComponentModel ;
using System . Runtime . CompilerServices ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{

	public class LoadingPageTaskState : INotifyPropertyChanged
	{

		public string CurrentLoading { get; set; }

		public List<string> PassedLoading { get; } = new List<string> ( );

		public void UpdateCurrentLoading ( string currentLoading )
		{
			PassedLoading . Add ( CurrentLoading );
			CurrentLoading = currentLoading;
		}

		public int Progress { get; set; }

		public LoadingPageTaskState ( )
		{

		}

		public event PropertyChangedEventHandler PropertyChanged ;

		[Properties . NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged ( [ CallerMemberName ] string propertyName = null )
		{
			PropertyChanged ? . Invoke ( this , new PropertyChangedEventArgs ( propertyName ) ) ;
		}

	}

}