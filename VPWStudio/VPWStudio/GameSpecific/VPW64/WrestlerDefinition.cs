using System;
using System.IO;

namespace VPWStudio.GameSpecific.VPW64
{
	/// <summary>
	/// Virtual Pro-Wrestling 64 Wrestler Definition
	/// </summary>
	public class WrestlerDefinition
	{
		#region Class Members
		/// <summary>
		/// ??? 1
		/// </summary>
		public UInt16 Unknown1;

		/// <summary>
		/// Wrestler ID4 (e.g. 0x0A01)
		/// </summary>
		public UInt16 WrestlerID4;

		/// <summary>
		/// Wrestler ID2
		/// </summary>
		public byte WrestlerID2;

		/// <summary>
		/// includes Heavyweight vs. Cruiserweight status
		/// </summary>
		public byte Flags1;

		/// <summary>
		/// ??? 2
		/// </summary>
		public UInt16 Unknown2;

		/// <summary>
		/// Pointer to Name data
		/// </summary>
		public UInt32 NamePointer;

		/// <summary>
		/// Pointer to Profile string
		/// </summary>
		public UInt32 ProfilePointer;

		/// <summary>
		/// Pointer to separate Height string
		/// </summary>
		public UInt32 HeightPointer;

		/// <summary>
		/// Pointer to separate Weight string
		/// </summary>
		public UInt32 WeightPointer;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerDefinition()
		{
			Unknown1 = 0;
			WrestlerID4 = 0;
			WrestlerID2 = 0;
			Flags1 = 0;
			Unknown2 = 0;
			NamePointer = 0;
			ProfilePointer = 0;
			HeightPointer = 0;
			WeightPointer = 0;
		}

		public WrestlerDefinition(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read WrestlerDefinition data with a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] unk1 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk1);
			}
			Unknown1 = BitConverter.ToUInt16(unk1, 0);

			byte[] id4 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			WrestlerID4 = BitConverter.ToUInt16(id4, 0);

			WrestlerID2 = br.ReadByte();
			Flags1 = br.ReadByte();

			byte[] unk2 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk2);
			}
			Unknown2 = BitConverter.ToUInt16(unk2, 0);

			byte[] namePtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(namePtr);
			}
			NamePointer = BitConverter.ToUInt32(namePtr, 0);

			byte[] profPtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(profPtr);
			}
			ProfilePointer = BitConverter.ToUInt32(profPtr, 0);

			byte[] hPtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(hPtr);
			}
			HeightPointer = BitConverter.ToUInt32(hPtr, 0);

			byte[] wPtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wPtr);
			}
			WeightPointer = BitConverter.ToUInt32(wPtr, 0);
		}

		public void WriteData(BinaryWriter bw)
		{
			byte[] id4 = BitConverter.GetBytes(WrestlerID4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			bw.Write(id4);
			// todo: the rest of it
		}
		#endregion
	}
}
