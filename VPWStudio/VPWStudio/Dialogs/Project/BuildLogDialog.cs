using System;
using System.Text;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class BuildLogDialog : Form
	{
		/// <summary>
		/// Has the build completed?
		/// </summary>
		public bool BuildFinished = false;

		public BuildLogDialog(BuildLogEventPublisher p)
		{
			InitializeComponent();
			BuildFinished = false;
			p.RaiseBuildLogEvent += BuildLogEvent;
		}

		/// <summary>
		/// Handle build log event.
		/// </summary>
		private void BuildLogEvent(object sender, BuildLogEventArgs e)
		{
			tbLogOutput.Text += e.Message;
			if (e.AddNewline)
			{
				tbLogOutput.Text += Environment.NewLine;
			}
		}

		/// <summary>
		/// Move the cursor to the end of the log output box.
		/// </summary>
		/// I probably could have avoided this and the event stuff if I just
		/// made the textbox public, but where's the fun in that?
		public void MoveCursorToEnd()
		{
			tbLogOutput.SelectionStart = tbLogOutput.Text.Length - 1;
			tbLogOutput.SelectionLength = 0;
		}

		/// <summary>
		/// Clear log output.
		/// </summary>
		public void Clear()
		{
			tbLogOutput.Clear();
		}

		/// <summary>
		/// Handle pressing Escape when build finished.
		/// </summary>
		private void tbLogOutput_KeyUp(object sender, KeyEventArgs e)
		{
			if (BuildFinished && e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}
	}
}
