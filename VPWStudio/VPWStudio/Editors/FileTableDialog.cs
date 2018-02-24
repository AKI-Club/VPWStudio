using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class FileTableDialog : Form
	{
		#region Column constants
		// update these any time you update a new column, which is hopefully never!!!
		private const int FILE_ID_COLUMN = 0;
		private const int LOCATION_COLUMN = 1;
		private const int ROM_ADDR_COLUMN = 2;
		private const int FILE_TYPE_COLUMN = 3;
		private const int LZSS_COLUMN = 4;
		private const int COMMENT_COLUMN = 5;
		#endregion

		#region Default File Table Data
		// todo: this possibly belongs in another file,
		// maybe ProgStructures/DefaultGameData.cs
		private class DefaultFileTableData
		{
			public Int32 FileTableOffset; // filetable offset
			public Int32 FileTableLength; // filetable length
			public UInt32 FirstFileOffset; // first file offset

			/// <summary>
			/// Default constructor
			/// </summary>
			public DefaultFileTableData()
			{
				this.FileTableOffset = 0;
				this.FileTableLength = 0;
				this.FirstFileOffset = 0;
			}

			/// <summary>
			/// Specific constructor
			/// </summary>
			/// <param name="_fto"></param>
			/// <param name="_ftl"></param>
			/// <param name="_firstFile"></param>
			public DefaultFileTableData(Int32 _fto, Int32 _ftl, UInt32 _firstFile)
			{
				this.FileTableOffset = _fto;
				this.FileTableLength = _ftl;
				this.FirstFileOffset = _firstFile;
			}
		}

		/// <summary>
		/// Default FileTable data for each game.
		/// </summary>
		/// this probably also belongs in ProgStructures/DefaultGameData.cs
		private Dictionary<SpecificGame, DefaultFileTableData> DefaultFileTables = new Dictionary<SpecificGame, DefaultFileTableData>()
		{
			{ SpecificGame.WorldTour_NTSC_U_10, new DefaultFileTableData(0x7C1A78, 21996, 0x39490) },
			{ SpecificGame.WorldTour_NTSC_U_11, new DefaultFileTableData(0x7C1C70, 21996, 0x39500) },
			{ SpecificGame.WorldTour_PAL, new DefaultFileTableData(0x7C1C00, 21996, 0x39490) },
			{ SpecificGame.VPW64_NTSC_J, new DefaultFileTableData(0xC7B578, 37432, 0x4AD00) },
			{ SpecificGame.Revenge_NTSC_U, new DefaultFileTableData(0xCE2752, 30632, 0xDAC50) },
			{ SpecificGame.Revenge_PAL, new DefaultFileTableData(0xCDFCE2, 30632, 0xD81E0) },
			{ SpecificGame.WM2K_NTSC_U, new DefaultFileTableData(0x11778BE, 41248, 0x144AA0) },
			{ SpecificGame.WM2K_NTSC_J, new DefaultFileTableData(0x116F3C2, 41480, 0x12C070) },
			{ SpecificGame.WM2K_PAL, new DefaultFileTableData(0x11778BE, 41248, 0x144AC0) },
			{ SpecificGame.VPW2_NTSC_J, new DefaultFileTableData(0x1310F40, 52364, 0x152DF0) },
			{ SpecificGame.NoMercy_NTSC_U_10, new DefaultFileTableData(0x16C3238, 77848, 0x1BD1B0) },
			{ SpecificGame.NoMercy_NTSC_U_11, new DefaultFileTableData(0x16C31D8, 77848, 0x1BD150) },
			{ SpecificGame.NoMercy_PAL_10, new DefaultFileTableData(0x16C32A8, 77848, 0x1BD220) },
			{ SpecificGame.NoMercy_PAL_11, new DefaultFileTableData(0x16C3148, 77848, 0x1BD0C0) },
		};
		#endregion

		public FileTableDialog(int focusEntry = 0)
		{
			InitializeComponent();

			if (Program.CurrentProject != null)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries.Count == 0)
				{
					MessageBox.Show(
						SharedStrings.FileTableDialog_AttemptRomTableBuild,
						SharedStrings.MainForm_Title,
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
					MakeFileTableFromRom();

					Program.UnsavedChanges = true;
					(Application.OpenForms["MainForm"] as MainForm).UpdateTitleBar();
				}
				UpdateEntryList();

				// check to see if a specific file was requested, and scroll to it if so.
				if (focusEntry != 0)
				{
					ListViewItem requestedFile = lvFileList.FindItemWithText(String.Format("{0:X4}", focusEntry), true, 0);
					lvFileList.FocusedItem = requestedFile;
					lvFileList.EnsureVisible(requestedFile.Index);
				}
			}
		}

		/// <summary>
		/// Load FileTable from current input ROM and assign the result to the ProjectFile.
		/// </summary>
		private void MakeFileTableFromRom()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			// load from input rom, then put in project filetable
			Program.CurrentProject.ProjectFileTable = new FileTable();

			bool hasLocation = false;
			bool hasLength = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.FileTable != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.FileTable.Address, SeekOrigin.Begin);
					Program.CurrentProject.ProjectFileTable.Read(br, Program.CurLocationFile.FileTable.Width);
					Program.CurrentProject.ProjectFileTable.Location = Program.CurLocationFile.FileTable.Address;
					hasLocation = true;
					hasLength = true;
				}
			}
			if (!hasLocation || !hasLength)
			{
				// fallback to hardcoded offset and length.
				MessageBox.Show(
					SharedStrings.FileTableDialog_UsingHardcodedValues,
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				int offset = this.DefaultFileTables[Program.CurrentProject.Settings.GameType].FileTableOffset;
				int length = this.DefaultFileTables[Program.CurrentProject.Settings.GameType].FileTableLength;

				if (offset != 0 && length != 0)
				{
					br.BaseStream.Seek(offset, SeekOrigin.Begin);
					Program.CurrentProject.ProjectFileTable.Read(br, length);
					Program.CurrentProject.ProjectFileTable.Location = (UInt32)offset;
				}
			}
			br.Close();
			LoadFileTableDB();
		}

		/// <summary>
		/// Get the path to the default FileTableDB for the loaded game type.
		/// </summary>
		/// <returns></returns>
		private string GetFileTableDBPath()
		{
			string dbFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\FileTableDB\\";

			// special case: WWF WrestleMania 2000 NTSC-J has a different FileTable
			// than the NTSC-U and PAL versions... Haven't figured out the actual changes yet.
			if (Program.CurrentProject.Settings.GameType == SpecificGame.WM2K_NTSC_J)
			{
				dbFilePath += "WM2K-J.txt";
			}
			else
			{
				dbFilePath += String.Format("{0}.txt", Program.CurrentProject.Settings.BaseGame.ToString());
			}

			return dbFilePath;
		}

		/// <summary>
		/// Load the file table database.
		/// </summary>
		private void LoadFileTableDB()
		{
			// read relevant file from FileTableDB
			FileTableDB ftdb;

			string dbFilePath = GetFileTableDBPath();
			// make sure it exists before we go and start adding things
			if (!File.Exists(dbFilePath))
			{
				// well you've gone and beefed it now.
				MessageBox.Show(
					"Unable to find the requested FileTable Database in the 'FileTableDB' directory.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			else
			{
				ftdb = new FileTableDB(dbFilePath);
				foreach (KeyValuePair<UInt16, FileTableDBEntry> entry in ftdb.Entries)
				{
					Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].FileType = entry.Value.FileType;
					Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].Comment = entry.Value.Comment;
				}
			}
		}

		/// <summary>
		/// Reload the FileTableDB.
		/// </summary>
		private void ReloadFileTableDB()
		{
			// this one is tricky because we don't want to kill any comments that were entered in the program.
		}

		/// <summary>
		/// Update the ListView with the file table entries.
		/// </summary>
		private void UpdateEntryList()
		{
			uint offset = 0;
			bool hasOffset = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.FirstFile != null)
				{
					offset = Program.CurLocationFile.FirstFile.Address;
					hasOffset = true;
				}
			}
			if (!hasOffset)
			{
				offset = this.DefaultFileTables[Program.CurrentProject.Settings.GameType].FirstFileOffset;
			}
			Program.CurrentProject.ProjectFileTable.FirstFile = offset;

			lvFileList.Items.Clear();
			lvFileList.BeginUpdate();
			int i = 0;
			foreach (KeyValuePair<int, FileTableEntry> fte in Program.CurrentProject.ProjectFileTable.Entries)
			{
				ListViewItem lvi = new ListViewItem(new string[] {
					String.Format("{0:X4}",fte.Value.FileID),
					String.Format("{0:X8}",fte.Value.Location),
					String.Format("{0:X8}",fte.Value.Location + offset),
					fte.Value.FileType.ToString(),
					fte.Value.IsEncoded.ToString(),
					fte.Value.Comment
				});
				lvi.UseItemStyleForSubItems = false;
				Color rowColor = (i % 2 == 0) ? Color.White : Color.FromArgb(240, 240, 240);
				foreach (ListViewItem.ListViewSubItem subitem in lvi.SubItems)
				{
					subitem.BackColor = rowColor;
				}

				Font regular = new Font(FontFamily.GenericSansSerif, 8.25f);
				Font mono = new Font(FontFamily.GenericMonospace, 10.0f);
				lvi.SubItems[FILE_ID_COLUMN].Font = mono;
				lvi.SubItems[LOCATION_COLUMN].Font = mono;
				lvi.SubItems[ROM_ADDR_COLUMN].Font = mono;
				lvi.SubItems[FILE_TYPE_COLUMN].Font = regular;
				lvi.SubItems[LZSS_COLUMN].Font = regular;
				lvi.SubItems[COMMENT_COLUMN].Font = regular;
				lvFileList.Items.Add(lvi);

				i++;
			}
			lvFileList.EndUpdate();
		}

		#region Context Menu
		/// <summary>
		/// Modify the context menu
		/// </summary>
		private void cmsFileEntry_Opening(object sender, CancelEventArgs e)
		{
			if (lvFileList.SelectedItems.Count > 1)
			{
				extractFileToolStripMenuItem.Text = SharedStrings.FileTableDialog_ExtractFiles;
			}
			else if (lvFileList.SelectedItems.Count == 1)
			{
				extractFileToolStripMenuItem.Text = SharedStrings.FileTableDialog_ExtractFile;

				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[0].Text, NumberStyles.HexNumber);
				extractRawToolStripMenuItem.Enabled = Program.CurrentProject.ProjectFileTable.Entries[key].IsEncoded;
			}
		}

		/// <summary>
		/// Edit the information of the selected FileTable entry/entries.
		/// </summary>
		private void editInformationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				LoadEditInfoDialog();
			}
			else
			{
				MessageBox.Show("multi select sucks, i haven't handled it yet");
				return;
			}
		}

		/// <summary>
		/// Extract the selected FileTable entry/entries.
		/// </summary>
		private void extractFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				MessageBox.Show("Please select at least one item to extract.");
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				// only one file; no need to go through rigmarole
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Extract File";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(romStream);

					FileStream outFile = new FileStream(sfd.FileName, FileMode.Create);
					BinaryWriter outWriter = new BinaryWriter(outFile);

					int key = int.Parse(lvFileList.SelectedItems[0].SubItems[0].Text, NumberStyles.HexNumber);
					bool lzss = Program.CurrentProject.ProjectFileTable.Entries[key].IsEncoded;
					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, key, lzss);

					outWriter.Flush();
					outWriter.Close();
					romReader.Close();
				}
			}
			else
			{
				// more than one file
				MessageBox.Show("Haven't implemented multi-extract dialog yet.");
				List<int> ExtractIDs = new List<int>();
				for (int i = 0; i < lvFileList.SelectedItems.Count; i++)
				{
					int key = int.Parse(lvFileList.SelectedItems[i].SubItems[0].Text, NumberStyles.HexNumber);
					ExtractIDs.Add(key);
				}
				FileTable_ExtractFilesDialog efd = new FileTable_ExtractFilesDialog(ExtractIDs);
				if (efd.ShowDialog() == DialogResult.OK)
				{

				}
			}
		}

		private void extractRawToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				MessageBox.Show("Please select at least one item to extract.");
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				// only one file; no need to go through rigmarole
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Extract File (Raw)";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(romStream);

					FileStream outFile = new FileStream(sfd.FileName, FileMode.Create);
					BinaryWriter outWriter = new BinaryWriter(outFile);

					int key = int.Parse(lvFileList.SelectedItems[0].SubItems[0].Text, NumberStyles.HexNumber);
					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, key);

					outWriter.Flush();
					outWriter.Close();
					romReader.Close();
				}
			}
			else
			{
				// more than one file
				MessageBox.Show("Haven't implemented it yet.");
			}
		}
		#endregion

		/// <summary>
		/// Load the Edit Information dialog for a single FileTable entry.
		/// </summary>
		private void LoadEditInfoDialog()
		{
			int key = int.Parse(lvFileList.SelectedItems[0].SubItems[0].Text, NumberStyles.HexNumber);
			FileTableEditEntryInfoDialog editInfoDialog = new FileTableEditEntryInfoDialog(Program.CurrentProject.ProjectFileTable.Entries[key]);
			if (editInfoDialog.ShowDialog() == DialogResult.OK)
			{
				Program.CurrentProject.ProjectFileTable.Entries[key].DeepCopy(editInfoDialog.CurEntry);
				lvFileList.SelectedItems[0].SubItems[FILE_TYPE_COLUMN].Text = editInfoDialog.CurEntry.FileType.ToString();
				lvFileList.SelectedItems[0].SubItems[COMMENT_COLUMN].Text = editInfoDialog.CurEntry.Comment;
			}
		}

		/// <summary>
		/// Double clicking on an item
		/// </summary>
		private void lvFileList_DoubleClick(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count == 0)
			{
				return;
			}

			if (lvFileList.SelectedItems.Count > 1)
			{
				return;
			}

			int key = int.Parse(lvFileList.SelectedItems[0].SubItems[0].Text, NumberStyles.HexNumber);
			switch (Program.CurrentProject.ProjectFileTable.Entries[key].FileType)
			{
				// "TEX" files
				case FileTypes.AkiTexture:
					FileTable_TexPreviewDialog tpd = new FileTable_TexPreviewDialog(key);
					tpd.ShowDialog();
					break;

				// CI4/CI8 textures
				case FileTypes.Ci4Texture:
				case FileTypes.Ci8Texture:
					FileTable_CiTexturePreviewDialog citd = new FileTable_CiTexturePreviewDialog(key);
					citd.ShowDialog();
					break;

				// CI4/CI8 palettes
				case FileTypes.Ci4Palette:
				case FileTypes.Ci8Palette:
					FileTable_CiPalettePreviewDialog cipd = new FileTable_CiPalettePreviewDialog(key);
					cipd.ShowDialog();
					break;

				// AkiText archive
				case FileTypes.AkiText:
					// temporary
					AkiTextDialog atd = new AkiTextDialog(key);
					atd.ShowDialog();
					break;

				// no default handler; show the hex viewer.
				default:
					((VPWStudio.MainForm)this.MdiParent).RequestHexViewer(key);
					break;
			}
		}

		/// <summary>
		/// Export the FileTable as a Midwaydec File List.
		/// </summary>
		private void exportMidwaydecFileListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Midwaydec File List";
			sfd.Filter = SharedStrings.FileFilter_Text;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
				StreamWriter sw = new StreamWriter(fs);
				Program.CurrentProject.ProjectFileTable.WriteMidwaydec(sw);
				sw.Flush();
				sw.Close();
			}
		}

		#region Navigation Menu Items
		/// <summary>
		/// Go to a specific file ID.
		/// </summary>
		private void goToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileTable_GoToDialog gtd = new FileTable_GoToDialog();
			if (gtd.ShowDialog() == DialogResult.OK)
			{
				lvFileList.FocusedItem = lvFileList.Items[gtd.DestinationFileID-1];
				lvFileList.EnsureVisible(gtd.DestinationFileID-1);
			}
		}

		/// <summary>
		/// Go to the top of the FileTable.
		/// </summary>
		private void goToTopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lvFileList.FocusedItem = lvFileList.Items[0];
			lvFileList.EnsureVisible(0);
		}

		/// <summary>
		/// Go to the bottom of the FileTable.
		/// </summary>
		private void goToBottomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lvFileList.FocusedItem = lvFileList.Items[lvFileList.Items.Count-1];
			lvFileList.EnsureVisible(lvFileList.Items.Count-1);
		}
		#endregion
	}
}
