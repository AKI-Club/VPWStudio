using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class BuildLogDialog : Form
	{
		public bool BuildFinished = false;

		public BuildLogDialog()
		{
			InitializeComponent();
			BuildFinished = false;
		}

		/// <summary>
		/// Clear log output
		/// </summary>
		public void Clear()
		{
			tbLogOutput.Clear();
		}

		/// <summary>
		/// Add text to log output (without newline)
		/// </summary>
		/// <param name="t">Text to add</param>
		public void AddText(string t)
		{
			tbLogOutput.Text += t;
		}

		/// <summary>
		/// Add text to log output (with newline)
		/// </summary>
		/// <param name="t">Text to add</param>
		public void AddLine(string t)
		{
			tbLogOutput.Text += t + Environment.NewLine;
		}

		/// <summary>
		/// Handle Escape when build finished
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
