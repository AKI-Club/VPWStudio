using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

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
		/// Number of Palette Entries.
		/// </summary>
		public UInt16 NumPalEntries;

		/// <summary>
		/// Define if the texture is mirrored horizontally.
		/// </summary>
		public byte HorizMirror;

		/// <summary>
		/// Define if the texture is mirrored vertically.
		/// </summary>
		public byte VertMirror;

		/// <summary>
		/// Bit length of Width value.
		/// </summary>
		public byte WidthBitLength;

		/// <summary>
		/// Bit length of Height value.
		/// </summary>
		public byte HeightBitLength;

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
			NumPalEntries = 256;
			HorizMirror = 0;
			VertMirror = 0;
			WidthBitLength = 0;
			HeightBitLength = 0;
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

			byte[] npe = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(npe);
			}
			NumPalEntries = BitConverter.ToUInt16(npe, 0);

			HorizMirror = br.ReadByte();
			VertMirror = br.ReadByte();
			WidthBitLength = br.ReadByte();
			HeightBitLength = br.ReadByte();

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
		/// Read Raw CI8 texture data (headerless) using a BinaryReader.
		/// </summary>
		/// <param name="width">Width of image</param>
		/// <param name="height">Height of image</param>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadRawData(int width, int height, BinaryReader br)
		{
			Width = width;
			Height = height;

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

			byte[] npe = BitConverter.GetBytes(NumPalEntries);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(npe);
			}
			bw.Write(npe);

			bw.Write(HorizMirror);
			bw.Write(VertMirror);
			bw.Write(WidthBitLength);
			bw.Write(HeightBitLength);

			// image data
			bw.Write(Data);
		}
		#endregion

		#region Bitmap Read/Write
		/// <summary>
		/// Convert this Ci8Texture to a Bitmap.
		/// </summary>
		/// <param name="pal">CI8 Palette data to use.</param>
		/// <returns>Bitmap representing the CI8Texture.</returns>
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
			BitmapData bData = bOut.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			IntPtr imageDataPtr = bData.Scan0;
			int numBytes = Math.Abs(bData.Stride) * Height;
			byte[] bPixels = new byte[numBytes];
			Marshal.Copy(imageDataPtr, bPixels, 0, numBytes);

			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					byte palIdx = Data[(y * Width) + x];
					Color c = N64Colors.Value5551ToColor(pal.Entries[palIdx]);
					bPixels[(((y * Width) + x) * 4)] = c.B;
					bPixels[(((y * Width) + x) * 4) + 1] = c.G;
					bPixels[(((y * Width) + x) * 4) + 2] = c.R;
					bPixels[(((y * Width) + x) * 4) + 3] = c.A;
				}
			}
			Marshal.Copy(bPixels, 0, imageDataPtr, numBytes);
			bOut.UnlockBits(bData);
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

			{
				int temp = Width - 1;
				int l = 0;
				do
				{
					l++;
				} while ((temp >>= 1) != 0);
				WidthBitLength = (byte)l;

				temp = Height - 1;
				l = 0;
				do
				{
					l++;
				} while ((temp >>= 1) != 0);
				HeightBitLength = (byte)l;
			}

			// convert palette
			SortedList<int, Color> BitmapColors = new SortedList<int, Color>();
			NumPalEntries = 256;
			UInt16[] Palette = new UInt16[NumPalEntries];
			for (int i = 0; i < inBmp.Palette.Entries.Length; i++)
			{
				BitmapColors.Add(i, inBmp.Palette.Entries[i]);
				Palette[i] = N64Colors.ColorToValue5551(inBmp.Palette.Entries[i]);
			}

			// one pixel = one byte
			BitmapData bData = inBmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
			IntPtr imageDataPtr = bData.Scan0;
			int numBytes = Math.Abs(bData.Stride) * Height;
			Data = new byte[numBytes];
			Marshal.Copy(imageDataPtr, Data, 0, numBytes);
			inBmp.UnlockBits(bData);
			return true;
		}
		#endregion
	}
}
