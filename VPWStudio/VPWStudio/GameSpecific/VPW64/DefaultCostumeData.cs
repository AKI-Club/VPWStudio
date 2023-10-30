using System;
using System.IO;

// note: doesn't handle the separate per-wrestler body table yet
namespace VPWStudio.GameSpecific.VPW64
{
	/// <summary>
	/// A single VPW64 Default Costume Data entry.
	/// </summary>
	public class DefaultCostumeDataEntry
	{
		#region Class Members
		/// <summary>
		/// Head/Mask number used for this costume. Often 0x00.
		/// </summary>
		public byte Head;

		/// <summary>
		/// Costume number used for this costume.
		/// </summary>
		public byte Costume;

		/// <summary>
		/// First color used for this costume.
		/// Format: 0x0_, where _ is the color (0-F).
		/// </summary>
		public byte Color1;

		/// <summary>
		/// Second and third colors used for this costume.
		/// </summary>
		public byte Color2;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public DefaultCostumeDataEntry()
		{
			Head = 0;
			Costume = 0;
			Color1 = 0;
			Color2 = 0;
		}

		/// <summary>
		/// Specific constructor using specific values.
		/// </summary>
		/// <param name="head">Head/Mask number. Most often 0x00.</param>
		/// <param name="cos">Costume number.</param>
		/// <param name="color1">Costume color 1.</param>
		/// <param name="color2">Costume colors 2 and 3.</param>
		public DefaultCostumeDataEntry(byte head, byte cos, byte color1, byte color2)
		{
			Head = head;
			Costume = cos;
			Color1 = color1;
			Color2 = color2;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public DefaultCostumeDataEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Helpers
		public int GetColor(int colNum)
		{
			switch (colNum)
			{
				case 0: return Color1;
				case 1: return (Color2 & 0xF0) >> 4;
				case 2: return (Color2 & 0x0F);
			}

			// invalid
			return -1;
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read a VPW64 default costume data slot using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Head = br.ReadByte();
			Costume = br.ReadByte();
			Color1 = br.ReadByte();
			Color2 = br.ReadByte();
		}

		/// <summary>
		/// Write a VPW64 default costume data slot using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(Head);
			bw.Write(Costume);
			bw.Write(Color1);
			bw.Write(Color2);
		}
		#endregion
	}

	/// <summary>
	/// VPW64 Default Costume Data.
	/// </summary>
	public class DefaultCostumeData
	{
		/// <summary>
		/// Number of costume entries per wrestler.
		/// </summary>
		public static readonly int NUM_COSTUMES = 4;

		#region Class Members
		/// <summary>
		/// The actual costumes.
		/// </summary>
		public DefaultCostumeDataEntry[] Costumes;

		/// <summary>
		/// Unknown value #1.
		/// First value after the last costume.
		/// If nonzero, 8 bytes of ExtraData follow.
		/// </summary>
		public UInt16 Unknown1;

		/// <summary>
		/// Unknown value #2.
		/// Position depends on value of Unknown1.
		/// </summary>
		public UInt16 Unknown2;

		/// <summary>
		/// 8 bytes of currently unknown purpose.
		/// </summary>
		public byte[] ExtraData;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public DefaultCostumeData()
		{
			Costumes = new DefaultCostumeDataEntry[NUM_COSTUMES];
			for (int _ = 0; _ < Costumes.Length; _++)
			{
				Costumes[_] = new DefaultCostumeDataEntry();
			}
			Unknown1 = 0;
			Unknown2 = 0;
			ExtraData = new byte[8];
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		// no, I can't use ": base()" here; I tried
		public DefaultCostumeData(BinaryReader br)
		{
			Costumes = new DefaultCostumeDataEntry[NUM_COSTUMES];
			for (int _ = 0; _ < Costumes.Length; _++)
			{
				Costumes[_] = new DefaultCostumeDataEntry();
			}
			Unknown1 = 0;
			Unknown2 = 0;
			ExtraData = new byte[8];

			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read VPW64 Default Costume Data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			for (int c = 0; c < Costumes.Length; c++)
			{
				Costumes[c].ReadData(br);
			}
			byte unk1_1 = br.ReadByte();
			byte unk1_2 = br.ReadByte();
			Unknown1 = (UInt16)(((unk1_1 & 0xFF) << 8) | (unk1_2 & 0xFF));

			if (Unknown1 != 0)
			{
				// ExtraData bullshite
				ExtraData = br.ReadBytes(8);
			}

			byte unk2_1 = br.ReadByte();
			byte unk2_2 = br.ReadByte();
			Unknown2 = (UInt16)(((unk2_1 & 0xFF) << 8) | (unk2_2 & 0xFF));
		}

		/// <summary>
		/// Write VPW64 Default Costume Data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			for (int c = 0; c < Costumes.Length; c++)
			{
				Costumes[c].WriteData(bw);
			}

			bw.Write((byte)((Unknown1 & 0xFF00) >> 8));
			bw.Write((byte)(Unknown1 & 0x00FF));

			if (Unknown1 != 0)
			{
				bw.Write(ExtraData);
			}

			bw.Write((byte)((Unknown2 & 0xFF00) >> 8));
			bw.Write((byte)(Unknown2 & 0x00FF));
		}
		#endregion
	}
}
