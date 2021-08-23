using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace VPWStudio
{
	/// <summary>
	/// CLUT (color lookup table; i.e. "palette") data
	/// </summary>
	public class ClutData
	{
		#region Class Members
		/// <summary>
		/// Length of the CLUT data, including the 4 bytes for this variable.
		/// </summary>
		public UInt32 DataLength;

		/// <summary>
		/// X coordinate for CLUT data in the framebuffer.
		/// </summary>
		public UInt16 XCoordinate;

		/// <summary>
		/// Y coordinate for CLUT data in the framebuffer.
		/// </summary>
		public UInt16 YCoordinate;

		/// <summary>
		/// Width of the CLUT data in the framebuffer.
		/// </summary>
		public UInt16 DataWidth;

		/// <summary>
		/// Height of the CLUT data in the framebuffer.
		/// </summary>
		public UInt16 DataHeight;

		/// <summary>
		/// CLUT values
		/// </summary>
		/// FEDCBA9876543210
		/// ||___||___||___|
		/// |  |    |    |
		/// |  |    |    +--- Red
		/// |  |    +-------- Green
		/// |  +------------- Blue
		/// +---------------- (Semi-)Transparent
		public List<UInt16> Data;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor. Not guaranteed to be usable.
		/// </summary>
		public ClutData()
		{
			DataLength = 12; // no data other than the header by default.
			XCoordinate = 0;
			YCoordinate = 0;
			DataWidth = 16;
			DataHeight = 1;
			Data = new List<UInt16>();
		}

		/// <summary>
		/// Constructor from BinaryReader, meant to be callled during TIM reading.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public ClutData(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Get the palette entries in the CLUT as System.Drawing.Color values.
		/// </summary>
		/// <returns>A List of System.Drawing.Color values representing the data in the CLUT.</returns>
		public List<Color> GetColors()
		{
			List<Color> colors = new List<Color>();

			foreach (UInt16 c in Data)
			{
				int r = (c & 0x1F) * 8;
				int g = ((c & 0x3E0) >> 5) * 8;
				int b = ((c & 0x7C00) >> 10) * 8;

				// alpha/transparency calculation is a bit more complicated than just checking the top bit
				bool isBlack = (r==0 && g==0 && b==0);
				bool topBitSet = (c & 0x8000) != 0;
				int a = 0;

				if (isBlack && !topBitSet)
				{
					// if r,g,b are 0 and stp/transparency is also 0, it's fully transparent.
					a = 0;
				}
				else if ((isBlack && topBitSet) || (!isBlack && !topBitSet))
				{
					a = 255;
				}
				else if (!isBlack && topBitSet)
				{
					// if stp/transparency is 1 and r,g,b, are not all 0, it's semi-transparent.
					a = 128;
				}

				colors.Add(Color.FromArgb(a, r, g, b));
			}

			return colors;
		}

		#region Binary Read/Write (CLUT inside of a TIM file)
		/// <summary>
		/// Read CLUT data from a TIM file using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] len = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(len);
			}
			DataLength = BitConverter.ToUInt32(len, 0);

			byte[] xPos = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(xPos);
			}
			XCoordinate = BitConverter.ToUInt16(xPos, 0);

			byte[] yPos = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(yPos);
			}
			YCoordinate = BitConverter.ToUInt16(yPos, 0);

			byte[] dataWidth = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(dataWidth);
			}
			DataWidth = BitConverter.ToUInt16(dataWidth, 0);

			byte[] dataHeight = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(dataHeight);
			}
			DataHeight = BitConverter.ToUInt16(dataHeight, 0);

			Data = new List<ushort>();
			for (int i = 0; i < (DataWidth * DataHeight); i++)
			{
				byte[] color = br.ReadBytes(2);
				if (!BitConverter.IsLittleEndian)
				{
					Array.Reverse(color);
				}
				Data.Add(BitConverter.ToUInt16(color,0));
			}
		}

		/// <summary>
		/// Write CLUT data to a TIM file using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			// re-calculate DataLength
			DataLength = (uint)((Data.Count * sizeof(UInt16)) + 12);
			byte[] len = BitConverter.GetBytes(DataLength);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(len);
			}
			bw.Write(len);

			byte[] xPos = BitConverter.GetBytes(XCoordinate);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(xPos);
			}
			bw.Write(xPos);

			byte[] yPos = BitConverter.GetBytes(YCoordinate);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(yPos);
			}
			bw.Write(yPos);

			byte[] dataWidth = BitConverter.GetBytes(DataWidth);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(dataWidth);
			}
			bw.Write(dataWidth);

			byte[] dataHeight = BitConverter.GetBytes(DataHeight);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(dataHeight);
			}
			bw.Write(dataHeight);

			foreach (UInt16 c in Data)
			{
				byte[] value = BitConverter.GetBytes(c);
				if (!BitConverter.IsLittleEndian)
				{
					Array.Reverse(value);
				}
				bw.Write(value);
			}
		}
		#endregion
	}
}
