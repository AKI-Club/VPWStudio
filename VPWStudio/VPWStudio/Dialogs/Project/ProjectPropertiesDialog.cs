using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

		/// <summary>
		/// List of game regions used in the drop-down list.
		/// </summary>
		private GameRegion[] RegionList;

		public ProjectPropertiesDialog()
		{
			InitializeComponent();

			cbGameType.BeginUpdate();
			foreach (KeyValuePair<SpecificGame, GameDefinition> def in GameInformation.GameDefs)
			{
				// xxx hack: don't add PS1 games, since support still needs to be coded
				if (def.Value.TargetConsole != PlatformType.PlayStation1)
				{
					cbGameType.Items.Add(GameInformation.GetSpecificGameName(def.Key));
				}
			}
			cbGameType.EndUpdate();

			#region N64-specific
			RegionList = new GameRegion[Enum.GetValues(typeof(GameRegion)).Length];

			cbRegionCode.BeginUpdate();
			int regionCounter = 0;
			foreach (KeyValuePair<GameRegion, string> region in GameRegionInfo.GameRegionNames)
			{
				RegionList[regionCounter] = region.Key;

				if (region.Key == GameRegion.Custom)
				{
					cbRegionCode.Items.Add(region.Value);
				}
				else
				{
					cbRegionCode.Items.Add(String.Format("{0} ({1})", region.Value, (char)region.Key));
				}

				regionCounter++;
			}
			cbRegionCode.EndUpdate();
			#endregion

			if (Program.CurrentProject == null)
			{
				MessageBox.Show("Now how in the world did you manage to do this?","???",MessageBoxButtons.OK);
			}
			else
			{
				NewSettings.DeepCopy(Program.CurrentProject.Settings);

				// main page
				tbProjectName.Text = Program.CurrentProject.Settings.ProjectName;
				tbAuthors.Text = Program.CurrentProject.Settings.Authors;
				cbGameType.SelectedIndex = (int)Program.CurrentProject.Settings.GameType;
				tbBaseROMPath.Text = Program.CurrentProject.Settings.InputRomPath;

				// output rom page
				tbOutROMPath.Text = Program.CurrentProject.Settings.OutputRomPath;
				tbOutRomInternalName.Text = Program.CurrentProject.Settings.OutputRomInternalName;

				if (Program.CurrentProject.Settings.OutputRomRegion == GameRegion.Custom)
				{
					cbRegionCode.SelectedIndex = cbRegionCode.Items.Count - 1;
				}
				else
				{
					// selected index is based on game region
					int regionIndex = Array.IndexOf(RegionList, Program.CurrentProject.Settings.OutputRomRegion);
					if (regionIndex != -1)
					{
						cbRegionCode.SelectedIndex = regionIndex;
					}
				}

				// output data page
				tbOutDataPath.Text = Program.CurrentProject.Settings.OutputDataPath;
				tbInDataPath.Text = Program.CurrentProject.Settings.InputDataPath;

				// project files page
				tbProjFilesPath.Text = Program.CurrentProject.Settings.ProjectFilesPath;
				tbAssetFilesPath.Text = Program.CurrentProject.Settings.AssetsPath;
				chbCustomLocation.Checked = Program.CurrentProject.Settings.UseCustomLocationFile;
				tbCustomLocationFile.Text = Program.CurrentProject.Settings.CustomLocationFilePath;
				chbCustomFileTableDB.Checked = Program.CurrentProject.Settings.UseCustomFileTableDB;
				tbCustomFileTableDBFile.Text = Program.CurrentProject.Settings.CustomFileTableDBPath;
				tbWrestlerNamesFile.Text = Program.CurrentProject.Settings.WrestlerNameFilePath;
			}

			// hide platform-specific tab pages
			PlatformType plat = Program.CurrentProject.Settings.GetPlatformType();
			if (plat == PlatformType.Nintendo64)
			{
				int hidePage = tcProjectProperties.TabPages.IndexOfKey("tpOutputData");
				tcProjectProperties.TabPages.Remove(tcProjectProperties.TabPages[hidePage]);
			}
			else if(plat == PlatformType.PlayStation1)
			{
				int hidePage = tcProjectProperties.TabPages.IndexOfKey("tpOutputRom");
				tcProjectProperties.TabPages.Remove(tcProjectProperties.TabPages[hidePage]);
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
				Program.ErrorMessageBox("Must provide a project name.");
				return;
			}

			// input ROM path must not be empty
			if (tbBaseROMPath.Text.Equals(String.Empty))
			{
				Program.ErrorMessageBox("Must provide Input ROM path.");
				return;
			}

			// input ROM path must be rooted if the project has not been saved yet
			if (Program.CurProjectPath == String.Empty && !Path.IsPathRooted(tbBaseROMPath.Text))
			{
				Program.ErrorMessageBox("Input ROM cannot use a relative path until the project file is saved for the first time.");
				return;
			}

			// input ROM must exist
			string baseRomPath = tbBaseROMPath.Text;
			if (!Path.IsPathRooted(baseRomPath))
			{
				baseRomPath = String.Format("{0}\\{1}", Path.GetDirectoryName(Program.CurProjectPath), baseRomPath);
			}

			if (!File.Exists(baseRomPath))
			{
				Program.ErrorMessageBox(String.Format("Input ROM file not found at\n{0}", Path.GetFullPath(baseRomPath)));
				return;
			}

			// if using custom location file, path to custom location must not be empty
			if (chbCustomLocation.Checked && tbCustomLocationFile.Text.Equals(String.Empty))
			{
				Program.ErrorMessageBox("Must provide custom Location File path if using a custom location file.");
				return;
			}

			// custom location file must exist if using it
			if (chbCustomLocation.Checked && !File.Exists(tbCustomLocationFile.Text))
			{
				Program.ErrorMessageBox(String.Format("Custom Location File not found at\n{0}", Path.GetFullPath(tbCustomLocationFile.Text)));
				return;
			}

			// if using custom FileTableDB, path to custom FileTableDB must not be empty
			if (chbCustomFileTableDB.Checked && tbCustomFileTableDBFile.Text.Equals(String.Empty))
			{
				Program.ErrorMessageBox("Must provide custom FileTableDB path if using a custom FileTableDB file.");
				return;
			}

			// custom FileTableDB must exist if using it
			if (chbCustomFileTableDB.Checked && !File.Exists(tbCustomFileTableDBFile.Text))
			{
				Program.ErrorMessageBox(String.Format("Custom FileTableDB File not found at\n{0}", Path.GetFullPath(tbCustomFileTableDBFile.Text)));
				return;
			}

			// todo: output rom internal name must not be blank?
			// length issues are ignored because they can be dealt with silently at build time.

			if (RegionList[cbRegionCode.SelectedIndex] == GameRegion.Custom && tbRegionCode.Text == String.Empty)
			{
				Program.ErrorMessageBox("Region code must be provided if using a custom region.");
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
			NewSettings.ProjectName = tbProjectName.Text;
			NewSettings.Authors = tbAuthors.Text;
			NewSettings.GameType = (SpecificGame)cbGameType.SelectedIndex;
			NewSettings.BaseGame = GameInformation.GetBaseGameFromSpecificGame(NewSettings.GameType);
			NewSettings.InputRomPath = tbBaseROMPath.Text;

			// output rom tab
			NewSettings.OutputRomPath = tbOutROMPath.Text;
			NewSettings.OutputRomInternalName = tbOutRomInternalName.Text;
			NewSettings.OutputRomRegion = RegionList[cbRegionCode.SelectedIndex];
			if (RegionList[cbRegionCode.SelectedIndex] == GameRegion.Custom)
			{
				NewSettings.OutputRomCustomRegion = tbRegionCode.Text[0];
			}
			else
			{
				NewSettings.OutputRomCustomRegion = (char)RegionList[cbRegionCode.SelectedIndex];
			}

			// output data tab
			if (NewSettings.GetPlatformType() == PlatformType.PlayStation1)
			{
				NewSettings.OutputDataPath = tbOutDataPath.Text;
				NewSettings.InputDataPath = tbInDataPath.Text;
			}
			else
			{
				NewSettings.OutputDataPath = null;
				NewSettings.InputDataPath = null;
			}

			// project files tab
			NewSettings.ProjectFilesPath = tbProjFilesPath.Text;
			NewSettings.AssetsPath = tbAssetFilesPath.Text;

			NewSettings.UseCustomLocationFile = (chbCustomLocation.Checked);
			if (chbCustomLocation.Checked)
			{
				NewSettings.CustomLocationFilePath = tbCustomLocationFile.Text;
			}
			else
			{
				NewSettings.CustomLocationFilePath = String.Empty;
			}

			NewSettings.UseCustomFileTableDB = (chbCustomFileTableDB.Checked);
			if (chbCustomFileTableDB.Checked)
			{
				NewSettings.CustomFileTableDBPath = tbCustomFileTableDBFile.Text;
			}
			else
			{
				NewSettings.CustomFileTableDBPath = String.Empty;
			}

			NewSettings.WrestlerNameFilePath = tbWrestlerNamesFile.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
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

		private void cbGameType_SelectedIndexChanged(object sender, EventArgs e)
		{
			// todo: something about choosing a different target platform than the current one and
			// telling people to close this damned thing and open it again to get the proper options
		}

		private void tbBaseROMPath_DragEnter(object sender, DragEventArgs e)
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

		private void tbBaseROMPath_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				tbBaseROMPath.Text = Path.GetFullPath(files[0]);
			}
		}
		#endregion

		#region Output ROM Tab (N64 games)
		/// <summary>
		/// Select output ROM path.
		/// </summary>
		private void buttonSetOutROM_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog()
			{
				Title = "Set Output ROM File Path",
				Filter = SharedStrings.FileFilter_N64Rom,
				CheckFileExists = false,
				OverwritePrompt = false
			};
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				tbBaseROMPath.Text = Path.GetFullPath(sfd.FileName);
			}
		}

		private void cbRegionCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbRegionCode.SelectedIndex < 0)
			{
				return;
			}

			// update region textbox
			if (cbRegionCode.SelectedIndex == cbRegionCode.Items.Count - 1)
			{
				tbRegionCode.ReadOnly = false;
				tbRegionCode.Text = "";
			}
			else
			{
				tbRegionCode.ReadOnly = true;
				tbRegionCode.Text = ((char)RegionList[cbRegionCode.SelectedIndex]).ToString();
			}
		}

		#endregion

		#region Output Data Tab (PS1 games)
		private void buttonSetInDataPath_Click(object sender, EventArgs e)
		{
			/*
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (Program.CurrentProject.Settings.InputDataPath != String.Empty)
			{
				fbd.SelectedPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.InputDataPath);
			}
			fbd.Description = "Select the Input Data directory.";
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				tbInDataPath.Text = Program.ShortenAbsolutePath(fbd.SelectedPath);
			}
			*/
		}

		private void buttonSetOutDataPath_Click(object sender, EventArgs e)
		{
			/*
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (Program.CurrentProject.Settings.OutputDataPath != String.Empty)
			{
				fbd.SelectedPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.OutputDataPath);
			}
			fbd.Description = "Select the Output Data directory.";
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				tbOutDataPath.Text = Program.ShortenAbsolutePath(fbd.SelectedPath);
			}
			*/
		}
		#endregion

		#region Project Files Tab
		private void buttonSetProjFilesPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (Program.CurrentProject.Settings.ProjectFilesPath != String.Empty)
			{
				fbd.SelectedPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath);
			}
			fbd.Description = "Select the Project Files directory.";
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				tbProjFilesPath.Text = Program.ShortenAbsolutePath(fbd.SelectedPath);
			}
		}

		private void buttonSetAssetFilesPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (Program.CurrentProject.Settings.AssetsPath != String.Empty)
			{
				fbd.SelectedPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.AssetsPath);
			}
			fbd.Description = "Select the Asset Files directory.";
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				tbAssetFilesPath.Text = Program.ShortenAbsolutePath(fbd.SelectedPath);
			}
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

		#region Drag and Drop
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
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
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
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				tbCustomFileTableDBFile.Text = Path.GetFullPath(files[0]);
			}
		}
		#endregion

		private void chbCustomFileTableDB_Click(object sender, EventArgs e)
		{
			buttonSetCustomFileTableDBFile.Enabled = chbCustomFileTableDB.Checked;
			tbCustomFileTableDBFile.Enabled = chbCustomFileTableDB.Checked;
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

		private void buttonSetWrestlerNameFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Wrestler Names File";
			ofd.Filter = SharedStrings.FileFilter_Text;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbWrestlerNamesFile.Text = ofd.FileName;
			}
		}
		#endregion
	}
}
