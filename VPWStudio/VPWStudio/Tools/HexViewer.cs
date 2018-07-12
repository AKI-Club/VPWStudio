using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public enum HexViewerDataSource
	{
		/// <summary>
		/// Data from a FileTable entry.
		/// </summary>
		FileTable = 0,

		/// <summary>
		/// External data passed in
		/// </summary>
		ExternalData
	}

	/// <summary>
	/// Quick and dirty hex dump viewer.
	/// </summary>
	public partial class HexViewer : Form
	{
		/// <summary>
		/// 
		/// </summary>
		public HexViewerDataSource ViewSource;

		#region Constructors
		/// <summary>
		/// HexViewer constructor using FileTable ID.
		/// </summary>
		/// <param name="fileID"></param>
		public HexViewer(int fileID)
		{
			InitializeComponent();
			byteViewer.SetDisplayMode(DisplayMode.Hexdump);
			ViewSource = HexViewerDataSource.FileTable;
			LoadFile(fileID);
		}

		/// <summary>
		/// HexViewer constructor using external data.
		/// </summary>
		/// <param name="data"></param>
		public HexViewer(byte[] data)
		{
			InitializeComponent();
			byteViewer.SetDisplayMode(DisplayMode.Hexdump);
			ViewSource = HexViewerDataSource.ExternalData;
			byteViewer.SetBytes(data);
		}
		#endregion

		public void RequestLoad(int fileID) => LoadFile(fileID);

		/// <summary>
		/// Load a file from the current project's filetable.
		/// </summary>
		/// <param name="fileID"></param>
		private void LoadFile(int fileID)
		{
			if (!Program.CurrentProject.ProjectFileTable.Entries.ContainsKey(fileID))
			{
				MessageBox.Show(
					String.Format("Error attempting to load file ID {0:X4}", fileID),
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream extractStream = new MemoryStream();
			BinaryWriter extractWriter = new BinaryWriter(extractStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extractWriter, fileID);
			romReader.Close();

			int size = (int)extractStream.Position;
			extractStream.Seek(0, SeekOrigin.Begin);
			BinaryReader br = new BinaryReader(extractStream);
			byte[] data = br.ReadBytes(size);
			br.Close();
			extractWriter.Close();

			byteViewer.SetBytes(data);
			Text = String.Format("Hex Viewer [{0:X4}]", fileID);
		}
	}
}
