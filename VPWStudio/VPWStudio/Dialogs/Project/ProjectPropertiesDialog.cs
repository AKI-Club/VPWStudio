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
	public partial class ProjectPropertiesDialog : Form
	{
		#region Project Settings
		/// <summary>
		/// New settings to copy over if OK button pressed.
		/// </summary>
		public ProjectSettings NewSettings = new ProjectSettings();
		#endregion

		public ProjectPropertiesDialog()
		{
			InitializeComponent();

			cbGameType.BeginUpdate();
			foreach (KeyValuePair<SpecificGame, GameDefinition> def in GameInformation.GameDefs)
			{
				cbGameType.Items.Add(GameInformation.GetSpecificGameName(def.Key));
			}
			cbGameType.EndUpdate();

			if (Program.CurrentProject == null)
			{
				MessageBox.Show("Now how in the world did you manage to do this?","???",MessageBoxButtons.OK);
			}
			else
			{
				this.NewSettings.DeepCopy(Program.CurrentProject.Settings);

				// main page
				tbProjectName.Text = Program.CurrentProject.Settings.ProjectName;
				tbAuthors.Text = Program.CurrentProject.Settings.Authors;
				cbGameType.SelectedIndex = (int)Program.CurrentProject.Settings.GameType;
				tbBaseROMPath.Text = Program.CurrentProject.Settings.InputRomPath;

				// output rom page
				tbOutROMPath.Text = Program.CurrentProject.Settings.OutputRomPath;
				tbOutRomInternalName.Text = Program.CurrentProject.Settings.OutputRomInternalName;
				tbOutRomProductCode.Text = Program.CurrentProject.Settings.OutputRomGameCode;

				// project files page
				tbProjFilesPath.Text = Program.CurrentProject.Settings.ProjectFilesPath;
				tbGSCodeFile.Text = Program.CurrentProject.Settings.ProjectGSCodeFilePath;
				chbCustomLocation.Checked = Program.CurrentProject.Settings.UseCustomLocationFile;
				tbCustomLocationFile.Text = Program.CurrentProject.Settings.CustomLocationFilePath;
			}
		}

		/// <summary>
		/// Hacky thing used by MainForm
		/// </summary>
		public void SetInitialTabPage()
		{
			tcProjectProperties.SelectedIndex = 0;
		}

		#region Main Buttons
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
			if (tbBaseROMPath.Text.Equals(String.Empty))
			{
				MessageBox.Show("Must provide Input ROM path.", SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// input ROM must exist
			if (!File.Exists(tbBaseROMPath.Text))
			{
				MessageBox.Show(String.Format("Input ROM file not found at\n{0}", Path.GetFullPath(tbBaseROMPath.Text)), SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

			// todo: output rom internal name must not be blank?
			// length issues are ignored because they can be dealt with silently at build time.

			if (tbOutRomProductCode.Text.Equals(String.Empty))
			{
				// empty string? replace with the game code for the current game.
				tbOutRomProductCode.Text = GameInformation.GameDefs[(SpecificGame)cbGameType.SelectedIndex].GameCode.Substring(0, 4);
			}
			else if (!tbOutRomProductCode.Text.StartsWith("N"))
			{
				// internal game code must start with "N" because none of the games have 64DD support
				// this isn't a hard error; just replace it silently.
				string remain = tbOutRomProductCode.Text.Substring(1, 3);
				tbOutRomProductCode.Text = "N" + remain;
			}
			else if (tbOutRomProductCode.Text.Length != 4)
			{
				// must be four characters.
				MessageBox.Show("Output ROM Product Code must be four characters long.", SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			#endregion

			// check for project type change
			if (Program.CurrentProject.Settings.GameType != (SpecificGame)cbGameType.SelectedIndex)
			{
				if (MessageBox.Show(
					"Changing the project game type will reset all project data.\nDo you want to proceed?",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation
					) == DialogResult.No)
				{
					return;
				}
			}

			// main tab
			this.NewSettings.ProjectName = tbProjectName.Text;
			this.NewSettings.Authors = tbAuthors.Text;
			this.NewSettings.GameType = (SpecificGame)cbGameType.SelectedIndex;
			this.NewSettings.BaseGame = GameInformation.GetBaseGameFromSpecificGame(this.NewSettings.GameType);
			this.NewSettings.InputRomPath = tbBaseROMPath.Text;

			// output rom tab
			this.NewSettings.OutputRomPath = tbOutROMPath.Text;
			this.NewSettings.OutputRomInternalName = tbOutRomInternalName.Text;
			this.NewSettings.OutputRomGameCode = tbOutRomProductCode.Text;

			// project files tab
			this.NewSettings.ProjectGSCodeFilePath = tbGSCodeFile.Text;

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

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		#endregion

		#region Main Tab
		/// <summary>
		/// Select input/base ROM path.
		/// </summary>
		private void buttonOpenBaseROM_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Set Base ROM File Path";
			ofd.Filter = SharedStrings.FileFilter_N64Rom;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbBaseROMPath.Text = Path.GetFullPath(ofd.FileName);
			}
		}
		#endregion

		#region Output ROM Tab
		/// <summary>
		/// Select output ROM path.
		/// </summary>
		private void buttonSetOutROM_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Set Output ROM File Path";
			sfd.Filter = SharedStrings.FileFilter_N64Rom;
			sfd.CheckFileExists = false;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				tbBaseROMPath.Text = Path.GetFullPath(sfd.FileName);
			}
		}
		#endregion

		#region Project Files Tab
		private void buttonSetProjFilesPath_Click(object sender, EventArgs e)
		{
			// todo: balls.
		}

		private void chbCustomLocation_Click(object sender, EventArgs e)
		{
			buttonSetCustomLocFile.Enabled = chbCustomLocation.Checked;
			tbCustomLocationFile.Enabled = chbCustomLocation.Checked;
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

		private void buttonSetGSCodefile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select GameShark Code File";
			ofd.Filter = SharedStrings.FileFilter_GameSharkCodes;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbGSCodeFile.Text = ofd.FileName;
			}
		}
		#endregion
	}
}
