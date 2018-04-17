using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
		/// <param name="fileID"></param>
		public AkiTextEditor(int fileID)
		{
			FileKey = fileID;
			InitializeComponent();
			LoadFromRom(fileID);
			OrigTextArchive.DeepCopy(CurTextArchive);
			PopulateEntryList();
		}

		/// <summary>
		/// Constructor using file path.
		/// </summary>
		/// <param name="path"></param>
		public AkiTextEditor(string path)
		{
			InitializeComponent();
			LoadFromFile(path);
			OrigTextArchive.DeepCopy(CurTextArchive);
			PopulateEntryList();
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
				cbTextEntries.Items.Add(String.Format("Entry {0}: {1}", i+1, CurTextArchive.Entries[i].Text));
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

		#region CSV Import/Export
		private void buttonImportCSV_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Import CSV";
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

		private void buttonExportCSV_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export CSV";
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

		private void tbNewText_KeyUp(object sender, KeyEventArgs e)
		{
			CurTextArchive.Entries[cbTextEntries.SelectedIndex].Text = tbNewText.Text.Replace(Environment.NewLine, "\n");
		}
	}
}
