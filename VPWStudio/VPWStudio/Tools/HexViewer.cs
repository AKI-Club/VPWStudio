using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace VPWStudio
{
	/// <summary>
	/// Source of the data passed into the HexViewer.
	/// </summary>
	public enum HexViewerDataSource
	{
		/// <summary>
		/// Data from a FileTable entry.
		/// </summary>
		FileTable = 0,

		/// <summary>
		/// External data passed in.
		/// </summary>
		ExternalData
	}

	/// <summary>
	/// Quick and dirty hex dump viewer.
	/// </summary>
	public partial class HexViewer : Form
	{
		#region Class Members
		/// <summary>
		/// Source of the data passed into the hex viewer.
		/// </summary>
		public HexViewerDataSource ViewSource;

		/// <summary>
		/// FileTable ID of loaded file (-1 if not loading from FileTable).
		/// </summary>
		public int FileID = -1;

		/// <summary>
		/// Data to be put in the HexViewer.
		/// </summary>
		public byte[] Data;
		#endregion

		#region Constructors
		/// <summary>
		/// HexViewer constructor.
		/// </summary>
		/// <param name="hvds">Viewer data source.</param>
		/// <param name="data">Data to load.</param>
		/// <param name="fileID">File ID, if loading from FileTable.</param>
		public HexViewer(HexViewerDataSource hvds, byte[] data, int fileID = -1)
		{
			InitializeComponent();
			byteViewer.SetDisplayMode(DisplayMode.Hexdump);
			ViewSource = hvds;
			byteViewer.SetBytes(data);
			FileID = fileID;

			if (FileID != -1)
			{
				Text = String.Format("Hex Viewer [{0:X4}]", fileID);
			}
		}
		#endregion

		/// <summary>
		/// Get the SHA256 hash of the currently loaded data.
		/// </summary>
		/// <returns>SHA256 of the data as byte array.</returns>
		public byte[] GetHash()
		{
			SHA256 sha256 = SHA256.Create();
			return sha256.ComputeHash(byteViewer.GetBytes());
		}

		/// <summary>
		/// Tell the hex viewer manager to remove this form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HexViewer_FormClosing(object sender, FormClosingEventArgs e)
		{
			Program.HexViewManager.FormClosed(this);
		}
	}
}
