using System;
using System.IO;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Shared Stable definition for World Tour and VPW64.
	/// </summary>
	public class StableDef_Early
	{
		#region Class Members
		/// <summary>
		/// Pointer to Wrestler Definitions for this Stable.
		/// </summary>
		public UInt32 WrestlerPointerStart;

		/// <summary>
		/// Number of wrestlers in this Stable.
		/// </summary>
		public UInt32 NumWrestlers;

		// pointer to championships

		/// <summary>
		/// Pointer to Championship Definitions for this Stable.
		/// </summary>
		public UInt32 ChampionshipPointerStart;

		/// <summary>
		/// Number of championships associated with this Stable.
		/// </summary>
		public UInt32 NumChampionships;
		#endregion

		#region Program-Specific
		/// <summary>
		/// Pointers to wrestler definitions used in this Stable.
		/// </summary>
		public UInt32[] WrestlerPointers;

		/// <summary>
		/// Championship data tied to this Stable.
		/// </summary>
		public ChampionshipDef_Early[] ChampionshipData;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StableDef_Early()
		{
			WrestlerPointerStart = 0;
			NumWrestlers = 0;
			ChampionshipPointerStart = 0;
			NumChampionships = 0;
			WrestlerPointers = null;
			ChampionshipData = null;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read StableDef_Early data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] wresPtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wresPtr);
			}
			WrestlerPointerStart = BitConverter.ToUInt32(wresPtr,0 );

			byte[] numWres = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numWres);
			}
			NumWrestlers = BitConverter.ToUInt32(numWres, 0);

			byte[] champPtr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(champPtr);
			}
			ChampionshipPointerStart = BitConverter.ToUInt32(champPtr, 0);

			byte[] numTitles = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numTitles);
			}
			NumChampionships = BitConverter.ToUInt32(numTitles, 0);

			// save location
			long curLoc = br.BaseStream.Position;

			WrestlerPointers = new UInt32[NumWrestlers];
			br.BaseStream.Seek(Z64Rom.PointerToRom(WrestlerPointerStart), SeekOrigin.Begin);
			// read wrestler pointers
			for (int i = 0; i < NumWrestlers; i++)
			{
				byte[] ptr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ptr);
				}
				WrestlerPointers[i] = BitConverter.ToUInt32(ptr, 0);
			}

			ChampionshipData = new ChampionshipDef_Early[NumChampionships];
			// jump to championship pointers
			br.BaseStream.Seek(Z64Rom.PointerToRom(ChampionshipPointerStart), SeekOrigin.Begin);
			// read championship data
			for (int i = 0; i < NumChampionships; i++)
			{
				ChampionshipData[i] = new ChampionshipDef_Early();
				ChampionshipData[i].ReadData(br);
			}

			// reload location
			br.BaseStream.Seek(curLoc, SeekOrigin.Begin);
		}

		/// <summary>
		/// Write StableDef_Early data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] wp = BitConverter.GetBytes(WrestlerPointerStart);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wp);
			}
			bw.Write(wp);

			byte[] wn = BitConverter.GetBytes(NumWrestlers);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wn);
			}
			bw.Write(wn);

			byte[] cp = BitConverter.GetBytes(ChampionshipPointerStart);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(cp);
			}
			bw.Write(cp);

			byte[] cn = BitConverter.GetBytes(NumChampionships);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(cn);
			}
			bw.Write(cn);

			long curPos = bw.BaseStream.Position;

			// update wrestler pointers
			bw.BaseStream.Seek(Z64Rom.PointerToRom(WrestlerPointerStart), SeekOrigin.Begin);
			for (int i = 0; i < NumWrestlers; i++)
			{
				byte[] wresPtr = BitConverter.GetBytes(WrestlerPointers[i]);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(wresPtr);
				}
				bw.Write(wresPtr);
			}

			// update championship data
			bw.BaseStream.Seek(Z64Rom.PointerToRom(ChampionshipPointerStart), SeekOrigin.Begin);
			for (int i = 0; i < NumChampionships; i++)
			{
				ChampionshipData[i].WriteData(bw);
			}

			bw.BaseStream.Seek(curPos, SeekOrigin.Begin);
		}
		#endregion
	}
}
