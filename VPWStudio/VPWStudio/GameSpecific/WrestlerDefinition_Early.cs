using System;
using System.IO;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// WCW vs. nWo World Tour and Virtual Pro-Wrestling 64 Wrestler Definition
	/// </summary>
	public class WrestlerDefinition_Early
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

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerDefinition_Early()
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

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WrestlerDefinition_Early(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read WrestlerDefinition_Early data with a BinaryReader.
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

		/// <summary>
		/// Write WrestlerDefinition_Early data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] unk1 = BitConverter.GetBytes(Unknown1);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk1);
			}
			bw.Write(unk1);

			byte[] id4 = BitConverter.GetBytes(WrestlerID4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			bw.Write(id4);

			bw.Write(WrestlerID2);
			bw.Write(Flags1);

			byte[] unk2 = BitConverter.GetBytes(Unknown2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk2);
			}
			bw.Write(unk2);

			byte[] namePtr = BitConverter.GetBytes(NamePointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(namePtr);
			}
			bw.Write(namePtr);

			byte[] profPtr = BitConverter.GetBytes(ProfilePointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(profPtr);
			}
			bw.Write(profPtr);

			byte[] heightPtr = BitConverter.GetBytes(HeightPointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(heightPtr);
			}
			bw.Write(heightPtr);

			byte[] weightPtr = BitConverter.GetBytes(WeightPointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(weightPtr);
			}
			bw.Write(weightPtr);
		}
		#endregion
	}
}
