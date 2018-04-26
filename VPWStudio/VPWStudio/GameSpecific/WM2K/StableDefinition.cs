using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// WWF WrestleMania 2000 Stable Definition.
	/// </summary>
	public class StableDefinition
	{
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

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StableDefinition()
		{
			WrestlerPointerStart = 0;
			NumWrestlers = 0;
			StableNamePointer = 0;
			WrestlerID2s = new byte[8];
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
			WrestlerID2s = new byte[8];
			StableName = String.Empty;
			ReadData(br);
		}

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
			if (NumWrestlers < 8)
			{
				for (int j = 8 - NumWrestlers; j < 8; j++)
				{
					WrestlerID2s[j] = 0;
				}
			}

			// obtain stable name
			br.BaseStream.Seek(Z64Rom.PointerToRom(StableNamePointer), SeekOrigin.Begin);

			string result = String.Empty;
			while (br.PeekChar() != 0)
			{
				result += br.ReadChar();
			}

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
				// pad with 0x00
			}

			// write stable name
			bw.BaseStream.Seek(Z64Rom.PointerToRom(StableNamePointer), SeekOrigin.Begin);

			// restore position
			bw.BaseStream.Seek(curPos, SeekOrigin.Begin);
		}
		#endregion
	}
}
