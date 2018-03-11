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
		AkiSmallFont
	}

	/// <summary>
	/// AKI font data.
	/// </summary>
	/// Some code in this class is based off of code in Zoinkity's Midwaydec.
	public class AkiFont
	{
		#region Constants
		// LargeFontWidth    - Character cell width
		// LargeFontHeight   - Character cell height
		// LargeFontCharSize - This could very well be calculated, but I'd rather not.
		// LargeFontChars    - Number of characters defined
		// LargeFontCols     - Number of columns in output image
		// LargeFontRows     - Number of rows in output image
		// (repeat the above list but starting with "Small" instead of "Large")

		private static Dictionary<VPWGames, Dictionary<string, int>> DefaultFontMetrics = new Dictionary<VPWGames, Dictionary<string, int>>()
		{
			{
				VPWGames.Revenge,
				// actual font characters differ between fonts
				new Dictionary<string, int>()
				{
					{ "LargeFontWidth", 24 },
					{ "LargeFontHeight", 23 },
					{ "LargeFontCharSize", 0x45 },
					{ "LargeFontChars", 120 },
					{ "LargeFontCols", 24 },
					{ "LargeFontRows", 5 },

					{ "SmallFontWidth", 16 },
					{ "SmallFontHeight", 14 },
					{ "SmallFontCharSize", 0x1C },
					{ "SmallFontChars", 128 },
					{ "SmallFontCols", 16 },
					{ "SmallFontRows", 9 },
				}
			},
			{
				VPWGames.WM2K,
				// Actual font characters: 103
				new Dictionary<string, int>()
				{
					{ "LargeFontWidth", 24 },
					{ "LargeFontHeight", 21 },
					{ "LargeFontCharSize", 0x3F },
					{ "LargeFontChars", 110 },
					{ "LargeFontCols", 16 },
					{ "LargeFontRows", 7 },

					{ "SmallFontWidth", 16 },
					{ "SmallFontHeight", 13 },
					{ "SmallFontCharSize", 0x1A },
					{ "SmallFontChars", 112 },
					{ "SmallFontCols", 16 },
					{ "SmallFontRows", 7 },
				}
			},
			{
				VPWGames.VPW2,
				// Actual font characters: 3253
				new Dictionary<string, int>()
				{
					{ "LargeFontWidth", 24 },
					{ "LargeFontHeight", 21 },
					{ "LargeFontCharSize", 0x3F },
					{ "LargeFontChars", 3260 },
					{ "LargeFontCols", 20 },
					{ "LargeFontRows", 163 },

					{ "SmallFontWidth", 16 },
					{ "SmallFontHeight", 13 },
					{ "SmallFontCharSize", 0x1A },
					{ "SmallFontChars", 3264 },
					{ "SmallFontCols", 64 },
					{ "SmallFontRows", 51 },
				}
			},
		};

		#endregion

		#region Class Members
		/// <summary>
		/// Game type for this AkiFont.
		/// </summary>
		/// "Why is this needed?", you will ask...
		/// Each game seems to require different values for the font data.
		/// There goes the neighborhood.
		public VPWGames GameType;

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
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AkiFont()
		{
			this.GameType = VPWGames.Invalid;
			this.FontType = AkiFontType.AkiSmallFont;
			this.Data = new List<byte>();
			this.RawData = new List<byte>();
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_ft">AkiFontType to use.</param>
		public AkiFont(VPWGames _game, AkiFontType _ft)
		{
			this.GameType = _game;
			this.FontType = _ft;
			this.Data = new List<byte>();
			this.RawData = new List<byte>();
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
			int numEntries = 0;
			while (true)
			{
				test = br.ReadBytes(3);
				if (test[2] == 0x0A)
				{
					break;
				}
				Data.AddRange(br.ReadBytes(DefaultFontMetrics[GameType]["LargeFontCharSize"]));
				numEntries++;
			}
			System.Windows.Forms.MessageBox.Show(String.Format("Loaded {0} chars from large font", numEntries));
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

			int numEntries = 0;
			while (br.BaseStream.Position < fileLen)
			{
				br.ReadBytes(2);
				Data.AddRange(br.ReadBytes(DefaultFontMetrics[GameType]["SmallFontCharSize"]));
				numEntries++;
			}
			System.Windows.Forms.MessageBox.Show(String.Format("Loaded {0} chars from small font", numEntries));
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
		}
		#endregion

		#region Write Data
		/// <summary>
		/// Convert the packed pixel data to raw pixel data.
		/// </summary>
		/// The equivalent of AKIfnt.i1(raw) in offsetter
		public void WriteRawData()
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
			int charWidth = 0;
			int charHeight = 0;
			int charBytes = 0;
			int outColumns = 0;
			int outRows = 0;
			int numChars = 0;

			switch (FontType)
			{
				case AkiFontType.AkiLargeFont:
					charWidth = DefaultFontMetrics[GameType]["LargeFontWidth"];
					charHeight = DefaultFontMetrics[GameType]["LargeFontHeight"];
					charBytes = charWidth * charHeight;
					outColumns = DefaultFontMetrics[GameType]["LargeFontCols"];
					outRows = DefaultFontMetrics[GameType]["LargeFontRows"];
					numChars = DefaultFontMetrics[GameType]["LargeFontChars"];
					break;

				case AkiFontType.AkiSmallFont:
					charWidth = DefaultFontMetrics[GameType]["SmallFontWidth"];
					charHeight = DefaultFontMetrics[GameType]["SmallFontHeight"];
					charBytes = charWidth * charHeight;
					outColumns = DefaultFontMetrics[GameType]["SmallFontCols"];
					outRows = DefaultFontMetrics[GameType]["SmallFontRows"];
					numChars = DefaultFontMetrics[GameType]["SmallFontChars"];
					break;
			}

			Bitmap mainBmp = new Bitmap((charWidth * outColumns), (charHeight * outRows));
			Graphics g = Graphics.FromImage(mainBmp);

			for (int curRow = 0; curRow < outRows; curRow++)
			{
				for (int curCol = 0; curCol < outColumns; curCol++)
				{
					Bitmap charBmp = new Bitmap(charWidth, charHeight);
					int basePixelAddr = (curRow * (charBytes * outColumns)) + (curCol * charBytes);
					if (basePixelAddr >= RawData.Count)
					{
						break;
					}
					for (int charY = 0; charY < charHeight; charY++)
					{
						for (int charX = 0; charX < charWidth; charX++)
						{
							charBmp.SetPixel(charX, charY,
									(RawData[basePixelAddr + ((charY * charWidth) + charX)] == 0) ? Color.White : Color.Black
								);
						}
					}
					// then copy that output to outBmp
					g.DrawImage(charBmp, new Rectangle((curCol * charWidth), (curRow * charHeight), charWidth, charHeight));
				}
			}

			for (int curRow = 0; curRow < outRows; curRow++)
			{
				for (int curCol = 0; curCol < outColumns; curCol++)
				{
					if (((curCol * outColumns) + (curRow * outRows)) < numChars )
					{
						// output each character to a charWidth*charHeight Bitmap
						Bitmap charBmp = new Bitmap(charWidth, charHeight);
						for (int charY = 0; charY < charHeight; charY++)
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

			return mainBmp.Clone(new Rectangle(0, 0, mainBmp.Width, mainBmp.Height), PixelFormat.Format1bppIndexed);
		}
		#endregion
	}
}
