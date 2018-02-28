using System;
using System.IO;
using System.Drawing;

namespace VPWStudio
{
	/// <summary>
	/// AkiTexture, a.k.a. "TEX" (based on the magic number.)
	/// </summary>
	public class AkiTexture
	{
		/// <summary>
		/// Possible 
		/// </summary>
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
			this.Width = 0;
			this.Height = 0;
			this.ImageFormat = 0;
			this.ColorWidth = 0;
			this.PaletteNumColors = 0;
			this.Palette = null;
			this.Data = null;
			//this.CachedBitmap = null;
		}

		/// <summary>
		/// Constructor using BinaryReader.
		/// </summary>
		/// <param name="br"></param>
		public AkiTexture(BinaryReader br)
		{
			this.ReadData(br);
			//this.CachedBitmap = null;
		}

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
			this.Width = BitConverter.ToUInt16(w, 0);

			byte[] h = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(h);
			}
			this.Height = BitConverter.ToUInt16(h, 0);

			this.ImageFormat = (AkiTextureFormat)br.ReadByte();
			this.ColorWidth = br.ReadByte();

			// read palette num colors
			byte[] pnc = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pnc);
			}
			this.PaletteNumColors = BitConverter.ToUInt16(pnc, 0);

			// skip to 0x10
			br.BaseStream.Seek(0x10, SeekOrigin.Begin);
			// read palette (todo: might need to handle this differently)
			this.Palette = new ushort[this.PaletteNumColors];
			for (int i = 0; i < this.PaletteNumColors; i++)
			{
				byte[] cd = br.ReadBytes(2);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(cd);
				}
				this.Palette[i] = BitConverter.ToUInt16(cd,0);
			}

			// read image data
			// size depends on image format...
			br.BaseStream.Seek((this.PaletteNumColors * this.ColorWidth) + 0x10, SeekOrigin.Begin);
			switch (this.ImageFormat)
			{
				case AkiTextureFormat.Ci4:
					// one byte = two pixels
					{
						int numPixels = this.Width * this.Height;
						this.Data = new byte[numPixels];
						int i = 0;
						while (i < numPixels)
						{
							byte b = br.ReadByte();
							this.Data[i] = (byte)((b & 0xF0) >> 4);
							this.Data[i + 1] = (byte)(b & 0x0F);
							i += 2;
						}
					}
					break;
				case AkiTextureFormat.Ci8:
					// one byte = one pixel
					{
						int numPixels = this.Width * this.Height;
						this.Data = new byte[numPixels];
						int i = 0;
						while (i < numPixels)
						{
							this.Data[i] = br.ReadByte();
							i++;
						}
					}
					break;
			}

			return true; // ok
		}

		/// <summary>
		/// Convert this AkiTexture to a Bitmap.
		/// </summary>
		/// <returns></returns>
		public Bitmap ToBitmap(bool _skipCache = false)
		{
			if (this.Data == null)
			{
				return null;
			}

			/*
			if (!_skipCache && this.CachedBitmap != null)
			{
				return this.CachedBitmap;
			}
			*/

			Bitmap bOut = new Bitmap(this.Width, this.Height);

			switch (this.ImageFormat)
			{
				case AkiTextureFormat.Ci4:
				case AkiTextureFormat.Ci8:
					ToBitmap_CI(bOut);
					break;

				default:
					break;
			}

			//this.CachedBitmap = bOut;
			return bOut;
		}

		/// <summary>
		/// Convert CI8 format image to Bitmap pixels.
		/// </summary>
		/// <param name="bOut"></param>
		private void ToBitmap_CI(Bitmap bOut)
		{
			for (int y = 0; y < this.Height; y++)
			{
				for (int x = 0; x < this.Width; x++)
				{
					byte palIdx = this.Data[(y * this.Width) + x];
					Color c = N64Colors.Value5551ToColor(this.Palette[palIdx]);
					bOut.SetPixel(x, y, c);
				}
			}
		}
	}
}
