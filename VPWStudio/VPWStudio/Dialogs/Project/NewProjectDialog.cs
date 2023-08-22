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

			// if using custom location file, the custom location file must exist
			if (chbCustomLocation.Checked && !File.Exists(tbCustomLocationFile.Text))
			{
				MessageBox.Show(String.Format("Custom Location File not found at\n{0}", Path.GetFullPath(tbCustomLocationFile.Text)), SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// if using custom FileTableDB file, path to custom FileTableDB must not be empty
			if (chbCustomFileTableDB.Checked && tbCustomFileTableDBFile.Text.Equals(String.Empty))
			{
				MessageBox.Show("Must provide custom FileTableDB path if using custom FileTableDB file.", SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// if using custom FileTableDB file, the custom FileTableDB file must exist
			if (chbCustomFileTableDB.Checked && !File.Exists(tbCustomFileTableDBFile.Text))
			{
				MessageBox.Show(String.Format("Custom FileTableDB File not found at\n{0}", Path.GetFullPath(tbCustomFileTableDBFile.Text)), SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			GameDefinition gd = GameInformation.GameDefs[(SpecificGame)cbGameVersion.SelectedIndex];
			// N64-specific checks
			if (gd.TargetConsole == PlatformType.Nintendo64)
			{
				// check input rom against selected project type
				Z64Rom romTemp = new Z64Rom(tbRomFile.Text);
				if (!string.Equals(romTemp.GameCode, gd.GameCode))
				{
					if (!string.Equals(romTemp.GameCode.Substring(1, 2), gd.GameCode.Substring(1, 2)))
					{
						// game code is outright wrong
						Program.ErrorMessageBox(String.Format("The project expects a game code of '{0}', but the selected base ROM has a game code of '{1}'.\n\nPlease select a valid {2} ROM file, or change the Game Type.",
							gd.GameCode.Substring(1, 2), romTemp.GameCode.Substring(1, 2), GameInformation.GetBaseGameName(gd.BaseGame)
						));
						return;
					}
					else if (romTemp.GameCode[3] != gd.GameCode[3])
					{
						// region mismatch
						Program.ErrorMessageBox(String.Format("The project's selected game variant is for region {0} ('{1}'), but the selected base ROM has a region value of '{2}' ({3}). Ensure that you have the correct ROM, or change the Game Type.",
							gd.Region, (char)gd.Region, romTemp.GameCode[3], ((GameRegion)romTemp.GameCode[3]).ToString()
						));
						return;
					}
				}

				if (romTemp.GameVersion != gd.GameVersion)
				{
					// game revision mismatch (only really necessary for World Tour NTSC-U and WWF No Mercy all regions)
					Program.ErrorMessageBox(String.Format("The project expects a game revision value of 0x{0:X2}, but the selected base ROM has a game revision value of 0x{1:X2}. Ensure that you have the correct version of the game, or change the Game Type.",
						gd.GameVersion, romTemp.GameVersion
					));
					return;
				}
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

			this.NewSettings.UseCustomFileTableDB = (chbCustomFileTableDB.Checked);
			if (chbCustomFileTableDB.Checked)
			{
				this.NewSettings.CustomFileTableDBPath = tbCustomFileTableDBFile.Text;
			}
			else
			{
				this.NewSettings.CustomFileTableDBPath = String.Empty;
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

		private void buttonSetCustomFileTableDBFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Custom FileTableDB File";
			ofd.Filter = SharedStrings.FileFilter_Text;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbCustomFileTableDBFile.Text = ofd.FileName;
			}
		}

		private void chbCustomLocation_Click(object sender, EventArgs e)
		{
			tbCustomLocationFile.Enabled = chbCustomLocation.Checked;
			buttonSetCustomLocFile.Enabled = chbCustomLocation.Checked;
		}

		private void chbCustomFileTableDB_Click(object sender, EventArgs e)
		{
			tbCustomFileTableDBFile.Enabled = chbCustomFileTableDB.Checked;
			buttonSetCustomFileTableDBFile.Enabled = chbCustomFileTableDB.Checked;
		}

		#region Drag and Drop
		private void tbRomFile_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void tbRomFile_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				tbRomFile.Text = Path.GetFullPath(files[0]);
			}
		}

		private void tbCustomLocationFile_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void tbCustomLocationFile_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop) && tbCustomLocationFile.Enabled)
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				tbCustomLocationFile.Text = Path.GetFullPath(files[0]);
			}
		}

		private void tbCustomFileTableDBFile_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void tbCustomFileTableDBFile_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop) && tbCustomFileTableDBFile.Enabled)
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				tbCustomFileTableDBFile.Text = Path.GetFullPath(files[0]);
			}
		}

		#endregion
	}
}
