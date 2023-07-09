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

		#region Fallback Character Sets
		// todo: these probably belong somewhere else, as to not get loaded each time the form is loaded

		/// <summary>
		/// Fallback character list for WCW vs. nWo World Tour small font.
		/// </summary>
		private readonly SortedList<int, string> FallbackCharacters_WorldTour_Small = new SortedList<int, string>()
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
			{ 22, "「" },
			{ 23, "」" },
			{ 24, "+" },
			{ 25, "-" },
			{ 26, "×" },
			{ 27, "=" },
			{ 28, "%" },
			{ 29, "#" },
			{ 30, "&" },
			{ 31, "*" },
			{ 32, "@" },
			{ 33, "○" },
			{ 34, "△" },
			{ 35, "►" },
			{ 36, "◄" },
			{ 37, "▲" },
			{ 38, "▼" },
			{ 39, "０" },
			{ 40, "１" },
			{ 41, "２" },
			{ 42, "３" },
			{ 43, "４" },
			{ 44, "５" },
			{ 45, "６" },
			{ 46, "７" },
			{ 47, "８" },
			{ 48, "９" },
			{ 49, "Ａ" },
			{ 50, "Ｂ" },
			{ 51, "Ｃ" },
			{ 52, "Ｄ" },
			{ 53, "Ｅ" },
			{ 54, "Ｆ" },
			{ 55, "Ｇ" },
			{ 56, "Ｈ" },
			{ 57, "Ｉ" },
			{ 58, "Ｊ" },
			{ 59, "Ｋ" },
			{ 60, "Ｌ" },
			{ 61, "Ｍ" },
			{ 62, "Ｎ" },
			{ 63, "Ｏ" },
			{ 64, "Ｐ" },
			{ 65, "Ｑ" },
			{ 66, "Ｒ" },
			{ 67, "Ｓ" },
			{ 68, "Ｔ" },
			{ 69, "Ｕ" },
			{ 70, "Ｖ" },
			{ 71, "Ｗ" },
			{ 72, "Ｘ" },
			{ 73, "Ｙ" },
			{ 74, "Ｚ" },
			{ 75, "ａ" },
			{ 76, "ｂ" },
			{ 77, "ｃ" },
			{ 78, "ｄ" },
			{ 79, "ｅ" },
			{ 80, "ｆ" },
			{ 81, "ｇ" },
			{ 82, "ｈ" },
			{ 83, "ｉ" },
			{ 84, "ｊ" },
			{ 85, "ｋ" },
			{ 86, "ｌ" },
			{ 87, "ｍ" },
			{ 88, "ｎ" },
			{ 89, "ｏ" },
			{ 90, "ｐ" },
			{ 91, "ｑ" },
			{ 92, "ｒ" },
			{ 93, "ｓ" },
			{ 94, "ｔ" },
			{ 95, "ｕ" },
			{ 96, "ｖ" },
			{ 97, "ｗ" },
			{ 98, "ｘ" },
			{ 99, "ｙ" },
			{ 100, "ｚ" },
			{ 101, "ぁ" },
			{ 102, "あ" },
			{ 103, "ぃ" },
			{ 104, "い" },
			{ 105, "ぅ" },
			{ 106, "う" },
			{ 107, "ぇ" },
			{ 108, "え" },
			{ 109, "ぉ" },
			{ 110, "お" },
			{ 111, "か" }
		};

		/// <summary>
		/// Fallback character list for WCW vs. nWo World Tour large font.
		/// </summary>
		private readonly SortedList<int, string> FallbackCharacters_WorldTour_Large = new SortedList<int, string>()
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
			{ 22, "「" },
			{ 23, "」" },
			{ 24, "+" },
			{ 25, "-" },
			{ 26, "×" },
			{ 27, "=" },
			{ 28, "%" },
			{ 29, "#" },
			{ 30, "&" },
			{ 31, "*" },
			{ 32, "@" },
			{ 33, "○" },
			{ 34, "△" },
			{ 35, "０" },
			{ 36, "１" },
			{ 37, "２" },
			{ 38, "３" },
			{ 39, "４" },
			{ 40, "５" },
			{ 41, "６" },
			{ 42, "７" },
			{ 43, "８" },
			{ 44, "９" },
			{ 45, "Ａ" },
			{ 46, "Ｂ" },
			{ 47, "Ｃ" },
			{ 48, "Ｄ" },
			{ 49, "Ｅ" },
			{ 50, "Ｆ" },
			{ 51, "Ｇ" },
			{ 52, "Ｈ" },
			{ 53, "Ｉ" },
			{ 54, "Ｊ" },
			{ 55, "Ｋ" },
			{ 56, "Ｌ" },
			{ 57, "Ｍ" },
			{ 58, "Ｎ" },
			{ 59, "Ｏ" },
			{ 60, "Ｐ" },
			{ 61, "Ｑ" },
			{ 62, "Ｒ" },
			{ 63, "Ｓ" },
			{ 64, "Ｔ" },
			{ 65, "Ｕ" },
			{ 66, "Ｖ" },
			{ 67, "Ｗ" },
			{ 68, "Ｘ" },
			{ 69, "Ｙ" },
			{ 70, "Ｚ" },
			{ 71, "ａ" },
			{ 72, "ｂ" },
			{ 73, "ｃ" },
			{ 74, "ｄ" },
			{ 75, "ｅ" },
			{ 76, "ｆ" },
			{ 77, "ｇ" },
			{ 78, "ｈ" },
			{ 79, "ｉ" },
			{ 80, "ｊ" },
			{ 81, "ｋ" },
			{ 82, "ｌ" },
			{ 83, "ｍ" },
			{ 84, "ｎ" },
			{ 85, "ｏ" },
			{ 86, "ｐ" },
			{ 87, "ｑ" },
			{ 88, "ｒ" },
			{ 89, "ｓ" },
			{ 90, "ｔ" },
			{ 91, "ｕ" },
			{ 92, "ｖ" },
			{ 93, "ｗ" },
			{ 94, "ｘ" },
			{ 95, "ｙ" },
			{ 96, "ｚ" },
			{ 97, "ぁ" },
			{ 98, "あ" },
			{ 99, "ぃ" }
		};

		/// <summary>
		/// Fallback character list for WCW vs. nWo Revenge small font.
		/// </summary>
		private readonly SortedList<int, string> FallbackCharacters_Revenge_Small = new SortedList<int, string>()
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
			{ 22, "「" },
			{ 23, "」" },
			{ 24, "+" },
			{ 25, "-" },
			{ 26, "×" },
			{ 27, "=" },
			{ 28, "%" },
			{ 29, "#" },
			{ 30, "&" },
			{ 31, "*" },
			{ 32, "@" },
			{ 33, "○" },
			{ 34, "△" },
			{ 35, "►" },
			{ 36, "◄" },
			{ 37, "▲" },
			{ 38, "▼" },
			{ 39, "０" },
			{ 40, "１" },
			{ 41, "２" },
			{ 42, "３" },
			{ 43, "４" },
			{ 44, "５" },
			{ 45, "６" },
			{ 46, "７" },
			{ 47, "８" },
			{ 48, "９" },
			{ 49, "Ａ" },
			{ 50, "Ｂ" },
			{ 51, "Ｃ" },
			{ 52, "Ｄ" },
			{ 53, "Ｅ" },
			{ 54, "Ｆ" },
			{ 55, "Ｇ" },
			{ 56, "Ｈ" },
			{ 57, "Ｉ" },
			{ 58, "Ｊ" },
			{ 59, "Ｋ" },
			{ 60, "Ｌ" },
			{ 61, "Ｍ" },
			{ 62, "Ｎ" },
			{ 63, "Ｏ" },
			{ 64, "Ｐ" },
			{ 65, "Ｑ" },
			{ 66, "Ｒ" },
			{ 67, "Ｓ" },
			{ 68, "Ｔ" },
			{ 69, "Ｕ" },
			{ 70, "Ｖ" },
			{ 71, "Ｗ" },
			{ 72, "Ｘ" },
			{ 73, "Ｙ" },
			{ 74, "Ｚ" },
			{ 75, "ａ" },
			{ 76, "ｂ" },
			{ 77, "ｃ" },
			{ 78, "ｄ" },
			{ 79, "ｅ" },
			{ 80, "ｆ" },
			{ 81, "ｇ" },
			{ 82, "ｈ" },
			{ 83, "ｉ" },
			{ 84, "ｊ" },
			{ 85, "ｋ" },
			{ 86, "ｌ" },
			{ 87, "ｍ" },
			{ 88, "ｎ" },
			{ 89, "ｏ" },
			{ 90, "ｐ" },
			{ 91, "ｑ" },
			{ 92, "ｒ" },
			{ 93, "ｓ" },
			{ 94, "ｔ" },
			{ 95, "ｕ" },
			{ 96, "ｖ" },
			{ 97, "ｗ" },
			{ 98, "ｘ" },
			{ 99, "ｙ" },
			{ 100, "ｚ" },
			{ 101, "●" },
			{ 102, "◎" },
			{ 103, "■" },
			{ 104, "◆" },
			{ 105, "♂" },
			{ 106, "♀" },
			{ 107, "♪" },
			{ 108, "★" },
			{ 109, "∞" },
			{ 110, "_" },
			{ 111, "?" },
			{ 112, "Ⅰ" },
			{ 113, "Ⅱ" },
			{ 114, "Ⅲ" },
			{ 115, "Ⅳ" },
			{ 116, "Ⅴ" },
			{ 117, "Ⅵ" },
			{ 118, "Ⅶ" },
			{ 119, "Ⅷ" },
			{ 120, "Ⅸ" },
			{ 121, "Ⅹ" },
			{ 122, "BS" },
			{ 123, "END" },
			{ 124, "?" },
			{ 125, "?" },
			{ 126, "?" },
			{ 127, "?" }
		};

		/// <summary>
		/// Fallback character list for WCW vs. nWo Revenge large font.
		/// </summary>
		private readonly SortedList<int, string> FallbackCharacters_Revenge_Large = new SortedList<int, string>()
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
			{ 22, "「" },
			{ 23, "」" },
			{ 24, "+" },
			{ 25, "-" },
			{ 26, "×" },
			{ 27, "=" },
			{ 28, "%" },
			{ 29, "#" },
			{ 30, "&" },
			{ 31, "*" },
			{ 32, "@" },
			{ 33, "○" },
			{ 34, "△" },
			{ 35, "０" },
			{ 36, "１" },
			{ 37, "２" },
			{ 38, "３" },
			{ 39, "４" },
			{ 40, "５" },
			{ 41, "６" },
			{ 42, "７" },
			{ 43, "８" },
			{ 44, "９" },
			{ 45, "Ａ" },
			{ 46, "Ｂ" },
			{ 47, "Ｃ" },
			{ 48, "Ｄ" },
			{ 49, "Ｅ" },
			{ 50, "Ｆ" },
			{ 51, "Ｇ" },
			{ 52, "Ｈ" },
			{ 53, "Ｉ" },
			{ 54, "Ｊ" },
			{ 55, "Ｋ" },
			{ 56, "Ｌ" },
			{ 57, "Ｍ" },
			{ 58, "Ｎ" },
			{ 59, "Ｏ" },
			{ 60, "Ｐ" },
			{ 61, "Ｑ" },
			{ 62, "Ｒ" },
			{ 63, "Ｓ" },
			{ 64, "Ｔ" },
			{ 65, "Ｕ" },
			{ 66, "Ｖ" },
			{ 67, "Ｗ" },
			{ 68, "Ｘ" },
			{ 69, "Ｙ" },
			{ 70, "Ｚ" },
			{ 71, "ａ" },
			{ 72, "ｂ" },
			{ 73, "ｃ" },
			{ 74, "ｄ" },
			{ 75, "ｅ" },
			{ 76, "ｆ" },
			{ 77, "ｇ" },
			{ 78, "ｈ" },
			{ 79, "ｉ" },
			{ 80, "ｊ" },
			{ 81, "ｋ" },
			{ 82, "ｌ" },
			{ 83, "ｍ" },
			{ 84, "ｎ" },
			{ 85, "ｏ" },
			{ 86, "ｐ" },
			{ 87, "ｑ" },
			{ 88, "ｒ" },
			{ 89, "ｓ" },
			{ 90, "ｔ" },
			{ 91, "ｕ" },
			{ 92, "ｖ" },
			{ 93, "ｗ" },
			{ 94, "ｘ" },
			{ 95, "ｙ" },
			{ 96, "ｚ" },
			{ 97, "●" },
			{ 98, "◎" },
			{ 99, "■" },
			{ 100, "◆" },
			{ 101, "♂" },
			{ 102, "♀" },
			{ 103, "♪" },
			{ 104, "★" },
			{ 105, "∞" },
			{ 106, "_" },
			{ 107, "Ⅰ" },
			{ 108, "Ⅱ" },
			{ 109, "Ⅲ" },
			{ 110, "Ⅳ" },
			{ 111, "Ⅴ" },
			{ 112, "Ⅵ" },
			{ 113, "Ⅶ" },
			{ 114, "Ⅷ" },
			{ 115, "Ⅸ" },
			{ 116, "Ⅹ" },
			{ 117, "BS" },
			{ 118, "END" },
			{ 119, "?" }
		};

		/// <summary>
		/// Fallback character list if an AkiFontChars entry is not found.
		/// </summary>
		private readonly SortedList<int, string> FallbackCharacters = new SortedList<int, string>()
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
		#endregion

		public FontDialog(int fileID, int charsID = 0)
		{
			InitializeComponent();
			LoadFont(fileID);
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
							FontCharacters = FallbackCharacters_WorldTour_Small;
						}
						else
						{
							FontCharacters = FallbackCharacters_WorldTour_Large;
						}
						break;

					case VPWGames.Revenge:
						if (CurFont.FontType == AkiFontType.AkiSmallFont)
						{
							FontCharacters = FallbackCharacters_Revenge_Small;
						}
						else
						{
							FontCharacters = FallbackCharacters_Revenge_Large;
						}
						break;

					default:
						FontCharacters = FallbackCharacters;
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

			if (CurFont.FontType == AkiFontType.AkiLargeFont)
			{
				// header is 3 bytes
				tbTemp.Text = String.Format("0x{0:X2}, 0x{1:X2}, 0x{2:X2}",
					CurFont.CharHeaders[lbCharacters.SelectedIndex][0],
					CurFont.CharHeaders[lbCharacters.SelectedIndex][1],
					CurFont.CharHeaders[lbCharacters.SelectedIndex][2]
				);
			}
			else
			{
				// header is 2 bytes
				tbTemp.Text = String.Format("0x{0:X2}, 0x{1:X2}", CurFont.CharHeaders[lbCharacters.SelectedIndex][0], CurFont.CharHeaders[lbCharacters.SelectedIndex][1]);
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
