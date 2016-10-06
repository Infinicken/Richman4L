using System ;

namespace FoggyConsole . Controls .Events
{

	/// <summary>
	///     Contains information about an occuring status-change of a <code>Checkbox</code>
	/// </summary>
	public class CheckedChangingEventArgs : EventArgs
	{

		/// <summary>
		///     The state the Checkbox is going to have
		/// </summary>
		public CheckState State { get ; private set ; }

		/// <summary>
		///     True if the change should be canceled, otherwise false
		/// </summary>
		public bool Cancel { get ; set ; }

		/// <summary>
		///     Creates a new <code>CheckboxCheckedChangingEventArg</code>
		/// </summary>
		/// <param name="state">The state the Checkbox is going to have</param>
		public CheckedChangingEventArgs ( CheckState state )
		{
			State = state ;
			Cancel = false ;
		}

	}

}