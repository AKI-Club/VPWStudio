using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace VPWStudio
{
	/// <summary>
	/// PS1 TIM file
	/// </summary>
	public class TimFile
	{
		/// <summary>
		/// Possible image formats for a TIM file.
		/// </summary>
		public enum ImageFormat
		{
			Clut4 = 0, // 4bpp CLUT/paletted (one uint16 value = 4 pixels)
			Clut8,     // 8bpp CLUT/paletted (one uint16 value = 2 pixels)
			Direct15,  // 15bpp direct       (one uint16 value = 1 pixel)
			Direct24,  // 24bpp direct       (one uint16 value = 2/3rds of a pixel; three uint16 values = 2 pixels)
			Mixed
		}

		// first byte is always 0x10

		#region Class Members
		/// <summary>
		/// TIM version number. Should always be 0.
		/// </summary>
		/// (found at file offset 0x01)
		public byte Version = 0;

		// (file offset 0x02 and 0x03 should be 0)

		/// <summary>
		/// A combination of ImageFormat (bits 0-2) and "has CLUT" (bit 3).
		/// </summary>
		/// (found at file offset 0x04)
		/// 
		/// lowest 8 bits:
		/// 76543210
		/// 0000||_|
		///     | |
		///     | +-- Image Format (see ImageFormat enum)
		///     +---- Has CLUT
		public UInt32 Flags;

		/// <summary>
		/// CLUT data, if it exists in the TIM file.
		/// </summary>
		public ClutData CLUT;

		/// <summary>
		/// Number of bytes to describe the pixel data, including the 4 bytes for this variable.
		/// </summary>
		public UInt32 PixelDataLength;

		/// <summary>
		/// X coordinate for pixel data in the framebuffer.
		/// </summary>
		public UInt16 PixelXCoordinate;

		/// <summary>
		/// Y coordinate for pixel data in the framebuffer.
		/// </summary>
		public UInt16 PixelYCoordinate;

		/// <summary>
		/// Width of the pixel data (in 16 bit/2 byte units).
		/// </summary>
		public UInt16 PixelWidth;

		/// <summary>
		/// Height of the pixel data.
		/// </summary>
		public UInt16 PixelHeight;

		/// <summary>
		/// Pixel data in this TIM file.
		/// The format of the pixel data depends on the image format.
		/// </summary>
		public List<UInt16> Pixels;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor. Creates a 15bpp TIM.
		/// </summary>
		public TimFile()
		{
			// todo: how to set Flags properly depending on endian
			CLUT = null; // don't store a CLUT by default
			Pixels = new List<UInt16>();
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public TimFile(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read a TIM file using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// TIM files always start with 0x10 as first byte.
			if (br.ReadByte() != 0x10)
			{
				return;
			}

			// version should always be 0, but we read it just in case
			Version = br.ReadByte();

			// next two bytes are always 0, so ignore the read
			br.ReadBytes(2);

			byte[] flag = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(flag);
			}
			Flags = BitConverter.ToUInt32(flag,0);

			// determine if we need to read CLUT data
			if ((byte)(Flags & 0x08) != 0)
			{
				CLUT = new ClutData(br);
			}

			// pixel section descriptors
			byte[] pixLen = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(pixLen);
			}
			PixelDataLength = BitConverter.ToUInt32(pixLen,0);

			byte[] pixPosX = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(pixPosX);
			}
			PixelXCoordinate = BitConverter.ToUInt16(pixPosX,0);

			byte[] pixPosY = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(pixPosY);
			}
			PixelYCoordinate = BitConverter.ToUInt16(pixPosY, 0);

			byte[] pixWidth = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(pixWidth);
			}
			PixelWidth = BitConverter.ToUInt16(pixWidth, 0);

			byte[] pixHeight = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(pixHeight);
			}
			PixelHeight = BitConverter.ToUInt16(pixHeight, 0);

			// read in pixel data
			Pixels = new List<UInt16>();
			for (int i = 0; i < (PixelWidth * PixelHeight); i++)
			{
				byte[] val = br.ReadBytes(2);
				if (!BitConverter.IsLittleEndian)
				{
					Array.Reverse(val);
				}
				Pixels.Add(BitConverter.ToUInt16(val,0));
			}
		}
		#endregion

		#region Bitmap Read/Write
		/// <summary>
		/// Converts this TIM image to a Bitmap.
		/// </summary>
		/// <param name="palNumber">(Optional) Palette number to use when a CLUT has multiple palettes. Only useful in 4bpp mode.</param>
		/// <param name="externalClut">(Optional) External CLUT data, if the TIM doesn't provide its own.</param>
		/// <returns>Bitmap containing an image drawn with the requested palette number.</returns>
		public Bitmap ToBitmap(int palNumber = 0, ClutData externalClut = null)
		{
			// need to know image format in order to find out actual image width
			ImageFormat format = (ImageFormat)((byte)Flags & 7);
			UInt16 actualWidth = 0;
			switch (format)
			{
				case ImageFormat.Clut4: actualWidth = (UInt16)(PixelWidth * 4); break;
				case ImageFormat.Clut8: actualWidth = (UInt16)(PixelWidth * 2); break;
				case ImageFormat.Direct15: actualWidth = PixelWidth; break;

				case ImageFormat.Direct24:
					// a little more complicated... every 3 uint16 values makes 2 pixels
					actualWidth = (UInt16)((PixelWidth / 3) * 2);
					break;

				case ImageFormat.Mixed:
				default:
					// unsure how to actually handle "Mixed" format
					break;
			}

			if (actualWidth == 0)
			{
				return null;
			}

			Bitmap bOut = new Bitmap(actualWidth, PixelHeight);

			// we only need to search for CLUT in 4bpp and 8bpp formats
			List<Color> clutColors = new List<Color>();
			if (format == ImageFormat.Clut4 || format == ImageFormat.Clut8)
			{
				if (externalClut != null)
				{
					clutColors = externalClut.GetColors();
				}
				else
				{
					if ((byte)(Flags & 8) == 0)
					{
						// no CLUT in this TIM file (and no external CLUT loaded either)
						// make an ad-hoc grayscale palette
						clutColors = new List<Color>();
						int limit = format == ImageFormat.Clut4 ? 16 : 256;
						int scalar = format == ImageFormat.Clut4 ? 16 : 1;
						for (int i = 0; i < limit; i++)
						{
							int v = Math.Min(i*scalar, 255);
							clutColors.Add(Color.FromArgb(255,v,v,v));
						}
					}
					else
					{
						clutColors = CLUT.GetColors();
					}
				}

				// handle sub-palettes
				if (format == ImageFormat.Clut4 && palNumber != 0)
				{
					clutColors = clutColors.GetRange(palNumber * 16, 16);
				}
			}

			// now for the hard part, the pixels.
			if (format == ImageFormat.Clut4)
			{
				// each uint16 is 4 pixels: 0x000F, 0x00F0, 0x0F00, 0xF000
				int x = 0;
				int y = 0;
				for (int i = 0; i < Pixels.Count; i++)
				{
					UInt16 pix = Pixels[i];
					int p1 = pix & 0x000F;
					int p2 = (pix & 0x00F0) >> 4;
					int p3 = (pix & 0x0F00) >> 8;
					int p4 = (pix & 0xF000) >> 12;

					bOut.SetPixel(x,y, clutColors[p1]);
					bOut.SetPixel(x+1,y, clutColors[p2]);
					bOut.SetPixel(x+2,y, clutColors[p3]);
					bOut.SetPixel(x+3,y, clutColors[p4]);

					x += 4;
					if (x == actualWidth)
					{
						x = 0;
						y++;
					}
				}
			}
			else if (format == ImageFormat.Clut8)
			{
				// each uint16 is 2 pixels: 0x00FF, 0xFF00
				int x = 0;
				int y = 0;
				for (int i = 0; i < Pixels.Count; i++)
				{
					UInt16 pix = Pixels[i];
					int p1 = pix & 0x00FF;
					int p2 = (pix & 0xFF00) >> 8;
					bOut.SetPixel(x, y, clutColors[p1]);
					bOut.SetPixel(x + 1, y, clutColors[p2]);

					x += 2;
					if (x == actualWidth)
					{
						x = 0;
						y++;
					}
				}
			}
			else if (format == ImageFormat.Direct15)
			{
				// each uint16 is one pixel
				for (int y = 0; y < PixelHeight; y++)
				{
					for (int x = 0; x < actualWidth; x++)
					{
						UInt16 pix = Pixels[(y * actualWidth) + x];
						int r = pix & 0x1F;
						int g = (pix & 0x3E0) >> 5;
						int b = (pix & 0x7C00) >> 10;
						// ignore alpha (pix & 0x8000) for now
						bOut.SetPixel(x,y,Color.FromArgb(255, r*8, g*8, b*8));
					}
				}
			}
			else if (format == ImageFormat.Direct24)
			{
				// (index % 3) to determine what part we're in
			}

			return bOut;
		}
		#endregion
	}
}
