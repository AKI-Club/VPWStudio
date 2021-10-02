using System;
using System.IO;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// WWF WrestleMania 2000 Stable Definition.
	/// </summary>
	public class StableDefinition
	{
		/// <summary>
		/// Maximum number of wrestlers in a stable.
		/// </summary>
		private const int MAX_WRESTLERS_IN_STABLE = 8;

		#region Class Members
		/// <summary>
		/// Pointer to Wrestler Definitions for this Stable.
		/// </summary>
		public UInt32 WrestlerPointerStart;

		/// <summary>
		/// Number of wrestlers in this Stable.
		/// </summary>
		public byte NumWrestlers;

		/// <summary>
		/// Pointer to stable name.
		/// </summary>
		public UInt32 StableNamePointer;

		/// <summary>
		/// Wrestlers in this stable.
		/// </summary>
		public byte[] WrestlerID2s;

		/// <summary>
		/// Actual stable name.
		/// </summary>
		public string StableName;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StableDefinition()
		{
			WrestlerPointerStart = 0;
			NumWrestlers = 0;
			StableNamePointer = 0;
			WrestlerID2s = new byte[MAX_WRESTLERS_IN_STABLE];
			StableName = String.Empty;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br"></param>
		public StableDefinition(BinaryReader br)
		{
			WrestlerPointerStart = 0;
			NumWrestlers = 0;
			StableNamePointer = 0;
			WrestlerID2s = new byte[MAX_WRESTLERS_IN_STABLE];
			StableName = String.Empty;
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read StableData using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// get wrestler pointer and num wrestlers
			byte[] wrsPtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wrsPtr);
			}
			WrestlerPointerStart = BitConverter.ToUInt32(wrsPtr, 0);

			NumWrestlers = br.ReadByte();

			// skip padding bytes
			br.ReadBytes(3);

			// get stable name pointer
			byte[] namePtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(namePtr);
			}
			StableNamePointer = BitConverter.ToUInt32(namePtr, 0);

			// save position for later
			long curPos = br.BaseStream.Position;

			// obtain wrestlers
			br.BaseStream.Seek(Z64Rom.PointerToRom(WrestlerPointerStart), SeekOrigin.Begin);
			for (int i = 0; i < NumWrestlers; i++)
			{
				WrestlerID2s[i] = br.ReadByte();
			}

			// fill in any blanks
			if (NumWrestlers < MAX_WRESTLERS_IN_STABLE)
			{
				for (int j = MAX_WRESTLERS_IN_STABLE-1; j > NumWrestlers; j--)
				{
					WrestlerID2s[j] = 0;
				}
			}

			// obtain stable name
			StableName = GetName(br);

			// restore position
			br.BaseStream.Seek(curPos, SeekOrigin.Begin);
		}

		/// <summary>
		/// Write StableData using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] wrsPtr = BitConverter.GetBytes(WrestlerPointerStart);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wrsPtr);
			}
			bw.Write(wrsPtr);

			// write number of wrestlers and padding bytes
			bw.Write(NumWrestlers);
			bw.Write(new byte[] { 0, 0, 0 });

			byte[] namePtr = BitConverter.GetBytes(StableNamePointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(namePtr);
			}
			bw.Write(namePtr);

			long curPos = bw.BaseStream.Position;

			// write wrestlers to pointer
			// this is trickier, because writing e.g. 3 wrestlers would be 4 slots
			bw.BaseStream.Seek(Z64Rom.PointerToRom(WrestlerPointerStart), SeekOrigin.Begin);
			for (int i = 0; i < NumWrestlers; i++)
			{
				bw.Write(WrestlerID2s[i]);
			}

			if (NumWrestlers % 4 != 0)
			{
				// determine the closest multiple of 4
				int numPad = 4 - (NumWrestlers % 4);

				// pad with 0x00
				for (int j = 0; j < numPad; j++)
				{
					bw.Write((byte)0);
				}
			}

			// write stable name (don't forget the ending 0x00)
			bw.BaseStream.Seek(Z64Rom.PointerToRom(StableNamePointer), SeekOrigin.Begin);

			// restore position
			bw.BaseStream.Seek(curPos, SeekOrigin.Begin);
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Get stable name from ROM.
		/// </summary>
		/// <param name="br">BinaryReader instance to use</param>
		/// <returns>A string with the stable's name</returns>
		public string GetName(BinaryReader br)
		{
			UInt32 nameAddr = Z64Rom.PointerToRom(StableNamePointer);
			br.BaseStream.Seek(nameAddr, SeekOrigin.Begin);
			string s = String.Empty;
			while (br.PeekChar() != 0)
			{
				s += br.ReadChar();
			}
			return s;
		}

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
			return GetWrestlerCount() == MAX_WRESTLERS_IN_STABLE;
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
