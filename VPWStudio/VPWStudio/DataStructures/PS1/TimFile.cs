using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

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
			Clut4 = 0, // 4bpp CLUT/paletted
			Clut8,     // 8bpp CLUT/paletted
			Direct15,  // 15bpp direct
			Direct24,  // 24bpp direct
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

		// The format of the pixel data depends on the image format.
		// Each "unit" takes 16 bits (2 bytes).
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
			for (int i = 0; i < (PixelDataLength - 12) / 2; i++)
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
		// ...eventually.
		#endregion
	}
}
