using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;
using System . Threading ;
using System . Windows . Controls ;

namespace WenceyWang . Richman4L . Apps . Wpf . Logic
{

	/// <summary>
	///     Wrapper around a standard synchronization context, that catches any unhandled exceptions.
	///     Acts as a facade passing calls to the original SynchronizationContext
	/// </summary>
	/// <example>
	///     Set this up inside your App.xaml.cs file as follows:
	///     <code>
	/// protected override void OnActivated(IActivatedEventArgs args)
	/// {
	///     EnsureSyncContext();
	///     ...
	/// }
	/// 
	/// protected override void OnLaunched(LaunchActivatedEventArgs args)
	/// {
	///     EnsureSyncContext();
	///     ...
	/// }
	/// 
	/// private void EnsureSyncContext()
	/// {
	///     var exceptionHandlingSynchronizationContext = ExceptionHandlingSynchronizationContext.Register();
	///     exceptionHandlingSynchronizationContext.UnhandledException += OnSynchronizationContextUnhandledException;
	/// }
	/// 
	/// private void OnSynchronizationContextUnhandledException(object sender, UnhandledExceptionEventArgs args)
	/// {
	///     args.Handled = true;
	/// }
	/// </code>
	/// </example>
	internal class ExceptionHandlingSynchronizationContext : SynchronizationContext
	{

		public SynchronizationContext SyncContext { get ; }

		public ExceptionHandlingSynchronizationContext ( SynchronizationContext syncContext ) { SyncContext = syncContext ; }

		/// <summary>
		///     Registration method.  Call this from OnLaunched and OnActivated inside the App.xaml.cs
		/// </summary>
		/// <returns></returns>
		public static ExceptionHandlingSynchronizationContext Register ( )
		{
			SynchronizationContext syncContext = Current ;
			if ( syncContext == null )
			{
				throw new InvalidOperationException ( "Ensure a synchronization context exists before calling this method." ) ;
			}


			ExceptionHandlingSynchronizationContext customSynchronizationContext =
				syncContext as ExceptionHandlingSynchronizationContext ;


			if ( customSynchronizationContext == null )
			{
				customSynchronizationContext = new ExceptionHandlingSynchronizationContext ( syncContext ) ;
				SetSynchronizationContext ( customSynchronizationContext ) ;
			}


			return customSynchronizationContext ;
		}

		/// <summary>
		///     Links the synchronization context to the specified frame
		///     and ensures that it is still in use after each navigation event
		/// </summary>
		/// <param name="rootFrame"></param>
		/// <returns></returns>
		public static ExceptionHandlingSynchronizationContext RegisterForFrame ( Frame rootFrame )
		{
			if ( rootFrame == null )
			{
				throw new ArgumentNullException ( "rootFrame" ) ;
			}

			ExceptionHandlingSynchronizationContext synchronizationContext = Register ( ) ;

			rootFrame . Navigating += ( sender , args ) => EnsureContext ( synchronizationContext ) ;
			rootFrame . Loaded += ( sender , args ) => EnsureContext ( synchronizationContext ) ;

			return synchronizationContext ;
		}

		private static void EnsureContext ( SynchronizationContext context )
		{
			if ( Current != context )
			{
				SetSynchronizationContext ( context ) ;
			}
		}


		public override SynchronizationContext CreateCopy ( )
		{
			return new ExceptionHandlingSynchronizationContext ( SyncContext . CreateCopy ( ) ) ;
		}


		public override void OperationCompleted ( ) { SyncContext . OperationCompleted ( ) ; }


		public override void OperationStarted ( ) { SyncContext . OperationStarted ( ) ; }


		public override void Post ( SendOrPostCallback d , object state )
		{
			SyncContext . Post ( WrapCallback ( d ) , state ) ;
		}


		public override void Send ( SendOrPostCallback d , object state ) { SyncContext . Send ( d , state ) ; }


		private SendOrPostCallback WrapCallback ( SendOrPostCallback sendOrPostCallback )
		{
			return state =>
					{
						try
						{
							sendOrPostCallback ( state ) ;
						}
						catch ( Exception ex )
						{
							if ( ! HandleException ( ex ) )
							{
								throw ;
							}
						}
					} ;
		}

		private bool HandleException ( Exception exception )
		{
			if ( UnhandledException == null )
			{
				return false ;
			}

			UnhandledExceptionEventArgs exWrapper = new UnhandledExceptionEventArgs { Exception = exception } ;

			UnhandledException ( this , exWrapper ) ;

#if DEBUG && !DISABLE_XAML_GENERATED_BREAK_ON_UNHANDLED_EXCEPTION
			if ( Debugger . IsAttached )
			{
				Debugger . Break ( ) ;
			}
#endif

			return exWrapper . Handled ;
		}


		/// <summary>
		///     Listen to this event to catch any unhandled exceptions and allow for handling them
		///     so they don't crash your application
		/// </summary>
		public event EventHandler <UnhandledExceptionEventArgs> UnhandledException ;

	}

	public class UnhandledExceptionEventArgs : EventArgs
	{

		public bool Handled { get ; set ; }

		public Exception Exception { get ; set ; }

	}

}
