﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

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
		public Ci4Texture()
		{
			Width = 0;
			Height = 0;
			NumPalEntries = 16;
			HorizMirror = 0;
			VertMirror = 0;
			WidthBitLength = 0;
			HeightBitLength = 0;
			Data = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public Ci4Texture(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read (headered) CI4Texture data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Width = (br.ReadByte() + 1);
			Height = (br.ReadByte() + 1);

			// ugly hack for Large Smackdown Mall font in No Mercy (file ID 4A50)
			/*
			if (Width == 256 && Height-1 < 8)
			{
				Height += 256;
			}
			*/

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
		/// Read raw CI4Texture data (no header)
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
		/// Write (headered) CI4Texture data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			// header
			bw.Write((byte)(Width - 1));
			bw.Write((byte)(Height - 1));

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

		/// <summary>
		/// Write Ci4Background data using a BinaryWriter.
		/// </summary>
		/// Ci4Background is a variant of Ci4Texture used in WWF No Mercy for Smackdown Mall backgrounds.
		/// All Ci4Backgrounds are 320x240, and the palette is stored in a separate file.
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteCi4BackgroundData(BinaryWriter bw)
		{
			// header has prefilled bytes
			bw.Write(new byte[]{ 0x3F,0xEF,0x00,0x20,0x00,0x00,0x08,0x07 });

			// then write image data as usual.
			bw.Write(Data);
		}
		#endregion

		#region Bitmap Read/Write
		/// <summary>
		/// Convert this Ci4Texture to a Bitmap.
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
					Color c;
					if (subPalette != 0)
					{
						c = N64Colors.Value5551ToColor(pal.SubPalettes[subPalette-1].Entries[palIdx]);
					}
					else
					{
						c = N64Colors.Value5551ToColor(pal.Entries[palIdx]);
					}
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
			NumPalEntries = 16;
			UInt16[] Palette = new UInt16[NumPalEntries];
			for (int i = 0; i < inBmp.Palette.Entries.Length; i++)
			{
				BitmapColors.Add(i, inBmp.Palette.Entries[i]);
				Palette[i] = N64Colors.ColorToValue5551(inBmp.Palette.Entries[i]);
			}

			// two pixels = one byte
			BitmapData bData = inBmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format4bppIndexed);
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
