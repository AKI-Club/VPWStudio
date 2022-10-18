using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Tools
{
	public partial class TimEditor : Form
	{
		public TimEditor()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Create a new project.
		/// </summary>
		private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timStatusLabel.Text = "New project file";
		}

		/// <summary>
		/// Open an existing TIM file to be used as a project base.
		/// </summary>
		private void openTIMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select TIM File";
			ofd.Filter = SharedStrings.FileLoadFilter_TextureTim;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				timStatusLabel.Text = String.Format("Existing TIM file at {0}", Path.GetFullPath(ofd.FileName));
			}
		}
	}
}
