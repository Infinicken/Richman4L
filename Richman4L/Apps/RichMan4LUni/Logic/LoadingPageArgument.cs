using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

using WenceyWang . Richman4L . Apps . Uni . UI . Pages ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{

	public sealed class LoadingPageArgument
	{

		private int _loadingProcess ;

		public Task TaskToWait { get ; }

		public Action <LoadingPage> ToDoNext { get ; }

		public int LoadingProcess
		{
			get => _loadingProcess ;
			set
			{
				if ( _loadingProcess != value )
				{
					_loadingProcess = value ;
					LoadingProcessChanged ? . Invoke ( this , new EventArgs ( ) ) ;
				}
			}
		}

		public List <LoadingStatus> LoadingStatusList { get ; } = new List <LoadingStatus> ( ) ;

		public LoadingPageArgument ( Task taskToWait , Action <LoadingPage> toDoNext )
		{
			if ( taskToWait == null )
			{
				throw new ArgumentNullException ( nameof(taskToWait) ) ;
			}
			if ( toDoNext == null )
			{
				throw new ArgumentNullException ( nameof(toDoNext) ) ;
			}

			TaskToWait = taskToWait ;
			ToDoNext = toDoNext ;
		}

		public void UpdateStatus ( LoadingStatus newStatus )
		{
			if ( newStatus == null )
			{
				throw new ArgumentNullException ( nameof(newStatus) ) ;
			}

			LoadingStatusList . Add ( newStatus ) ;
			LoadingStatusAdded ? . Invoke ( this , new LoadingStatusAddedEventArgs ( newStatus ) ) ;
		}

		public event EventHandler LoadingProcessChanged ;

		public event EventHandler <LoadingStatusAddedEventArgs> LoadingStatusAdded ;

	}

	public class LoadingStatusAddedEventArgs : EventArgs
	{

		public LoadingStatus NewStatus { get ; }

		public LoadingStatusAddedEventArgs ( LoadingStatus newStatus ) { NewStatus = newStatus ; }

	}

	public sealed class LoadingStatus
	{

		private int _loadingProcess ;

		public string Name { get ; }

		public int LoadingProcess
		{
			get => _loadingProcess ;
			set
			{
				if ( _loadingProcess != value )
				{
					_loadingProcess = value ;
					LoadingProcessChanged ? . Invoke ( this , new EventArgs ( ) ) ;
				}
			}
		}

		public event EventHandler LoadingProcessChanged ;

		public void Finished ( ) { FinishedEvent ? . Invoke ( this , new EventArgs ( ) ) ; }

		public event EventHandler FinishedEvent ;

	}

}
