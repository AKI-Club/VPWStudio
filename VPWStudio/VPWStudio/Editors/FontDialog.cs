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
	public partial class FontDialog : Form
	{
		/// <summary>
		/// AkiFont to view
		/// </summary>
		public AkiFont CurFont = new AkiFont();

		/// <summary>
		/// Characters in the font.
		/// </summary>
		private SortedList<int, string> FontCharacters = new SortedList<int, string>();

		public FontDialog(int fileID, int charsID)
		{
			InitializeComponent();
			LoadFont(fileID);
			LoadCharacters(charsID);
		}

		/// <summary>
		/// Load font from file ID
		/// </summary>
		/// <param name="fileID">File ID of AkiFont data.</param>
		private void LoadFont(int fileID)
		{
			// rom bullshit

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream fontStream = new MemoryStream();
			BinaryWriter fontWriter = new BinaryWriter(fontStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fontWriter, fileID);

			fontStream.Seek(0, SeekOrigin.Begin);
			BinaryReader fontReader = new BinaryReader(fontStream);
			CurFont.ReadData(fontReader);
			fontReader.Close();
			romReader.Close();

			// AkiSmallFont vs. AkiLargeFont is determined by FileType
			//Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType
		}

		/// <summary>
		/// Load font from external file
		/// </summary>
		/// <param name="fontPath">Path to AkiFont data file.</param>
		/// xxx: this should probably take in more arguments...
		private void LoadFont(string fontPath)
		{
			using (FileStream fs = new FileStream(fontPath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurFont = new AkiFont();
					CurFont.ReadData(br);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="charsID"></param>
		private void LoadCharacters(int charsID)
		{
			// add items to FontCharacters
			/*
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream charsStream = new MemoryStream();
			BinaryWriter charsWriter = new BinaryWriter(charsStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, charsWriter, charsID);

			romReader.Close();
			charsStream.Seek(0, SeekOrigin.Begin);
			*/
		}

		/// <summary>
		/// Populate the character listbox
		/// </summary>
		private void PopulateCharacterList()
		{
			lbCharacters.Items.Clear();
			lbCharacters.BeginUpdate();

			// todo: FontCharacters needs to be populated somehow...
			if (FontCharacters.Count > 0)
			{
				foreach (string c in FontCharacters.Values)
				{
					lbCharacters.Items.Add(c);
				}
			}
			else
			{
				// otherwise, we have to fall back.
				// (this is OK for the non-japanese games...)
			}

			lbCharacters.EndUpdate();
		}

		/// <summary>
		/// Selected a new character.
		/// </summary>
		private void lbCharacters_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbCharacters.SelectedIndex < 0)
			{
				return;
			}

			// update preview
		}

		/// <summary>
		/// Export the current font to a PNG file.
		/// </summary>
		private void buttonExportFontGraphic_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "PNG Files (*.png)|*.png";
			sfd.Title = "Export Font Graphic";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				CurFont.ToBitmap().Save(sfd.FileName);
			}
		}
	}
}
