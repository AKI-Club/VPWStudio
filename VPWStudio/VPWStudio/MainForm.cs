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
	public partial class MainForm : Form
	{
		#region Children Forms

		#region Project Forms
		/// <summary>
		/// Project Properties form
		/// </summary>
		public ProjectPropertiesDialog ProjPropDialog = null;

		/// <summary>
		/// Wrestler Edit dialog
		/// </summary>
		public WrestlerEditMain WresEditDialog = null;
		#endregion

		#region Tool Forms
		/// <summary>
		/// Model Tool form
		/// </summary>
		public ModelTool ModelToolForm = null;

		/// <summary>
		/// Packed File Tool form
		/// </summary>
		public PackedFileTool PackFileTool = null;

		/// <summary>
		/// GameShark Tool form
		/// </summary>
		public GameSharkTool GSTool = null;
		#endregion

		/// <summary>
		/// Program options dialog
		/// </summary>
		public ProgramOptionsDialog ProgOptionsDialog = null;
		#endregion

		public MainForm(string[] args)
		{
			InitializeComponent();

			if (args.Length > 0)
			{
				// passed in command line arguments... probably a project file.
			}

			UpdateValidMenus();
		}

		#region Program Exit Routines
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Program.CurrentProject != null && Program.UnsavedChanges)
			{
				// todo: seriously what the fuck do I need to do here?
				// is it "exit without saving?" "save changes before exiting?"

				// omg do you want to save the changes first
				if (MessageBox.Show("There are unsaved project changes.\n\nDo you want to discard the changes and exit?", SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}
		#endregion

		#region File Menu Items
		/// <summary>
		/// New Project
		/// </summary>
		private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject != null && Program.UnsavedChanges)
			{
				// ask if it's ok to make a new project without saving changes to the current one.
			}

			NewProjectDialog npd = new NewProjectDialog();
			if (npd.ShowDialog() == DialogResult.OK)
			{
				// set up new project based on data given
				Program.CurrentProject = new ProjectFile();
				Program.CurrentProject.Settings.DeepCopy(npd.NewSettings);
				// todo: set base game in the dialogs instead of here
				Program.CurrentProject.Settings.BaseGame = GameInformation.GameDefs[Program.CurrentProject.Settings.GameType].BaseGame;

				Program.CurProjectPath = String.Empty; // unsaved file
				Program.UnsavedChanges = true;
				UpdateValidMenus();
				UpdateStatusBar();
				UpdateTitleBar();

				// load ROM
				Program.CurrentInputROM = new Z64Rom();
				Program.CurrentInputROM.LoadFile(Program.CurrentProject.Settings.InputRomPath);

				if (Program.CurrentProject.Settings.UseCustomLocationFile)
				{
					// load custom location file
					Program.CurLocationFile = new LocationFile();
					Program.CurLocationFile.LoadFile(Program.CurrentProject.Settings.CustomLocationFilePath);
					Program.CurLocationFilePath = Program.CurrentProject.Settings.CustomLocationFilePath;
				}
				else
				{
					// load location file based on game name
					Program.CurLocationFile = new LocationFile();
					string lfn = GameInformation.GameDefs[Program.CurrentProject.Settings.GameType].GameCode + ".txt";
					string locPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\LocationFiles\\" + lfn;
					Program.CurLocationFile.LoadFile(locPath);
					Program.CurLocationFilePath = locPath;
				}
			}
		}

		/// <summary>
		/// Open Project
		/// </summary>
		private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject != null && Program.UnsavedChanges)
			{
				// there are unsaved changes. discard and open new project file?
			}

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open VPW Studio Project File";
			ofd.Filter = SharedStrings.FileFilter_Project;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Program.CurrentProject = new ProjectFile();
				Program.CurrentProject.LoadFile(ofd.FileName);
				Program.CurProjectPath = ofd.FileName;
				Program.UnsavedChanges = false;
				UpdateValidMenus();
				UpdateStatusBar();
				UpdateTitleBar();

				// load input ROM if it exists.
				if (File.Exists(Program.CurrentProject.Settings.InputRomPath))
				{
					Program.CurrentInputROM = new Z64Rom();
					Program.CurrentInputROM.LoadFile(Program.CurrentProject.Settings.InputRomPath);
				}
				else
				{
					// unable to find input ROM, please see project settings.
					MessageBox.Show(
						String.Format("Unable to load Input ROM file {0}.\nPlease set the Input ROM Path in the Project Settings.", Program.CurrentProject.Settings.InputRomPath),
						SharedStrings.MainForm_Title,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
					Program.CurrentInputROM = null;
				}

				// load location file
				Program.CurLocationFile = new LocationFile();
				if (Program.CurrentProject.Settings.UseCustomLocationFile)
				{
					// custom locations
					Program.CurLocationFile.LoadFile(Program.CurrentProject.Settings.CustomLocationFilePath);
					Program.CurLocationFilePath = Program.CurrentProject.Settings.CustomLocationFilePath;
				}
				else
				{
					// default location file
					string lfn = GameInformation.GameDefs[Program.CurrentProject.Settings.GameType].GameCode + ".txt";
					string locPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\LocationFiles\\" + lfn;
					Program.CurLocationFile.LoadFile(locPath);
					Program.CurLocationFilePath = locPath;
				}
			}
		}

		/// <summary>
		/// Save Project
		/// </summary>
		private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			// check if this is a new project that hasn't been saved yet
			if (Program.CurProjectPath == String.Empty)
			{
				// set the project path
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Save VPW Studio Project File";
				sfd.Filter = SharedStrings.FileFilter_Project;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					Program.CurProjectPath = sfd.FileName;
					UpdateStatusBar();
				}
			}

			// do the actual saving
			Program.CurrentProject.SaveFile(Program.CurProjectPath);
			Program.UnsavedChanges = false;
			UpdateTitleBar();
		}

		/// <summary>
		/// Save Project As
		/// </summary>
		private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			// always ask for save path
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save VPW Studio Project File";
			sfd.Filter = SharedStrings.FileFilter_Project;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				// in case someone decides to do "Save As" first...
				if (Program.CurProjectPath.Equals(String.Empty))
				{
					Program.CurProjectPath = sfd.FileName;
				}

				// hack to unset UnsavedChanges if saving over the existing file.
				if (Path.GetFullPath(sfd.FileName).Equals(Program.CurProjectPath))
				{
					Program.UnsavedChanges = false;
					UpdateTitleBar();
				}

				// write to specified file
				Program.CurrentProject.SaveFile(sfd.FileName);
			}
		}

		/// <summary>
		/// Close current project.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// can't close something that isn't there...
			if (Program.CurrentProject == null)
			{
				return;
			}

			if (Program.CurrentProject != null && Program.UnsavedChanges)
			{
				// omg do you want to save the changes first
			}

			Program.CurrentProject = null;
			Program.CurProjectPath = String.Empty;
			Program.UnsavedChanges = false;
			Program.CurLocationFile = null;
			Program.CurLocationFilePath = String.Empty;
			Program.CurrentInputROM = null;
			Program.CurrentOutputROM = null;

			UpdateTitleBar();
			UpdateValidMenus();
			UpdateStatusBar();
		}
		#endregion

		#region Project Menu Items
		/// <summary>
		/// Project Properties
		/// </summary>
		private void projectPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			if (this.ProjPropDialog == null)
			{
				this.ProjPropDialog = new ProjectPropertiesDialog();
			}

			if (this.ProjPropDialog.ShowDialog() == DialogResult.OK)
			{
				string oldInRomPath = Program.CurrentProject.Settings.InputRomPath;

				Program.CurrentProject.Settings.DeepCopy(this.ProjPropDialog.NewSettings);
				Program.UnsavedChanges = true;

				// check to see if Input ROM was changed
				if (Program.CurrentInputROM == null)
				{
					if (Program.CurrentProject.Settings.InputRomPath != oldInRomPath)
					{
						// attempt to load
						if (File.Exists(Program.CurrentProject.Settings.InputRomPath))
						{
							Program.CurrentInputROM = new Z64Rom();
							Program.CurrentInputROM.LoadFile(Program.CurrentProject.Settings.InputRomPath);
						}
						else
						{
							MessageBox.Show(
								String.Format("Unable to load Input ROM file {0}.\nPlease set the Input ROM Path in the Project Settings.", Program.CurrentProject.Settings.InputRomPath),
								SharedStrings.MainForm_Title,
								MessageBoxButtons.OK,
								MessageBoxIcon.Error
							);
						}
					}
				}

				UpdateTitleBar();
				UpdateStatusBar();
			}
		}

		private void arenasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// arena dialog not yet designed
		}

		private void fileTableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// filetable dialog not yet designed
		}

		private void movesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// moves dialog not yet designed
		}

		private void stablesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// stables dialog not yet designed
		}

		private void wrestlersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			if (this.WresEditDialog == null)
			{
				this.WresEditDialog = new WrestlerEditMain();
				this.WresEditDialog.MdiParent = this;
				this.WresEditDialog.Show();
			}
			else
			{
				if (this.WresEditDialog.IsDisposed)
				{
					this.WresEditDialog = new WrestlerEditMain();
				}
				// if it was minimized, show it again.
				if (this.WresEditDialog.WindowState == FormWindowState.Minimized)
				{
					this.WresEditDialog.WindowState = FormWindowState.Normal;
				}
				this.WresEditDialog.MdiParent = this;
				this.WresEditDialog.Show();
			}
			
		}

		#region Project build section
		private void buildROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				// no project loaded to build ROM for
				return;
			}

			// todo: check if output rom path is a valid one

			// perform "build" process
		}

		private void playROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				// no project loaded to play ROM of
				// todo: allow launching the emulator (alone) anyways?
				MessageBox.Show(
					SharedStrings.PlayRomError_NoProjectLoaded,
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			// playing ROM depends on program options
			if (VPWStudio.Properties.Settings.Default.EmulatorPath.Equals(String.Empty))
			{
				// must set emulator path
				MessageBox.Show(
					SharedStrings.PlayRomError_EmuPathNotSet,
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			if (!File.Exists(VPWStudio.Properties.Settings.Default.EmulatorPath))
			{
				// invalid emulator path
				MessageBox.Show(
					SharedStrings.PlayRomError_EmuPathNotExist,
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			// todo: rebuild before loading?

			System.Diagnostics.Process.Start(
				VPWStudio.Properties.Settings.Default.EmulatorPath,
				Program.CurrentProject.Settings.InputRomPath
			);
		}
		#endregion

		#endregion

		#region Tool Menu Items
		private void programOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ProgOptionsDialog == null)
			{
				this.ProgOptionsDialog = new ProgramOptionsDialog();
			}

			if (this.ProgOptionsDialog.ShowDialog() == DialogResult.OK)
			{
				VPWStudio.Properties.Settings.Default.EmulatorPath = this.ProgOptionsDialog.EmulatorPath;
				VPWStudio.Properties.Settings.Default.Save();
			}
		}

		/// <summary>
		/// Model Data
		/// </summary>
		private void modelDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ModelToolForm == null)
			{
				this.ModelToolForm = new ModelTool();
				this.ModelToolForm.MdiParent = this;
				this.ModelToolForm.Show();
			}
			else
			{
				if (this.ModelToolForm.IsDisposed)
				{
					this.ModelToolForm = new ModelTool();
				}

				// if it was minimized, show it again.
				if (this.ModelToolForm.WindowState == FormWindowState.Minimized)
				{
					this.ModelToolForm.WindowState = FormWindowState.Normal;
				}
				this.ModelToolForm.MdiParent = this;
				this.ModelToolForm.Show();
			}
		}

		/// <summary>
		/// Packed File
		/// </summary>
		private void packedFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.PackFileTool == null)
			{
				this.PackFileTool = new PackedFileTool();
				this.PackFileTool.MdiParent = this;
				this.PackFileTool.Show();
			}
			else
			{
				if (this.PackFileTool.IsDisposed)
				{
					this.PackFileTool = new PackedFileTool();
				}

				// if it was minimized, show it again.
				if (this.PackFileTool.WindowState == FormWindowState.Minimized)
				{
					this.PackFileTool.WindowState = FormWindowState.Normal;
				}
				this.ModelToolForm.MdiParent = this;
				this.ModelToolForm.Show();
			}
		}

		/// <summary>
		/// GameShark Code Tool
		/// </summary>
		/// currently a little broken, but not the form's fault...?
		private void sharkTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.GSTool == null)
			{
				this.GSTool = new GameSharkTool();
				this.GSTool.MdiParent = this;
				this.GSTool.Show();
			}
			else
			{
				if (this.GSTool.IsDisposed)
				{
					this.GSTool = new GameSharkTool();
				}

				// if it was minimized, show it again.
				if (this.GSTool.WindowState == FormWindowState.Minimized)
				{
					this.GSTool.WindowState = FormWindowState.Normal;
				}
				this.GSTool.MdiParent = this;
				this.GSTool.Show();
			}
		}
		#endregion

		#region Help Menu Items
		private void aboutVPWStudioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// temporary thing
			MessageBox.Show(
				String.Format("VPW Studio (indev version {0}) by freem", Application.ProductVersion),
				SharedStrings.MainForm_Title,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}
		#endregion

		#region Interface Update Routines
		/// <summary>
		/// Update the title bar caption based on the current project status.
		/// </summary>
		private void UpdateTitleBar()
		{
			string titleBar = String.Format("{0}", SharedStrings.MainForm_Title);

			if (Program.CurrentProject != null)
			{
				titleBar += String.Format(" - {0}{1}",
					Program.CurrentProject.Settings.ProjectName,
					Program.UnsavedChanges ? "*" : ""
				);
			}

			this.Text = titleBar;
		}

		private void UpdateValidMenus()
		{
			bool projFileOpen = (Program.CurrentProject != null);

			// File menu
			saveProjectToolStripMenuItem.Enabled = projFileOpen;
			saveProjectAsToolStripMenuItem.Enabled = projFileOpen;
			closeProjectToolStripMenuItem.Enabled = projFileOpen;

			// Project menu
			projectPropertiesToolStripMenuItem.Enabled = projFileOpen;
			arenasToolStripMenuItem.Enabled = projFileOpen;
			costumesToolStripMenuItem.Enabled = projFileOpen;
			fileTableToolStripMenuItem.Enabled = projFileOpen;
			movesToolStripMenuItem.Enabled = projFileOpen;
			stablesToolStripMenuItem.Enabled = projFileOpen;
			wrestlersToolStripMenuItem.Enabled = projFileOpen;
			buildROMToolStripMenuItem.Enabled = projFileOpen;
			playROMToolStripMenuItem.Enabled = projFileOpen;
		}

		/// <summary>
		/// Updates the status bar file label.
		/// </summary>
		private void UpdateStatusBar()
		{
			if (Program.CurrentProject == null)
			{
				tssLabelCurFile.Text = "No project file opened.";
				tssLabelGameType.Text = String.Empty;
				tssLabelGameType.Visible = false;
				tssLabelGameType.Image = null;
			}
			else
			{
				if (Program.CurProjectPath == String.Empty)
				{
					tssLabelCurFile.Text = "(New unsaved project)";
				}
				else
				{
					tssLabelCurFile.Text = Program.CurProjectPath;
				}
				tssLabelGameType.Text = GameInformation.GetSpecificGameName(Program.CurrentProject.Settings.GameType);
				tssLabelGameType.Visible = true;
				tssLabelGameType.Image = GetGameIcon_16px();
			}
		}
		#endregion


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private Bitmap GetGameIcon_16px()
		{
			if (Program.CurrentProject == null)
			{
				return null;
			}

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.WorldTour: return VPWStudio.Properties.Resources.GameIcon16_WorldTour;
				case VPWGames.VPW64: return VPWStudio.Properties.Resources.GameIcon16_VPW64;
				case VPWGames.Revenge: return VPWStudio.Properties.Resources.GameIcon16_Revenge;
				case VPWGames.WM2K: return VPWStudio.Properties.Resources.GameIcon16_WM2K;
				case VPWGames.VPW2: return VPWStudio.Properties.Resources.GameIcon16_VPW2;
				case VPWGames.NoMercy: return VPWStudio.Properties.Resources.GameIcon16_NoMercy;
				default:
					return null;
			}
		}

		private void asmikLzssTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select file to LZSS";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream inStr = new FileStream(ofd.FileName, FileMode.Open);
				BinaryReader br = new BinaryReader(inStr);
				FileStream outStr = new FileStream("comp.lzss", FileMode.Create);
				BinaryWriter bw = new BinaryWriter(outStr);

				TestLzss.Compress(br, bw);

				bw.Flush();
				bw.Close();
				br.Close();
			}
		}

		private void lzssDecompressTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select LZSS file to decompress";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream inStr = new FileStream(ofd.FileName, FileMode.Open);
				BinaryReader br = new BinaryReader(inStr);
				FileStream outStr = new FileStream("decomp.bin", FileMode.Create);
				BinaryWriter bw = new BinaryWriter(outStr);

				AsmikLzss.Decode(br, bw);

				bw.Flush();
				bw.Close();
				br.Close();
			}
		}

	}
}
