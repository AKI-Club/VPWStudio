using System;
using System.Drawing;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// 4BPP intensity-only image.
	/// </summary>
	/// todo: the images I've found do not give width and height values.
	/// other note: the values are possibly reversed (meaning F is transparent and 0 is opaque)
	public class I4Texture
	{
		#region Class Members
		/// <summary>
		/// Image pixels
		/// </summary>
		public byte[] Data;
		#endregion

		public I4Texture()
		{
		}

		public I4Texture(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read I4Texture data with a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// determine file size
			br.BaseStream.Seek(0, SeekOrigin.End);
			int fileSize = (int)br.BaseStream.Position;
			br.BaseStream.Seek(0, SeekOrigin.Begin);

			int numPixels = fileSize * 2;
			Data = new byte[numPixels];

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
		/// Convert this I4Image to a Bitmap.
		/// </summary>
		/// <returns>Bitmap containing an image drawn with the requested Ci4Palette.</returns>
		public Bitmap GetBitmap(int width, int height)
		{
			if (this.Data == null)
			{
				return null;
			}

			Bitmap bOut = new Bitmap(width, height);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					byte palIdx = this.Data[(y * width) + x];
					bOut.SetPixel(x, y, Color.FromArgb(palIdx * 16, 255, 255, 255));
				}
			}

			return bOut;
		}
	}
}
