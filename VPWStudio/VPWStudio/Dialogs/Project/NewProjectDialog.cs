using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class NewProjectDialog : Form
	{
		public ProjectSettings NewSettings = new ProjectSettings();

		public NewProjectDialog()
		{
			InitializeComponent();

			cbGameVersion.BeginUpdate();
			foreach (KeyValuePair<SpecificGame, GameDefinition> def in GameInformation.GameDefs)
			{
				// xxx hack: don't add PS1 games, since support still needs to be coded
				if (def.Value.TargetConsole != PlatformType.PlayStation1)
				{
					cbGameVersion.Items.Add(GameInformation.GetSpecificGameName(def.Key));
				}
			}
			cbGameVersion.EndUpdate();
			cbGameVersion.SelectedIndex = 0;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			#region Validation
			// project name must not be empty
			if (tbProjectName.Text.Equals(String.Empty))
			{
				MessageBox.Show("Must provide a project name.", SharedStrings.MainForm_Title, MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			// input ROM path must not be empty
			if (tbRomFile.Text.Equals(String.Empty))
			{
				MessageBox.Show("Must provide path to a ROM.", SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// input ROM path cannot be relative on project creation
			// (this is because relative paths are relative to the project file path,
			// which doesn't exist until the project file is saved for the first time.)
			if (!Path.IsPathRooted(tbRomFile.Text))
			{
				MessageBox.Show("ROM file path must be absolute on new project creation.\nYou may change the ROM path to a relative one once the project file is saved for the first time.", SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// input ROM must exist
			if (!File.Exists(tbRomFile.Text))
			{
				MessageBox.Show(String.Format("ROM file not found at\n{0}",Path.GetFullPath(tbRomFile.Text)), SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// if using custom location file, path to custom location must not be empty
			if (chbCustomLocation.Checked && tbCustomLocationFile.Text.Equals(String.Empty))
			{
				MessageBox.Show("Must provide custom location path if using custom location file.", SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// custom location file must exist
			if (chbCustomLocation.Checked && !File.Exists(tbCustomLocationFile.Text))
			{
				MessageBox.Show(String.Format("Custom Location File not found at\n{0}", Path.GetFullPath(tbCustomLocationFile.Text)), SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			#endregion

			// set results
			this.NewSettings.ProjectName = tbProjectName.Text;
			this.NewSettings.Authors = tbAuthors.Text;
			this.NewSettings.GameType = (SpecificGame)cbGameVersion.SelectedIndex;
			this.NewSettings.BaseGame = GameInformation.GetBaseGameFromSpecificGame((SpecificGame)cbGameVersion.SelectedIndex);
			this.NewSettings.InputRomPath = tbRomFile.Text;
			this.NewSettings.OutputRomPath = tbOutROMPath.Text;
			this.NewSettings.UseCustomLocationFile = (chbCustomLocation.Checked);
			if (chbCustomLocation.Checked)
			{
				this.NewSettings.CustomLocationFilePath = tbCustomLocationFile.Text;
			}
			else
			{
				this.NewSettings.CustomLocationFilePath = String.Empty;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonOpenROM_Click(object sender, EventArgs e)
		{
			OpenFileDialog openRom = new OpenFileDialog();
			openRom.Title = "Select Base ROM File";
			openRom.Filter = SharedStrings.FileFilter_N64Rom;
			if (openRom.ShowDialog() == DialogResult.OK)
			{
				tbRomFile.Text = openRom.FileName;
			}
		}

		private void buttonSetOutROM_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveRom = new SaveFileDialog();
			saveRom.Title = "Select Output ROM File";
			saveRom.Filter = SharedStrings.FileFilter_N64Rom;
			saveRom.CheckFileExists = false;
			if (saveRom.ShowDialog() == DialogResult.OK)
			{
				tbOutROMPath.Text = saveRom.FileName;
			}
		}

		private void buttonSetCustomLocFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Custom Location File";
			ofd.Filter = SharedStrings.FileFilter_Text;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbCustomLocationFile.Text = ofd.FileName;
			}
		}

		private void chbCustomLocation_Click(object sender, EventArgs e)
		{
			tbCustomLocationFile.Enabled = chbCustomLocation.Checked;
			buttonSetCustomLocFile.Enabled = chbCustomLocation.Checked;
		}
	}
}
