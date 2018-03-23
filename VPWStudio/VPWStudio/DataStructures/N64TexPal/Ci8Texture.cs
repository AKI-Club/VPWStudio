using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace VPWStudio
{
	/// <summary>
	/// CI8 (Color, Indexed 8bpp) Texture
	/// </summary>
	public class Ci8Texture
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
		public Ci8Texture()
		{
			Width = 0;
			Height = 0;
			Unknown = new byte[6]{ 0x01, 0x00, 0x01, 0x01, 0x05, 0x06 };
			Data = null;
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read CI8 texture data using a BinaryReader.
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

			// one pixel per byte
			int i = 0;
			while (i < numPixels)
			{
				Data[i] = br.ReadByte();
				i++;
			}
		}

		/// <summary>
		/// Write CI8 texture data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			// header
			bw.Write((byte)(Width-1));
			bw.Write((byte)(Height-1));
			bw.Write(Unknown);

			// image data
			for (int i = 0; i < Data.Length; i++)
			{
				bw.Write(Data[i]);
			}
		}
		#endregion

		#region Bitmap Read/Write
		/// <summary>
		/// Convert this Ci8Image to a Bitmap.
		/// </summary>
		/// <param name="pal">CI8 Palette data to use.</param>
		/// <returns></returns>
		public Bitmap ToBitmap(Ci8Palette pal)
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

			Bitmap bOut = new Bitmap(Width, Height);

			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					byte palIdx = Data[(y * Width) + x];
					Color c = N64Colors.Value5551ToColor(pal.Entries[palIdx]);
					bOut.SetPixel(x, y, c);
				}
			}

			return bOut;
		}

		/// <summary>
		/// Convert Bitmap to Ci8Texture.
		/// </summary>
		/// <param name="inBmp">Bitmap to convert.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool FromBitmap(Bitmap inBmp)
		{
			if (inBmp.PixelFormat != PixelFormat.Format8bppIndexed)
			{
				return false;
			}

			Width = (UInt16)inBmp.Width;
			Height = (UInt16)inBmp.Height;

			// convert palette
			SortedList<int, Color> BitmapColors = new SortedList<int, Color>();
			UInt16[] Palette = new UInt16[256];
			for (int i = 0; i < inBmp.Palette.Entries.Length; i++)
			{
				BitmapColors.Add(i, inBmp.Palette.Entries[i]);
				Palette[i] = N64Colors.ColorToValue5551(inBmp.Palette.Entries[i]);
			}

			// one pixel = one byte
			Data = new byte[Width * Height];
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					Data[(y * Width) + x] = (byte)BitmapColors.IndexOfValue(inBmp.GetPixel(x, y));
				}
			}

			return true;
		}
		#endregion
	}
}
