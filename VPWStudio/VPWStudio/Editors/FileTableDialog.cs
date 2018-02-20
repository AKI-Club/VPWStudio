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

		public FileTableDialog()
		{
			InitializeComponent();

			if (Program.CurrentProject != null)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries.Count == 0)
				{
					MessageBox.Show(
						"Project FileTable not found. Attempting to create from ROM.",
						SharedStrings.MainForm_Title,
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
					MakeFileTableFromRom();

					Program.UnsavedChanges = true;
					(Application.OpenForms["MainForm"] as MainForm).UpdateTitleBar();
				}
				UpdateEntryList();
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
					hasLocation = true;
					hasLength = true;
				}
			}
			if (!hasLocation || !hasLength)
			{
				// fallback to hardedcoded offset and length.
				MessageBox.Show(
					"File Table location not found; using hardcoded offset and length instead.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				int offset = 0;
				int length = 0;
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.WorldTour_NTSC_U_10:
						offset = 0x7C1A78;
						length = 21996;
						break;
					case SpecificGame.WorldTour_NTSC_U_11:
						offset = 0x7C1C70;
						length = 21996;
						break;
					case SpecificGame.WorldTour_PAL:
						offset = 0x7C1C00;
						length = 21996;
						break;
					case SpecificGame.VPW64_NTSC_J:
						offset = 0xC7B578;
						length = 37432;
						break;
					case SpecificGame.Revenge_NTSC_U:
						offset = 0xCE2752;
						length = 30632;
						break;
					case SpecificGame.Revenge_PAL:
						offset = 0xCDFCE2;
						length = 30632;
						break;
					case SpecificGame.WM2K_NTSC_U:
						offset = 0x11778BE;
						length = 41248;
						break;
					case SpecificGame.WM2K_NTSC_J:
						offset = 0x116F3C2;
						length = 41480;
						break;
					case SpecificGame.WM2K_PAL:
						offset = 0x11778BE;
						length = 41248;
						break;
					case SpecificGame.VPW2_NTSC_J:
						offset = 0x1310F40;
						length = 52364;
						break;
					case SpecificGame.NoMercy_NTSC_U_10:
						offset = 0x16C3238;
						length = 77848;
						break;
					case SpecificGame.NoMercy_NTSC_U_11:
						offset = 0x16C31D8;
						length = 77848;
						break;
					case SpecificGame.NoMercy_PAL_10:
						offset = 0x16C32A8;
						length = 77848;
						break;
					case SpecificGame.NoMercy_PAL_11:
						offset = 0x16C3148;
						length = 77848;
						break;
				}
				if (offset != 0 && length != 0)
				{
					br.BaseStream.Seek(offset, SeekOrigin.Begin);
					Program.CurrentProject.ProjectFileTable.Read(br, length);
				}
			}
			br.Close();

			// read relevant file from FileTableDB
			FileTableDB ftdb;
			string dbFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\FileTableDB\\";

			// special case WWF WrestleMania 2000 NTSC-J
			if (Program.CurrentProject.Settings.GameType == SpecificGame.WM2K_NTSC_J)
			{
				dbFilePath += "WM2K-J.txt";
			}
			else
			{
				dbFilePath += String.Format("{0}.txt", Program.CurrentProject.Settings.BaseGame.ToString());
			}

			// make sure it exists before we go and start adding things
			if (!File.Exists(dbFilePath))
			{
				// well you've gone and beefed it now.
				MessageBox.Show("I need to write a proper error dialog, but the filetable db for this game isn't there.");
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
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.WorldTour_NTSC_U_10:
					case SpecificGame.WorldTour_PAL:
						offset = 0x39490;
						break;
					case SpecificGame.WorldTour_NTSC_U_11:
						offset = 0x39500;
						break;
					case SpecificGame.VPW64_NTSC_J:
						offset = 0x4AD00;
						break;
					case SpecificGame.Revenge_NTSC_U:
						offset = 0xDAC50;
						break;
					case SpecificGame.Revenge_PAL:
						offset = 0xD81E0;
						break;
					case SpecificGame.WM2K_NTSC_U:
						offset = 0x144AA0;
						break;
					case SpecificGame.WM2K_NTSC_J:
						offset = 0x12C070;
						break;
					case SpecificGame.WM2K_PAL:
						offset = 0x144AC0;
						break;
					case SpecificGame.VPW2_NTSC_J:
						offset = 0x152DF0;
						break;
					case SpecificGame.NoMercy_NTSC_U_10:
						offset = 0x1BD1B0;
						break;
					case SpecificGame.NoMercy_NTSC_U_11:
						offset = 0x1BD150;
						break;
					case SpecificGame.NoMercy_PAL_10:
						offset = 0x1BD220;
						break;
					case SpecificGame.NoMercy_PAL_11:
						offset = 0x1BD0C0;
						break;
				}
			}

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
				lvi.SubItems[FILE_ID_COLUMN].BackColor = rowColor;
				lvi.SubItems[LOCATION_COLUMN].BackColor = rowColor;
				lvi.SubItems[ROM_ADDR_COLUMN].BackColor = rowColor;
				lvi.SubItems[FILE_TYPE_COLUMN].BackColor = rowColor;
				lvi.SubItems[LZSS_COLUMN].BackColor = rowColor;
				lvi.SubItems[COMMENT_COLUMN].BackColor = rowColor;

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

		private void editInformationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count == 0)
			{
				return;
			}

			if (lvFileList.SelectedItems.Count > 1)
			{
				MessageBox.Show("multi select sucks, i haven't handled it yet");
				return;
			}

			int key = int.Parse(lvFileList.SelectedItems[0].SubItems[0].Text, NumberStyles.HexNumber);
			FileTableEditEntryInfoDialog editInfoDialog = new FileTableEditEntryInfoDialog(Program.CurrentProject.ProjectFileTable.Entries[key]);
			if (editInfoDialog.ShowDialog() == DialogResult.OK)
			{
				Program.CurrentProject.ProjectFileTable.Entries[key].DeepCopy(editInfoDialog.CurEntry);
				lvFileList.SelectedItems[0].SubItems[FILE_TYPE_COLUMN].Text = editInfoDialog.CurEntry.FileType.ToString();
				lvFileList.SelectedItems[0].SubItems[COMMENT_COLUMN].Text = editInfoDialog.CurEntry.Comment;
			}
		}

		private void extractFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count == 0)
			{
				return;
			}

			MessageBox.Show("haven't implemented it yet.");
		}
	}
}
