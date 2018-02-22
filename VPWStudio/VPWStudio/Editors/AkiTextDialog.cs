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
	public partial class AkiTextDialog : Form
	{
		private AkiText CurAkiText = new AkiText();

		private List<int> AkiTextIDs = new List<int>();

		public AkiTextDialog(int fileID = 0)
		{
			InitializeComponent();
			PopulateAkiTextList();

			if (fileID != 0)
			{
				LoadFromID(fileID);
				cbAvailableAkiText.SelectedIndex = AkiTextIDs.IndexOf(fileID);
			}
		}

		/// <summary>
		/// Load AkiText from file ID.
		/// </summary>
		/// <param name="fileID"></param>
		private void LoadFromID(int fileID)
		{
			CurAkiText = new AkiText();

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			bool lzss = Program.CurrentProject.ProjectFileTable.Entries[fileID].IsEncoded;
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, fileID, lzss);
			romReader.Close();

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			CurAkiText.Decode(outReader);

			outReader.Close();
			outWriter.Close();

			PopulateStringList();
		}

		/// <summary>
		/// Populate the list of known AkiText items.
		/// </summary>
		private void PopulateAkiTextList()
		{
			cbAvailableAkiText.Items.Clear();
			AkiTextIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.AkiText);
			cbAvailableAkiText.BeginUpdate();
			foreach (int i in AkiTextIDs)
			{
				cbAvailableAkiText.Items.Add(String.Format("{0:X4}", i));
			}
			cbAvailableAkiText.EndUpdate();
		}

		/// <summary>
		/// Populate the string list of the selected item.
		/// </summary>
		private void PopulateStringList()
		{
			lbEntries.Items.Clear();
			lbEntries.BeginUpdate();
			foreach (KeyValuePair<int, AkiTextEntry> entry in CurAkiText.Entries)
			{
				lbEntries.Items.Add(entry.Value.Text);
			}
			lbEntries.EndUpdate();
		}

		/// <summary>
		/// Selected a new text entry.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lbEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbEntries.SelectedIndex < 0)
			{
				return;
			}

			tbTextValue.Text = CurAkiText.Entries[lbEntries.SelectedIndex].Text.Replace("\n","\r\n");
		}

		/// <summary>
		/// Selected a new AkiText archive.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbAvailableAkiText_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbAvailableAkiText.SelectedIndex < 0)
			{
				return;
			}

			LoadFromID(AkiTextIDs[cbAvailableAkiText.SelectedIndex]);
		}
	}
}
