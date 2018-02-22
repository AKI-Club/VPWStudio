using System;
using System.IO;
using System.Drawing;

namespace VPWStudio
{
	/// <summary>
	/// CI8 palette; 256 colors.
	/// </summary>
	public class Ci8Palette
	{
		// 512 bytes
		public UInt16[] Entries;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Ci8Palette()
		{
			this.Entries = new UInt16[256];
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public Ci8Palette(BinaryReader br)
		{
			this.ReadData(br);
		}

		#region Read/Write Data.
		/// <summary>
		/// Read CI8 palette data with a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			for (int i = 0; i < 256; i++)
			{
				byte[] b = br.ReadBytes(2);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(b);
				}
				this.Entries[i] = BitConverter.ToUInt16(b, 0);
			}
		}

		/// <summary>
		/// Write CI8 palette data with a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			for (int i = 0; i < 256; i++)
			{
				byte[] b = BitConverter.GetBytes(this.Entries[i]);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(b);
				}
				bw.Write(b);
			}
		}
		#endregion
	}
}
