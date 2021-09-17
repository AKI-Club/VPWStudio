using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio.GameSpecific.VPW64
{
	/// <summary>
	/// Virtual Pro-Wrestling 64 Stable Definition
	/// </summary>
	public class StableDefinition
	{
		/// <summary>
		/// Maximum number of wrestlers in a stable.
		/// </summary>
		private const int MAX_WRESTLERS_IN_STABLE = 16;

		#region Class Members
		/// <summary>
		/// Pointer to Wrestler Definitions for this Stable.
		/// </summary>
		public UInt32 WrestlerPointerStart;

		/// <summary>
		/// Number of wrestlers in this Stable.
		/// </summary>
		public UInt32 NumWrestlers;

		/// <summary>
		/// Pointer to Championship Text for this Stable.
		/// </summary>
		public UInt32 ChampionshipTextPointer;

		/// <summary>
		/// Number of Championships for this Stable.
		/// </summary>
		public UInt32 NumChampionships;
		#endregion

		#region Program-Specific
		/// <summary>
		/// Pointers to wrestler definitions used in this Stable.
		/// </summary>
		public UInt32[] WrestlerPointers;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StableDefinition()
		{
			WrestlerPointerStart = 0;
			NumWrestlers = 0;
			ChampionshipTextPointer = 0;
			NumChampionships = 0;
			WrestlerPointers = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StableDefinition(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Populate the list of Wrestler pointers.
		/// </summary>
		/// <param name="br">BinaryReader instance with the Input ROM loaded.</param>
		public void PopulateWrestlerPointers(BinaryReader br)
		{
			if (WrestlerPointers == null)
			{
				WrestlerPointers = new UInt32[NumWrestlers];
			}

			br.BaseStream.Seek(Z64Rom.PointerToRom(WrestlerPointerStart), SeekOrigin.Begin);
			for (int i = 0; i < this.NumWrestlers; i++)
			{
				byte[] ptr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ptr);
				}
				WrestlerPointers[i] = BitConverter.ToUInt32(ptr, 0);
			}
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

			byte[] numWrestlers = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numWrestlers);
			}
			NumWrestlers = BitConverter.ToUInt32(numWrestlers, 0);

			byte[] cptr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(cptr);
			}
			ChampionshipTextPointer = BitConverter.ToUInt32(cptr, 0);

			byte[] numBelts = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numBelts);
			}
			NumChampionships = BitConverter.ToUInt32(numBelts, 0);

			// get wrestler pointers
			long curLoc = br.BaseStream.Position;
			PopulateWrestlerPointers(br);
			br.BaseStream.Seek(curLoc, SeekOrigin.Begin);
		}
		#endregion
	}
}
