using System;
using System.IO;
using System.Windows.Forms;

namespace VPWStudio.Editors
{
	public partial class AkiTextEditor : Form
	{
		/// <summary>
		/// Current active text archive.
		/// </summary>
		public AkiText CurTextArchive = new AkiText();

		/// <summary>
		/// Original text archive.
		/// </summary>
		private AkiText OrigTextArchive = new AkiText();

		/// <summary>
		/// pseudo-crap
		/// </summary>
		private int FileKey = -1;

		#region Constructors
		/// <summary>
		/// Constructor using file ID.
		/// </summary>
		/// <param name="fileID">File ID of AkiText to load.</param>
		/// <param name="selectEntry">(optional) Entry number to select.</param>
		public AkiTextEditor(int fileID, int selectEntry = -1)
		{
			FileKey = fileID;
			InitializeComponent();
			LoadFromRom(fileID);
			OrigTextArchive.DeepCopy(CurTextArchive);
			PopulateEntryList();

			Text = String.Format("AKI Text Editor - [{0:X4}]", FileKey);
			string comment = Program.CurrentProject.ProjectFileTable.Entries[FileKey].Comment;
			if (!String.IsNullOrEmpty(comment))
			{
				Text += String.Format(" {0}", comment);
			}

			if (selectEntry != -1)
			{
				cbTextEntries.SelectedIndex = selectEntry;
			}
		}

		/// <summary>
		/// Constructor using file path.
		/// </summary>
		/// <param name="path">Path to AkiText to load.</param>
		/// <param name="selectEntry">(optional) Entry number to select.</param>
		public AkiTextEditor(string path, int selectEntry = -1)
		{
			InitializeComponent();
			LoadFromFile(path);
			OrigTextArchive.DeepCopy(CurTextArchive);
			PopulateEntryList();

			Text = String.Format("AKI Text Editor - {0}", Program.ShortenAbsolutePath(path));

			if (selectEntry != -1)
			{
				cbTextEntries.SelectedIndex = selectEntry;
			}
		}
		#endregion

		/// <summary>
		/// Add all entries from the AkiText archive to the dropdown list.
		/// </summary>
		private void PopulateEntryList()
		{
			cbTextEntries.Items.Clear();
			cbTextEntries.BeginUpdate();
			for (int i = 0; i < CurTextArchive.Entries.Count; i++)
			{
				cbTextEntries.Items.Add(String.Format("Entry {0}: {1}", i, CurTextArchive.Entries[i].Text));
			}
			cbTextEntries.EndUpdate();
			cbTextEntries.SelectedIndex = 0;
		}

		/// <summary>
		/// Load AkiText archive from the current ROM.
		/// </summary>
		/// <param name="fileID"></param>
		private void LoadFromRom(int fileID)
		{
			CurTextArchive = new AkiText();
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, fileID);
			romReader.Close();

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			CurTextArchive.ReadData(outReader);

			outReader.Close();
			outWriter.Close();
		}

		/// <summary>
		/// Load AkiText archive from a file on disk.
		/// </summary>
		/// <param name="path">Path to AkiText archive to open.</param>
		private void LoadFromFile(string path)
		{
			CurTextArchive = new AkiText();

			using (FileStream fs = new FileStream(path, FileMode.Open))
			{
				// someone might have put a CSV file here...
				if (Path.GetExtension(path) == ".csv")
				{
					// Zoinkity's CSV format
					using (StreamReader sr = new StreamReader(fs))
					{
						CurTextArchive.ReadCsv(sr);
					}
				}
				else if (Path.GetExtension(path) == ".txt")
				{
					// akitext command line tool format
					using (StreamReader sr = new StreamReader(fs))
					{
						CurTextArchive.ReadToolImport(sr);
					}
				}
				else
				{
					// AkiText binary format
					using (BinaryReader br = new BinaryReader(fs))
					{
						CurTextArchive.ReadData(br);
					}
				}
			}
		}

