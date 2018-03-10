using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VPWStudio
{
	/*
	 * Various notes on VPW2:
	 * 3253 actual characters according to font.txt (File ID 0x0003)
	 */

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
		// XXX: THESE VALUES ONLY MAKE SENSE FOR VPW2
		// they also work with WM2K for some "unknown" reason (a.k.a. they based WM2K off of VPW2)

		#region Large Font Constants
		/// <summary>
		/// Large font character cell width.
		/// </summary>
		public const int LARGE_FONT_WIDTH = 24;
		/// <summary>
		/// Large font character cell height.
		/// </summary>
		public const int LARGE_FONT_HEIGHT = 21;
		/// <summary>
		/// Total number of characters in the large font data.
		/// </summary>
		public const int LARGE_FONT_CHARS = 3260;
		/// <summary>
		/// Number of characters per row for large font output image.
		/// </summary>
		public const int LARGE_FONT_COLS = 20;
		/// <summary>
		/// Number of rows for large font output image.
		/// </summary>
		public const int LARGE_FONT_ROWS = 163;
		#endregion

		#region Small Font Constants
		/// <summary>
		/// Small font character cell width.
		/// </summary>
		public const int SMALL_FONT_WIDTH = 16;
		/// <summary>
		/// Small font character cell height.
		/// </summary>
		public const int SMALL_FONT_HEIGHT = 13;
		/// <summary>
		/// Total number of characters in the small font data.
		/// </summary>
		public const int SMALL_FONT_CHARS = 3264;
		/// <summary>
		/// Number of characters per row for small font output image.
		/// </summary>
		public const int SMALL_FONT_COLS = 64;
		/// <summary>
		/// Number of rows for small font output image.
		/// </summary>
		public const int SMALL_FONT_ROWS = 51;
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
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AkiFont()
		{
			this.FontType = AkiFontType.AkiSmallFont;
			this.Data = new List<byte>();
			this.RawData = new List<byte>();
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_ft">AkiFontType to use.</param>
		public AkiFont(AkiFontType _ft)
		{
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
			while (true)
			{
				test = br.ReadBytes(3);
				if (test[2] == 0x0A)
				{
					break;
				}
				Data.AddRange(br.ReadBytes(0x3F));
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

			while (br.BaseStream.Position < fileLen)
			{
				br.ReadBytes(2);
				Data.AddRange(br.ReadBytes(0x1A));
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
					charWidth = LARGE_FONT_WIDTH;
					charHeight = LARGE_FONT_HEIGHT;
					charBytes = LARGE_FONT_WIDTH * LARGE_FONT_HEIGHT;
					outColumns = LARGE_FONT_COLS;
					outRows = LARGE_FONT_ROWS;
					numChars = LARGE_FONT_CHARS;
					break;

				case AkiFontType.AkiSmallFont:
					charWidth = SMALL_FONT_WIDTH;
					charHeight = SMALL_FONT_HEIGHT;
					charBytes = SMALL_FONT_WIDTH * SMALL_FONT_HEIGHT;
					outColumns = SMALL_FONT_COLS;
					outRows = SMALL_FONT_ROWS;
					numChars = SMALL_FONT_CHARS;
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
