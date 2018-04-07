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
		public string EmulatorArgs;

		public ProgramOptionsDialog()
		{
			EmulatorPath = Properties.Settings.Default.EmulatorPath;
			EmulatorArgs = Properties.Settings.Default.EmulatorArguments;

			InitializeComponent();

			tbEmuPath.Text = EmulatorPath;
			tbEmulatorArguments.Text = EmulatorArgs;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (tbEmuPath.Text != String.Empty && !File.Exists(tbEmuPath.Text))
			{
				// todo: error
				Program.ErrorMessageBox("Emulator executable not found.");
				return;
			}
			EmulatorPath = tbEmuPath.Text;
			EmulatorArgs = tbEmulatorArguments.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
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
