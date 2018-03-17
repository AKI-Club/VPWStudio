using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	public class BuildLogEventArgs : EventArgs
	{
		public string Message;
		public bool AddNewline;

		public BuildLogEventArgs(string _msg, bool _newline)
		{
			Message = _msg;
			AddNewline = _newline;
		}
	}

	public class BuildLogEventPublisher
	{
		public event EventHandler<BuildLogEventArgs> RaiseBuildLogEvent;

		public void AddLine(string s, bool n = true)
		{
			OnRaiseBuildLogEvent(new BuildLogEventArgs(s, n));
		}

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
