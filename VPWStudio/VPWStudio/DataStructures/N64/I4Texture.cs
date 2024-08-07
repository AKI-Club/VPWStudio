﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// 4BPP intensity-only image.
	/// </summary>
	/// Images I've found do not have width and height values; game probably provides them somehow.
	public class I4Texture
	{
		#region Class Members
		/// <summary>
		/// Image pixels
		/// </summary>
		public byte[] Data;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public I4Texture()
		{
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
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
				Data[i] = (byte)((b & 0xF0) >> 4);
				Data[i + 1] = (byte)(b & 0x0F);
				i += 2;
			}
		}
		#endregion

		/// <summary>
		/// Convert this I4Texture into a Bitmap.
		/// </summary>
		/// <param name="width">I4Texture Width</param>
		/// <param name="height">I4Texture Height</param>
		/// <param name="drawColor">Color to draw with (optional; defaults to White)</param>
		/// <returns>Bitmap representing the I4Texture.</returns>
		public Bitmap ToBitmap(int width, int height, Color? drawColor = null)
		{
			if (Data == null)
			{
				return null;
			}

			if (drawColor == null)
			{
				drawColor = Color.White;
			}

			Bitmap bOut = new Bitmap(width, height);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					byte palIdx = Data[(y * width) + x];
					// I am not sure if alpha is meant to be calculated like this,
					// but it matches how most I4 textures look in game.
					// Whether or not the game performs this transform is unknown.
					bOut.SetPixel(x, y, Color.FromArgb((15 - palIdx) * 16, drawColor.Value.R, drawColor.Value.G, drawColor.Value.B));
				}
			}

			return bOut;
		}
	}
}
