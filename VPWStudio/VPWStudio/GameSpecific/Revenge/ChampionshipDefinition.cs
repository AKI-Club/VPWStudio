using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio.GameSpecific.Revenge
{
	/// <summary>
	/// WCW/nWo Revenge Championship Definition
	/// </summary>
	public class ChampionshipDefinition
	{
		// (20 bytes)

		// [byte] championship number?
		public byte Identifier;

		// [byte] ??? always 7
		public byte Unknown1;

		// [byte] Initial Champion 1 ID2
		public byte ID2_Champion1;

		// [byte] Initial Champion 2 ID2 (leave as 0 if not Tag Team)
		public byte ID2_Champion2;

		// [byte] unknown
		public byte Unknown2;

		// [byte] unknown
		public byte Unknown3;

		// [byte] flags 1 (cruiserweight; others?)
		public byte Flags1;

		// [byte] flags 2 (number of wrestlers; others?)
		public byte Flags2;

		// [byte] unknown (this and the below may be a halfword)
		public byte Unknown4;

		// [byte] unknown (this and the above may be a halfword)
		public byte Unknown5;

		// [half] assumed halfword 1
		public UInt16 Unknown6;

		// [half] assumed halfword 2
		public UInt16 Unknown7;

		// [half] assumed halfword 3
		public UInt16 Unknown8;

		// [word] Pointer to some ID2 list
		public UInt32 RosterPointer;

		// values in roster list
		public List<byte> RosterID2s;

		/// <summary>
		/// Default constructor
		/// </summary>
		public ChampionshipDefinition()
		{
			Identifier = 0;
			Unknown1 = 7;
			ID2_Champion1 = 0;
			ID2_Champion2 = 0;
			Unknown2 = 0;
			Unknown3 = 0;
			Flags1 = 0;
			Flags2 = 0;
			Unknown4 = 0;
			Unknown5 = 0;
			Unknown6 = 0;
			Unknown7 = 0;
			Unknown8 = 0;
			RosterPointer = 0;
			RosterID2s = new List<byte>();
		}

		public ChampionshipDefinition(BinaryReader br)
		{
			RosterID2s = new List<byte>();
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read ChampionshipDefinition data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Identifier = br.ReadByte();
			Unknown1 = br.ReadByte();
			ID2_Champion1 = br.ReadByte();
			ID2_Champion2 = br.ReadByte();
			Unknown2 = br.ReadByte();
			Unknown3 = br.ReadByte();
			Flags1 = br.ReadByte();
			Flags2 = br.ReadByte();
			Unknown4 = br.ReadByte();
			Unknown5 = br.ReadByte();

			byte[] unk6 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk6);
			}
			Unknown6 = BitConverter.ToUInt16(unk6, 0);

			byte[] unk7 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk7);
			}
			Unknown7 = BitConverter.ToUInt16(unk7, 0);

			byte[] unk8 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk8);
			}
			Unknown8 = BitConverter.ToUInt16(unk8, 0);

			byte[] ptrRoster = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ptrRoster);
			}
			RosterPointer = BitConverter.ToUInt32(ptrRoster, 0);

			// read roster data
			long curPos = br.BaseStream.Position;
			br.BaseStream.Seek(Z64Rom.PointerToRom(RosterPointer), SeekOrigin.Begin);
			while (br.PeekChar() != 0)
			{
				RosterID2s.Add(br.ReadByte());
			}

			// restore position for next read
			br.BaseStream.Seek(curPos, SeekOrigin.Begin);
		}
		#endregion
	}
}
