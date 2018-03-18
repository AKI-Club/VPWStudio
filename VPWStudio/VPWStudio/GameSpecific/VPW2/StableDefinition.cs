using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Virtual Pro-Wrestling 2 Stable Definition
	/// </summary>
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

		#region Binary Read/Write
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
		#endregion
	}
}
