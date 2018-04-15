using System;
using System.IO;
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
		public int BuildLogVerbosity;

		public ProgramOptionsDialog()
		{
			EmulatorPath = Properties.Settings.Default.EmulatorPath;
			EmulatorArgs = Properties.Settings.Default.EmulatorArguments;

			InitializeComponent();
			tvOptions.SelectedNode = tvOptions.Nodes["Emulator"];

			optionControlEmu.tbEmuPath.Text = EmulatorPath;
			optionControlEmu.tbEmulatorArguments.Text = EmulatorArgs;

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
			if (optionControlEmu.tbEmuPath.Text != String.Empty && !File.Exists(optionControlEmu.tbEmuPath.Text))
			{
				Program.ErrorMessageBox("Emulator executable not found.");
				return;
			}
			EmulatorPath = optionControlEmu.tbEmuPath.Text;
			EmulatorArgs = optionControlEmu.tbEmulatorArguments.Text;
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

			switch (tvOptions.SelectedNode.Name)
			{
				case "Emulator":
					{
						optionControlEmu.Visible = true;
						tlpBuildLogVerbosity.Visible = false;
					}
					break;
				case "Build":
					{
						optionControlEmu.Visible = false;
						tlpBuildLogVerbosity.Visible = true;
					}
					break;
			}
		}
	}
}
