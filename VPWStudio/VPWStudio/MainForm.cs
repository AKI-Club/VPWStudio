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
	public partial class MainForm : Form
	{
		#region Children Forms

		#region Project Forms
		/// <summary>
		/// Project Properties form
		/// </summary>
		public ProjectPropertiesDialog ProjPropDialog = null;

		/// <summary>
		/// File Table dialog
		/// </summary>
		public FileTableDialog FileTableEditor = null;

		/// <summary>
		/// AkiText dialog
		/// </summary>
		public AkiTextDialog AkiTextEditor = null;
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

		#region Program-related Forms
		/// <summary>
		/// Program options dialog
		/// </summary>
		public ProgramOptionsDialog ProgOptionsDialog = null;

		/// <summary>
		/// About box
		/// </summary>
		public AboutBox AboutVPWStudio = null;
		#endregion

		#region Game-Specific Editors

		#region World Tour
		#endregion

		#region VPW64
		#endregion

		#region Revenge
		#endregion

		#region WM2K
		#endregion

		#region VPW2
		/// <summary>
		/// VPW2 Wrestler Editor, main form
		/// </summary>
		public Editors.VPW2.WrestlerMain_VPW2 WrestlerMain_VPW2 = null;
		#endregion

		#region No Mercy
		/// <summary>
		/// No Mercy Wrestler Editor, main form
		/// </summary>
		public Editors.NoMercy.WrestlerMain_NoMercy WrestlerMain_NoMercy = null;
		#endregion

		#endregion

		#endregion // children forms

		public MainForm(string[] args)
		{
			InitializeComponent();

			if (args.Length > 0)
			{
				// passed in command line arguments... probably a project file.
				LoadProject(args[0]);
			}

			UpdateTitleBar();
			UpdateValidMenus();
			UpdateStatusBar();
		}

		#region Project Load/Save
		/// <summary>
		/// Load the project file from the specified path.
		/// </summary>
		/// <param name="_path"></param>
		public void LoadProject(string _path)
		{
			Program.CurrentProject = new ProjectFile();
			Program.CurrentProject.LoadFile(_path);
			Program.CurProjectPath = _path;
		}
		#endregion

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
				Program.CurProjectPath = String.Empty; // unsaved file
				Program.UnsavedChanges = true;
				UpdateValidMenus();
				UpdateStatusBar();
				UpdateTitleBar();
				UpdateBackground();

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
				LoadProject(ofd.FileName);
				Program.UnsavedChanges = false;
				UpdateValidMenus();
				UpdateStatusBar();
				UpdateTitleBar();
				UpdateBackground();

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

			// todo: close any open dialogs
			foreach (Form f in this.MdiChildren)
			{
				f.Close();
			}

			UpdateTitleBar();
			UpdateValidMenus();
			UpdateStatusBar();
			UpdateWindowMenus();
			UpdateBackground();
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

			if (ProjPropDialog == null)
			{
				ProjPropDialog = new ProjectPropertiesDialog();
			}

			if (ProjPropDialog.ShowDialog() == DialogResult.OK)
			{
				// check to see if project game type was changed
				bool updateBG = false;
				if (Program.CurrentProject.Settings.GameType != this.ProjPropDialog.NewSettings.GameType)
				{
					updateBG = true;
					// invalidate project data
					Program.CurrentProject.ProjectFileTable = new FileTable();
				}

				string oldInRomPath = Program.CurrentProject.Settings.InputRomPath;

				Program.CurrentProject.Settings.DeepCopy(ProjPropDialog.NewSettings);
				Program.UnsavedChanges = true;

				if (updateBG)
				{
					UpdateBackground();
				}

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

		/// <summary>
		/// Arena editor
		/// </summary>
		private void arenasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("arena dialog not yet designed");
		}

		/// <summary>
		/// Championship editor
		/// </summary>
		/// This is also the Story Mode editor for:
		/// * WCW vs. nWo World Tour
		/// * Virtual Pro-Wrestling 64
		/// * WCW/nWo Revenge
		/// 
		/// In WM2K and VPW2, it allows you to edit the possible belt choices.
		/// In No Mercy, it allows you to edit the belts themselves.
		private void championshipsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("championships dialog not yet designed");
		}

		/// <summary>
		/// Costume editor
		/// </summary>
		private void costumesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("costumes dialog not yet designed");
		}

		/// <summary>
		/// File table editor
		/// </summary>
		private void fileTableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			if (FileTableEditor == null)
			{
				FileTableEditor = new FileTableDialog();
				FileTableEditor.MdiParent = this;
				FileTableEditor.Show();
				UpdateWindowMenus();
			}
			else
			{
				if (FileTableEditor.IsDisposed)
				{
					FileTableEditor = new FileTableDialog();
				}
				// if it was minimized, show it again.
				if (FileTableEditor.WindowState == FormWindowState.Minimized)
				{
					FileTableEditor.WindowState = FormWindowState.Normal;
				}
				FileTableEditor.MdiParent = this;
				FileTableEditor.Show();
				UpdateWindowMenus();
			}
		}

		/// <summary>
		/// Menu editor
		/// </summary>
		private void menusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("menu dialog not yet designed");
		}

		/// <summary>
		/// Move editor
		/// </summary>
		private void movesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("moves dialog not yet designed");
		}

		/// <summary>
		/// Sounds editor
		/// </summary>
		private void soundsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("sounds dialog not yet designed");
		}

		/// <summary>
		/// Stables editor
		/// </summary>
		private void stablesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("stables dialog not yet designed");
		}

		/// <summary>
		/// Story Mode editor (WM2K, VPW2, and No Mercy only)
		/// </summary>
		private void storyModeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("story mode dialogs not yet designed");
		}

		/// <summary>
		/// AkiText editor (and maybe some in-ROM strings too.)
		/// </summary>
		private void textArchivesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			// todo: world tour and vpw64 may need special handling?
			if (AkiTextEditor == null)
			{
				AkiTextEditor = new AkiTextDialog();
				AkiTextEditor.MdiParent = this;
				AkiTextEditor.Show();
			}
			else
			{
				if (AkiTextEditor.IsDisposed)
				{
					AkiTextEditor = new AkiTextDialog();
				}
				if (AkiTextEditor.WindowState == FormWindowState.Minimized)
				{
					AkiTextEditor.WindowState = FormWindowState.Normal;
				}
				AkiTextEditor.MdiParent = this;
				AkiTextEditor.Show();
				UpdateWindowMenus();
			}
		}

		/// <summary>
		/// Wrestler editor
		/// </summary>
		private void wrestlersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.VPW2:
					if (this.WrestlerMain_VPW2 == null)
					{
						this.WrestlerMain_VPW2 = new Editors.VPW2.WrestlerMain_VPW2();
						this.WrestlerMain_VPW2.MdiParent = this;
						this.WrestlerMain_VPW2.Show();
						UpdateWindowMenus();
					}
					else
					{
						if (this.WrestlerMain_VPW2.IsDisposed)
						{
							this.WrestlerMain_VPW2 = new Editors.VPW2.WrestlerMain_VPW2();
						}
						// check for minimized
						if (this.WrestlerMain_VPW2.WindowState == FormWindowState.Minimized)
						{
							this.WrestlerMain_VPW2.WindowState = FormWindowState.Normal;
						}
						this.WrestlerMain_VPW2.MdiParent = this;
						this.WrestlerMain_VPW2.Show();
						UpdateWindowMenus();
					}
					break;

				case VPWGames.NoMercy:
					if (this.WrestlerMain_NoMercy == null)
					{
						this.WrestlerMain_NoMercy = new Editors.NoMercy.WrestlerMain_NoMercy();
						this.WrestlerMain_NoMercy.MdiParent = this;
						this.WrestlerMain_NoMercy.Show();
						UpdateWindowMenus();
					}
					else
					{
						if (this.WrestlerMain_NoMercy.IsDisposed)
						{
							this.WrestlerMain_NoMercy = new Editors.NoMercy.WrestlerMain_NoMercy();
						}
						// check for minimized
						if (this.WrestlerMain_NoMercy.WindowState == FormWindowState.Minimized)
						{
							this.WrestlerMain_NoMercy.WindowState = FormWindowState.Normal;
						}
						this.WrestlerMain_NoMercy.MdiParent = this;
						this.WrestlerMain_NoMercy.Show();
						UpdateWindowMenus();
					}
					break;

				default:
					MessageBox.Show(String.Format("wrestler definition editor not implemented for {0} yet", Program.CurrentProject.Settings.BaseGame.ToString()));
					break;
			}
		}

		#region Project build section
		/// <summary>
		/// Build ROM
		/// </summary>
		private void buildROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				// no project loaded to build ROM for
				return;
			}

			MessageBox.Show("doesn't do anything yet");

			// todo: check if output rom path is a valid one

			// perform "build" process
		}

		/// <summary>
		/// Play ROM
		/// </summary>
		private void playROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// todo: use the output rom instead of input

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

			// todo: rebuild output rom if needed

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
				UpdateWindowMenus();
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
				UpdateWindowMenus();
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
				UpdateWindowMenus();
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
				this.PackFileTool.MdiParent = this;
				this.PackFileTool.Show();
				UpdateWindowMenus();
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
				UpdateWindowMenus();
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
				UpdateWindowMenus();
			}
		}
		#endregion

		#region Window Menu Items
		private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form f in this.MdiChildren)
			{
				f.Close();
			}
			UpdateWindowMenus();
		}
		#endregion

		#region Help Menu Items
		/// <summary>
		/// eventually this will launch the manual.
		/// but there is none right now.
		/// </summary>
		private void manualToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("I can't yell at you to read the manual because it doesn't exist yet. it also won't exist for a while because this program is THAT early into development.");
		}

		/// <summary>
		/// About
		/// </summary>
		private void aboutVPWStudioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//AboutVPWStudio
			if (this.AboutVPWStudio == null)
			{
				this.AboutVPWStudio = new AboutBox();
				this.AboutVPWStudio.ShowDialog();
			}
			else
			{
				if (this.AboutVPWStudio.IsDisposed)
				{
					this.AboutVPWStudio = new AboutBox();
				}
				this.AboutVPWStudio.ShowDialog();
			}
		}
		#endregion

		#region Interface Update Routines
		/// <summary>
		/// Prevent the background image from getting removed
		/// </summary>
		private void MainForm_Resize(object sender, EventArgs e)
		{
			UpdateBackground();
		}

		/// <summary>
		/// Update the title bar caption based on the current project status.
		/// </summary>
		public void UpdateTitleBar()
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

		/// <summary>
		/// Update valid menus based on the current project status.
		/// </summary>
		private void UpdateValidMenus()
		{
			bool projFileOpen = (Program.CurrentProject != null);

			// File menu
			saveProjectToolStripMenuItem.Enabled = projFileOpen;
			saveProjectAsToolStripMenuItem.Enabled = projFileOpen;
			closeProjectToolStripMenuItem.Enabled = projFileOpen;

			// Project menu
			foreach (ToolStripItem tsi in projectToolStripMenuItem.DropDownItems)
			{
				if (tsi.GetType() == typeof(ToolStripMenuItem))
				{
					tsi.Enabled = projFileOpen;
				}
			}

			// special case for Story Mode
			if (Program.CurrentProject != null)
			{
				VPWGames bg = Program.CurrentProject.Settings.BaseGame;
				bool showStoryMode = (bg == VPWGames.WM2K || bg == VPWGames.VPW2 || bg == VPWGames.NoMercy);
				storyModeToolStripMenuItem.Enabled = showStoryMode;
				storyModeToolStripMenuItem.Visible = showStoryMode;
				switch (bg)
				{
					case VPWGames.WM2K:
					case VPWGames.VPW2:
						storyModeToolStripMenuItem.Image = VPWStudio.Properties.Resources.MenuIcon16_Story_WM2K_VPW2;
						break;
					case VPWGames.NoMercy:
						storyModeToolStripMenuItem.Image = VPWStudio.Properties.Resources.MenuIcon16_Story_NoMercy;
						break;
					default:
						storyModeToolStripMenuItem.Image = null;
						break;
				}
			}

			UpdateWindowMenus();
		}

		/// <summary>
		/// Updates the Window menu.
		/// </summary>
		private void UpdateWindowMenus()
		{
			bool anyWindowsOpen = this.MdiChildren.Length > 0;
			cascadeToolStripMenuItem.Enabled = anyWindowsOpen;
			tileHorizontallyToolStripMenuItem.Enabled = anyWindowsOpen;
			tileVerticallyToolStripMenuItem.Enabled = anyWindowsOpen;
			closeAllToolStripMenuItem.Enabled = anyWindowsOpen;
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

		/// <summary>
		/// Update the main menu background.
		/// </summary>
		private void UpdateBackground()
		{
			this.BackgroundImage = GetMainMenuBG();
		}
		#endregion


		#region Various Helpers
		/// <summary>
		/// Get the 16px game icon for the current project's base game.
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

		/// <summary>
		/// Get the background for the main form based on the current project's base game.
		/// </summary>
		/// <returns></returns>
		private Bitmap GetMainMenuBG()
		{
			if (Program.CurrentProject == null)
			{
				return null;
			}

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.WorldTour: return VPWStudio.Properties.Resources.MainMenuBG_WorldTour;
				case VPWGames.VPW64: return VPWStudio.Properties.Resources.MainMenuBG_VPW64;
				case VPWGames.Revenge: return VPWStudio.Properties.Resources.MainMenuBG_Revenge;
				case VPWGames.WM2K: return VPWStudio.Properties.Resources.MainMenuBG_WM2K;
				case VPWGames.VPW2: return VPWStudio.Properties.Resources.MainMenuBG_VPW2;
				case VPWGames.NoMercy: return VPWStudio.Properties.Resources.MainMenuBG_NoMercy;
				default:
					return null;
			}
		}
		#endregion

		#region Danger Zone items
		// items in this section are short lived.
		// I just wanted a better place to put them.

		private void asmikLzssTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("this thing SUUUUUUUUUCKS, don't use it.\n\nwait until I finish the better lzss");

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

		private void akiTextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AkiTextTool att = new AkiTextTool();
			att.ShowDialog();
		}

		private void nameEncoderdecoderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NameEncodeDecodeTool nedTool = new NameEncodeDecodeTool();
			nedTool.ShowDialog();
		}
		#endregion

	}
}
