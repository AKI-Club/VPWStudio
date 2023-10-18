using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// Possible AKI font types.
	/// </summary>
	public enum AkiFontType
	{
		/// <summary>
		/// 24px wide
		/// </summary>
		AkiLargeFont,

		/// <summary>
		/// 16px wide
		/// </summary>
		AkiSmallFont/*,

		/// <summary>
		/// the one used in No Mercy for in-match names (file ID 0396)
		/// </summary>
		/// Technically stored as 2x, or drawn at 0.5x or something like that.
		/// offset 0x00: byte imgWidth
		/// offset 0x01: byte imgHeight
		/// offset 0x02, 0x03: both values are 0x00
		/// 1bpp data follows, but not character-based like the other formats.
		AkiTinyFont
		*/
	}

	/// <summary>
	/// AKI font data.
	/// </summary>
	/// Some code in this class is based off of code in Zoinkity's Midwaydec.
	public class AkiFont
	{
		#region Fallback Character Sets
		/// <summary>
		/// Fallback character list for WCW vs. nWo World Tour small font.
		/// </summary>
		public static readonly SortedList<int, string> FallbackCharacters_WorldTour_Small = new SortedList<int, string>()
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
		public static readonly SortedList<int, string> FallbackCharacters_WorldTour_Large = new SortedList<int, string>()
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
		public static readonly SortedList<int, string> FallbackCharacters_Revenge_Small = new SortedList<int, string>()
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
		public static readonly SortedList<int, string> FallbackCharacters_Revenge_Large = new SortedList<int, string>()
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
		public static readonly SortedList<int, string> FallbackCharacters = new SortedList<int, string>()
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

		#region Constants
		// * FontHeight   - Character cell height
		// * FontChars    - Number of characters defined
		// * FontCols     - Number of columns in output image
		// * FontRows     - Number of rows in output image

		// WM2K Actual font characters: 103
		// VPW2 Actual font characters: 3253

		#region Large Font
		/// <summary>
		/// Large font character width is 24 pixels.
		/// </summary>
		public static readonly int LARGE_FONT_CHAR_WIDTH = 24;

		/// <summary>
		/// Large Font character height, in pixels.
		/// </summary>
		private static Dictionary<VPWGames, int> LargeFontHeight = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 23 },
			{ VPWGames.VPW64, 23 },
			{ VPWGames.Revenge, 23 },
			{ VPWGames.WM2K, 21 },
			{ VPWGames.VPW2, 21 },
			{ VPWGames.NoMercy, 22 },
		};

		/// <summary>
		/// Hardcoded number of characters in Large Fonts.
		/// </summary>
		/// Not exactly an ideal solution.
		private static Dictionary<VPWGames, int> LargeFontNumChars = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 100 },
			{ VPWGames.VPW64, 3240 },
			{ VPWGames.Revenge, 120 },
			{ VPWGames.WM2K, 110 },
			{ VPWGames.VPW2, 3260 },
			{ VPWGames.NoMercy, 110 },
		};

		/// <summary>
		/// Characters per row in Large Font image export.
		/// </summary>
		private static Dictionary<VPWGames, int> LargeFontOutCols = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 24 },
			{ VPWGames.VPW64, 24 },
			{ VPWGames.Revenge, 24 },
			{ VPWGames.WM2K, 16 },
			{ VPWGames.VPW2, 20 },
			{ VPWGames.NoMercy, 24 },
		};

		/// <summary>
		/// Number of rows in Large Font image export.
		/// </summary>
		/// This could possibly be calculated at runtime, but it's not.
		private static Dictionary<VPWGames, int> LargeFontOutRows = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 5 },
			{ VPWGames.VPW64, 135 },
			{ VPWGames.Revenge, 5 },
			{ VPWGames.WM2K, 7 },
			{ VPWGames.VPW2, 163 },
			{ VPWGames.NoMercy, 5 },
		};
		#endregion

		#region Small Font
		/// <summary>
		/// Small font character width is 16 pixels.
		/// </summary>
		public static readonly int SMALL_FONT_CHAR_WIDTH = 16;

		/// <summary>
		/// Small Font character heignt, in pixels.
		/// </summary>
		private static Dictionary<VPWGames, int> SmallFontHeight = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 14 },
			{ VPWGames.VPW64, 14 },
			{ VPWGames.Revenge, 14 },
			{ VPWGames.WM2K, 13 },
			{ VPWGames.VPW2, 13 },
			{ VPWGames.NoMercy, 14 },
		};

		/// <summary>
		/// Hardcoded number of characters in Small Fonts.
		/// </summary>
		/// Again, not ideal.
		private static Dictionary<VPWGames, int> SmallFontNumChars = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 112 },
			{ VPWGames.VPW64, 3248 },
			{ VPWGames.Revenge, 128 },
			{ VPWGames.WM2K, 112 },
			{ VPWGames.VPW2, 3264 },
			{ VPWGames.NoMercy, 112 },
		};

		/// <summary>
		/// Characters per row in Small Font image export.
		/// </summary>
		private static Dictionary<VPWGames, int> SmallFontOutCols = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 16 },
			{ VPWGames.VPW64, 16 },
			{ VPWGames.Revenge, 16 },
			{ VPWGames.WM2K, 16 },
			{ VPWGames.VPW2, 64 },
			{ VPWGames.NoMercy, 16 },
		};

		/// <summary>
		/// Number of rows in Small Font image export.
		/// </summary>
		/// Again, could be generated at runtime, but isn't.
		private static Dictionary<VPWGames, int> SmallFontOutRows = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 7 },
			{ VPWGames.VPW64, 203 },
			{ VPWGames.Revenge, 8 },
			{ VPWGames.WM2K, 7 },
			{ VPWGames.VPW2, 51 },
			{ VPWGames.NoMercy, 7 },
		};
		#endregion

		#endregion

		#region Class Members
		/// <summary>
		/// Font type (large or small)
		/// </summary>
		public AkiFontType FontType;

		/// <summary>
		/// Packed pixel data (1BPP)
		/// </summary>
		public List<byte> Data;

		/// <summary>
		/// Unpacked pixel data (1BPP)
		/// </summary>
		public List<byte> RawData;

		/// <summary>
		/// Character header data.
		/// (2 bytes for small fonts, 3 bytes for large fonts)
		/// </summary>

		/// [Small Fonts]
		/// offset 0x00 - unknown (always 0?)
		/// offset 0x01 - leading spacing and width
		/// 76543210
		/// |__||__|
		///  |    |
		///  |    +-- Character width?
		///  +------- Number of leading blank pixels?

		/// [Large Fonts]
		/// offset 0x00 - leading spacing?
		/// offset 0x01 - character width?
		/// offset 0x02 - unknown (always 0?)
		public Dictionary<int, byte[]> CharHeaders;

		/// <summary>
		/// Height of each character cell.
		/// </summary>
		public int CellHeight;

		/// <summary>
		/// Number of characters in the font data.
		/// </summary>
		public int NumCharacters;

		/// <summary>
		/// Number of columns to output.
		/// </summary>
		public int OutColumns;

		/// <summary>
		/// Number of rows to output.
		/// </summary>
		public int OutRows;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public AkiFont()
		{
			FontType = AkiFontType.AkiSmallFont;
			Data = new List<byte>();
			RawData = new List<byte>();
			CharHeaders = new Dictionary<int, byte[]>();

			CellHeight = 0;
			NumCharacters = 0;
			OutColumns = 0;
			OutRows = 0;
		}

		/// <summary>
		/// Specific constructor using specific game defaults.
		/// </summary>
		/// <param name="_ft">AkiFontType to use.</param>
		/// <param name="_game">VPWGames enum entry to get defaults from.</param>
		public AkiFont(AkiFontType _ft, VPWGames _game)
		{
			FontType = _ft;
			Data = new List<byte>();
			RawData = new List<byte>();
			CharHeaders = new Dictionary<int, byte[]>();

			switch (FontType)
			{
				case AkiFontType.AkiLargeFont:
					CellHeight = LargeFontHeight[_game];
					NumCharacters = LargeFontNumChars[_game];
					OutColumns = LargeFontOutCols[_game];
					OutRows = LargeFontOutRows[_game];
					break;
				case AkiFontType.AkiSmallFont:
					CellHeight = SmallFontHeight[_game];
					NumCharacters = SmallFontNumChars[_game];
					OutColumns = SmallFontOutCols[_game];
					OutRows = SmallFontOutRows[_game];
					break;
			}
		}

		/// <summary>
		/// Specific constructor using manually-provided details.
		/// </summary>
		/// <param name="_ft">AkiFontType to use.</param>
		/// <param name="_cellHeight">Cell height for each character.</param>
		/// <param name="_numChars">Number of characters in this font.</param>
		/// <param name="_outCols">Number of columns to output.</param>
		/// <param name="_outRows">Number of rows to output.</param>
		public AkiFont(AkiFontType _ft, int _cellHeight, int _numChars, int _outCols, int _outRows)
		{
			FontType = _ft;
			Data = new List<byte>();
			RawData = new List<byte>();
			CharHeaders = new Dictionary<int, byte[]>();

			CellHeight = _cellHeight;
			NumCharacters = _numChars;
			OutColumns = _outCols;
			OutRows = _outRows;
		}
		#endregion

		/// <summary>
		/// Get a Bitmap for a single character.
		/// </summary>
		/// <param name="charNo">Character number to get Bitmap for.</param>
		/// <returns>Bitmap of the specified character.</returns>
		public Bitmap GetCharacterBitmap(int charNo)
		{
			int charWidth = (FontType == AkiFontType.AkiLargeFont) ? LARGE_FONT_CHAR_WIDTH : SMALL_FONT_CHAR_WIDTH;
			int charBytes = (charWidth * CellHeight);

			Bitmap chrBmp = new Bitmap(charWidth, CellHeight);

			// get character pixels
			int baseAddr = charBytes * charNo;
			for (int y = 0; y < CellHeight; y++)
			{
				for (int x = 0; x < charWidth; x++)
				{
					chrBmp.SetPixel(x, y,
							(RawData[baseAddr + ((y * charWidth) + x)] == 0) ? Color.White : Color.Black
					);
				}
			}

			return chrBmp.Clone(new Rectangle(0, 0, chrBmp.Width, chrBmp.Height), PixelFormat.Format1bppIndexed);
		}

		#region Read Data
		/// <summary>
		/// Read large font data.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// The equivalent of AKIfnt.from_large(cls, data) in offsetter
		private void ReadFontData_Large(BinaryReader br)
		{
			byte[] test = new byte[3];
			int charBytes = (CellHeight * LARGE_FONT_CHAR_WIDTH) / 8;
			int charNum = 0;
			while (true)
			{
				test = br.ReadBytes(3);

				if (test[2] == 0x0A)
				{
					break;
				}
				CharHeaders.Add(charNum++, test);

				Data.AddRange(br.ReadBytes(charBytes));
			}
		}

		/// <summary>
		/// Read small font data.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// The equivalent of AKIfnt.from_small(cls, data) in offsetter
		private void ReadFontData_Small(BinaryReader br)
		{
			br.BaseStream.Seek(0, SeekOrigin.End);
			int fileLen = (int)br.BaseStream.Position;
			br.BaseStream.Seek(0, SeekOrigin.Begin);

			int charBytes = (CellHeight * SMALL_FONT_CHAR_WIDTH) / 8;
			int charNum = 0;
			while (br.BaseStream.Position < fileLen)
			{
				CharHeaders.Add(charNum++, br.ReadBytes(2));
				Data.AddRange(br.ReadBytes(charBytes));
			}
		}

		/// <summary>
		/// Read font data.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Data.Clear();
			switch (FontType)
			{
				case AkiFontType.AkiLargeFont:
					ReadFontData_Large(br);
					break;
				case AkiFontType.AkiSmallFont:
					ReadFontData_Small(br);
					break;
			}
			// update raw data values
			WriteRawData();
		}
		#endregion

		#region Write Data
		/// <summary>
		/// Convert the packed pixel data to raw pixel data.
		/// </summary>
		/// The equivalent of AKIfnt.i1(raw) in offsetter
		private void WriteRawData()
		{
			RawData.Clear();
			for (int i = 0; i < Data.Count; i++)
			{
				RawData.Add(((Data[i] & 0x80) == 0) ? (byte)0 : (byte)0xFF);
				RawData.Add(((Data[i] & 0x40) == 0) ? (byte)0 : (byte)0xFF);
				RawData.Add(((Data[i] & 0x20) == 0) ? (byte)0 : (byte)0xFF);
				RawData.Add(((Data[i] & 0x10) == 0) ? (byte)0 : (byte)0xFF);
				RawData.Add(((Data[i] & 0x08) == 0) ? (byte)0 : (byte)0xFF);
				RawData.Add(((Data[i] & 0x04) == 0) ? (byte)0 : (byte)0xFF);
				RawData.Add(((Data[i] & 0x02) == 0) ? (byte)0 : (byte)0xFF);
				RawData.Add(((Data[i] & 0x01) == 0) ? (byte)0 : (byte)0xFF);
			}
		}

		/// <summary>
		/// Converts the AkiFont into a Bitmap.
		/// </summary>
		/// <returns>Bitmap with the characters.</returns>
		/// todo: replace SetPixel commands if possible
		public Bitmap ToBitmap()
		{
			int charWidth = (FontType == AkiFontType.AkiLargeFont) ? LARGE_FONT_CHAR_WIDTH : SMALL_FONT_CHAR_WIDTH;
			int charBytes = (charWidth * CellHeight);

			Bitmap mainBmp = new Bitmap((charWidth * OutColumns), (CellHeight * OutRows));
			Graphics g = Graphics.FromImage(mainBmp);

			for (int curRow = 0; curRow < OutRows; curRow++)
			{
				for (int curCol = 0; curCol < OutColumns; curCol++)
				{
					Bitmap charBmp = new Bitmap(charWidth, CellHeight);
					int basePixelAddr = (curRow * (charBytes * OutColumns)) + (curCol * charBytes);
					if (basePixelAddr >= RawData.Count)
					{
						break;
					}
					for (int charY = 0; charY < CellHeight; charY++)
					{
						for (int charX = 0; charX < charWidth; charX++)
						{
							charBmp.SetPixel(charX, charY,
									(RawData[basePixelAddr + ((charY * charWidth) + charX)] == 0) ? Color.White : Color.Black
								);
						}
					}
					// then copy that output to outBmp
					g.DrawImage(charBmp, new Rectangle((curCol * charWidth), (curRow * CellHeight), charWidth, CellHeight));
				}
			}

			for (int curRow = 0; curRow < OutRows; curRow++)
			{
				for (int curCol = 0; curCol < OutColumns; curCol++)
				{
					if (((curCol * OutColumns) + (curRow * OutRows)) < NumCharacters )
					{
						// output each character to a charWidth*charHeight Bitmap
						Bitmap charBmp = new Bitmap(charWidth, CellHeight);
						for (int charY = 0; charY < CellHeight; charY++)
						{
							for (int charX = 0; charX < charWidth; charX++)
							{
								charBmp.SetPixel(charX, charY,
									(RawData[((curCol * charWidth) + (charY * charWidth) + charX)] == 0) ? Color.White : Color.Black
								);
							}
						}
						
					}
				}
			}
			g.Dispose();

			// save as 1bpp, since that's what the data is stored as.
			return mainBmp.Clone(new Rectangle(0, 0, mainBmp.Width, mainBmp.Height), PixelFormat.Format1bppIndexed);
		}
		#endregion
	}
}
