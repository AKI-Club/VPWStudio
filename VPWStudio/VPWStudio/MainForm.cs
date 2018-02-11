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
		/// <summary>
		/// Polygon/Model Tool form
		/// </summary>
		public ModelTool PolyTool = null;

		/// <summary>
		/// Project Properties form
		/// </summary>
		public ProjectPropertiesDialog ProjPropDialog = null;

		/// <summary>
		/// Packed File Tool form
		/// </summary>
		public PackedFileTool PackFileTool = null;
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
				if (MessageBox.Show("There are unsaved project changes.\n\nDo you want to discard the changes and exit?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}
		#endregion

		#region File Menu Items
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

				if (Program.CurrentProject.Settings.UseCustomLocationFile)
				{
					// load custom location file
					Program.CurLocationFile = new LocationFile();
					Program.CurLocationFile.LoadFile(Program.CurrentProject.Settings.CustomLocationFilePath);
				}
				else
				{
					// load location file based on game name
					Program.CurLocationFile = new LocationFile();
					string lfn = GameInformation.GameDefs[Program.CurrentProject.Settings.GameType].GameCode + ".txt";
					Program.CurLocationFile.LoadFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\LocationFiles\\" + lfn);
				}
			}
		}

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

				// load location file
				Program.CurLocationFile = new LocationFile();
				if (Program.CurrentProject.Settings.UseCustomLocationFile)
				{
					// custom locations
					Program.CurLocationFile.LoadFile(Program.CurrentProject.Settings.CustomLocationFilePath);
				}
				else
				{
					// default location file
					string lfn = GameInformation.GameDefs[Program.CurrentProject.Settings.GameType].GameCode + ".txt";
					Program.CurLocationFile.LoadFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\LocationFiles\\" + lfn);
				}
			}
		}

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
				// write to specified file
				Program.CurrentProject.SaveFile(sfd.FileName);
			}
		}

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
			UpdateValidMenus();
			UpdateStatusBar();
			UpdateTitleBar();
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
				Program.CurrentProject.Settings.DeepCopy(this.ProjPropDialog.NewSettings);
				Program.UnsavedChanges = true;
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

		private void wrestlersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// wrestlers dialog not yet designed
		}

		private void buildROMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// build rom dialog? not yet designed
		}
		#endregion

		#region Tool Menu Items
		private void programOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// program options dialog not yet designed
		}

		/// <summary>
		/// Polygon Data
		/// </summary>
		private void polygonDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.PolyTool == null)
			{
				this.PolyTool = new ModelTool();
			}
			this.PolyTool.MdiParent = this;
			this.PolyTool.Show();

			// if it was minimized, show it again.
			if (this.PolyTool.WindowState == FormWindowState.Minimized)
			{
				this.PolyTool.WindowState = FormWindowState.Normal;
			}
		}

		private void packedFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.PackFileTool == null)
			{
				this.PackFileTool = new PackedFileTool();
			}
			this.PackFileTool.MdiParent = this;
			this.PackFileTool.Show();

			// if it was minimized, show it again.
			if (this.PackFileTool.WindowState == FormWindowState.Minimized)
			{
				this.PackFileTool.WindowState = FormWindowState.Normal;
			}
		}
		#endregion

		#region Help Menu Items
		private void aboutVPWStudioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// temporary thing
			MessageBox.Show(
				String.Format("VPW Studio (indev version {0}) by freem", Application.ProductVersion),
				"About VPW Studio",
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
			fileTableToolStripMenuItem.Enabled = projFileOpen;
			movesToolStripMenuItem.Enabled = projFileOpen;
			wrestlersToolStripMenuItem.Enabled = projFileOpen;
			buildROMToolStripMenuItem.Enabled = projFileOpen;
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

		// currently a little broken, but not the form's fault...
		private void sharkTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GameSharkTool gst = new GameSharkTool();
			gst.MdiParent = this;
			gst.Show();
		}

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
	}
}
