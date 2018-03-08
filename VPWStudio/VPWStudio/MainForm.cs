using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

		/// <summary>
		/// Hex Viewer form
		/// </summary>
		public HexViewer HexViewerForm = null;
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

		/// <summary>
		/// Build Log dialog
		/// </summary>
		public BuildLogDialog BuildLogForm = null;
		#endregion

		#region Game-Specific Editors

		#region World Tour
		#endregion

		#region VPW64
		#endregion

		#region Revenge
		/// <summary>
		/// WCW/nWo Revenge Costume and Mask/Head Editor
		/// </summary>
		public Editors.Revenge.CostumeDefs_Revenge CostumeDefs_Revenge = null;

		/// <summary>
		/// WCW/nWo Revenge Stable Editor
		/// </summary>
		public Editors.Revenge.StableDefs_Revenge StableDefs_Revenge = null;
		#endregion

		#region WM2K
		/// <summary>
		/// VPW2 Wrestler Editor, main form
		/// </summary>
		public Editors.WM2K.WrestlerMain_WM2K WrestlerMain_WM2K = null;
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

				if (MessageBox.Show(SharedStrings.UnsavedProject_ExitProgram, SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}
		#endregion

		#region Form Handling
		/// <summary>
		/// Request the use of the AkiTextDialog.
		/// </summary>
		/// <param name="fileID">File ID to load.</param>
		/// <param name="stringNum">(optional) String index to select.</param>
		public void RequestAkiTextDialog(int fileID, int stringNum = -1)
		{
			if (AkiTextEditor == null)
			{
				AkiTextEditor = new AkiTextDialog(fileID, stringNum);
				AkiTextEditor.MdiParent = this;
				AkiTextEditor.Show();
			}
			else
			{
				if (AkiTextEditor.IsDisposed)
				{
					AkiTextEditor = new AkiTextDialog(fileID, stringNum);
				}
				else
				{
					AkiTextEditor.RequestLoad(fileID, stringNum);
					AkiTextEditor.Focus();
				}
				AkiTextEditor.MdiParent = this;
				AkiTextEditor.Show();
				if (AkiTextEditor.WindowState == FormWindowState.Minimized)
				{
					AkiTextEditor.WindowState = FormWindowState.Normal;
				}
			}
		}
		
		/// <summary>
		/// Request the use of the HexViewerForm.
		/// </summary>
		/// <param name="fileID">File ID to load.</param>
		public void RequestHexViewer(int fileID)
		{
			if (HexViewerForm == null)
			{
				HexViewerForm = new HexViewer(fileID);
				HexViewerForm.MdiParent = this;
				HexViewerForm.Show();
			}
			else
			{
				if (HexViewerForm.IsDisposed)
				{
					HexViewerForm = new HexViewer(fileID);
				}
				else
				{
					HexViewerForm.RequestLoad(fileID);
					HexViewerForm.Focus();
				}
				HexViewerForm.MdiParent = this;
				HexViewerForm.Show();
				if (HexViewerForm.WindowState == FormWindowState.Minimized)
				{
					HexViewerForm.WindowState = FormWindowState.Normal;
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
				if (MessageBox.Show(SharedStrings.UnsavedProject_NewProject, SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				{
					return;
				}
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

				// set up internal game name and code
				MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
				BinaryReader br = new BinaryReader(ms);
				ms.Seek(0x20, SeekOrigin.Begin);
				byte[] gameName = br.ReadBytes(20);
				Program.CurrentProject.Settings.OutputRomInternalName = Encoding.GetEncoding("shift_jis").GetString(gameName, 0, 20);

				ms.Seek(0x3B, SeekOrigin.Begin);
				char[] gameCode = br.ReadChars(4);
				Program.CurrentProject.Settings.OutputRomGameCode = String.Format("{0}{1}{2}{3}", gameCode[0], gameCode[1], gameCode[2], gameCode[3]);
				br.Close();

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
					string lfn = GameInformation.GameDefs[Program.CurrentProject.Settings.GameType].GameCode + ".txt";
					string locPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\LocationFiles\\" + lfn;

					if (!File.Exists(locPath))
					{
						MessageBox.Show(
							String.Format("Location file {0} does not exist.", locPath),
							SharedStrings.MainForm_Title,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
						);
						Program.CurLocationFile = null;
					}
					else
					{
						Program.CurLocationFile = new LocationFile();
						Program.CurLocationFile.LoadFile(locPath);
						Program.CurLocationFilePath = locPath;
					}
				}

				// generate initial filelist
				if (Program.CurLocationFile != null)
				{
					// look for filetable entry
					LocationFileEntry ftEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["FileTable"]);
					if (ftEntry != null)
					{
						Program.CurrentProject.CreateProjectFileTable(ftEntry.Address, ftEntry.Width);
						Program.CurrentProject.ProjectFileTable.Location = ftEntry.Address;
					}
					else
					{
						// todo: this is blatantly copy/pasted from the fallback situation below.
						uint offset = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FileTable"].Offset;
						uint size = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FileTable"].Length;
						Program.CurrentProject.CreateProjectFileTable(offset, (int)size);
						Program.CurrentProject.ProjectFileTable.Location = offset;
					}

					// look for first file offset
					LocationFileEntry ffEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["FirstFile"]);
					if (ffEntry != null)
					{
						Program.CurrentProject.ProjectFileTable.FirstFile = ffEntry.Address;
					}
					else
					{
						Program.CurrentProject.ProjectFileTable.FirstFile = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FirstFile"].Offset;
					}
				}
				else
				{
					// use fallback
					uint offset = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FileTable"].Offset;
					uint size = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FileTable"].Length;
					Program.CurrentProject.CreateProjectFileTable(offset, (int)size);
					Program.CurrentProject.ProjectFileTable.Location = offset;
					Program.CurrentProject.ProjectFileTable.FirstFile = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FirstFile"].Offset;
				}

				// filelist part 2: load data from FileTableDB
				string ftdbPath = Program.GetFileTableDBPath();
				if (!ftdbPath.Equals(String.Empty) && File.Exists(ftdbPath))
				{
					FileTableDB ftdb = new FileTableDB(ftdbPath);
					foreach (KeyValuePair<UInt16, FileTableDBEntry> entry in ftdb.Entries)
					{
						Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].FileType = entry.Value.FileType;
						Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].Comment = entry.Value.Comment;
					}
				}

				// close any open dialogs
				foreach (Form f in this.MdiChildren)
				{
					f.Close();
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
				if (MessageBox.Show(SharedStrings.UnsavedProject_OpenProject, SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				{
					return;
				}
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

				// close any open dialogs
				foreach (Form f in this.MdiChildren)
				{
					f.Close();
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

			if (Program.CurrentProject.Settings.ProjectFilesPath == String.Empty)
			{
				// make new folder where the project file is being saved
				string projFilesDir = Path.GetDirectoryName(Program.CurProjectPath) + @"\ProjectFiles";
				Directory.CreateDirectory(projFilesDir);
				// set relative path
				Program.CurrentProject.Settings.ProjectFilesPath = "ProjectFiles";
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

				// todo: handle ProjectFiles folder

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
				if (MessageBox.Show(SharedStrings.UnsavedProject_CloseProject, SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				{
					return;
				}
			}

			Program.CurrentProject = null;
			Program.CurProjectPath = String.Empty;
			Program.UnsavedChanges = false;
			Program.CurLocationFile = null;
			Program.CurLocationFilePath = String.Empty;
			Program.CurrentInputROM = null;
			Program.CurrentOutputROM = null;

			// close any open dialogs
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
			else
			{
				ProjPropDialog.SetInitialTabPage();
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

					// close any open dialogs; they contain invalid data now
					foreach (Form f in this.MdiChildren)
					{
						f.Close();
					}

					// todo: probably have to reload filetable data.
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

		#region Project editor section
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

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.Revenge:
					if (CostumeDefs_Revenge == null)
					{
						CostumeDefs_Revenge = new Editors.Revenge.CostumeDefs_Revenge();
						CostumeDefs_Revenge.MdiParent = this;
						CostumeDefs_Revenge.Show();
					}
					else
					{
						if (CostumeDefs_Revenge.IsDisposed)
						{
							CostumeDefs_Revenge = new Editors.Revenge.CostumeDefs_Revenge();
						}
						if (CostumeDefs_Revenge.WindowState == FormWindowState.Minimized)
						{
							CostumeDefs_Revenge.WindowState = FormWindowState.Normal;
						}
						CostumeDefs_Revenge.MdiParent = this;
						CostumeDefs_Revenge.Show();
					}
					break;

				default:
					MessageBox.Show(String.Format("costumes dialog not yet designed for {0}", Program.CurrentProject.Settings.BaseGame));
					break;
			}
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

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.Revenge:
					if (StableDefs_Revenge == null)
					{
						StableDefs_Revenge = new Editors.Revenge.StableDefs_Revenge();
						StableDefs_Revenge.MdiParent = this;
						StableDefs_Revenge.Show();
					}
					else
					{
						if (StableDefs_Revenge.IsDisposed)
						{
							StableDefs_Revenge = new Editors.Revenge.StableDefs_Revenge();
						}
						if (StableDefs_Revenge.WindowState == FormWindowState.Minimized)
						{
							StableDefs_Revenge.WindowState = FormWindowState.Normal;
						}
						StableDefs_Revenge.MdiParent = this;
						StableDefs_Revenge.Show();
					}
					break;

				default:
					MessageBox.Show(String.Format("stables dialog not yet designed for {0}", Program.CurrentProject.Settings.BaseGame));
					break;
			}
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
		/// Weapon editor
		/// </summary>
		private void weaponsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			MessageBox.Show("weapons dialog not yet designed");
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
				case VPWGames.WM2K:
					if (this.WrestlerMain_WM2K == null)
					{
						this.WrestlerMain_WM2K = new Editors.WM2K.WrestlerMain_WM2K();
						this.WrestlerMain_WM2K.MdiParent = this;
						this.WrestlerMain_WM2K.Show();
					}
					else
					{
						if (this.WrestlerMain_WM2K.IsDisposed)
						{
							this.WrestlerMain_WM2K = new Editors.WM2K.WrestlerMain_WM2K();
						}
						// check for minimized
						if (this.WrestlerMain_WM2K.WindowState == FormWindowState.Minimized)
						{
							this.WrestlerMain_WM2K.WindowState = FormWindowState.Normal;
						}
						this.WrestlerMain_WM2K.MdiParent = this;
						this.WrestlerMain_WM2K.Show();
					}
					break;

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
		#endregion

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

			if (Program.CurrentInputROM == null)
			{
				// needs input ROM.
				return;
			}

			if (Program.CurrentProject.Settings.OutputRomPath == String.Empty)
			{
				// invalid output ROM path
				MessageBox.Show(
					"Output ROM path not set. Please set Output ROM path in Project Options.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			// perform "build" process
			// todo: the actual build process could probably be moved into Program.cs

			MessageBox.Show("This *KIND OF* works, but I'm not fully confident about it at the moment.");
			//return;

			if (BuildLogForm == null)
			{
				BuildLogForm = new BuildLogDialog();
			}
			else
			{
				if (BuildLogForm.IsDisposed)
				{
					BuildLogForm = new BuildLogDialog();
				}
			}
			BuildLogForm.MdiParent = this;
			BuildLogForm.Show();
			BuildLogForm.Clear();
			DateTime startTime = DateTime.Now;

			// copy the input ROM to the output ROM
			Program.CurrentOutputROM = new Z64Rom();
			// output ROM may be bigger than input ROM, so use a List.
			List<byte> outRomData = new List<byte>();
			outRomData.AddRange(Program.CurrentInputROM.Data);

			// make changes based on the project file contents

			#region Internal Game Name
			string intName = Program.CurrentProject.Settings.OutputRomInternalName;
			if (intName.Length > 20)
			{
				//  truncate
				intName = intName.Substring(0, 20);
			}
			else if (intName.Length < 20)
			{
				// pad
				intName = intName.PadRight(20);
			}

			byte[] nameBytes = Encoding.GetEncoding("Shift-JIS").GetBytes(intName);
			for (int i = 0; i < 20; i++)
			{
				outRomData[0x20 + i] = nameBytes[i];
			}

			BuildLogForm.AddLine(String.Format("Internal Game Name: {0}", Program.CurrentProject.Settings.OutputRomInternalName));
			#endregion

			#region Product/Game Code
			// - game code
			string intCode = Program.CurrentProject.Settings.OutputRomGameCode;
			if (intCode.Length != 4)
			{
				// error
			}
			if (!intCode.StartsWith("N"))
			{
				// not error, but fix
			}
			#endregion

			#region FileTable
			// General FileTable tasks:
			// 1) change the offsets for files after the index
			// 2) insert file data
			// todo: it's a bit more complicated than this.

			// Work on a copy of the filetable. If you don't do this, the
			// Project FileTable will get changed, and reading data from the
			// Input ROM becomes somewhat impossible once you start changing items.
			FileTable buildFileTable = new FileTable();
			buildFileTable.DeepCopy(Program.CurrentProject.ProjectFileTable);

			// The total difference from all of the changed files.

			// In Zoinkity's original offsetter code, files are added one at a time,
			// with all relevant code addresses (e.g. WaveTables, PointerTables)
			// being updated on each change.

			// Here, we're remaking the entire FileTable at once,
			// saving the necessary code changes for later.
			int totalDifference = 0;

			// (File IDs start at 0x0001, and Entries is a SortedList with the file ID as Key.)
			for (int i = 1; i < buildFileTable.Entries.Count; i++)
			{
				FileTableEntry fte = buildFileTable.Entries[i];
				if (fte.ReplaceFilePath != String.Empty)
				{
					int start = (int)fte.Location;
					int end = (int)buildFileTable.Entries[i + 1].Location;

					// try loading file data
					string replaceFilePath = String.Empty;
					if (!Path.IsPathRooted(fte.ReplaceFilePath))
					{
						// relative path, harder
						// The base is Path.GetDirectoryName(Program.CurProjectPath)
						replaceFilePath = String.Format("{0}\\{1}", Path.GetDirectoryName(Program.CurProjectPath), fte.ReplaceFilePath);

						// This is typically going to be in the ProjectFiles or Assets directories.
						// Anything in ProjectFiles is either raw data or pre-LZSS'd data.

						// The Assets directory is for files that get converted to other types.
						// (PNG to TEX (AkiTexture), PNG to CI4/CI8 Texture, JASC PAL to CI4/CI8 Palette, etc.)
					}
					else
					{
						// absolute path, easy
						replaceFilePath = fte.ReplaceFilePath;
					}

					// check if the file exists.
					// If it doesn't, we're going to have a hard time replacing data.
					if (!File.Exists(replaceFilePath))
					{
						BuildLogForm.AddLine(String.Format("Error attempting to open '{0}'", replaceFilePath));
						continue;
					}

					// another general todo for this section:
					// if converting a file from the Assets folder, the current
					// type of the file being replaced is infinitely helpful to know.

					FileStream curFileFS = new FileStream(replaceFilePath, FileMode.Open);
					BinaryReader curFileBR = new BinaryReader(curFileFS);

					MemoryStream outDataMS = new MemoryStream();
					BinaryWriter outDataBW = new BinaryWriter(outDataMS);

					curFileBR.BaseStream.Seek(0, SeekOrigin.End);
					int fileLen = (int)curFileBR.BaseStream.Position;
					curFileBR.BaseStream.Seek(0, SeekOrigin.Begin);

					// determine if we need to compress this.
					// todo: take into account existing slot's encoding
					switch (fte.ReplaceEncoding)
					{
						case FileTableReplaceEncoding.ForceRaw:
							// force raw
							outDataBW.Write(curFileBR.ReadBytes(fileLen));
							break;

						case FileTableReplaceEncoding.ForceLzss:
							// force LZSS
							AsmikLzss.Encode(curFileBR, outDataBW);
							break;

						case FileTableReplaceEncoding.PickBest:
						default:
							// pick best fit... ugh
							break;
					}

					curFileBR.Close();
					curFileFS.Close();

					// perform alignment if needed
					if ((fileLen & 1) != 0)
					{
						outDataBW.Write((byte)0);
					}

					// if successful, calculate difference
					int diff = fileLen - (end - start);
					totalDifference += diff;

					BuildLogForm.AddText(String.Format("[File {0:X4}] ", fte.FileID));
					string sizeCompareChar = "";

					if (fileLen > (end - start))
					{
						sizeCompareChar = "<";
					}
					else if (fileLen < (end - start))
					{
						sizeCompareChar = ">";
					}
					else
					{
						sizeCompareChar = "=";
					}
					BuildLogForm.AddLine(
						String.Format("old size = {0} {1} new size = {2}",
						(end - start),
						sizeCompareChar,
						fileLen
						)
					);

					// todo: handle a possible situation where the new file is smaller than the older one.

					// update future filetable indices
					for (int u = fte.FileID + 1; u < buildFileTable.Entries.Count; u++)
					{
						buildFileTable.Entries[u].Location += (uint)diff;
					}

					// add data to ROM
					outDataBW.BaseStream.Seek(0, SeekOrigin.Begin);
					for (int d = 0; d < fileLen; d++)
					{
						outRomData[(int)(d + buildFileTable.FirstFile + fte.Location)] = (byte)outDataBW.BaseStream.ReadByte();
					}

					// not sure if I need this, but...
					// if the new file is smaller than the older one, fill the gap between
					// the end of the new data and the end of the old data with 0x00.

					// in the future, you might want to move the other files upwards to
					// take advantage of the space, but that's a bit complicated for now.
					if (diff < 0)
					{
						for (int dx = 0; dx < ((end - start) - fileLen); dx++)
						{
							outRomData[(int)(buildFileTable.FirstFile + fte.Location + fileLen + dx)] = 0;
						}
					}

					outDataBW.Close();
				}
			}

			// todo: maybe you should consider re-writing the FileTable huh freem
			// oh and be advised that it IS possible for the FileTable position (and size) to change.
			#endregion

			// - other junk

			// if adding/removing files (you madman),
			// update the relevant parts of the game code.

			// fix up soundtable references

			#region Create Output ROM
			// determine if the new output ROM is too big to run on console
			if (outRomData.Count >= 0x4000000)
			{
				MessageBox.Show(
					"This ROM exceeds 512Mbits and *will not* run on console.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
			}

			// write outRomData to Program.CurrentOutputROM.Data
			Program.CurrentOutputROM.Data = outRomData.ToArray();

			// fix checksums
			Program.CurrentOutputROM.FixChecksums();

			// determine output ROM path (may be relative to project file)
			string outRomPath = Program.CurrentProject.Settings.OutputRomPath;
			string prevWorkDir = Environment.CurrentDirectory;
			bool resetWorkDir = false;
			if (!Path.IsPathRooted(outRomPath))
			{
				Environment.CurrentDirectory = Path.GetDirectoryName(Program.CurProjectPath);
				resetWorkDir = true;
			}

			// write ROM
			FileStream outRomFS = new FileStream(outRomPath, FileMode.Create);
			BinaryWriter outRomBW = new BinaryWriter(outRomFS);
			outRomBW.Write(Program.CurrentOutputROM.Data);
			outRomBW.Flush();
			outRomBW.Dispose();

			TimeSpan buildTimeTaken = (DateTime.Now - startTime);
			BuildLogForm.AddLine(
				String.Format("Successfully built '{0}' in {1} (min:sec.ms)",
					outRomPath,
					buildTimeTaken.ToString(@"mm\:ss\.fffff")
				)
			);
			BuildLogForm.BuildFinished = true;

			if (resetWorkDir)
			{
				Environment.CurrentDirectory = prevWorkDir;
			}
			#endregion
		}

		/// <summary>
		/// Play ROM
		/// </summary>
		private void playROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// todo: use the output rom instead of input

			// no project loaded to play ROM of
			if (Program.CurrentProject == null)
			{
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
			if (Properties.Settings.Default.EmulatorPath.Equals(String.Empty))
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

			// check that emulator exists
			if (!File.Exists(Properties.Settings.Default.EmulatorPath))
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

			// check if output ROM exists
			string romPath = String.Empty;
			if (!Path.IsPathRooted(Program.CurrentProject.Settings.OutputRomPath))
			{
				// relative to project file
				romPath = String.Format("{0}\\{1}", Path.GetDirectoryName(Program.CurProjectPath), Program.CurrentProject.Settings.OutputRomPath);
			}
			else
			{
				// absolute
				romPath = Program.CurrentProject.Settings.OutputRomPath;
			}

			if (!File.Exists(romPath))
			{
				// output ROM does not exist
				// technically, we should build in this situation.
				MessageBox.Show(
					"Output ROM does not exist.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			// todo: rebuild output rom if needed

			System.Diagnostics.Process.Start(
				Properties.Settings.Default.EmulatorPath,
				romPath
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
		/// Ooh! I pressed the F1 key!
		/// </summary>
		private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			manualToolStripMenuItem_Click(sender, hlpevent);
		}

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
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select file to LZSS";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream inStr = new FileStream(ofd.FileName, FileMode.Open);
				BinaryReader br = new BinaryReader(inStr);
				FileStream outStr = new FileStream("comp.lzss", FileMode.Create);
				BinaryWriter bw = new BinaryWriter(outStr);

				AsmikLzss.Encode(br, bw);

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

		private void toki1Testvpw2OnlyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Toki1TestDialog t1td = new Toki1TestDialog();
			t1td.ShowDialog();
		}

		private void pngTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Convert PNG to TEX";
			ofd.Filter = "PNG files (*.png)|*.png|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Bitmap b = new Bitmap(ofd.FileName);
				if (b.PixelFormat == PixelFormat.Format8bppIndexed ||
					b.PixelFormat == PixelFormat.Format4bppIndexed)
				{
					AkiTexture test = new AkiTexture();
					test.FromBitmap(b);
					FileStream fs = new FileStream("test.tex", FileMode.Create);
					BinaryWriter bw = new BinaryWriter(fs);
					test.WriteData(bw);
					bw.Close();
					fs.Close();
				}
				else if (b.PixelFormat == PixelFormat.Format32bppArgb)
				{
					MessageBox.Show(
						"Images with transparency are not properly handled at the moment.",
						SharedStrings.MainForm_Title,
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
					// dealing with a transparent image, which is possibly paletted.
					HashSet<Color> usedColors = new HashSet<Color>();
					UInt16 alphaColor = 0;
					// xxx: this could be done with LockBits but eh, I'm lazy as fuck.
					for (int y = 0; y < b.Height; y++)
					{
						for (int x = 0; x < b.Width; x++)
						{
							Color c = b.GetPixel(x, y);
							if (c.A == 0)
							{
								alphaColor = N64Colors.ColorToValue5551(c);
							}

							if (usedColors.Contains(c))
								continue;

							usedColors.Add(c);
						}
					}

					AkiTexture test = new AkiTexture();
					Bitmap converted;
					// xxx: this conversion sucks
					if (usedColors.Count <= 16)
					{
						// ci4
						converted = b.Clone(new Rectangle(0, 0, b.Width, b.Height), PixelFormat.Format4bppIndexed);
					}
					else
					{
						// assume ci8
						converted = b.Clone(new Rectangle(0, 0, b.Width, b.Height), PixelFormat.Format8bppIndexed);

					}
					test.FromBitmap(converted);

					// find the alpha color and kill its alpha bit
					for (int i = 0; i < test.Palette.Length; i++)
					{
						UInt16 thisColor = test.Palette[i];
						if ((thisColor & 0xFFFE) == alphaColor)
						{
							test.Palette[i] &= 0xFFFE;
						}
					}

					FileStream fs = new FileStream("test.tex", FileMode.Create);
					BinaryWriter bw = new BinaryWriter(fs);
					test.WriteData(bw);
					bw.Close();
					fs.Close();
				}
				else
				{
					MessageBox.Show(
						String.Format("Unsupported PixelFormat {0}", b.PixelFormat),
						SharedStrings.MainForm_Title,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
				}
			}
		}
		#endregion
	}
}
