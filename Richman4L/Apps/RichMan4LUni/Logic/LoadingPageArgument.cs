using System ;
using System . Threading . Tasks ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{

	public class LoadingPageArgument
	{
		public Task TaskToWait { get; }

		public Action ToDoNext { get; }

		public LoadingPageArgument ( Task taskToWait , Action toDoNext )
		{
			if ( taskToWait == null )
			{
				throw new ArgumentNullException ( nameof ( taskToWait ) ) ;
			}
			if ( toDoNext == null )
			{
				throw new ArgumentNullException ( nameof ( toDoNext ) ) ;
			}
			
			TaskToWait = taskToWait ;
			ToDoNext = toDoNext ;
		}

	}
}
