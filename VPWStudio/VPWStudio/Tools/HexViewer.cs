using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using Be.Windows.Forms;

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
		/// Byte provider for the Be HexBox
		/// </summary>
		private DynamicByteProvider HexBoxByteProvider;
		#endregion

		#region Constructors
		/// <summary>
		/// HexViewer constructor.
		/// </summary>
		/// <param name="hvds">Viewer data source.</param>
		/// <param name="data">Data to load.</param>
		/// <param name="fileID">File ID, if loading from FileTable.</param>
		/// <param name="title">Title to use for hex viewer window.</param>
		public HexViewer(HexViewerDataSource hvds, byte[] data, int fileID = -1, string title = "")
		{
			InitializeComponent();
			labelHexViewStatus.Text = String.Empty;
			labelInsertMode.Text = hexBox1.InsertActive ? "INS" : "OVR";

			ViewSource = hvds;
			FileID = fileID;

			HexBoxByteProvider = new DynamicByteProvider(data);
			HexBoxByteProvider.Changed += HexDataChanged;
			hexBox1.ByteProvider = HexBoxByteProvider;

			if (FileID != -1)
			{
				Text = String.Format("Hex Viewer [{0:X4}]", fileID);
				string comment = Program.CurrentProject.ProjectFileTable.Entries[fileID].Comment;
				if (!String.IsNullOrEmpty(comment))
				{
					Text += " " + comment;
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(title))
				{
					Text = String.Format("Hex Viewer [{0}]", title);
				}
			}
		}
		#endregion

		public void HexDataChanged(object sender, EventArgs e)
		{
			if (hexBox1.ByteProvider.HasChanges())
			{
				labelHexViewStatus.Text = "Modified!";
			}
			else
			{
				labelHexViewStatus.Text = String.Empty;
			}
		}

		/// <summary>
		/// Get the SHA256 hash of the currently loaded data.
		/// </summary>
		/// <returns>SHA256 of the data as byte array.</returns>
		public byte[] GetHash()
		{
			SHA256 sha256 = SHA256.Create();
			return sha256.ComputeHash(HexBoxByteProvider.Bytes.ToArray());
		}

		/// <summary>
		/// Tell the hex viewer manager to remove this form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HexViewer_FormClosing(object sender, FormClosingEventArgs e)
		{
			// check if data has been modified, and ask to save changes if so.
			if (HexBoxByteProvider.HasChanges())
			{
				if (Program.QuestionMessageBox_YesNo("File has been modified. Do you want to save the changes?", MessageBoxIcon.Exclamation))
				{
					if (FileID != -1)
					{
						// replacing something in the FileTable
						if (Program.CurrentProject.ProjectFileTable.Entries[FileID].HasReplacementFile())
						{
							// replacement file already exists; update it
							string replaceFilePath = Program.ConvertRelativePath(Program.CurrentProject.ProjectFileTable.Entries[FileID].ReplaceFilePath);

							using (FileStream fs = new FileStream(replaceFilePath, FileMode.Open))
							{
								using (BinaryWriter br = new BinaryWriter(fs))
								{
									br.Write(HexBoxByteProvider.Bytes.ToArray());
								}
							}
						}
						else
						{
							// replacement file doesn't exist; create it in ProjectFiles dir
							string outFileName = string.Format("{0}\\{1:X4}.bin", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), FileID);
							using (FileStream fs = new FileStream(outFileName, FileMode.Create))
							{
								using (BinaryWriter br = new BinaryWriter(fs))
								{
									br.Write(HexBoxByteProvider.Bytes.ToArray());
								}
							}
							Program.CurrentProject.ProjectFileTable.Entries[FileID].ReplaceFilePath = Program.ShortenAbsolutePath(outFileName);
							Program.InfoMessageBox(string.Format("Wrote modified file to\n{0}", outFileName));
						}
					}
					else
					{
						// external file
						// HexViewer currently has no knowledge of files; all it knows is bytes.
					}
				}
			}

			IDisposable hbp = HexBoxByteProvider as IDisposable;
			if (hbp != null)
			{
				hbp.Dispose();
			}
			hexBox1.ByteProvider = null;

			Program.HexViewManager.FormClosed(this);
		}

		private void hexBox1_Copied(object sender, EventArgs e)
		{
			hexBox1.CopyHex();
			string hex = Clipboard.GetText().Replace(" ",String.Empty);
			Clipboard.SetText(hex);
		}

		private void hexBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
			{
				hexBox1.SelectAll();
			}

			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void hexBox1_InsertActiveChanged(object sender, EventArgs e)
		{
			labelInsertMode.Text = hexBox1.InsertActive ? "INS" : "OVR";
		}
	}
}