		/// <summary>
		/// OK button
		/// </summary>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// Cancel button
		/// </summary>
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		// selected new entry
		private void cbTextEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTextEntries.SelectedIndex < 0)
			{
				return;
			}

			string oldText = OrigTextArchive.Entries[cbTextEntries.SelectedIndex].Text.Replace("\n", Environment.NewLine);
			string curText = CurTextArchive.Entries[cbTextEntries.SelectedIndex].Text.Replace("\n", Environment.NewLine);

			tbCurText.Text = oldText;
			tbNewText.Text = curText;
		}

		#region Import/Export Tab-separated CSV
		private void importTabCSVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Import Tab-separated CSV";
			ofd.Filter = SharedStrings.FileFilter_CSV;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
				{
					using (StreamReader sr = new StreamReader(fs))
					{
						CurTextArchive = new AkiText();
						CurTextArchive.ReadCsv(sr);
						PopulateEntryList();
					}
				}
			}
		}

		private void exportTabCSVToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Tab-separated CSV";
			sfd.Filter = SharedStrings.FileFilter_CSV;
			if (FileKey == -1)
			{
				// todo: we could make this better
				sfd.FileName = "export.csv";
			}
			else
			{
				sfd.FileName = String.Format("{0:X4}.csv", FileKey);
			}
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						CurTextArchive.WriteCsv(sw);
					}
				}
			}
		}
		#endregion

		#region Import/Export akitext command line tool format
		private void importAkiTextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Import akitext Command Line Tool Format";
			ofd.Filter = SharedStrings.FileFilter_TXT;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
				{
					using (StreamReader sr = new StreamReader(fs))
					{
						CurTextArchive = new AkiText();
						CurTextArchive.ReadToolImport(sr);
						PopulateEntryList();
					}
				}
			}
		}

		private void exportAkiTextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export akitext Command Line Tool Format";
			sfd.Filter = SharedStrings.FileFilter_CSV;
			if (FileKey == -1)
			{
				// todo: we could make this better
				sfd.FileName = "export.txt";
			}
			else
			{
				sfd.FileName = String.Format("{0:X4}.txt", FileKey);
			}
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						CurTextArchive.WriteToolExport(sw);
					}
				}
			}
		}
		#endregion

		/// <summary>
		/// Editing active text entry
		/// </summary>
		private void tbNewText_KeyUp(object sender, KeyEventArgs e)
		{
			CurTextArchive.Entries[cbTextEntries.SelectedIndex].Text = tbNewText.Text.Replace(Environment.NewLine, "\n");
		}

		/// <summary>
		/// Control code reference.
		/// Defined separately because... well, look how long it is.
		/// </summary>
		private static string KnownControlCodes = "Known control codes:\n" +
			"@B - Text Color Blue\n" +
			"@C - Text Color Cyan\n" +
			"@D - Default text color\n" +
			"@G - Text Color Green\n" +
			"@H - hidden costume item?\n" +
			"@h - hidden move item?\n" +
			"@K - Text Color Black\n" +
			"@O - Text Color Orange\n" +
			"@P - Text Color Gray\n" +
			"@R - Text Color Red\n" +
			"@W - Text Color White\n" +
			"@Y - Text Color Yellow\n" +
			"%### - Short name of Wrestler with ID4 ###\n" +
			"$0 - A button\n" +
			"$1 - B button\n" +
			"$2 - L button\n" +
			"$3 - R button\n" +
			"$4 - Z button\n" +
			"$5 - 3D Stick\n" +
			"$6 - C Up\n" +
			"$7 - C Down\n" +
			"$8 - C Left\n" +
			"$9 - C Right\n" +
			"$a - D-Pad Up\n" +
			"$b - D-Pad Down\n" +
			"$c - D-Pad Left\n" +
			"$d - D-Pad Right\n" +
			"$e - Start button\n"+
			"$f - D-Pad";

		/// <summary>
		/// Show the Control Codes reference.
		/// </summary>
		private void buttonControlCodes_Click(object sender, EventArgs e)
		{
			Program.InfoMessageBox(KnownControlCodes);
		}

	}
}
