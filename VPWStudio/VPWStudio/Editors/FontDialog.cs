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
	/// <summary>
	/// Font Dialog
	/// </summary>
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

		public FontDialog(int fileID, int charsID = 0)
		{
			InitializeComponent();

			if (Program.CurrentProject.ProjectFileTable.Entries[fileID].HasReplacementFile())
			{
				LoadFont(Program.ConvertRelativePath(Program.CurrentProject.ProjectFileTable.Entries[fileID].ReplaceFilePath),
					Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType == FileTypes.AkiLargeFont ? AkiFontType.AkiLargeFont : AkiFontType.AkiSmallFont);
			}
			else
			{
				LoadFont(fileID);
			}

			Text = String.Format("Fonts - File ID {0:X4}",fileID);
			if (charsID > 0)
			{
				LoadCharacters(charsID);
				PopulateCharacterList();
			}
			else
			{
				// fallback charset
				switch (Program.CurrentProject.Settings.BaseGame)
				{
					case VPWGames.WorldTour:
						if (CurFont.FontType == AkiFontType.AkiSmallFont)
						{
							FontCharacters = AkiFont.FallbackCharacters_WorldTour_Small;
						}
						else
						{
							FontCharacters = AkiFont.FallbackCharacters_WorldTour_Large;
						}
						break;

					case VPWGames.Revenge:
						if (CurFont.FontType == AkiFontType.AkiSmallFont)
						{
							FontCharacters = AkiFont.FallbackCharacters_Revenge_Small;
						}
						else
						{
							FontCharacters = AkiFont.FallbackCharacters_Revenge_Large;
						}
						break;

					default:
						FontCharacters = AkiFont.FallbackCharacters;
						tbTemp.BackColor = Color.FromArgb(255, 208, 240, 255);
						break;
				}

				PopulateCharacterList();
			}
		}

		/// <summary>
		/// Load font from file ID
		/// </summary>
		/// <param name="fileID">File ID of AkiFont data.</param>
		private void LoadFont(int fileID)
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream fontStream = new MemoryStream();
			BinaryWriter fontWriter = new BinaryWriter(fontStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fontWriter, fileID);

			fontStream.Seek(0, SeekOrigin.Begin);
			BinaryReader fontReader = new BinaryReader(fontStream);
			CurFont = new AkiFont(
				(Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType == FileTypes.AkiLargeFont) ? AkiFontType.AkiLargeFont : AkiFontType.AkiSmallFont,
				Program.CurrentProject.Settings.BaseGame
			);
			CurFont.ReadData(fontReader);
			fontReader.Close();
			romReader.Close();
			UpdateValues();
		}

		/// <summary>
		/// Load font from external file
		/// </summary>
		/// <param name="fontPath">Path to AkiFont data file.</param>
		/// <param name="fontType">Which font type to load the data as.</param>
		private void LoadFont(string fontPath, AkiFontType fontType)
		{
			using (FileStream fs = new FileStream(fontPath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurFont = new AkiFont(fontType, Program.CurrentProject.Settings.BaseGame);
					CurFont.ReadData(br);
					UpdateValues();
				}
			}
		}

		/// <summary>
		/// Update data labels
		/// </summary>
		private void UpdateValues()
		{
			labelFontTypeValue.Text = CurFont.FontType.ToString();
			labelNumCharsValue.Text = CurFont.NumCharacters.ToString();
			labelCharWidthValue.Text = (CurFont.FontType == AkiFontType.AkiLargeFont) ? "24" : "16";
			labelCharHeightValue.Text = CurFont.CellHeight.ToString();
		}

		/// <summary>
		/// Load font characters from File ID. Assumes Shift-JIS encoding.
		/// </summary>
		/// <param name="charsID">File ID with character list.</param>
		private void LoadCharacters(int charsID)
		{
			// add items to FontCharacters
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream charsStream = new MemoryStream();
			BinaryWriter charsWriter = new BinaryWriter(charsStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, charsWriter, charsID);

			romReader.Close();
			charsStream.Seek(0, SeekOrigin.Begin);
			BinaryReader br = new BinaryReader(charsStream);
			for (int i = 0; i < CurFont.NumCharacters; i++)
			{
				byte[] temp = br.ReadBytes(2);
				FontCharacters[i] = Encoding.GetEncoding("Shift-JIS").GetString(temp);
			}
			br.Close();
		}

		/// <summary>
		/// Populate the character listbox.
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
			pbCharacterPreview.Image = CurFont.GetCharacterBitmap(lbCharacters.SelectedIndex);

			if (CurFont.FontType == AkiFontType.AkiLargeFont)
			{
				// Large font character header is 3 bytes
				tbTemp.Text = String.Format("0x{0:X2},0x{1:X2},0x{2:X2} (lead {0}; width {1})",
					CurFont.CharHeaders[lbCharacters.SelectedIndex][0],
					CurFont.CharHeaders[lbCharacters.SelectedIndex][1],
					CurFont.CharHeaders[lbCharacters.SelectedIndex][2]
				);
			}
			else
			{
				// Small font character header is 2 bytes
				tbTemp.Text = String.Format("0x{0:X2},0x{1:X2} (lead {2}; width {3})",
					CurFont.CharHeaders[lbCharacters.SelectedIndex][0],
					CurFont.CharHeaders[lbCharacters.SelectedIndex][1],
					(CurFont.CharHeaders[lbCharacters.SelectedIndex][1]&0xF0)>>4,
					(CurFont.CharHeaders[lbCharacters.SelectedIndex][1]&0x0F)
				);
			}
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

		private void FontDialog_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
