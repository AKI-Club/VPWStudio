using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.Revenge
{
	/// <summary>
	/// WCW/nWo Revenge Wrestler Parameters
	/// </summary>
	public class WrestlerParams
	{
		// 64 bytes worth of data.
		#region Class Members
		// 0x00-0x04 currently unknown
		public byte Offset00;
		public byte Offset01;
		public byte Offset02;
		public byte Offset03;
		public byte Offset04;
		
		/// <summary>
		/// Attack parameters. (Offsets 0x05-0x09 inclusive)
		/// </summary>
		public byte[] OffenseValues;

		/// <summary>
		/// Defense parameters. (Offsets 0x0A-0x0E inclusive)
		/// </summary>
		public byte[] DefenseValues;

		// 0x0F-0x2D currently unknown
		public byte Offset0F;
		public byte Offset10;
		public byte Offset11;
		public byte Offset12;
		public byte Offset13;
		public byte Offset14;
		public byte Offset15;
		public byte Offset16;
		public byte Offset17;
		public byte Offset18;
		public byte Offset19;
		public byte Offset1A;
		public byte Offset1B;
		public byte Offset1C;
		public byte Offset1D;
		public byte Offset1E;
		public byte Offset1F;
		public byte Offset20;
		public byte Offset21;
		public byte Offset22;
		public byte Offset23;
		public byte Offset24;
		public byte Offset25;
		public byte Offset26;
		public byte Offset27;
		public byte Offset28;
		public byte Offset29;
		public byte Offset2A;
		public byte Offset2B;
		public byte Offset2C;
		public byte Offset2D;

		/// <summary>
		/// ID4s of wrestlers who will interfere in matches. (Offsets 0x2E-0x37 inclusive)
		/// </summary>
		public UInt16[] InterferenceID4s;

		// 0x38-0x3F currently (mostly) unknown
		public byte Offset38;
		public byte Offset39;
		public byte Offset3A;
		public byte Offset3B;
		public byte Offset3C;
		public byte Offset3D;
		public byte Offset3E;
		public byte Offset3F;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerParams()
		{
			OffenseValues = new byte[5];
			DefenseValues = new byte[5];
			InterferenceID4s = new UInt16[5];
		}
		#endregion

		#region Binary Load/Save
		public void ReadData(BinaryReader br)
		{
			Offset00 = br.ReadByte();
			Offset01 = br.ReadByte();
			Offset02 = br.ReadByte();
			Offset03 = br.ReadByte();
			Offset04 = br.ReadByte();

			OffenseValues = br.ReadBytes(5);
			DefenseValues = br.ReadBytes(5);

			Offset0F = br.ReadByte();
			Offset10 = br.ReadByte();
			Offset11 = br.ReadByte();
			Offset12 = br.ReadByte();
			Offset13 = br.ReadByte();
			Offset14 = br.ReadByte();
			Offset15 = br.ReadByte();
			Offset16 = br.ReadByte();
			Offset17 = br.ReadByte();
			Offset18 = br.ReadByte();
			Offset19 = br.ReadByte();
			Offset1A = br.ReadByte();
			Offset1B = br.ReadByte();
			Offset1C = br.ReadByte();
			Offset1D = br.ReadByte();
			Offset1E = br.ReadByte();
			Offset1F = br.ReadByte();
			Offset20 = br.ReadByte();
			Offset21 = br.ReadByte();
			Offset22 = br.ReadByte();
			Offset23 = br.ReadByte();
			Offset24 = br.ReadByte();
			Offset25 = br.ReadByte();
			Offset26 = br.ReadByte();
			Offset27 = br.ReadByte();
			Offset28 = br.ReadByte();
			Offset29 = br.ReadByte();
			Offset2A = br.ReadByte();
			Offset2B = br.ReadByte();
			Offset2C = br.ReadByte();
			Offset2D = br.ReadByte();

			// interference ID4s
			for (int i = 0; i < InterferenceID4s.Length; i++)
			{
				byte[] id4 = br.ReadBytes(2);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(id4);
				}
				InterferenceID4s[i] = BitConverter.ToUInt16(id4, 0);
			}

			Offset38 = br.ReadByte();
			Offset39 = br.ReadByte();
			Offset3A = br.ReadByte();
			Offset3B = br.ReadByte();
			Offset3C = br.ReadByte();
			Offset3D = br.ReadByte();
			Offset3E = br.ReadByte();
			Offset3F = br.ReadByte();
		}

		public void WriteData(BinaryWriter bw)
		{

		}
		#endregion
	}
}
