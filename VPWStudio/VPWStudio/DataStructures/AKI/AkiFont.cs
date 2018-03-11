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
		// *FontWidth    - Character cell width
		// *FontHeight   - Character cell height
		// *FontCharSize - This could very well be calculated, but I'd rather not.
		// *FontChars    - Number of characters defined
		// *FontCols     - Number of columns in output image
		// *FontRows     - Number of rows in output image

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
			int charBytes = (LargeFontHeight[GameType] * 24) / 8;
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

			int charBytes = (SmallFontHeight[GameType] * 16) / 8;
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
			int charHeight = 0;
			int charBytes = 0;
			int outColumns = 0;
			int outRows = 0;
			int numChars = 0;

			switch (FontType)
			{
				case AkiFontType.AkiLargeFont:
					charHeight = LargeFontHeight[GameType];
					charBytes = (charWidth * charHeight);
					outColumns = LargeFontOutCols[GameType];
					outRows = LargeFontOutRows[GameType];
					numChars = LargeFontNumChars[GameType];
					break;

				case AkiFontType.AkiSmallFont:
					charHeight = SmallFontHeight[GameType];
					charBytes = (charWidth * charHeight);
					outColumns = SmallFontOutCols[GameType];
					outRows = SmallFontOutRows[GameType];
					numChars = SmallFontNumChars[GameType];
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

			// save as 1bpp, since that's what the data is stored as.
			return mainBmp.Clone(new Rectangle(0, 0, mainBmp.Width, mainBmp.Height), PixelFormat.Format1bppIndexed);
		}
		#endregion
	}
}
