using System;
using System.IO;
using System.Drawing;

namespace VPWStudio
{
	/// <summary>
	/// CI8 (Color, Indexed 8bpp) Image
	/// </summary>
	public class Ci8Image
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
		public Ci8Image()
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

			// one pixel per byte
			int i = 0;
			while (i < numPixels)
			{
				this.Data[i] = br.ReadByte();
				i++;
			}
		}

		/// <summary>
		/// Convert this Ci8Image to a Bitmap.
		/// </summary>
		/// <param name="pal">CI8 Palette data to use.</param>
		/// <returns></returns>
		public Bitmap GetBitmap(Ci8Palette pal)
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
