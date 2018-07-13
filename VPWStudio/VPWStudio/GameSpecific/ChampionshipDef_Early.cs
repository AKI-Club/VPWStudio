using System;
using System.IO;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Championship definition for WCW vs. nWo World Tour and Virtual Pro-Wrestling 64.
	/// </summary>
	/// I forget if Revenge uses something similar offhand and I'm too lazy to check right now.
	public class ChampionshipDef_Early
	{
		// a single championship data is 16 bytes
		#region Class Members
		public byte Unknown0;
		public byte Unknown1;
		public byte Unknown2;
		public byte Unknown3;
		public byte Unknown4; // weight class
		public byte Unknown5; // match type
		public byte Unknown6; // (related to icon)
		public byte Unknown7; // (related to icon)

		public UInt16 Unknown8;
		public UInt16 Unknown10;

		/// <summary>
		/// Pointer to name for this Championship.
		/// </summary>
		public UInt32 NamePointer;
		#endregion

		#region Program-specific
		/// <summary>
		/// Actual championship name.
		/// </summary>
		public string ChampionshipName;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ChampionshipDef_Early()
		{
			Unknown0 = 0;
			Unknown1 = 0;
			Unknown2 = 0;
			Unknown3 = 0;
			Unknown4 = 0;
			Unknown5 = 0;
			Unknown6 = 0;
			Unknown7 = 0;

			Unknown8 = 0;
			Unknown10 = 0;
			NamePointer = 0;
			ChampionshipName = String.Empty;
		}

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			Unknown0 = br.ReadByte();
			Unknown1 = br.ReadByte();
			Unknown2 = br.ReadByte();
			Unknown3 = br.ReadByte();
			Unknown4 = br.ReadByte();
			Unknown5 = br.ReadByte();
			Unknown6 = br.ReadByte();
			Unknown7 = br.ReadByte();

			byte[] unk8 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk8);
			}
			Unknown8 = BitConverter.ToUInt16(unk8, 0);

			byte[] unk10 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk10);
			}
			Unknown10 = BitConverter.ToUInt16(unk10, 0);

			// then handle the name pointer
			byte[] namePtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(namePtr);
			}
			NamePointer = BitConverter.ToUInt32(namePtr, 0);
		}

		public void WriteData(BinaryWriter bw)
		{
			bw.Write(Unknown0);
			bw.Write(Unknown1);
			bw.Write(Unknown2);
			bw.Write(Unknown3);
			bw.Write(Unknown4);
			bw.Write(Unknown5);
			bw.Write(Unknown6);
			bw.Write(Unknown7);

			byte[] unk8 = BitConverter.GetBytes(Unknown8);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk8);
			}
			bw.Write(unk8);

			byte[] unk10 = BitConverter.GetBytes(Unknown10);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk10);
			}
			bw.Write(unk10);

			byte[] namePtr = BitConverter.GetBytes(NamePointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(namePtr);
			}
			bw.Write(namePtr);
		}
		#endregion
	}
}
