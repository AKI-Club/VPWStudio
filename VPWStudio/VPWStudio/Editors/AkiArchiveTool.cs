using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VPWStudio.Editors;

namespace VPWStudio
{
	public partial class AkiArchiveTool : Form
	{
		public int FileID = -1;

		public AkiArchive CurArchive;

		private const string FormTitle = "AKI Archive Tool [File {0:X4}]";

		private StringBuilder InfoStringBuilder = new StringBuilder();

		#region Constructors
		public AkiArchiveTool(int _fileID)
		{
			CurArchive = new AkiArchive();
			InitializeComponent();
			LoadFromFileTable(_fileID);
			PopulateFileList();
			Text = String.Format(FormTitle, _fileID);
		}

		public AkiArchiveTool(string path)
		{
			CurArchive = new AkiArchive();
			InitializeComponent();
			LoadFromExternalFile(path);
			PopulateFileList();
		}
		#endregion

		#region Load
		/// <summary>
		/// Load AkiArchive from FileTable.
		/// </summary>
		/// <param name="_fileID">File ID of archive to open.</param>
		private void LoadFromFileTable(int _fileID)
		{
			FileID = _fileID;

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream arcStream = new MemoryStream();
			BinaryWriter arcWriter = new BinaryWriter(arcStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, arcWriter, _fileID);

			arcStream.Seek(0, SeekOrigin.Begin);
			BinaryReader fr = new BinaryReader(arcStream);
			CurArchive.ReadData(fr);
			fr.Close();
		}

		/// <summary>
		/// Load AkiArchive from external file.
		/// </summary>
		/// <param name="path">Path to AkiArchive file.</param>
		private void LoadFromExternalFile(string path)
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			CurArchive.ReadData(br);
			br.Close();
		}
		#endregion

		private void PopulateFileList()
		{
			lbFiles.Items.Clear();
			lbFiles.BeginUpdate();

			for (int i = 0; i < CurArchive.NumFiles; i++)
			{
				// only add valid entries
				if (CurArchive.FileEntries[i].Size > 0)
				{
					lbFiles.Items.Add(String.Format("File {0}", i));
				}
			}

			lbFiles.EndUpdate();
		}

		#region	OK/Cancel buttons
		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
		#endregion

		#region File List buttons
		private void buttonExtract_Click(object sender, EventArgs e)
		{
			if (lbFiles.SelectedIndex < 0)
			{
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog()
			{
				Title="Extract File",
				Filter = SharedStrings.FileFilter_None
			};

			// suggest filename for extracted file
			if (FileID == -1)
			{
				// archive loaded from external file
				sfd.FileName = String.Format("extracted{0}.bin", lbFiles.SelectedIndex);
			}
			else
			{
				// archive loaded from filetable
				if (Program.AkiArchiveFileDB != null)
				{
					if (Program.AkiArchiveFileDB.Entries[FileID].Count > 0 && lbFiles.SelectedIndex < Program.AkiArchiveFileDB.Entries[FileID].Count)
					{
						if (Program.AkiArchiveFileDB.Entries[FileID][lbFiles.SelectedIndex] != null)
						{
							sfd.FileName = String.Format("{0:X4}-{1}{2}", FileID, lbFiles.SelectedIndex,
								FileTypeInfo.DefaultFileTypeExtensions[Program.AkiArchiveFileDB.Entries[FileID][lbFiles.SelectedIndex].FileType]);
						}
						else
						{
							sfd.FileName = String.Format("{0:X4}-{1}.bin", FileID, lbFiles.SelectedIndex);
						}
					}
					else
					{
						sfd.FileName = String.Format("{0:X4}-{1}.bin", FileID, lbFiles.SelectedIndex);
					}
				}
				else
				{
					sfd.FileName = String.Format("{0:X4}-{1}.bin", FileID, lbFiles.SelectedIndex);
				}
			}


			if (sfd.ShowDialog() == DialogResult.OK)
			{
				CurArchive.ExtractSingleFile(lbFiles.SelectedIndex, sfd.FileName);
			}
		}

		private void buttonReplace_Click(object sender, EventArgs e)
		{
			if (lbFiles.SelectedIndex < 0)
			{
				return;
			}

			Program.ErrorMessageBox("haven't implemented it");
		}
		#endregion

		private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbFiles.SelectedIndex < 0)
			{
				return;
			}

			tbSelItemInfo.Clear();

			AkiArchiveEntry aae = CurArchive.FileEntries[lbFiles.SelectedIndex];
			InfoStringBuilder.Clear();
			InfoStringBuilder.AppendLine(String.Format("File Index {0} (0x{0:X4}):", lbFiles.SelectedIndex));
			InfoStringBuilder.AppendLine(String.Format("Start Offset: 0x{0:X8}", aae.StartAddr));
			InfoStringBuilder.AppendLine(String.Format("File Size: 0x{0:X8}", aae.Size));

			if (Program.AkiArchiveFileDB != null && Program.AkiArchiveFileDB.Entries.ContainsKey(FileID))
			{
				if (Program.AkiArchiveFileDB.Entries[FileID].Count > 0 && lbFiles.SelectedIndex < Program.AkiArchiveFileDB.Entries[FileID].Count)
				{
					if (Program.AkiArchiveFileDB.Entries[FileID][lbFiles.SelectedIndex] != null)
					{
						ArchiveFileEntry arcE = Program.AkiArchiveFileDB.Entries[FileID][lbFiles.SelectedIndex];
						InfoStringBuilder.AppendLine();
						InfoStringBuilder.AppendLine(String.Format("File Type: {0}", arcE.FileType.ToString()));
						InfoStringBuilder.AppendLine(String.Format("Comment: {0}", arcE.Comment));
					}
				}
			}

			tbSelItemInfo.Text = InfoStringBuilder.ToString();
		}

		private void buttonViewHexEditor_Click(object sender, EventArgs e)
		{
			if (lbFiles.SelectedIndex < 0)
			{
				return;
			}

			HexViewer hv = Program.HexViewManager.NewViewerData(CurArchive.FileEntries[lbFiles.SelectedIndex].Data);
			hv.Show();
		}

		private void buttonOpenAs_Click(object sender, EventArgs e)
		{
			// todo: if filetype is known, automatically choose viewer

			Button b = (Button)sender;
			Point ptLowerLeft = new Point(0, b.Height);
			ptLowerLeft = b.PointToScreen(ptLowerLeft);
			cmsOpenAs.Show(ptLowerLeft);
		}

		private void akiTextureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbFiles.SelectedIndex < 0)
			{
				return;
			}

			TexPreviewDialog tpd = new TexPreviewDialog(CurArchive.FileEntries[lbFiles.SelectedIndex].Data);
			tpd.Show();
		}

		private void iTextureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbFiles.SelectedIndex < 0)
			{
				return;
			}

			ITexturePreviewDialog ipd = new ITexturePreviewDialog(CurArchive.FileEntries[lbFiles.SelectedIndex].Data);
			ipd.Show();
		}

		private void cI4PaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbFiles.SelectedIndex < 0)
			{
				return;
			}

			CiPaletteEditor cpd = new CiPaletteEditor(CurArchive.FileEntries[lbFiles.SelectedIndex].Data);
			cpd.ShowDialog();
		}

		private void cI8PaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbFiles.SelectedIndex < 0)
			{
				return;
			}

			CiPaletteEditor cpd = new CiPaletteEditor(CurArchive.FileEntries[lbFiles.SelectedIndex].Data, true);
			cpd.ShowDialog();
		}
	}
}
