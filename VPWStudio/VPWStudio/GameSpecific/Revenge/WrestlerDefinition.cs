﻿using System;
using System.IO;

namespace VPWStudio.GameSpecific.Revenge
{
	/// <summary>
	/// WCW/nWo Revenge Wrestler Definition
	/// </summary>
	public class WrestlerDefinition
	{
		#region Class Members
		/// <summary>
		/// Wrestler ID4 (e.g. 0x0A01)
		/// </summary>
		public UInt16 WrestlerID4;

		/// <summary>
		/// Wrestler ID2
		/// </summary>
		public byte WrestlerID2;

		public byte Unknown1;

		public UInt16 Unknown2;

		public UInt16 Unknown3;

		/// <summary>
		/// Pointer to Name data
		/// </summary>
		public UInt32 NamePointer;

		/// <summary>
		/// Pointer to Height data
		/// </summary>
		public UInt32 HeightPointer;

		/// <summary>
		/// Pointer to Weight data
		/// </summary>
		public UInt32 WeightPointer;

		public byte Unknown4;

		/// <summary>
		/// ID2 of Manager
		/// </summary>
		public byte ManagerID2;

		public byte Unknown5;
		public byte Unknown6;

		public string Name;
		public string HeightString;
		public string WeightString;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerDefinition()
		{
			WrestlerID4 = 0;
			WrestlerID2 = 0;
			Unknown1 = 0;
			Unknown2 = 0;
			Unknown3 = 0;
			NamePointer = 0;
			HeightPointer = 0;
			WeightPointer = 0;
			Unknown4 = 0;
			Unknown5 = 0;
			Unknown6 = 0;

			Name = "";
			HeightString = "";
			WeightString = "";
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
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
			byte[] id4 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			WrestlerID4 = BitConverter.ToUInt16(id4, 0);

			WrestlerID2 = br.ReadByte();
			Unknown1 = br.ReadByte();

			byte[] unk2 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk2);
			}
			Unknown2 = BitConverter.ToUInt16(unk2, 0);

			byte[] unk3 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk3);
			}
			Unknown3 = BitConverter.ToUInt16(unk3, 0);

			byte[] namePtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(namePtr);
			}
			NamePointer = BitConverter.ToUInt32(namePtr, 0);

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

			Unknown4 = br.ReadByte();
			ManagerID2 = br.ReadByte();
			Unknown5 = br.ReadByte();
			Unknown6 = br.ReadByte();

			// read and ignore terminator bytes
			br.ReadBytes(2);

			// getting name, height, and weight strings interferes with trying to read wrestler data sequentially
			long previousPos = br.BaseStream.Position;
			Name = GetName(br);
			HeightString = GetHeightString(br);
			WeightString = GetWeightString(br);
			br.BaseStream.Seek(previousPos, SeekOrigin.Begin);
		}

		/// <summary>
		/// Write WrestlerDefinition data with a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] id4 = BitConverter.GetBytes(WrestlerID4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			bw.Write(id4);
			bw.Write(WrestlerID2);
			bw.Write(Unknown1);

			byte[] unk2 = BitConverter.GetBytes(Unknown2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk2);
			}
			bw.Write(unk2);

			byte[] unk3 = BitConverter.GetBytes(Unknown3);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk3);
			}
			bw.Write(unk3);

			byte[] namePtr = BitConverter.GetBytes(NamePointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(namePtr);
			}
			bw.Write(namePtr);

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

			bw.Write(Unknown4);
			bw.Write(ManagerID2);
			bw.Write(Unknown5);
			bw.Write(Unknown6);

			// terminator bytes
			bw.Write((ushort)0);
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Get wrestler name from ROM.
		/// </summary>
		/// <param name="br">BinaryReader instance to use</param>
		/// <returns>A string with the wrestler's name</returns>
		public string GetName(BinaryReader br)
		{
			UInt32 nameAddr = Z64Rom.PointerToRom(NamePointer);
			br.BaseStream.Seek(nameAddr, SeekOrigin.Begin);
			string s = String.Empty;
			while (br.PeekChar() != 0)
			{
				s += br.ReadChar();
			}
			return s;
		}

		public string GetHeightString(BinaryReader br)
		{
			UInt32 nameAddr = Z64Rom.PointerToRom(HeightPointer);
			br.BaseStream.Seek(nameAddr, SeekOrigin.Begin);
			string s = String.Empty;
			while (br.PeekChar() != 0)
			{
				s += br.ReadChar();
			}
			return s;
		}

		public string GetWeightString(BinaryReader br)
		{
			UInt32 nameAddr = Z64Rom.PointerToRom(WeightPointer);
			br.BaseStream.Seek(nameAddr, SeekOrigin.Begin);
			string s = String.Empty;
			while (br.PeekChar() != 0)
			{
				s += br.ReadChar();
			}
			return s;
		}
		#endregion
	}
}
