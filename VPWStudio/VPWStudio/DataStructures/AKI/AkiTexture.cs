using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace VPWStudio
{
	/// <summary>
	/// AkiTexture, a.k.a. "TEX" (based on the magic number.)
	/// </summary>
	public class AkiTexture
	{
		/// <summary>
		/// Possible image formats.
		/// </summary>
		/// Non-CI4/CI8 formats have not been found in TEX files yet??
		public enum AkiTextureFormat
		{
			Ci4 = 0x04, // 4bpp
			Ci8 = 0x08  // 8bpp
		}

		#region Class Members
		/// <summary>
		/// Image width
		/// </summary>
		/// Offset 0x04
		public UInt16 Width;

		/// <summary>
		/// Image height
		/// </summary>
		/// Offset 0x06
		public UInt16 Height;

		/// <summary>
		/// Image format.
		/// </summary>
		/// Offset 0x08
		public AkiTextureFormat ImageFormat;

		/// <summary>
		/// Number of bytes per color.
		/// </summary>
		/// Offset 0x09
		public byte ColorWidth;

		/// <summary>
		/// Number of colors in the palette.
		/// </summary>
		/// Offset 0x0A
		public UInt16 PaletteNumColors; // 0x0A

		// offsets 0x0C-0x0F are usually 0x00 for alignment purposes?

		/// <summary>
		/// Palette data.
		/// </summary>
		/// Offset 0x10; length depends on image type.
		public UInt16[] Palette; // 0x10

		/// <summary>
		/// Image bytes.
		/// </summary>
		public byte[] Data;

		/// <summary>
		/// Cached Bitmap data.
		/// </summary>
		/*
		public Bitmap CachedBitmap;
		*/
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AkiTexture()
		{
			Width = 0;
			Height = 0;
			ImageFormat = 0;
			ColorWidth = 0;
			PaletteNumColors = 0;
			Palette = null;
			Data = null;
			//CachedBitmap = null;
		}

		/// <summary>
		/// Constructor using BinaryReader.
		/// </summary>
		/// <param name="br"></param>
		public AkiTexture(BinaryReader br)
		{
			ReadData(br);
			//CachedBitmap = null;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read AkiTexture data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public bool ReadData(BinaryReader br)
		{
			// make sure we have "TEX",0x00 header
			byte[] magic = br.ReadBytes(4);
			if (magic[0] != 'T' && magic[1] != 'E' && magic[2] != 'X' && magic[3] != 0)
			{
				return false;
			}

			byte[] w = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(w);
			}
			Width = BitConverter.ToUInt16(w, 0);

			byte[] h = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(h);
			}
			Height = BitConverter.ToUInt16(h, 0);

			ImageFormat = (AkiTextureFormat)br.ReadByte();
			ColorWidth = br.ReadByte();

			// read palette num colors
			byte[] pnc = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pnc);
			}
			PaletteNumColors = BitConverter.ToUInt16(pnc, 0);

			// skip to 0x10
			br.BaseStream.Seek(0x10, SeekOrigin.Begin);
			// read palette (todo: might need to handle this differently)
			Palette = new ushort[PaletteNumColors];
			for (int i = 0; i < PaletteNumColors; i++)
			{
				byte[] cd = br.ReadBytes(2);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(cd);
				}
				Palette[i] = BitConverter.ToUInt16(cd,0);
			}

			// read image data
			// size depends on image format...
			br.BaseStream.Seek((PaletteNumColors * ColorWidth) + 0x10, SeekOrigin.Begin);
			switch (ImageFormat)
			{
				case AkiTextureFormat.Ci4:
					// one byte = two pixels
					{
						int numPixels = Width * Height;
						Data = new byte[numPixels];
						int i = 0;
						while (i < numPixels)
						{
							byte b = br.ReadByte();
							Data[i] = (byte)((b & 0xF0) >> 4);
							Data[i + 1] = (byte)(b & 0x0F);
							i += 2;
						}
					}
					break;
				case AkiTextureFormat.Ci8:
					// one byte = one pixel
					{
						int numPixels = Width * Height;
						Data = new byte[numPixels];
						int i = 0;
						while (i < numPixels)
						{
							Data[i] = br.ReadByte();
							i++;
						}
					}
					break;
			}

			return true; // ok
		}

		/// <summary>
		/// Write AkiTexture data using a BinaryWriter.
		/// </summary>
		/// <param name="bw"></param>
		public void WriteData(BinaryWriter bw)
		{
			// header
			bw.Write('T');
			bw.Write('E');
			bw.Write('X');
			bw.Write((byte)0);

			// width
			byte[] w = BitConverter.GetBytes(Width);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(w);
			}
			bw.Write(w);

			// height
			byte[] h = BitConverter.GetBytes(Height);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(h);
			}
			bw.Write(h);

			// image format
			bw.Write((byte)ImageFormat);

			// color width
			bw.Write(ColorWidth);

			// number of colors
			byte[] nc = BitConverter.GetBytes(PaletteNumColors);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(nc);
			}
			bw.Write(nc);

			// palette data at 0x10
			bw.Seek(0x10, SeekOrigin.Begin);
			for (int i = 0; i < PaletteNumColors; i++)
			{
				byte[] cv = BitConverter.GetBytes(Palette[i]);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(cv);
				}
				bw.Write(cv);
			}

			// image data after palette
			bw.Write(Data);
		}
		#endregion

		#region Bitmap conversion routines
		/// <summary>
		/// Convert this AkiTexture to a Bitmap.
		/// </summary>
		/// <returns></returns>
		public Bitmap ToBitmap(bool _skipCache = false)
		{
			if (Data == null)
			{
				return null;
			}

			/*
			if (!_skipCache && CachedBitmap != null)
			{
				return CachedBitmap;
			}
			*/

			Bitmap bOut = new Bitmap(Width, Height);

			switch (ImageFormat)
			{
				case AkiTextureFormat.Ci4:
				case AkiTextureFormat.Ci8:
					ToBitmap_CI(bOut);
					break;

				default:
					break;
			}

			//CachedBitmap = bOut;
			return bOut;
		}

		/// <summary>
		/// Convert CI8 format image to Bitmap pixels.
		/// </summary>
		/// <param name="bOut"></param>
		private void ToBitmap_CI(Bitmap bOut)
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					byte palIdx = Data[(y * Width) + x];
					Color c = N64Colors.Value5551ToColor(Palette[palIdx]);
					bOut.SetPixel(x, y, c);
				}
			}
		}

		/// <summary>
		/// Convert a Bitmap to an AkiTexture.
		/// </summary>
		/// <param name="bm">Bitmap to convert.</param>
		/// <remarks>Only supports CI4 (16 colors) and CI8 (256 colors) formats.</remarks>
		public void FromBitmap(Bitmap bm)
		{
			if (bm.PixelFormat == PixelFormat.Format4bppIndexed)
			{
				// CI4
				ImageFormat = AkiTextureFormat.Ci4;
				ColorWidth = 2;
				PaletteNumColors = 16;
			}
			else if (bm.PixelFormat == PixelFormat.Format8bppIndexed)
			{
				// CI8
				ImageFormat = AkiTextureFormat.Ci8;
				ColorWidth = 2;
				PaletteNumColors = 256;
			}
			else
			{
				// unsupported format
				return;
			}

			// set common items
			Width = (UInt16)bm.Width;
			Height = (UInt16)bm.Height;

			// convert palette
			SortedList<int, Color> BitmapColors = new SortedList<int, Color>();
			Palette = new UInt16[PaletteNumColors];
			for (int i = 0; i < bm.Palette.Entries.Length; i++)
			{
				BitmapColors.Add(i, bm.Palette.Entries[i]);
				Palette[i] = N64Colors.ColorToValue5551(bm.Palette.Entries[i]);
			}

			// convert image data
			switch (ImageFormat)
			{
				case AkiTextureFormat.Ci4:
					// one pixel = two bytes
					Data = new byte[(Width/2) * Height];
					List<byte> pixels = new List<byte>();
					byte build = 0;
					for (int y = 0; y < Height; y++)
					{
						for (int x = 0; x < Width; x++)
						{
							if (x % 2 == 0)
							{
								build = (byte)((BitmapColors.IndexOfValue(bm.GetPixel(x, y)) & 0x0F) << 4);
							}
							else
							{
								build |= (byte)(BitmapColors.IndexOfValue(bm.GetPixel(x, y)) & 0x0F);
								pixels.Add(build);
							}
						}
					}
					for (int i = 0; i < pixels.Count; i++)
					{
						Data[i] = pixels[i];
					}
					break;

				case AkiTextureFormat.Ci8:
					// one pixel = one byte
					Data = new byte[Width * Height];
					for (int y = 0; y < Height; y++)
					{
						for (int x = 0; x < Width; x++)
						{
							Data[(y*Width) + x] = (byte)BitmapColors.IndexOfValue(bm.GetPixel(x, y));
						}
					}
					break;
			}
		}
		#endregion
	}
}
