using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class ProgramOptionsDialog : Form
	{
		/// <summary>
		/// Path to emulator executable.
		/// </summary>
		public string EmulatorPath;

		public ProgramOptionsDialog()
		{
			this.EmulatorPath = VPWStudio.Properties.Settings.Default.EmulatorPath;

			InitializeComponent();

			tbEmuPath.Text = this.EmulatorPath;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (!File.Exists(tbEmuPath.Text))
			{
				// todo: error
				return;
			}
			this.EmulatorPath = tbEmuPath.Text;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Emulator Executable";
			ofd.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbEmuPath.Text = ofd.FileName;
			}
		}
	}
}
