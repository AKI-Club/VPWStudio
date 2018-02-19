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
				UpdateInfoDump();
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
		}

		private void UpdateInfoDump()
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
					fte.Value.IsEncoded.ToString(),
					fte.Value.Comment
				});
				lvi.UseItemStyleForSubItems = false;
				Color rowColor = (i % 2 == 0) ? Color.White : Color.FromArgb(240, 240, 240);
				lvi.SubItems[0].BackColor = rowColor;
				lvi.SubItems[1].BackColor = rowColor;
				lvi.SubItems[2].BackColor = rowColor;
				lvi.SubItems[3].BackColor = rowColor;
				lvi.SubItems[4].BackColor = rowColor;

				Font regular = new Font(FontFamily.GenericSansSerif, 8.25f);
				Font mono = new Font(FontFamily.GenericMonospace, 10.0f);
				lvi.SubItems[0].Font = mono;
				lvi.SubItems[1].Font = mono;
				lvi.SubItems[2].Font = mono;
				lvi.SubItems[3].Font = regular;
				lvi.SubItems[4].Font = regular;
				lvFileList.Items.Add(lvi);

				i++;
			}
			lvFileList.EndUpdate();
		}

		/// <summary>
		/// Set the comment of the selected FileTable entry.
		/// </summary>
		private void setCommentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count == 0)
			{
				return;
			}

			if (lvFileList.SelectedItems.Count > 1)
			{
				// ugh this blows dick, should really be a separate dialog
				MessageBox.Show("I haven't implemented multiple rename yet, ugh");
			}
			else
			{
				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[0].Text, NumberStyles.HexNumber);
				FileTableEditCommentDialog ftecd = new FileTableEditCommentDialog(key, Program.CurrentProject.ProjectFileTable.Entries[key].Comment);
				if (ftecd.ShowDialog() == DialogResult.OK)
				{
					Program.CurrentProject.ProjectFileTable.Entries[key].Comment = ftecd.NewComment;
					lvFileList.SelectedItems[0].SubItems[4].Text = ftecd.NewComment;
				}
			}
		}
	}
}
