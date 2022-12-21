using System;
using System.IO;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class ProgramOptionsDialog : Form
	{
		// todo: anything involving an emulator is currently N64-specific
		/// <summary>
		/// Path to emulator executable.
		/// </summary>
		public string EmulatorPath;
		public string EmulatorArgs;

		/// <summary>
		/// Controls output displayed during the build phase.
		/// </summary>
		public int BuildLogVerbosity;

		public ProgramOptionsDialog()
		{
			EmulatorPath = Properties.Settings.Default.EmulatorPath;
			EmulatorArgs = Properties.Settings.Default.EmulatorArguments;

			InitializeComponent();
			tvOptions.SelectedNode = tvOptions.Nodes["EmulatorN64"];

			optionControlEmuN64.tbEmuPath.Text = EmulatorPath;
			optionControlEmuN64.tbEmulatorArguments.Text = EmulatorArgs;

			cbBuildLogVerbosity.BeginUpdate();
			foreach (int i in Enum.GetValues(typeof(BuildLogEventPublisher.BuildLogVerbosity)))
			{
				cbBuildLogVerbosity.Items.Add(((BuildLogEventPublisher.BuildLogVerbosity)i).ToString());
			}
			cbBuildLogVerbosity.EndUpdate();
			cbBuildLogVerbosity.SelectedIndex = Properties.Settings.Default.BuildLogVerbosity;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (optionControlEmuN64.tbEmuPath.Text != String.Empty && !File.Exists(optionControlEmuN64.tbEmuPath.Text))
			{
				Program.ErrorMessageBox("Emulator executable not found.");
				return;
			}
			EmulatorPath = optionControlEmuN64.tbEmuPath.Text;
			EmulatorArgs = optionControlEmuN64.tbEmulatorArguments.Text;
			BuildLogVerbosity = cbBuildLogVerbosity.SelectedIndex;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void tvOptions_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (tvOptions.SelectedNode == null)
			{
				return;
			}

			optionControlEmuN64.Visible = (tvOptions.SelectedNode.Name == "EmulatorN64");
			tlpBuildLogVerbosity.Visible = (tvOptions.SelectedNode.Name == "Build");
		}
	}
}
