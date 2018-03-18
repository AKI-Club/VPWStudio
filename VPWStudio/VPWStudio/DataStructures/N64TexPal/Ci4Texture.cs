using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// CI4 (Color, Indexed 4bpp) Texture
	/// </summary>
	public class Ci4Texture
	{
		#region Class Members
		/// <summary>
		/// Image width
		/// </summary>
		public int Width;

		/// <summary>
		/// Image height
		/// </summary>
		public int Height;

		/// <summary>
		/// Bytes with currently unknown purpose.
		/// </summary>
		public byte[] Unknown;

		/// <summary>
		/// Image pixels
		/// </summary>
		public byte[] Data;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Ci4Texture()
		{
			Width = 0;
			Height = 0;
			Unknown = null;
			Data = null;
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read image data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Width = (br.ReadByte() + 1);
			Height = (br.ReadByte() + 1);

			// 6 bytes with unknown purpose; some of these might be format indicators?
			Unknown = br.ReadBytes(6);

			int numPixels = Width * Height;
			Data = new byte[numPixels];

			// two pixels in one byte
			int i = 0;
			while (i < numPixels)
			{
				byte b = br.ReadByte();
				Data[i] = (byte)((b & 0xF0) >> 4);
				Data[i + 1] = (byte)(b & 0x0F);
				i+=2;
			}
		}

		/// <summary>
		/// Read raw CI4 image data (no header)
		/// </summary>
		/// <param name="width">Width of image</param>
		/// <param name="height">Height of image</param>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadRawData(int width, int height, BinaryReader br)
		{
			// set width and height
			Width = width;
			Height = height;

			int numPixels = width * height;
			Data = new byte[numPixels];

			// two pixels in one byte
			int i = 0;
			while (i < numPixels)
			{
				byte b = br.ReadByte();
				Data[i] = (byte)((b & 0xF0) >> 4);
				Data[i + 1] = (byte)(b & 0x0F);
				i += 2;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			// header
			bw.Write(((byte)Width - 1));
			bw.Write(((byte)Height - 1));
			bw.Write(Unknown);

			// image data
			for (int i = 0; i < Data.Length; i+=2)
			{
				byte outPixel = (byte)(Data[i+1] & 0x0F);
				outPixel |= (byte)(Data[i] << 4);
				bw.Write(outPixel);
			}
		}
		#endregion

		#region Bitmap Read/Write
		/// <summary>
		/// Convert this Ci4Image to a Bitmap.
		/// </summary>
		/// <param name="pal">CI4 Palette data to use.</param>
		/// <param name="subPalette">Optional sub-palette number to use.</param>
		/// <returns>Bitmap containing an image drawn with the requested Ci4Palette.</returns>
		public Bitmap ToBitmap(Ci4Palette pal, int subPalette = 0)
		{
			if (Data == null)
			{
				return null;
			}

			// requires palette
			if (pal == null)
			{
				return null;
			}

			// failsafe for subpalette usage
			if (subPalette > 0 && pal.SubPalettes.Count <= 0)
			{
				subPalette = 0;
			}

			Bitmap bOut = new Bitmap(Width, Height);

			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					byte palIdx = Data[(y * Width) + x];
					Color c;
					if (subPalette != 0)
					{
						c = N64Colors.Value5551ToColor(pal.SubPalettes[subPalette-1].Entries[palIdx]);
					}
					else
					{
						c = N64Colors.Value5551ToColor(pal.Entries[palIdx]);
					}
					bOut.SetPixel(x, y, c);
				}
			}

			return bOut;
		}

		/// <summary>
		/// Convert Bitmap to Ci4Texture.
		/// </summary>
		/// <param name="inBmp">Bitmap to convert.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool FromBitmap(Bitmap inBmp)
		{
			if (inBmp.PixelFormat != PixelFormat.Format4bppIndexed)
			{
				return false;
			}

			Width = (UInt16)inBmp.Width;
			Height = (UInt16)inBmp.Height;

			// convert palette
			SortedList<int, Color> BitmapColors = new SortedList<int, Color>();
			UInt16[] Palette = new UInt16[16];
			for (int i = 0; i < inBmp.Palette.Entries.Length; i++)
			{
				BitmapColors.Add(i, inBmp.Palette.Entries[i]);
				Palette[i] = N64Colors.ColorToValue5551(inBmp.Palette.Entries[i]);
			}

			// one pixel = two bytes
			Data = new byte[(Width / 2) * Height];
			List<byte> pixels = new List<byte>();
			byte build = 0;
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					if (x % 2 == 0)
					{
						build = (byte)((BitmapColors.IndexOfValue(inBmp.GetPixel(x, y)) & 0x0F) << 4);
					}
					else
					{
						build |= (byte)(BitmapColors.IndexOfValue(inBmp.GetPixel(x, y)) & 0x0F);
						pixels.Add(build);
					}
				}
			}
			for (int i = 0; i < pixels.Count; i++)
			{
				Data[i] = pixels[i];
			}

			return true;
		}
		#endregion
	}
}
