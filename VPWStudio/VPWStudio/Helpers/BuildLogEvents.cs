using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// BuildLog Event arguments
	/// </summary>
	public class BuildLogEventArgs : EventArgs
	{
		/// <summary>
		/// Message to add to log.
		/// </summary>
		public string Message;

		/// <summary>
		/// Add a newline to the end of the message?
		/// </summary>
		public bool AddNewline;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_msg">Message data</param>
		/// <param name="_newline">Add newline?</param>
		public BuildLogEventArgs(string _msg, bool _newline)
		{
			Message = _msg;
			AddNewline = _newline;
		}
	}

	/// <summary>
	/// BuildLog Event Publisher.
	/// </summary>
	public class BuildLogEventPublisher
	{
		/// <summary>
		/// Values for possible Build Log verbosity.
		/// </summary>
		public enum BuildLogVerbosity
		{
			/// <summary>
			/// Only "required" items
			/// </summary>
			Minimal = 0,

			/// <summary>
			/// Default logging level.
			/// </summary>
			Normal,

			/// <summary>
			/// Show most everything.
			/// </summary>
			Detailed,

			/// <summary>
			/// Show me EVERYTHING.
			/// </summary>
			Diagnostic
		}

		public event EventHandler<BuildLogEventArgs> RaiseBuildLogEvent;

		/// <summary>
		/// Raise a BuildLogEvent with a newline.
		/// </summary>
		public void AddLine()
		{
			OnRaiseBuildLogEvent(new BuildLogEventArgs(Environment.NewLine, false));
		}

		/// <summary>
		/// Raise a BuildLogEvent with a newline for the specified BuildLogVerbosity.
		/// </summary>
		/// <param name="vl">Minimum level of verbosity to show this line.</param>
		public void AddLine(BuildLogVerbosity vl)
		{
			if ((BuildLogVerbosity)Properties.Settings.Default.BuildLogVerbosity >= vl)
			{
				OnRaiseBuildLogEvent(new BuildLogEventArgs(Environment.NewLine, false));
			}
		}

		/// <summary>
		/// Raise a BuildLogEvent with the specified message.
		/// </summary>
		/// <param name="s">Message to add to the log.</param>
		/// <param name="n">Add newline at the end of message? Defaults to true.</param>
		/// <param name="vl">Minimum level of verbosity to show this line.</param>
		public void AddLine(string s, bool n = true, BuildLogVerbosity vl = BuildLogVerbosity.Normal)
		{
			if ((BuildLogVerbosity)Properties.Settings.Default.BuildLogVerbosity >= vl)
			{
				OnRaiseBuildLogEvent(new BuildLogEventArgs(s, n));
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnRaiseBuildLogEvent(BuildLogEventArgs e)
		{
			EventHandler<BuildLogEventArgs> handler = RaiseBuildLogEvent;
			if (handler != null)
			{
				handler(this, e);
			}
		}
	}
}
