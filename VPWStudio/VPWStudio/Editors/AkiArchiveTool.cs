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
	public partial class AkiArchiveTool : Form
	{
		public int FileID = -1;

		public AkiArchive CurArchive;

		private const string FormTitle = "AKI Archive Tool [File {0:X4}]";

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
				lbFiles.Items.Add(String.Format("File {0}", i));
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
				Title="Extract File"
			};
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
			tbSelItemInfo.Text = String.Format(
				"File Index {0}:\r\nStart Offset: 0x{1:X8}\r\nFile Size: 0x{2:X8}\r\n\r\n",
				lbFiles.SelectedIndex,
				aae.StartAddr,
				aae.Size
			);
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
	}
}
