using System;
using System.Drawing;
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
			this.Width = 0;
			this.Height = 0;
			this.Unknown = null;
			this.Data = null;
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read image data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			this.Width = (br.ReadByte() + 1);
			this.Height = (br.ReadByte() + 1);

			// 6 bytes with unknown purpose; some of these might be format indicators?
			this.Unknown = br.ReadBytes(6);

			int numPixels = this.Width * this.Height;
			this.Data = new byte[numPixels];

			// two pixels in one byte
			int i = 0;
			while (i < numPixels)
			{
				byte b = br.ReadByte();
				this.Data[i] = (byte)((b & 0xF0) >> 4);
				this.Data[i + 1] = (byte)(b & 0x0F);
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
			this.Width = width;
			this.Height = height;

			int numPixels = width * height;
			this.Data = new byte[numPixels];

			// two pixels in one byte
			int i = 0;
			while (i < numPixels)
			{
				byte b = br.ReadByte();
				this.Data[i] = (byte)((b & 0xF0) >> 4);
				this.Data[i + 1] = (byte)(b & 0x0F);
				i += 2;
			}
		}
		#endregion

		/// <summary>
		/// Convert this Ci4Image to a Bitmap.
		/// </summary>
		/// <param name="pal">CI4 Palette data to use.</param>
		/// <param name="subPalette">Optional sub-palette number to use.</param>
		/// <returns>Bitmap containing an image drawn with the requested Ci4Palette.</returns>
		public Bitmap GetBitmap(Ci4Palette pal, int subPalette = 0)
		{
			if (this.Data == null)
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

			Bitmap bOut = new Bitmap(this.Width, this.Height);

			for (int y = 0; y < this.Height; y++)
			{
				for (int x = 0; x < this.Width; x++)
				{
					byte palIdx = this.Data[(y * this.Width) + x];
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
	}
}
