using System;
using System.Drawing;
using System.IO;

namespace VPWStudio.GameSpecific.Revenge
{
	/// <summary>
	/// A collection of two AkiTexture files, back to back.
	/// Used in the WCW/nWo Revenge credits sequence.
	/// </summary>
	public class DoubleTex
	{
		/// <summary>
		/// AkiTextures in this DoubleTex.
		/// </summary>
		AkiTexture[] Textures;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DoubleTex()
		{
			Textures = new AkiTexture[2];
			Textures[0] = new AkiTexture();
			Textures[1] = new AkiTexture();
		}

		#region Binary Read/Write
		/// <summary>
		/// Read DoubleTex data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Textures[0].ReadData(br);
			Textures[1].ReadData(br);
		}

		/// <summary>
		/// Write DoubleTex data using a BinaryWriter.
		/// </summary>
		/// <param name="br">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			Textures[0].WriteData(bw);
			Textures[1].WriteData(bw);
		}
		#endregion

		/// <summary>
		/// Convert a DoubleTex into two Bitmap objects.
		/// </summary>
		/// <returns>An array of two Bitmap objects representing the textures in the DoubleTex.</returns>
		public Bitmap[] ToBitmaps()
		{
			return new Bitmap[2]
			{
				Textures[0].ToBitmap(),
				Textures[1].ToBitmap()
			};
		}
	}
}
