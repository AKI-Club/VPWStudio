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

		/// <summary>
		/// Fallback character list if an AkiFontChars entry is not found.
		/// </summary>
		private SortedList<int, string> FallbackCharacters = new SortedList<int, string>()
		{
			{ 0, "　" },
			{ 1, "、" },
			{ 2, "。" },
			{ 3, "，" },
			{ 4, "．" },
			{ 5, "・" },
			{ 6, "：" },
			{ 7, "？" },
			{ 8, "！" },
			{ 9, "゛" },
			{ 10, "゜" },
			{ 11, "々" },
			{ 12, "ー" },
			{ 13, "／" },
			{ 14, "～" },
			{ 15, "｜" },
			{ 16, "’" },
			{ 17, "”" },
			{ 18, "（" },
			{ 19, "）" },
			{ 20, "［" },
			{ 21, "］" },
			{ 22, "｛" },
			{ 23, "｝" },
			{ 24, "「" },
			{ 25, "」" },
			{ 26, "＋" },
			{ 27, "－" },
			{ 28, "×" },
			{ 29, "＝" },
			{ 30, "＜" },
			{ 31, "＞" },
			{ 32, "￥" },
			{ 33, "＄" },
			{ 34, "％" },
			{ 35, "＃" },
			{ 36, "＆" },
			{ 37, "＊" },
			{ 38, "＠" },
			{ 39, "☆" },
			{ 40, "○" },
			{ 41, "△" },
			{ 42, "→" },
			{ 43, "←" },
			{ 44, "０" },
			{ 45, "１" },
			{ 46, "２" },
			{ 47, "３" },
			{ 48, "４" },
			{ 49, "５" },
			{ 50, "６" },
			{ 51, "７" },
			{ 52, "８" },
			{ 53, "９" },
			{ 54, "Ａ" },
			{ 55, "Ｂ" },
			{ 56, "Ｃ" },
			{ 57, "Ｄ" },
			{ 58, "Ｅ" },
			{ 59, "Ｆ" },
			{ 60, "Ｇ" },
			{ 61, "Ｈ" },
			{ 62, "Ｉ" },
			{ 63, "Ｊ" },
			{ 64, "Ｋ" },
			{ 65, "Ｌ" },
			{ 66, "Ｍ" },
			{ 67, "Ｎ" },
			{ 68, "Ｏ" },
			{ 69, "Ｐ" },
			{ 70, "Ｑ" },
			{ 71, "Ｒ" },
			{ 72, "Ｓ" },
			{ 73, "Ｔ" },
			{ 74, "Ｕ" },
			{ 75, "Ｖ" },
			{ 76, "Ｗ" },
			{ 77, "Ｘ" },
			{ 78, "Ｙ" },
			{ 79, "Ｚ" },
			{ 80, "ａ" },
			{ 81, "ｂ" },
			{ 82, "ｃ" },
			{ 83, "ｄ" },
			{ 84, "ｅ" },
			{ 85, "ｆ" },
			{ 86, "ｇ" },
			{ 87, "ｈ" },
			{ 88, "ｉ" },
			{ 89, "ｊ" },
			{ 90, "ｋ" },
			{ 91, "ｌ" },
			{ 92, "ｍ" },
			{ 93, "ｎ" },
			{ 94, "ｏ" },
			{ 95, "ｐ" },
			{ 96, "ｑ" },
			{ 97, "ｒ" },
			{ 98, "ｓ" },
			{ 99, "ｔ" },
			{ 100, "ｕ" },
			{ 101, "ｖ" },
			{ 102, "ｗ" },
			{ 103, "ｘ" },
			{ 104, "ｙ" },
			{ 105, "ｚ" }
		};

		public FontDialog(int fileID, int charsID = 0)
		{
			InitializeComponent();
			LoadFont(fileID);
			if (charsID > 0)
			{
				LoadCharacters(charsID);
				PopulateCharacterList();
			}
			else
			{
				// fallback charset
				FontCharacters = FallbackCharacters;
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
		/// xxx: this should probably take in more arguments...
		private void LoadFont(string fontPath)
		{
			using (FileStream fs = new FileStream(fontPath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurFont = new AkiFont();
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
		/// 
		/// </summary>
		/// <param name="charsID"></param>
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
			pbCharacterPreview.Image = CurFont.GetCharacterBitmap(lbCharacters.SelectedIndex);
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
