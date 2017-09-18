using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel ;
using System . Linq ;
using System . Runtime . CompilerServices ;

using JetBrains . Annotations ;

namespace WenceyWang . Richman4L . Apps . Wpf . Logic
{

	public class LoadingPageTaskState : INotifyPropertyChanged
	{

		public string CurrentLoading { get ; set ; }

		public List <string> PassedLoading { get ; } = new List <string> ( ) ;

		public int Progress { get ; set ; }

		public event PropertyChangedEventHandler PropertyChanged ;

		public void UpdateCurrentLoading ( string currentLoading )
		{
			PassedLoading . Add ( CurrentLoading ) ;
			CurrentLoading = currentLoading ;
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged ( [CallerMemberName] string propertyName = null )
		{
			PropertyChanged ? . Invoke ( this , new PropertyChangedEventArgs ( propertyName ) ) ;
		}

	}

}
