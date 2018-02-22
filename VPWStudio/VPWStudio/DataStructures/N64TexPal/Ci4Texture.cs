using System;
using System.IO;
using System.Drawing;

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
		/// Convert this Ci4Image to a Bitmap.
		/// </summary>
		/// <param name="pal">CI4 Palette data to use.</param>
		/// <returns></returns>
		public Bitmap GetBitmap(Ci4Palette pal)
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

			Bitmap bOut = new Bitmap(this.Width, this.Height);

			for (int y = 0; y < this.Height; y++)
			{
				for (int x = 0; x < this.Width; x++)
				{
					byte palIdx = this.Data[(y * this.Width) + x];
					Color c = N64Colors.ValueToColor5551(pal.Entries[palIdx]);
					bOut.SetPixel(x, y, c);
				}
			}

			return bOut;
		}
	}
}
