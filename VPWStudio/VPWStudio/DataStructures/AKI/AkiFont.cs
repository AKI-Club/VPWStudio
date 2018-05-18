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
		/// the one used in No Mercy for in-match names
		/// </summary>
		AkiTinyFont
		*/
	}

	/// <summary>
	/// AKI font data.
	/// </summary>
	/// Some code in this class is based off of code in Zoinkity's Midwaydec.
	public class AkiFont
	{
		#region Constants
		// * FontHeight   - Character cell height
		// * FontChars    - Number of characters defined
		// * FontCols     - Number of columns in output image
		// * FontRows     - Number of rows in output image

		// WM2K Actual font characters: 103
		// VPW2 Actual font characters: 3253

		#region Large Font
		private static Dictionary<VPWGames, int> LargeFontHeight = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 23 },
			{ VPWGames.VPW64, 23 },
			{ VPWGames.Revenge, 23 },
			{ VPWGames.WM2K, 21 },
			{ VPWGames.VPW2, 21 },
			{ VPWGames.NoMercy, 22 },
		};

		private static Dictionary<VPWGames, int> LargeFontNumChars = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 100 },
			{ VPWGames.VPW64, 3240 },
			{ VPWGames.Revenge, 120 },
			{ VPWGames.WM2K, 110 },
			{ VPWGames.VPW2, 3260 },
			{ VPWGames.NoMercy, 110 },
		};

		private static Dictionary<VPWGames, int> LargeFontOutCols = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 24 },
			{ VPWGames.VPW64, 24 },
			{ VPWGames.Revenge, 24 },
			{ VPWGames.WM2K, 16 },
			{ VPWGames.VPW2, 20 },
			{ VPWGames.NoMercy, 24 },
		};

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
		private static Dictionary<VPWGames, int> SmallFontHeight = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 14 },
			{ VPWGames.VPW64, 14 },
			{ VPWGames.Revenge, 14 },
			{ VPWGames.WM2K, 13 },
			{ VPWGames.VPW2, 13 },
			{ VPWGames.NoMercy, 14 },
		};

		private static Dictionary<VPWGames, int> SmallFontNumChars = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 112 },
			{ VPWGames.VPW64, 3248 },
			{ VPWGames.Revenge, 128 },
			{ VPWGames.WM2K, 112 },
			{ VPWGames.VPW2, 3264 },
			{ VPWGames.NoMercy, 112 },
		};

		private static Dictionary<VPWGames, int> SmallFontOutCols = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 16 },
			{ VPWGames.VPW64, 16 },
			{ VPWGames.Revenge, 16 },
			{ VPWGames.WM2K, 16 },
			{ VPWGames.VPW2, 64 },
			{ VPWGames.NoMercy, 16 },
		};

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

		#region WrestleMania 2000 (NTSC-J)
		// this game is probably a giant exception to the rule for certain fonts
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
			int charWidth = (FontType == AkiFontType.AkiLargeFont) ? 24 : 16;
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
			int charBytes = (CellHeight * 24) / 8;
			while (true)
			{
				test = br.ReadBytes(3);
				if (test[2] == 0x0A)
				{
					break;
				}
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

			int charBytes = (CellHeight * 16) / 8;
			while (br.BaseStream.Position < fileLen)
			{
				br.ReadBytes(2);
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
		public Bitmap ToBitmap()
		{
			int charWidth = (FontType == AkiFontType.AkiLargeFont) ? 24 : 16;
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
