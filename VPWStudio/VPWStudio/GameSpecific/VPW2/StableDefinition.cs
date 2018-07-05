using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Virtual Pro-Wrestling 2 Stable Definition
	/// </summary>
	/// todo: WWF No Mercy uses the same format.
	public class StableDefinition
	{
		#region Class Members
		/// <summary>
		/// Pointer to Wrestler Definitions for this Stable.
		/// </summary>
		public UInt32 WrestlerPointerStart;

		/// <summary>
		/// Index of the stable name.
		/// </summary>
		public UInt32 StableNameIndex;

		/// <summary>
		/// Wrestlers in this stable.
		/// </summary>
		public byte[] WrestlerID2s;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StableDefinition()
		{
			WrestlerPointerStart = 0;
			StableNameIndex = 0;
			WrestlerID2s = new byte[8];
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StableDefinition(BinaryReader br)
		{
			WrestlerPointerStart = 0;
			StableNameIndex = 0;
			WrestlerID2s = new byte[8];
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read StableDefinition data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] wptr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wptr);
			}
			WrestlerPointerStart = BitConverter.ToUInt32(wptr, 0);

			byte[] name = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(name);
			}
			StableNameIndex = BitConverter.ToUInt32(name, 0);

			// read in wrestlers
			long curPos = br.BaseStream.Position;
			br.BaseStream.Seek(Z64Rom.PointerToRom(WrestlerPointerStart), SeekOrigin.Begin);
			int i = 0;
			while (br.PeekChar() != 0)
			{
				WrestlerID2s[i] = br.ReadByte();
				i++;
			}
			br.BaseStream.Seek(curPos, SeekOrigin.Begin);
		}

		public void WriteData(BinaryWriter bw)
		{
			byte[] wptr = BitConverter.GetBytes(WrestlerPointerStart);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wptr);
			}
			bw.Write(wptr);

			byte[] name = BitConverter.GetBytes(StableNameIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(name);
			}
			bw.Write(name);
			long curPos = bw.BaseStream.Position;

			// write out the wrestler IDs
			bw.BaseStream.Seek(Z64Rom.PointerToRom(WrestlerPointerStart), SeekOrigin.Begin);
			for (int i = 0; i < WrestlerID2s.Length; i++)
			{
				bw.Write(WrestlerID2s[i]);
			}
			bw.BaseStream.Seek(curPos, SeekOrigin.Begin);
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Get the number of used wrestler slots in this Stable.
		/// </summary>
		/// <returns>Number of non-zero entries in WrestlerID2s.</returns>
		public int GetWrestlerCount()
		{
			int count = 0;
			for (int i = 0; i < WrestlerID2s.Length; i++)
			{
				if (WrestlerID2s[i] != 0)
				{
					count++;
				}
			}
			return count;
		}

		/// <summary>
		/// Determine if this group has the maximum amount of wrestlers.
		/// </summary>
		/// <returns>True if all slots are used in this group, false otherwise.</returns>
		public bool IsGroupFull()
		{
			return GetWrestlerCount() == 8;
		}

		/// <summary>
		/// Gets the index of the first empty slot in this stable.
		/// </summary>
		/// <returns>Positive integer if found empty, -1 if group is full.</returns>
		public int GetFirstEmptySlot()
		{
			int slot = -1;
			for (int i = 0; i < WrestlerID2s.Length; i++)
			{
				if (WrestlerID2s[i] == 0)
				{
					slot = i;
					break;
				}
			}

			return slot;
		}
		#endregion
	}
}
