using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.Editors;

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
		/// Hex Viewer form
		/// </summary>
		public HexViewer HexViewerForm = null;

		#region Danger Zone Tool Forms
		public Tools.TextIndexTool TextIndexDecoder = null;
		#endregion
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

		/// <summary>
		/// Costume and Mask/Head Editor for early VPW games
		/// </summary>
		public Editors.CostumeDefs_Early CostumeDefs_Early = null;

		/// <summary>
		/// Game introduction editor for Revenge and later.
		/// </summary>
		public GameIntroEditor_Later GameIntroEditor_Later = null;

		/// <summary>
		/// Stable Editor for WCW vs. nWo World Tour and Virtual Pro-Wrestling 64
		/// </summary>
		public Editors.StableDefs_Early StableDefs_Early = null;

		/// <summary>
		/// Wrestler Editor, main form for WCW vs. nWo World Tour and Virtual Pro-Wrestling 64
		/// </summary>
		public Editors.WrestlerMain_Early WrestlerMain_Early = null;

		/// <summary>
		/// Championship definition editor, for WCW vs. nWo World Tour and Virtual Pro-Wrestling 64
		/// </summary>
		public Editors.ChampionshipDefs_Early ChampDefs_Early = null;

		#region World Tour
		#endregion

		#region VPW64
		/// <summary>
		/// Game introduction editor for VPW64.
		/// </summary>
		public Editors.VPW64.GameIntroEditor_VPW64 GameIntroEditor_VPW64 = null;
		#endregion

		#region Revenge
		/// <summary>
		/// WCW/nWo Revenge Championship Editor
		/// </summary>
		public Editors.Revenge.ChampionshipDefs_Revenge ChampDefs_Revenge = null;

		/// <summary>
		/// WCW/nWo Revenge Stable Editor
		/// </summary>
		public Editors.Revenge.StableDefs_Revenge StableDefs_Revenge = null;

		/// <summary>
		/// Revenge Wrestler Editor, main form
		/// </summary>
		public Editors.Revenge.WrestlerMain_Revenge WrestlerMain_Revenge = null;

		/// <summary>
		/// WCW/nWo Revenge Costume and Mask/Head Editor
		/// </summary>
		public Editors.Revenge.CostumeDefs_Revenge CostumeDefs_Revenge = null;
		#endregion

		#region WM2K
		/// <summary>
		/// WM2K Wrestler Editor, main form
		/// </summary>
		public Editors.WM2K.WrestlerMain_WM2K WrestlerMain_WM2K = null;

		/// <summary>
		/// WM2K Stable Editor
		/// </summary>
		public Editors.WM2K.StableDefs_WM2K StableDefs_WM2K = null;

		/// <summary>
		/// WM2K Tag Team Editor
		/// </summary>
		public Editors.WM2K.TagTeams_WM2K TagTeams_WM2K = null;
		#endregion

		#region VPW2
		/// <summary>
		/// VPW2 Wrestler Editor, main form
		/// </summary>
		public Editors.VPW2.WrestlerMain_VPW2 WrestlerMain_VPW2 = null;

		/// <summary>
		/// VPW2 Stable Editor
		/// </summary>
		public Editors.VPW2.StableDefs_VPW2 StableDefs_VPW2 = null;

		/// <summary>
		/// VPW2 Costume Editor
		/// </summary>
		public Editors.VPW2.CostumeDefs_VPW2 CostumeDefs_VPW2 = null;
		#endregion

		#region No Mercy
		/// <summary>
		/// No Mercy Wrestler Editor, main form
		/// </summary>
		public Editors.NoMercy.WrestlerMain_NoMercy WrestlerMain_NoMercy = null;

		/// <summary>
		/// No Mercy Stable Editor
		/// </summary>
		public Editors.NoMercy.StableDefs_NoMercy StableDefs_NoMercy = null;
		#endregion

		#endregion

		#region Danger Zone
		public NameEncodeDecodeTool nedTool = null;

		public Toki1TestDialog Toki1Test = null;

		public MoveDamageTestDialog MoveDamageTest = null;

		public TestScene3D Test3dDialog = null;

		public StringRenderTest RenderStringTest = null;

		public ClientTest NetClientTest = null;
		#endregion

		#endregion // children forms

		public MainForm(string[] args)
		{
			InitializeComponent();

			// settings check
			if (Properties.Settings.Default.GetPreviousVersion("ForceUpgrade") == null)
			{
				Properties.Settings.Default.ForceUpgrade = true;
			}
			if (Properties.Settings.Default.ForceUpgrade)
			{
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.Reload();
				Properties.Settings.Default.ForceUpgrade = false;
				Properties.Settings.Default.Save();
			}

			if (args.Length > 0)
			{
				// passed in command line arguments... probably a project file.
				if (Path.GetExtension(args[0]) == ".vpwsproj")
				{
					LoadProject(args[0]);

					// update working directory to project path
					Environment.CurrentDirectory = Path.GetDirectoryName(Program.CurProjectPath);
				}
				else
				{
					Program.ErrorMessageBox(String.Format("{0} does not appear to be a VPW Studio Project File.",args[0]));
				}
			}

			UpdateTitleBar();
			UpdateValidMenus();
			UpdateStatusBar();
		}

		#region Project Load/Save
		/// <summary>
		/// Load LocationFile. Does not show errors if the file(s) do not exist.
		/// </summary>
		private void LoadLocationFile()
		{
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

				// xxx: hacks for WWF No Mercy prototypes
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.NoMercy_Proto_NTSC_June2000: lfn = "NoMercy_June2000.txt"; break;
					case SpecificGame.NoMercy_Proto_NTSC_July2000: lfn = "NoMercy_Jul2000.txt"; break;
					case SpecificGame.NoMercy_Proto_NTSC_August2000: lfn = "NoMercy_Aug2000.txt"; break;
					case SpecificGame.NoMercy_Proto_NTSC_September2000: lfn = "NoMercy_Sep2000.txt"; break;
				}

				string locPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\LocationFiles\\" + lfn;
				Program.CurLocationFile.LoadFile(locPath);
				Program.CurLocationFilePath = locPath;
			}
		}

		/// <summary>
		/// Load the project file from the specified path.
		/// </summary>
		/// <param name="_path">Path to VPW Studio Project File to load.</param>
		public void LoadProject(string _path)
		{
			Program.CurrentProject = new ProjectFile(_path);
			Program.CurProjectPath = _path;
			Program.UnsavedChanges = false;

			// allow for relative paths
			string baseRomPath = Program.CurrentProject.Settings.InputRomPath;
			if (!Path.IsPathRooted(baseRomPath))
			{
				baseRomPath = String.Format("{0}\\{1}", Path.GetDirectoryName(_path), baseRomPath);
			}

			// load input ROM if it exists.
			if (File.Exists(baseRomPath))
			{
				Program.CurrentInputROM = new Z64Rom();
				Program.CurrentInputROM.LoadFile(baseRomPath);
			}
			else
			{
				// unable to find input ROM, please see project settings.
				MessageBox.Show(
					String.Format("Unable to load Input ROM file {0}.\nPlease set the Input ROM Path in the Project Settings.", baseRomPath),
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				Program.CurrentInputROM = null;
			}

			LoadLocationFile();

			// if a custom location file is being used and the filetable's
			// location doesn't match the value in the custom location file,
			// change it.
			if (Program.CurrentProject.Settings.UseCustomLocationFile && Program.CurrentProject.ProjectFileTable != null)
			{
				LocationFileEntry ftLoc = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["FileTable"]);
				if (ftLoc != null)
				{
					if (Program.CurrentProject.ProjectFileTable.Location != ftLoc.Address)
					{
						Program.CurrentProject.ProjectFileTable.Location = ftLoc.Address;
						Program.WarningMessageBox("The project's FileTable location differs from the value in the custom location file.\nUpdating the project's FileTable location now. Please save changes.");
						Program.UnsavedChanges = true;
						UpdateTitleBar();
					}
				}
			}

			playROMToolStripMenuItem.Enabled = true;
			playROMToolStripMenuItem.Visible = true;
		}

		#region Drag and Drop
		/// <summary>
		/// Drag and Drop, Drag portion.
		/// </summary>
		private void MainForm_DragEnter(object sender, DragEventArgs e)
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

		/// <summary>
		/// Drag and Drop, Drop portion.
		/// </summary>
		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (files.Length > 1)
				{
					Program.WarningMessageBox("More than one file dragged, only opening the first.");
				}

				// this check should probably be more robust
				if (Path.GetExtension(files[0]) != ".vpwsproj")
				{
					Program.ErrorMessageBox(String.Format("{0} does not appear to be a VPW Studio Project File.", files[0]));
					return;
				}

				if (Program.CurrentProject != null && Program.UnsavedChanges)
				{
					// there are unsaved changes. discard and open new project file?
					if (MessageBox.Show(SharedStrings.UnsavedProject_OpenProject, SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
					{
						return;
					}
				}

				LoadProject(files[0]);
				// update active directory to dragged in project file's location
				Environment.CurrentDirectory = Path.GetDirectoryName(files[0]);

				UpdateTitleBar();
				UpdateValidMenus();
				UpdateStatusBar();
				UpdateBackground();
			}
		}
		#endregion

		#endregion

		#region Program Exit Routines
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// todo: handle closing while Program.RomBuildActive is true

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
		/// Request a HexViewerForm using a FileTable entry.
		/// </summary>
		/// <param name="fileID">File ID to load.</param>
		public void RequestHexViewer(int fileID)
		{
			HexViewer newHV = Program.HexViewManager.NewViewerFileTable(fileID);
			newHV.MdiParent = this;
			newHV.Show();
			newHV.BringToFront();
			if (newHV.WindowState == FormWindowState.Minimized)
			{
				newHV.WindowState = FormWindowState.Normal;
			}
		}

		/// <summary>
		/// Request a HexViewerForm using data passed in.
		/// </summary>
		/// <param name="data">Data to view in HexViewer.</param>
		public void RequestHexViewer(byte[] data, string title = "")
		{
			HexViewer newHV = Program.HexViewManager.NewViewerData(data, title);
			newHV.MdiParent = this;
			newHV.Show();
			newHV.BringToFront();
			if (newHV.WindowState == FormWindowState.Minimized)
			{
				newHV.WindowState = FormWindowState.Normal;
			}
		}

		public void RequestHexViewer(string filePath, string title = "")
		{
			HexViewer newHV = Program.HexViewManager.HexViewerExternalFile(filePath, title);
			newHV.MdiParent = this;
			newHV.Show();
			newHV.BringToFront();
			if (newHV.WindowState == FormWindowState.Minimized)
			{
				newHV.WindowState = FormWindowState.Normal;
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

				// xxx hack: Prototype versions of games can have 0x00-filled name data, which makes the XML parser choke
				// for whatever reason when reading it back.
				if (gameName[0] == 0)
				{
					Program.CurrentProject.Settings.OutputRomInternalName = String.Empty;
				}
				else
				{
					Program.CurrentProject.Settings.OutputRomInternalName = Encoding.GetEncoding("shift_jis").GetString(gameName, 0, 20);
				}

				// assume first letter at 0x3B is 'N'
				ms.Seek(0x3E, SeekOrigin.Begin);
				char gameRegion = br.ReadChar();
				br.Close();

				Program.CurrentProject.Settings.OutputRomCustomRegion = gameRegion;

				bool foundRegion = false;
				foreach (GameRegion gr in Enum.GetValues(typeof(GameRegion)))
				{
					if (gameRegion == (char)gr)
					{
						foundRegion = true;
						Program.CurrentProject.Settings.OutputRomRegion = gr;
						break;
					}
				}
				if (!foundRegion)
				{
					Program.CurrentProject.Settings.OutputRomRegion = GameRegion.Custom;
				}

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

					// xxx hack for WWF No Mercy prototypes
					switch (Program.CurrentProject.Settings.GameType)
					{
						case SpecificGame.NoMercy_Proto_NTSC_June2000:      lfn = "NoMercy_June2000.txt"; break;
						case SpecificGame.NoMercy_Proto_NTSC_July2000:      lfn = "NoMercy_Jul2000.txt"; break;
						case SpecificGame.NoMercy_Proto_NTSC_August2000:    lfn = "NoMercy_Aug2000.txt"; break;
						case SpecificGame.NoMercy_Proto_NTSC_September2000: lfn = "NoMercy_Sep2000.txt"; break;
					}

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
						Program.CurrentProject.CreateProjectFileTable(ftEntry.Address, ftEntry.Length);
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

					if (ftdb.ErrorList.Count > 0)
					{
						StringBuilder sb = new StringBuilder();
						foreach (string error in ftdb.ErrorList)
						{
							sb.AppendLine(error);
						}
						Program.ErrorMessageBox("Error doing something or other:\n"+sb.ToString());
					}

					foreach (KeyValuePair<UInt16, FileTableDBEntry> entry in ftdb.Entries)
					{
						int fileID = entry.Value.FileID;
						Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType = entry.Value.FileType;
						Program.CurrentProject.ProjectFileTable.Entries[fileID].Comment = entry.Value.Comment;

						if (entry.Value.ExtraData != null)
						{
							if (entry.Value.ExtraData != string.Empty)
							{
								Program.CurrentProject.ProjectFileTable.Entries[fileID].ParseExtraDataString(entry.Value.ExtraData);
							}
						}
					}
				}

				// filelist part 3: load data from ArchiveFileDB
				if (Program.CurrentProject.Settings.BaseGame >= VPWGames.Revenge)
				{
					if (!Program.GetArchiveFileDBPath().Equals(String.Empty))
					{
						Program.AkiArchiveFileDB = new ArchiveFileDB(Program.GetArchiveFileDBPath());
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

				// load data from ArchiveFileDB
				if (Program.CurrentProject.Settings.BaseGame >= VPWGames.Revenge)
				{
					if (!Program.GetArchiveFileDBPath().Equals(String.Empty))
					{
						Program.AkiArchiveFileDB = new ArchiveFileDB(Program.GetArchiveFileDBPath());
					}
				}

				/*
				#region Upgrade fixing
				// Game Code and Region
				// In Pre-Alpha Preview 6, the Game Code changed from 4 characters (NxxR) to 2 (xx).
				// Game Region was added to the Project File, and needs to be calculated from the previous game code.
				if (Program.CurrentProject.Settings.OutputRomGameCode.Length == 4)
				{
					string oldCode = Program.CurrentProject.Settings.OutputRomGameCode;
					Program.CurrentProject.Settings.OutputRomGameCode = oldCode.Substring(1, 2);

					// determine region
					bool customRegion = true;
					char oldRegion = oldCode[3];
					foreach (GameRegion gr in Enum.GetValues(typeof(GameRegion)))
					{
						if ((char)gr == oldRegion)
						{
							customRegion = false;
							Program.CurrentProject.Settings.OutputRomRegion = gr;
							break;
						}
					}

					if (customRegion)
					{
						Program.CurrentProject.Settings.OutputRomRegion = GameRegion.Custom;
						Program.CurrentProject.Settings.OutputRomCustomRegion = oldRegion;
					}
					Program.UnsavedChanges = true;
				}
				#endregion
				*/

				UpdateValidMenus();
				UpdateStatusBar();
				UpdateTitleBar();
				UpdateBackground();

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
				else
				{
					// they hit cancel; don't do anything below
					return;
				}
			}

			// Create new directories where the project is being saved,
			// and set relative paths in the project file.
			string projPath = Path.GetDirectoryName(Program.CurProjectPath);
			if (Program.CurrentProject.Settings.ProjectFilesPath == String.Empty)
			{
				Directory.CreateDirectory(projPath + @"\ProjectFiles");
				Program.CurrentProject.Settings.ProjectFilesPath = "ProjectFiles";
			}
			if (Program.CurrentProject.Settings.AssetsPath == String.Empty)
			{
				Directory.CreateDirectory(projPath + @"\Assets");
				Program.CurrentProject.Settings.AssetsPath = "Assets";
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

					// todo: handle ProjectFiles and Assets directories?
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
			Program.AkiArchiveFileDB = null;

			// close any open dialogs
			foreach (Form f in MdiChildren)
			{
				f.Close();
			}

			UpdateTitleBar();
			UpdateValidMenus();
			UpdateStatusBar();
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

			ProjPropDialog = new ProjectPropertiesDialog();

			if (ProjPropDialog.ShowDialog() == DialogResult.OK)
			{
				// check to see if project game type was changed
				bool updateBG = false;
				if (Program.CurrentProject.Settings.GameType != ProjPropDialog.NewSettings.GameType)
				{
					updateBG = true;
					// invalidate project data
					Program.CurrentProject.ProjectFileTable = new FileTable();

					// close any open dialogs; they contain invalid data now
					foreach (Form f in MdiChildren)
					{
						f.Close();
					}

					// reload locationfile, since the game type changed
					LoadLocationFile();

					// reload filetable data
					string ftdbPath = Program.GetFileTableDBPath();
					if (!ftdbPath.Equals(String.Empty) && File.Exists(ftdbPath))
					{
						FileTableDB ftdb = new FileTableDB(ftdbPath);

						if (ftdb.ErrorList.Count > 0)
						{
							StringBuilder sb = new StringBuilder();
							foreach (string error in ftdb.ErrorList)
							{
								sb.AppendLine(error);
							}
							Program.ErrorMessageBox(sb.ToString());
						}

						foreach (KeyValuePair<UInt16, FileTableDBEntry> entry in ftdb.Entries)
						{
							FileTableEntry fte = new FileTableEntry
							{
								FileID = entry.Value.FileID,
								FileType = entry.Value.FileType,
								Comment = entry.Value.Comment
							};
							Program.CurrentProject.ProjectFileTable.Entries.Add(entry.Value.FileID, fte);
						}
					}

					// reload ArchiveFileDB
					if (Program.CurrentProject.Settings.BaseGame >= VPWGames.Revenge)
					{
						if (!Program.GetArchiveFileDBPath().Equals(String.Empty))
						{
							Program.AkiArchiveFileDB = new ArchiveFileDB(Program.GetArchiveFileDBPath());
						}
					}

					// update valid menus, since they can change per game
					UpdateValidMenus();
				}

				string oldInRomPath = Program.CurrentProject.Settings.InputRomPath;

				Program.CurrentProject.Settings.DeepCopy(ProjPropDialog.NewSettings);
				Program.UnsavedChanges = true;

				if (updateBG)
				{
					UpdateBackground();
				}

				// check to see if Input ROM was changed
				if (Program.CurrentProject.Settings.InputRomPath != oldInRomPath)
				{
					// attempt to load
					string baseRomPath = Program.CurrentProject.Settings.InputRomPath;
					if (!Path.IsPathRooted(baseRomPath))
					{
						baseRomPath = String.Format("{0}\\{1}", Path.GetDirectoryName(Program.CurProjectPath), baseRomPath);
					}

					if (File.Exists(baseRomPath))
					{
						Program.CurrentInputROM = new Z64Rom();
						Program.CurrentInputROM.LoadFile(baseRomPath);
					}
					else
					{
						Program.ErrorMessageBox(String.Format("Unable to load Input ROM file {0}.\nPlease set the Input ROM Path in the Project Settings.", baseRomPath));
					}
				}

				// todo: check to see if custom location file is being used (filetable edit)

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

			Program.ErrorMessageBox("The Arena dialog has not been designed or implemented.\nUnless you are a programmer, you can not fix this.");
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

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.WorldTour:
				case VPWGames.VPW64:
					{
						if (ChampDefs_Early == null || ChampDefs_Early.IsDisposed)
						{
							ChampDefs_Early = new ChampionshipDefs_Early();
						}
						if (ChampDefs_Early.WindowState == FormWindowState.Minimized)
						{
							ChampDefs_Early.WindowState = FormWindowState.Normal;
						}
						ChampDefs_Early.MdiParent = this;
						ChampDefs_Early.Show();
					}
					break;

				case VPWGames.Revenge:
					{
						if (ChampDefs_Revenge == null || ChampDefs_Revenge.IsDisposed)
						{
							ChampDefs_Revenge = new Editors.Revenge.ChampionshipDefs_Revenge();
						}
						if (ChampDefs_Revenge.WindowState == FormWindowState.Minimized)
						{
							ChampDefs_Revenge.WindowState = FormWindowState.Normal;
						}
						ChampDefs_Revenge.MdiParent = this;
						ChampDefs_Revenge.Show();
					}
					break;

				default:
					Program.ErrorMessageBox("Championships dialog not yet designed for this game.\nUnless you are a programmer, you can not fix this.");
					break;
			}
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
				// Early VPW games
				case VPWGames.WorldTour:
				case VPWGames.VPW64:
					if (CostumeDefs_Early == null || CostumeDefs_Early.IsDisposed)
					{
						CostumeDefs_Early = new Editors.CostumeDefs_Early();
					}
					if (CostumeDefs_Early.WindowState == FormWindowState.Minimized)
					{
						CostumeDefs_Early.WindowState = FormWindowState.Normal;
					}
					CostumeDefs_Early.MdiParent = this;
					CostumeDefs_Early.Show();
					break;

				case VPWGames.Revenge:
					if (CostumeDefs_Revenge == null || CostumeDefs_Revenge.IsDisposed)
					{
						CostumeDefs_Revenge = new Editors.Revenge.CostumeDefs_Revenge();
					}
					if (CostumeDefs_Revenge.WindowState == FormWindowState.Minimized)
					{
						CostumeDefs_Revenge.WindowState = FormWindowState.Normal;
					}
					CostumeDefs_Revenge.MdiParent = this;
					CostumeDefs_Revenge.Show();
					break;

				// WIP shite
				case VPWGames.VPW2:
					// xxx: shift key is a hack so I can keep developing the form without needing to keep commenting and un-commenting it out
					if (ModifierKeys.HasFlag(Keys.Shift))
					{
						if (CostumeDefs_VPW2 == null || CostumeDefs_VPW2.IsDisposed)
						{
							CostumeDefs_VPW2 = new Editors.VPW2.CostumeDefs_VPW2();
						}
						if (CostumeDefs_VPW2.WindowState == FormWindowState.Minimized)
						{
							CostumeDefs_VPW2.WindowState = FormWindowState.Normal;
						}
						CostumeDefs_VPW2.MdiParent = this;
						CostumeDefs_VPW2.Show();
					}
					else
					{
						Program.ErrorMessageBox("VPW2 costumes dialog is not complete");
					}
					
					break;

				default:
					Program.ErrorMessageBox(String.Format("Costumes dialog not yet designed for {0}.\nUnless you are a programmer, you can not fix this.", Program.CurrentProject.Settings.BaseGame));
					break;
			}
		}

		private void demoMatchesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.VPW2:
					{
						Editors.VPW2.DemoMatch_VPW2 demoMatchEd = new Editors.VPW2.DemoMatch_VPW2();
						if (demoMatchEd.ShowDialog() == DialogResult.OK)
						{
							Program.ErrorMessageBox("Data does not get saved yet, sorry\nUnless you are a programmer, you can not fix this.");
						}
					}
					break;

				case VPWGames.NoMercy:
					{
						Editors.NoMercy.DemoMatch_NoMercy demoMatchEd = new Editors.NoMercy.DemoMatch_NoMercy();
						if (demoMatchEd.ShowDialog() == DialogResult.OK)
						{
							Program.ErrorMessageBox("Data does not get saved yet, sorry\nUnless you are a programmer, you can not fix this.");
						}
					}
					break;

				default:
					Program.ErrorMessageBox("Demo match locations for games before VPW2 may not even exist... The data has yet to be found, in any case.\nUnless you are a programmer, you can not fix this.");
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

			if (FileTableEditor == null || FileTableEditor.IsDisposed)
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
		}

		// until the intro data format(s) are found for WorldTour and VPW64, this stays:
		private static List<VPWGames> IntroEditorSupported = new List<VPWGames>{
			VPWGames.VPW64,
			VPWGames.Revenge,
			VPWGames.WM2K,
			VPWGames.VPW2,
			VPWGames.NoMercy
		};

		/// <summary>
		/// Game intro editor
		/// </summary>
		private void gameIntroductionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			if (!IntroEditorSupported.Contains(Program.CurrentProject.Settings.BaseGame))
			{
				MessageBox.Show("Game Intro Editor only \"works\" for Revenge and later.\nUnless you are a programmer, you can not fix this.", "Game Intro Editor");
				return;
			}

			if (Program.CurrentProject.Settings.BaseGame == VPWGames.VPW64)
			{
				// specifically vpw64
				//
				if (GameIntroEditor_VPW64 == null || GameIntroEditor_VPW64.IsDisposed)
				{
					GameIntroEditor_VPW64 = new Editors.VPW64.GameIntroEditor_VPW64();
				}

				if (GameIntroEditor_VPW64.ShowDialog() == DialogResult.OK)
				{
					// update intro data
					// ...wait a minute, there's currently no OK or Cancel buttons on this form!
					Program.ErrorMessageBox("Editing/writeback not implemented yet\nUnless you are a programmer, you can not fix this.");
				}
			}
			else
			{
				// assume Revenge or later
				if (GameIntroEditor_Later == null || GameIntroEditor_Later.IsDisposed)
				{
					GameIntroEditor_Later = new GameIntroEditor_Later();
				}

				if (GameIntroEditor_Later.ShowDialog() == DialogResult.OK)
				{
					// update intro data
					Program.ErrorMessageBox("Editing/writeback not implemented yet\nUnless you are a programmer, you can not fix this.");
				}
			}
		}

		private void matchRulesetsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.WM2K:
					{
						Editors.WM2K.Ruleset_WM2K rules = new Editors.WM2K.Ruleset_WM2K();
						if (rules.ShowDialog() == DialogResult.OK)
						{
							Program.ErrorMessageBox("Data does not get saved yet, sorry\nUnless you are a programmer, you can not fix this.");
						}
					}
					break;

				case VPWGames.VPW2:
					{
						Editors.VPW2.Ruleset_VPW2 rules = new Editors.VPW2.Ruleset_VPW2();
						if (rules.ShowDialog() == DialogResult.OK)
						{
							Program.ErrorMessageBox("Data does not get saved yet, sorry\nUnless you are a programmer, you can not fix this.");
						}
					}
					break;

				case VPWGames.NoMercy:
					{
						Editors.NoMercy.Ruleset_NoMercy rules = new Editors.NoMercy.Ruleset_NoMercy();
						if (rules.ShowDialog() == DialogResult.OK)
						{
							Program.ErrorMessageBox("Data does not get saved yet, sorry\nUnless you are a programmer, you can not fix this.");
						}
					}
					break;

				default:
					Program.ErrorMessageBox(String.Format("Ruleset data needs to be found (or re-found) for {0}.\nUnless you are a programmer, you can not fix this.", Program.CurrentProject.Settings.BaseGame));
					break;
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

			Program.ErrorMessageBox("Menu dialog not yet designed.\nUnless you are a programmer, you can not fix this.");
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

			Program.ErrorMessageBox("Moves dialog not yet designed.\nConsidering that moves consist of many parts, this is going to take a while.\nUnless you are a programmer, you can not fix this.");
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

			Program.ErrorMessageBox("Sound/Music dialog not yet designed.\nUnless you are a programmer, you can not fix this.");
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
				case VPWGames.WorldTour:
				case VPWGames.VPW64:
					{
						if (StableDefs_Early == null || StableDefs_Early.IsDisposed)
						{
							StableDefs_Early = new Editors.StableDefs_Early();
						}

						if (StableDefs_Early.ShowDialog() == DialogResult.OK)
						{
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save Stable Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							// check if StableDef file exists.
							string stableDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath);
							bool writePath = false;

							if (!File.Exists(stableDefPath))
							{
								stableDefPath = Program.ConvertRelativePath(@"ProjectFiles\StableDefs.txt");
								writePath = true;
							}

							FileStream fs = new FileStream(stableDefPath, FileMode.OpenOrCreate);
							StreamWriter sw = new StreamWriter(fs);
							StableDefFile sdefs = new StableDefFile(Program.CurrentProject.Settings.BaseGame);
							sdefs.StableDefs_Early = StableDefs_Early.StableDefs;
							sdefs.WriteFile(sw);
							sw.Close();

							if (writePath)
							{
								Program.CurrentProject.Settings.StableDefinitionFilePath = stableDefPath;
								Program.UnsavedChanges = true;
								UpdateTitleBar();
								Program.InfoMessageBox(String.Format("Wrote new Stable Definition file to {0}.", Program.ShortenAbsolutePath(stableDefPath)));
							}
						}

						// manually kill this dialog to prevent issues when switching between World Tour and VPW64 projects
						StableDefs_Early = null;
					}
					break;

				case VPWGames.Revenge:
					{
						if (StableDefs_Revenge == null || StableDefs_Revenge.IsDisposed)
						{
							StableDefs_Revenge = new Editors.Revenge.StableDefs_Revenge();
						}

						if (StableDefs_Revenge.ShowDialog() == DialogResult.OK)
						{
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save Stable Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							// check if StableDef file exists.
							string stableDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath);
							bool writePath = false;

							if (!File.Exists(stableDefPath))
							{
								stableDefPath = Program.ConvertRelativePath(@"ProjectFiles\StableDefs.txt");
								writePath = true;
							}

							FileStream fs = new FileStream(stableDefPath, FileMode.OpenOrCreate);
							StreamWriter sw = new StreamWriter(fs);
							StableDefFile sdefs = new StableDefFile(Program.CurrentProject.Settings.BaseGame);
							sdefs.StableDefs_Revenge = StableDefs_Revenge.StableDefs;
							sdefs.WriteFile(sw);
							sw.Close();

							if (writePath)
							{
								Program.CurrentProject.Settings.StableDefinitionFilePath = stableDefPath;
								Program.UnsavedChanges = true;
								UpdateTitleBar();
								Program.InfoMessageBox(String.Format("Wrote new Stable Definition file to {0}.", Program.ShortenAbsolutePath(stableDefPath)));
							}
						}
					}
					break;

				case VPWGames.WM2K:
					{
						if (StableDefs_WM2K == null || StableDefs_WM2K.IsDisposed)
						{
							StableDefs_WM2K = new Editors.WM2K.StableDefs_WM2K();
						}

						if (StableDefs_WM2K.ShowDialog() == DialogResult.OK)
						{
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save Stable Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							// check if StableDef file exists.
							string stableDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath);
							bool writePath = false;

							if (!File.Exists(stableDefPath))
							{
								stableDefPath = Program.ConvertRelativePath(@"ProjectFiles\StableDefs.txt");
								writePath = true;
							}

							FileStream fs = new FileStream(stableDefPath, FileMode.OpenOrCreate);
							StreamWriter sw = new StreamWriter(fs);
							StableDefFile sdefs = new StableDefFile(Program.CurrentProject.Settings.BaseGame);
							sdefs.StableDefs_WM2K = StableDefs_WM2K.StableDefs;
							sdefs.WriteFile(sw);
							sw.Close();

							if (writePath)
							{
								Program.CurrentProject.Settings.StableDefinitionFilePath = stableDefPath;
								Program.UnsavedChanges = true;
								UpdateTitleBar();
								Program.InfoMessageBox(String.Format("Wrote new Stable Definition file to {0}.", Program.ShortenAbsolutePath(stableDefPath)));
							}
						}

						// manually kill this dialog to prevent issues when switching between different region WM2K projects
						StableDefs_WM2K = null;
					}
					break;

				case VPWGames.VPW2:
					{
						if (StableDefs_VPW2 == null || StableDefs_VPW2.IsDisposed)
						{
							StableDefs_VPW2 = new Editors.VPW2.StableDefs_VPW2();
						}

						if (StableDefs_VPW2.ShowDialog() == DialogResult.OK)
						{
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save Stable Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							// check if StableDef file exists.
							string stableDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath);
							bool writePath = false;

							if (!File.Exists(stableDefPath))
							{
								stableDefPath = Program.ConvertRelativePath(@"ProjectFiles\StableDefs.txt");
								writePath = true;
							}

							FileStream fs = new FileStream(stableDefPath, FileMode.OpenOrCreate);
							StreamWriter sw = new StreamWriter(fs);
							StableDefFile sdefs = new StableDefFile(Program.CurrentProject.Settings.BaseGame);
							sdefs.StableDefs_VPW2 = StableDefs_VPW2.StableDefs;
							sdefs.WriteFile(sw);
							sw.Close();

							if (writePath)
							{
								Program.CurrentProject.Settings.StableDefinitionFilePath = stableDefPath;
								Program.UnsavedChanges = true;
								UpdateTitleBar();
								Program.InfoMessageBox(String.Format("Wrote new Stable Definition file to {0}.", Program.ShortenAbsolutePath(stableDefPath)));
							}
						}
					}
					break;

				case VPWGames.NoMercy:
					{
						if (StableDefs_NoMercy == null || StableDefs_NoMercy.IsDisposed)
						{
							StableDefs_NoMercy = new Editors.NoMercy.StableDefs_NoMercy();
						}

						if (StableDefs_NoMercy.ShowDialog() == DialogResult.OK)
						{
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save Stable Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							// check if StableDef file exists.
							string stableDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath);
							bool writePath = false;

							if (!File.Exists(stableDefPath))
							{
								stableDefPath = Program.ConvertRelativePath(@"ProjectFiles\StableDefs.txt");
								writePath = true;
							}

							FileStream fs = new FileStream(stableDefPath, FileMode.OpenOrCreate);
							StreamWriter sw = new StreamWriter(fs);
							StableDefFile sdefs = new StableDefFile(Program.CurrentProject.Settings.BaseGame);
							sdefs.StableDefs_NoMercy = StableDefs_NoMercy.StableDefs;
							sdefs.WriteFile(sw);
							sw.Close();

							if (writePath)
							{
								Program.CurrentProject.Settings.StableDefinitionFilePath = stableDefPath;
								Program.UnsavedChanges = true;
								UpdateTitleBar();
								Program.InfoMessageBox(String.Format("Wrote new Stable Definition file to {0}.", Program.ShortenAbsolutePath(stableDefPath)));
							}
						}
					}
					break;

				default:
					Program.ErrorMessageBox(String.Format("Stables dialog not yet designed for {0}.\nUnless you are a programmer, you can not fix this.", Program.CurrentProject.Settings.BaseGame));
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

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.WM2K:
					Program.ErrorMessageBox("Not implemented yet, but this will be similar to the VPW2 editor, so it will exist sooner rather than later.\nUnless you are a programmer, you can not fix this.");
					break;
				case VPWGames.VPW2:
					Editors.VPW2.StoryMode_VPW2 sme = new Editors.VPW2.StoryMode_VPW2();
					sme.ShowDialog();
					break;
				case VPWGames.NoMercy:
					Program.ErrorMessageBox("No Mercy Story Mode Dialog will take some time, since the Story Mode is a lot more complex.\nUnless you are a programmer, you can not fix this.");
					break;
				default:
					Program.ErrorMessageBox("Story mode dialogs not yet designed for non-VPW2 games.\nUnless you are a programmer, you can not fix this.");
					break;
			}
		}
		/// <summary>
		/// Tag Teams editor
		/// </summary>
		private void tagTeamsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			if (Program.CurrentProject.Settings.BaseGame != VPWGames.WM2K)
			{
				return;
			}

			if (TagTeams_WM2K == null || TagTeams_WM2K.IsDisposed)
			{
				TagTeams_WM2K = new Editors.WM2K.TagTeams_WM2K();
			}
			TagTeams_WM2K.MdiParent = this;
			TagTeams_WM2K.Show();
		}


		/// <summary>
		/// Titantron editor
		/// </summary>
		private void titantronVideosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			if (Program.CurrentProject.Settings.BaseGame != VPWGames.WM2K && Program.CurrentProject.Settings.BaseGame != VPWGames.NoMercy)
			{
				Program.ErrorMessageBox("Titantrons don't exist in non-WWF games.");
				return;
			}

			Program.ErrorMessageBox("need to design titantron dialog\nUnless you are a programmer, you can not fix this.");
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

			Program.ErrorMessageBox("Weapons dialog not yet designed.\nUnless you are a programmer, you can not fix this.");
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
				case VPWGames.WorldTour:
				case VPWGames.VPW64:
					if (WrestlerMain_Early == null || WrestlerMain_Early.IsDisposed)
					{
						WrestlerMain_Early = new Editors.WrestlerMain_Early();
					}

					if (WrestlerMain_Early.ShowDialog() == DialogResult.OK)
					{
						if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
						{
							// we need to have saved in order to actually... save.
							Program.ErrorMessageBox("Can not save Wrestler Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
							return;
						}

						// check if WrestlerDef file exists.
						string wrestlerDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
						bool writePath = false;

						if (!File.Exists(wrestlerDefPath))
						{
							wrestlerDefPath = Program.ConvertRelativePath(@"ProjectFiles\WrestlerDefs.txt");
							writePath = true;
						}

						FileStream fs = new FileStream(wrestlerDefPath, FileMode.OpenOrCreate);
						StreamWriter sw = new StreamWriter(fs);
						WrestlerDefFile wdefs = new WrestlerDefFile(Program.CurrentProject.Settings.BaseGame);
						wdefs.WrestlerDefs_Early = WrestlerMain_Early.WrestlerDefs;
						wdefs.WriteFile(sw);
						sw.Close();

						if (writePath)
						{
							Program.CurrentProject.Settings.WrestlerDefinitionFilePath = wrestlerDefPath;
							Program.UnsavedChanges = true;
							UpdateTitleBar();
							Program.InfoMessageBox(String.Format("Wrote new Wrestler Definition file to {0}.", Program.ShortenAbsolutePath(wrestlerDefPath)));
						}
					}
					// manually kill this dialog to prevent issues when switching between World Tour and VPW64 projects
					WrestlerMain_Early = null;
					break;

				case VPWGames.Revenge:
					if (WrestlerMain_Revenge == null || WrestlerMain_Revenge.IsDisposed)
					{
						WrestlerMain_Revenge = new Editors.Revenge.WrestlerMain_Revenge();
					}

					if (WrestlerMain_Revenge.ShowDialog() == DialogResult.OK)
					{
						if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
						{
							// we need to have saved in order to actually... save.
							Program.ErrorMessageBox("Can not save Wrestler Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
							return;
						}

						// check if WrestlerDef file exists.
						string wrestlerDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
						bool writePath = false;

						if (!File.Exists(wrestlerDefPath))
						{
							wrestlerDefPath = Program.ConvertRelativePath(@"ProjectFiles\WrestlerDefs.txt");
							writePath = true;
						}

						FileStream fs = new FileStream(wrestlerDefPath, FileMode.OpenOrCreate);
						StreamWriter sw = new StreamWriter(fs);
						WrestlerDefFile wdefs = new WrestlerDefFile(Program.CurrentProject.Settings.BaseGame);
						wdefs.WrestlerDefs_Revenge = WrestlerMain_Revenge.WrestlerDefs;
						wdefs.WriteFile(sw);
						sw.Close();

						if (writePath)
						{
							Program.CurrentProject.Settings.WrestlerDefinitionFilePath = wrestlerDefPath;
							Program.UnsavedChanges = true;
							UpdateTitleBar();
							Program.InfoMessageBox(String.Format("Wrote new Wrestler Definition file to {0}.", Program.ShortenAbsolutePath(wrestlerDefPath)));
						}
					}
					break;

				case VPWGames.WM2K:
					if (WrestlerMain_WM2K == null || WrestlerMain_WM2K.IsDisposed)
					{
						WrestlerMain_WM2K = new Editors.WM2K.WrestlerMain_WM2K();
					}

					if(WrestlerMain_WM2K.ShowDialog() == DialogResult.OK)
					{
						if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
						{
							// we need to have saved in order to actually... save.
							Program.ErrorMessageBox("Can not save Wrestler Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
							return;
						}

						// check if WrestlerDef file exists.
						string wrestlerDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
						bool writePath = false;

						if (!File.Exists(wrestlerDefPath))
						{
							wrestlerDefPath = Program.ConvertRelativePath(@"ProjectFiles\WrestlerDefs.txt");
							writePath = true;
						}

						FileStream fs = new FileStream(wrestlerDefPath, FileMode.OpenOrCreate);
						StreamWriter sw = new StreamWriter(fs);
						WrestlerDefFile wdefs = new WrestlerDefFile(Program.CurrentProject.Settings.BaseGame);
						wdefs.WrestlerDefs_WM2K = WrestlerMain_WM2K.WrestlerDefs;
						wdefs.WriteFile(sw);
						sw.Close();

						if (writePath)
						{
							Program.CurrentProject.Settings.WrestlerDefinitionFilePath = wrestlerDefPath;
							Program.UnsavedChanges = true;
							UpdateTitleBar();
							Program.InfoMessageBox(String.Format("Wrote new Wrestler Definition file to {0}.", Program.ShortenAbsolutePath(wrestlerDefPath)));
						}
					}

					// manually kill this dialog to prevent issues when switching between WM2K NTSC-U/PAL and NTSC-J projects
					WrestlerMain_WM2K = null;
					break;

				case VPWGames.VPW2:
					if (WrestlerMain_VPW2 == null || WrestlerMain_VPW2.IsDisposed)
					{
						WrestlerMain_VPW2 = new Editors.VPW2.WrestlerMain_VPW2();
					}

					if (WrestlerMain_VPW2.ShowDialog() == DialogResult.OK)
					{
						if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
						{
							// we need to have saved in order to actually... save.
							Program.ErrorMessageBox("Can not save Wrestler Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
							return;
						}

						// check if WrestlerDef file exists.
						string wrestlerDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
						bool writePath = false;

						if (!File.Exists(wrestlerDefPath))
						{
							wrestlerDefPath = Program.ConvertRelativePath(@"ProjectFiles\WrestlerDefs.txt");
							writePath = true;
						}

						FileStream fs = new FileStream(wrestlerDefPath, FileMode.OpenOrCreate);
						StreamWriter sw = new StreamWriter(fs);
						WrestlerDefFile wdefs = new WrestlerDefFile(Program.CurrentProject.Settings.BaseGame);
						wdefs.WrestlerDefs_VPW2 = WrestlerMain_VPW2.WrestlerDefs;
						wdefs.WriteFile(sw);
						sw.Close();

						if (writePath)
						{
							Program.CurrentProject.Settings.WrestlerDefinitionFilePath = wrestlerDefPath;
							Program.UnsavedChanges = true;
							UpdateTitleBar();
							Program.InfoMessageBox(String.Format("Wrote new Wrestler Definition file to {0}.", Program.ShortenAbsolutePath(wrestlerDefPath)));
						}
					}
					WrestlerMain_VPW2 = null;
					break;

				case VPWGames.NoMercy:
					if (WrestlerMain_NoMercy == null || WrestlerMain_NoMercy.IsDisposed)
					{
						WrestlerMain_NoMercy = new Editors.NoMercy.WrestlerMain_NoMercy();
					}

					if (WrestlerMain_NoMercy.ShowDialog() == DialogResult.OK)
					{
						if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
						{
							// we need to have saved in order to actually... save.
							Program.ErrorMessageBox("Can not save Wrestler Definition changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
							return;
						}

						// check if WrestlerDef file exists.
						string wrestlerDefPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
						bool writePath = false;

						if (!File.Exists(wrestlerDefPath))
						{
							wrestlerDefPath = Program.ConvertRelativePath(@"ProjectFiles\WrestlerDefs.txt");
							writePath = true;
						}

						FileStream fs = new FileStream(wrestlerDefPath, FileMode.OpenOrCreate);
						StreamWriter sw = new StreamWriter(fs);
						WrestlerDefFile wdefs = new WrestlerDefFile(Program.CurrentProject.Settings.BaseGame);
						wdefs.WrestlerDefs_NoMercy = WrestlerMain_NoMercy.WrestlerDefs;
						wdefs.WriteFile(sw);
						sw.Close();

						if (writePath)
						{
							Program.CurrentProject.Settings.WrestlerDefinitionFilePath = wrestlerDefPath;
							Program.UnsavedChanges = true;
							UpdateTitleBar();
							Program.InfoMessageBox(String.Format("Wrote new Wrestler Definition file to {0}.", Program.ShortenAbsolutePath(wrestlerDefPath)));
						}
					}
					WrestlerMain_NoMercy = null;
					break;

				default:
					Program.ErrorMessageBox(String.Format("Wrestler definition editor not implemented for {0} yet.\nUnless you are a programmer, you can not fix this.", Program.CurrentProject.Settings.BaseGame.ToString()));
					break;
			}
		}

		/// <summary>
		/// Global Text editor
		/// </summary>
		private void globalTextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				return;
			}

			// this is only valid for WM2K and later
			if (Program.CurrentProject.Settings.BaseGame <= VPWGames.Revenge)
			{
				Program.ErrorMessageBox("Global Text editor not available for this game.");
				return;
			}

			GlobalTextEditor gtEd = new GlobalTextEditor();
			if (gtEd.ShowDialog() == DialogResult.OK)
			{
				Program.ErrorMessageBox("Global Text writeback not implemented yet.\nUnless you are a programmer, you can not fix this.");
			}
		}
		#endregion

		#region Project Build section
		private void PostBuildAction()
		{

		}

		/// <summary>
		/// Build ROM
		/// </summary>
		private void buildROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			#region Sanity Checking
			if (Program.CurrentProject == null)
			{
				// no project loaded to build ROM for
				return;
			}

			// we need to have a saved project
			if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
			{
				MessageBox.Show("ROM Building process requires Project File to be saved.\nPlease save the Project File before continuing.", SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				saveProjectToolStripMenuItem_Click(this, new EventArgs());

				// if we don't have a project file path, we can't continue with the build process.
				if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
				{
					Program.ErrorMessageBox("Project File not saved; aborting ROM Building process.");
					return;
				}
			}

			if (Program.CurrentInputROM == null)
			{
				// needs input ROM.
				Program.ErrorMessageBox("No Input ROM available to build from.\nPlease set Input path in Project Options.");
				return;
			}

			if (Program.CurrentProject.Settings.OutputRomPath == String.Empty)
			{
				// invalid output ROM path
				Program.ErrorMessageBox("Output ROM path not set.\nPlease set Output ROM path in Project Options.");
				return;
			}

			if (!Directory.Exists(Path.GetDirectoryName(Program.ConvertRelativePath(Program.CurrentProject.Settings.OutputRomPath))))
			{
				// output directory doesn't exist
				if (MessageBox.Show(String.Format("The Output ROM Path directory '{0}' does not exist. Create it?", Path.GetDirectoryName(Program.ConvertRelativePath(Program.CurrentProject.Settings.OutputRomPath))), "VPW Studio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					Directory.CreateDirectory(Path.GetDirectoryName(Program.ConvertRelativePath(Program.CurrentProject.Settings.OutputRomPath)));
				}
				else
				{
					// output directory was not made, cancel build
					Program.ErrorMessageBox("Output ROM directory does not exist, and the attempt to create it was canceled. Project build has been halted.");
					return;
				}
				return;
			}

			// force pre-release/prototype versions to be unsupported because I don't want to deal with them at the moment
			if (GameInformation.GameDefs[Program.CurrentProject.Settings.GameType].IsPrototype)
			{
				Program.ErrorMessageBox("Building projects is not supported for pre-release/prototype versions at this time.");
				return;
			}
			#endregion

			// set up logging
			BuildLogEventPublisher buildLogPub = Program.BuildLogPub;
			if (BuildLogForm == null)
			{
				BuildLogForm = new BuildLogDialog(buildLogPub);
			}
			else
			{
				if (BuildLogForm.IsDisposed)
				{
					BuildLogForm = new BuildLogDialog(buildLogPub);
				}
			}
			BuildLogForm.MdiParent = this;
			BuildLogForm.Show();
			BuildLogForm.BringToFront();
			BuildLogForm.Clear();
			DateTime startTime = DateTime.Now;
			buildLogPub.AddLine(
				String.Format("[{0}] Beginning build process for '{1}'",
					startTime.ToString(),
					Program.CurrentProject.Settings.ProjectName
				), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet
			);

			// todo: don't block the UI thread
			Program.BuildRom();
			UpdateBuildMenuItems();

			// xxx: is every build successful?
			TimeSpan buildTimeTaken = (DateTime.Now - startTime);
			buildLogPub.AddLine(
				String.Format("[{0}] Successfully built '{1}' in {2} (min:sec.ms)",
					DateTime.Now.ToString(),
					Program.CurrentProject.Settings.OutputRomPath,
					buildTimeTaken.ToString(@"mm\:ss\.fffff")
				), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet
			);
			BuildLogForm.BuildFinished = true;

			// show any warnings and errors
			if (Program.BuildMessages.Count > 0)
			{
				buildLogPub.AddLine();
				foreach (BuildWarnErr bwe in Program.BuildMessages)
				{
					buildLogPub.AddLine(String.Format("[{0}] File ID {1:X4}: {2}", bwe.MessageType.ToString(), bwe.FileID, bwe.MessageText), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
				}
			}

			BuildLogForm.Focus();
			BuildLogForm.MoveCursorToEnd();
			UpdateBuildMenuItems();
		}

		/// <summary>
		/// Cancels the currently active ROM build
		/// </summary>
		private void cancelBuildToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.RomBuildActive)
			{
				Program.RomBuildActive = false;
				Program.BuildLogPub.AddLine(string.Format("[{0}] Canceled build", DateTime.Now.ToString()));
			}
		}

		/// <summary>
		/// Play ROM
		/// </summary>
		private void playROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			#region Sanity Checking
			// no project loaded to play ROM of
			if (Program.CurrentProject == null)
			{
				// todo: allow launching the emulator (alone) anyways?
				Program.ErrorMessageBox(SharedStrings.PlayRomError_NoProjectLoaded);
				return;
			}

			// playing ROM depends on program options
			if (Properties.Settings.Default.EmulatorPath.Equals(String.Empty))
			{
				// must set emulator path
				Program.ErrorMessageBox(SharedStrings.PlayRomError_EmuPathNotSet);
				return;
			}

			// check that emulator exists
			if (!File.Exists(Properties.Settings.Default.EmulatorPath))
			{
				// invalid emulator path
				Program.ErrorMessageBox(SharedStrings.PlayRomError_EmuPathNotExist);
				return;
			}

			// check if output ROM exists
			string romPath = String.Empty;
			if (Program.CurrentProject.Settings.OutputRomPath == romPath)
			{
				// empty string
				Program.ErrorMessageBox("The Output ROM path is empty. Please set it before continuing.");
				return;
			}
			#endregion

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
				// output ROM does not exist; rebuild it
				buildROMToolStripMenuItem_Click(this, null);
			}

			// todo: rebuild output rom if needed (a.k.a. changes made since last build)

			string emuArgs = String.Empty;
			if (Properties.Settings.Default.EmulatorArguments != String.Empty)
			{
				emuArgs = String.Format("{0} {1}", Properties.Settings.Default.EmulatorArguments, romPath);
			}
			else
			{
				emuArgs = romPath;
			}

			// latest project64 versions assume "$AppPath" is the currently active directory, which breaks things
			string curWorkingDir = Environment.CurrentDirectory;
			Environment.CurrentDirectory = Path.GetDirectoryName(Properties.Settings.Default.EmulatorPath);
			System.Diagnostics.Process.Start(
				Properties.Settings.Default.EmulatorPath,
				emuArgs
			);

			// restore directory so to not break *our* program
			Environment.CurrentDirectory = curWorkingDir;
		}

		#endregion

		#endregion

		#region Tool Menu Items
		private void programOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ProgOptionsDialog == null)
			{
				ProgOptionsDialog = new ProgramOptionsDialog();
			}

			if (ProgOptionsDialog.ShowDialog() == DialogResult.OK)
			{
				Properties.Settings.Default.EmulatorPath = ProgOptionsDialog.EmulatorPath;
				Properties.Settings.Default.EmulatorArguments = ProgOptionsDialog.EmulatorArgs;
				Properties.Settings.Default.BuildLogVerbosity = ProgOptionsDialog.BuildLogVerbosity;
				Properties.Settings.Default.Save();
			}
		}

		/// <summary>
		/// Model Data
		/// </summary>
		private void modelDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ModelToolForm == null)
			{
				ModelToolForm = new ModelTool();
				ModelToolForm.MdiParent = this;
				ModelToolForm.Show();
			}
			else
			{
				if (ModelToolForm.IsDisposed)
				{
					ModelToolForm = new ModelTool();
				}

				// if it was minimized, show it again.
				if (ModelToolForm.WindowState == FormWindowState.Minimized)
				{
					ModelToolForm.WindowState = FormWindowState.Normal;
				}
				ModelToolForm.MdiParent = this;
				ModelToolForm.Show();
			}
		}

		#region Graphics Conversion
		// PNG to TEX
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
					if (test.FromBitmap(b))
					{
						using (FileStream fs = new FileStream(String.Format("{0}.tex", Path.GetFileNameWithoutExtension(ofd.FileName)), FileMode.Create))
						{
							using (BinaryWriter bw = new BinaryWriter(fs))
							{
								test.WriteData(bw);
								bw.Close();
								fs.Close();
								Program.InfoMessageBox(String.Format("Converted file written to {0}", Path.GetFullPath(fs.Name)));
							}
						}
					}
				}
				else if (b.PixelFormat == PixelFormat.Format32bppArgb)
				{
					// todo: this doesn't always imply transparency
					Program.WarningMessageBox("Images with transparency are not properly handled at the moment.");

					// dealing with a transparent image, which is possibly paletted.
					HashSet<Color> usedColors = new HashSet<Color>();
					UInt16 alphaColor = 0;
					// todo: use LockBits/UnlockBits
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
					// xxx: this conversion sucks (specifically, the way the number of colors is checked)
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
					Program.ErrorMessageBox(String.Format("Input image has unsupported PixelFormat {0}", b.PixelFormat));
				}
				b.Dispose();
			}
		}

		private void pngToCi4ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Convert PNG to CI4";
			ofd.Filter = "PNG files (*.png)|*.png|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Bitmap b = new Bitmap(ofd.FileName);
				if (b.PixelFormat == PixelFormat.Format4bppIndexed)
				{
					Ci4Texture test = new Ci4Texture();
					test.FromBitmap(b);
					using (FileStream fs = new FileStream(String.Format("{0}.ci4tex", Path.GetFileNameWithoutExtension(ofd.FileName)), FileMode.Create))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							test.WriteData(bw);
							bw.Flush();
							Program.InfoMessageBox(String.Format("Converted file written to {0}", Path.GetFullPath(fs.Name)));
						}
					}
				}
				else if (b.PixelFormat == PixelFormat.Format8bppIndexed)
				{
					// in theory, this can be converted, but the results will probably not be good
					// UNLESS the input image only uses the first 16 palette indices.
					Program.ErrorMessageBox("Input image is 256 colors/PixelFormat.Format8bppIndexed, expected 16 colors/PixelFormat.Format4bppIndexed");
				}
				else
				{
					Program.ErrorMessageBox(String.Format("Can not convert input image of PixelFormat {0} to CI4/PixelFormat.Format4bppIndexed", b.PixelFormat));
				}
				b.Dispose();
			}
		}

		private void pngToCi8ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Convert PNG to CI8";
			ofd.Filter = "PNG files (*.png)|*.png|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Bitmap b = new Bitmap(ofd.FileName);
				if (b.PixelFormat == PixelFormat.Format8bppIndexed)
				{
					Ci8Texture test = new Ci8Texture();
					test.FromBitmap(b);
					using (FileStream fs = new FileStream(String.Format("{0}.ci8tex", Path.GetFileNameWithoutExtension(ofd.FileName)), FileMode.Create))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							test.WriteData(bw);
							bw.Flush();
							Program.InfoMessageBox(String.Format("Converted file written to {0}", Path.GetFullPath(fs.Name)));
						}
					}
				}
				else if (b.PixelFormat == PixelFormat.Format4bppIndexed)
				{
					// in theory, this can be converted, but I have to write the code for it.
					Program.ErrorMessageBox("Input image is 16 colors/PixelFormat.Format4bppIndexed, expected 256 colors/PixelFormat.Format8bppIndexed");
				}
				else
				{
					Program.ErrorMessageBox(String.Format("Can not convert input image of PixelFormat {0} to CI8/PixelFormat.Format8bppIndexed", b.PixelFormat));
				}
				b.Dispose();
			}
		}

		private void pngToMenubgToolStripMenuItem_Click(object sender, EventArgs e)
		{
			#region Old single-file .menubg export
			/*
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Convert PNG to MenuBackground";
			ofd.Filter = "PNG files (*.png)|*.png|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Bitmap b = new Bitmap(ofd.FileName);
				MenuBackground mbg = new MenuBackground();
				if (mbg.FromBitmap(b))
				{
					using (FileStream fs = new FileStream("menubackground.menubg", FileMode.Create))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							bw.Write(mbg.WriteData());
							bw.Flush();
							bw.Close();
						}
					}
				}
				else
				{
					Program.ErrorMessageBox("unspecified error attempting to create MenuBackground from Bitmap");
				}
				b.Dispose();
			}
			*/
			#endregion

			#region New multi-file export
			MenuBackgroundConverter mbc = new MenuBackgroundConverter();
			if (mbc.ShowDialog() == DialogResult.OK)
			{
				Bitmap b = new Bitmap(mbc.InputFile);
				MenuBackground mbg = new MenuBackground(mbc.GameType);
				if (mbg.FromBitmap(b))
				{
					for (int i = 0; i < mbg.ChunkRows * mbg.ChunkColumns; i++)
					{
						using (FileStream fs = new FileStream(String.Format("{0}\\bg{1:D2}.bin", mbc.OutputDirectory, i + 1), FileMode.Create))
						{
							using (BinaryWriter bw = new BinaryWriter(fs))
							{
								bw.Write(mbg.GetChunkBytes(i));
							}
						}
					}
				}
				else
				{
					Program.ErrorMessageBox("unspecified error attempting to create MenuBackground from Bitmap");
				}
				b.Dispose();
			}
			#endregion
		}
		#endregion

		/// <summary>
		/// Packed File
		/// </summary>
		private void packedFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (PackFileTool == null)
			{
				PackFileTool = new PackedFileTool();
				PackFileTool.MdiParent = this;
				PackFileTool.Show();
			}
			else
			{
				if (PackFileTool.IsDisposed)
				{
					PackFileTool = new PackedFileTool();
				}

				// if it was minimized, show it again.
				if (PackFileTool.WindowState == FormWindowState.Minimized)
				{
					PackFileTool.WindowState = FormWindowState.Normal;
				}
				PackFileTool.MdiParent = this;
				PackFileTool.Show();
			}
		}
		#endregion

		#region Help Menu Items
		/// <summary>
		/// Launch the manual (what little there is).
		/// </summary>
		private void manualToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Program.LaunchManual();
		}

		private void gameSpecificInformationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// attempt to launch the game-specific documentation for the project currently being edited.
			Program.LaunchGameDoc();
		}

		/// <summary>
		/// About
		/// </summary>
		private void aboutVPWStudioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (AboutVPWStudio == null || AboutVPWStudio.IsDisposed)
			{
				AboutVPWStudio = new AboutBox();
			}
			AboutVPWStudio.ShowDialog();
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

			Text = titleBar;
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

			// Help menu
			gameSpecificInformationToolStripMenuItem.Enabled = projFileOpen;

			// Project menu
			foreach (ToolStripItem tsi in projectToolStripMenuItem.DropDownItems)
			{
				if (tsi.GetType() == typeof(ToolStripMenuItem))
				{
					tsi.Enabled = projFileOpen;
				}
			}
			UpdateBuildMenuItems();

			// only handle special cases if a project is open
			if (projFileOpen)
			{
				VPWGames bg = Program.CurrentProject.Settings.BaseGame;

				// special case for Story Mode
				bool showStoryMode = (bg == VPWGames.WM2K || bg == VPWGames.VPW2 || bg == VPWGames.NoMercy);
				storyModeToolStripMenuItem.Enabled = showStoryMode;
				storyModeToolStripMenuItem.Visible = showStoryMode;
				switch (bg)
				{
					case VPWGames.WM2K:
					case VPWGames.VPW2:
						storyModeToolStripMenuItem.Image = Properties.Resources.MenuIcon16_Story_WM2K_VPW2;
						break;
					case VPWGames.NoMercy:
						storyModeToolStripMenuItem.Image = Properties.Resources.MenuIcon16_Story_NoMercy;
						break;
					default:
						storyModeToolStripMenuItem.Image = null;
						break;
				}

				// special case for Titantron
				bool showTitantron = (bg == VPWGames.WM2K || bg == VPWGames.NoMercy);
				titantronVideosToolStripMenuItem.Enabled = showTitantron;
				titantronVideosToolStripMenuItem.Visible = showTitantron;

				// tag team data has only been found in WM2K
				bool showTagTeams = (bg == VPWGames.WM2K);
				tagTeamsToolStripMenuItem.Enabled = showTagTeams;
				tagTeamsToolStripMenuItem.Visible = showTagTeams;

				// Global Text is in WM2K and later
				bool showGlobalText = (bg >= VPWGames.WM2K);
				globalTextToolStripMenuItem.Enabled = showGlobalText;
				globalTextToolStripMenuItem.Visible = showGlobalText;
			}
		}

		/// <summary>
		/// Update valid build/cancel menu items
		/// </summary>
		private void UpdateBuildMenuItems()
		{
			if (Program.CurrentProject == null)
			{
				buildROMToolStripMenuItem.Enabled = false;
				buildROMToolStripMenuItem.Visible = false;
				cancelBuildToolStripMenuItem.Enabled = false;
				cancelBuildToolStripMenuItem.Visible = false;
				playROMToolStripMenuItem.Enabled = false;
				playROMToolStripMenuItem.Visible = false;
			}
			else
			{
				if (Program.RomBuildActive)
				{
					buildROMToolStripMenuItem.Enabled = false;
					buildROMToolStripMenuItem.Visible = false;
					cancelBuildToolStripMenuItem.Enabled = true;
					cancelBuildToolStripMenuItem.Visible = true;
				}
				else
				{
					buildROMToolStripMenuItem.Enabled = true;
					buildROMToolStripMenuItem.Visible = true;
					cancelBuildToolStripMenuItem.Enabled = false;
					cancelBuildToolStripMenuItem.Visible = false;
				}
			}
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
			BackgroundImage = GetMainMenuBG();
		}
		#endregion


		#region Various Helpers
		/// <summary>
		/// Ooh! I pressed the F1 key!
		/// </summary>
		private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
		{
			if (!ModifierKeys.HasFlag(Keys.Shift))
			{
				manualToolStripMenuItem_Click(sender, hlpevent);
			}
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
				case VPWGames.WorldTour: return Properties.Resources.GameIcon16_WorldTour;
				case VPWGames.VPW64: return Properties.Resources.GameIcon16_VPW64;
				case VPWGames.Revenge: return Properties.Resources.GameIcon16_Revenge;
				case VPWGames.WM2K: return Properties.Resources.GameIcon16_WM2K;
				case VPWGames.VPW2: return Properties.Resources.GameIcon16_VPW2;
				case VPWGames.NoMercy: return Properties.Resources.GameIcon16_NoMercy;

				case VPWGames.VPW: return Properties.Resources.GameIcon16_VPW;
				case VPWGames.WCWvsWorld: return Properties.Resources.GameIcon16_WCWvsWorld;

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
				case VPWGames.WorldTour: return Properties.Resources.MainMenuBG_WorldTour;
				case VPWGames.VPW64: return Properties.Resources.MainMenuBG_VPW64;
				case VPWGames.Revenge: return Properties.Resources.MainMenuBG_Revenge;
				case VPWGames.WM2K: return Properties.Resources.MainMenuBG_WM2K;
				case VPWGames.VPW2: return Properties.Resources.MainMenuBG_VPW2;
				case VPWGames.NoMercy: return Properties.Resources.MainMenuBG_NoMercy;

				case VPWGames.VPW: return Properties.Resources.MainMenuBG_VPW;
				case VPWGames.WCWvsWorld: return Properties.Resources.MainMenuBG_WCWvsWorld;

				default:
					return null;
			}
		}
		#endregion

		#region Danger Zone items
		// items in this section are (meant to be) short lived.
		// I just wanted a better place to put them.

		#region LZSS testing
		private void asmikLzssTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select file to LZSS";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream inStr = new FileStream(ofd.FileName, FileMode.Open);
				BinaryReader br = new BinaryReader(inStr);
				FileStream outStr = new FileStream(String.Format("{0}.lzss", Path.GetFileNameWithoutExtension(ofd.FileName)), FileMode.Create);
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
				FileStream outStr = new FileStream(String.Format("{0}.bin", Path.GetFileNameWithoutExtension(ofd.FileName)), FileMode.Create);
				BinaryWriter bw = new BinaryWriter(outStr);

				AsmikLzss.Decode(br, bw);

				bw.Flush();
				bw.Close();
				br.Close();
			}
		}
		#endregion

		private void nameEncoderdecoderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (nedTool == null || nedTool.IsDisposed)
			{
				nedTool = new NameEncodeDecodeTool();
			}
			nedTool.MdiParent = this;
			nedTool.Show();
		}

		private void toki1TestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				Program.ErrorMessageBox("Toki 1 Test requires open project file");
				return;
			}

			if (Toki1Test == null || Toki1Test.IsDisposed)
			{
				Toki1Test = new Toki1TestDialog();
			}
			Toki1Test.MdiParent = this;
			Toki1Test.Show();
		}

		private void vpw2FaceTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				Program.ErrorMessageBox("Requires an open project file.");
				return;
			}

			if (Program.CurrentProject.Settings.BaseGame != VPWGames.VPW2 && Program.CurrentProject.Settings.BaseGame != VPWGames.WM2K)
			{
				Program.ErrorMessageBox("This works with VPW2 and WM2K only!! (because freem's lazy)");
				return;
			}

			FaceTester ft = new FaceTester();
			ft.ShowDialog();
		}

		private void stableParseTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StableDefParseTest sdpt = new StableDefParseTest();
			sdpt.ShowDialog();
		}

		private void romSliceTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				Program.ErrorMessageBox("no project open to get a rom slice for");
				return;
			}

			RomSliceDialog rsd = new RomSliceDialog();
			if (rsd.ShowDialog() == DialogResult.OK)
			{
				byte[] romSlice;

				if (rsd.EndValueIsOffset)
				{
					// calculate length
					int len = rsd.EndValue - rsd.StartOffset;
					romSlice = Program.GetRomSlice(rsd.StartOffset, len);
				}
				else
				{
					// length
					romSlice = Program.GetRomSlice(rsd.StartOffset, rsd.EndValue);
				}

				HexViewer hv = Program.HexViewManager.NewViewerData(romSlice);
				hv.MdiParent = this;
				hv.Show();
				hv.BringToFront();
			}
		}

		private void openFileInHexViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select File";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				HexViewer hv = Program.HexViewManager.HexViewerExternalFile(ofd.FileName, Path.GetFullPath(ofd.FileName));
				hv.MdiParent = this;
				hv.Show();
				hv.BringToFront();
			}
		}

		private void moveDamageTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				Program.ErrorMessageBox("Move Damage Test requires open project file");
				return;
			}

			if (MoveDamageTest == null || MoveDamageTest.IsDisposed)
			{
				MoveDamageTest = new MoveDamageTestDialog();
			}
			MoveDamageTest.MdiParent = this;
			MoveDamageTest.Show();
		}

		private void timTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TimTester t = new TimTester();
			t.ShowDialog();
		}

		private void vpw2TextIndexToolToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TextIndexDecoder == null || TextIndexDecoder.IsDisposed)
			{
				TextIndexDecoder = new Tools.TextIndexTool();
			}
			TextIndexDecoder.MdiParent = this;
			TextIndexDecoder.Show();
		}

		private void testScene3dToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				Program.ErrorMessageBox("test 3d scene requires open project file");
				return;
			}

			if (Test3dDialog == null || Test3dDialog.IsDisposed)
			{
				Test3dDialog = new TestScene3D();
			}
			Test3dDialog.MdiParent = this;
			Test3dDialog.Show();
		}

		private void paramUnpackTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				Program.ErrorMessageBox("param unpack test requires open project file");
				return;
			}

			if (Program.CurrentProject.Settings.BaseGame < VPWGames.WM2K || Program.CurrentProject.Settings.BaseGame > VPWGames.NoMercy)
			{
				Program.ErrorMessageBox("param unpack test only works for wm2k, vpw2, no mercy");
				return;
			}

			ParamDecodeTest pdt = new ParamDecodeTest();
			pdt.MdiParent = this;
			pdt.Show();
		}

		private void vpw64CostumeTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				Program.ErrorMessageBox("Requires an open VPW64 project to use.");
				return;
			}

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.VPW64:
					Editors.VPW64.DefaultCostume_VPW64 vpw64ce = new Editors.VPW64.DefaultCostume_VPW64();
					vpw64ce.ShowDialog();
					break;

				case VPWGames.Revenge:
					Editors.Revenge.DefaultCostume_Revenge revce = new Editors.Revenge.DefaultCostume_Revenge();
					revce.ShowDialog();
					break;

				default:
					Program.ErrorMessageBox("This only works with VPW64 and Revenge.");
					return;
			}

			
		}

		private void stringRenderTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (RenderStringTest == null || RenderStringTest.IsDisposed)
			{
				RenderStringTest = new StringRenderTest();
			}

			RenderStringTest.MdiParent = this;
			RenderStringTest.Show();
		}

		private void clientTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (NetClientTest == null || NetClientTest.IsDisposed)
			{
				NetClientTest = new ClientTest();
			}
			NetClientTest.MdiParent = this;
			NetClientTest.Show();
		}

		private void codeSegmentTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject == null)
			{
				Program.ErrorMessageBox("Requires an open project to use.");
				return;
			}

			if (!DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations.ContainsKey("CodeSegDefs"))
			{
				Program.ErrorMessageBox("Requires a game that has code segment definitions defined.");
				return;
			}

			CodeSegTest cst = new CodeSegTest();
			cst.ShowDialog();
		}
		#endregion

		private void tssLabelGameType_Click(object sender, EventArgs e)
		{
			if (Program.CurrentProject != null)
			{
				projectPropertiesToolStripMenuItem_Click(sender, e);
			}
		}

		private void splitModelTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SplitModelTest smt = new SplitModelTest();
			smt.ShowDialog();
		}
	}
}
