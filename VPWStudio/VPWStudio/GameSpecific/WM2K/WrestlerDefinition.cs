using System;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// WWF WrestleMania 2000 Wrestler Definition.
	/// </summary>
	[Serializable]
	public class WrestlerDefinition
	{
		#region Class Members
		/// <summary>
		/// Name pointer
		/// </summary>
		public UInt32 NamePointer;

		/// <summary>
		/// Wrestler ID4 (e.g. 0x0A01)
		/// </summary>
		public UInt16 WrestlerID4;

		/// <summary>
		/// Wrestler ID2
		/// </summary>
		public UInt16 WrestlerID2;

		/// <summary>
		/// Height value (in ?; add 0x?? (?) for real value)
		/// </summary>
		/// 0x00 = 5'0"
		/// 0x23 = 7'11"
		/// 0x24 = ??? 1 (Short)
		/// 0x25 = ??? 2 (Medium)
		/// 0x26 = ??? 3 (Tall)
		public UInt16 Height;

		/// <summary>
		/// Weight value (in pounds; add 0x64 (100) for real value)
		/// </summary>
		/// Special case: values over 699 are shown as "???"
		public UInt16 Weight;

		/// <summary>
		/// Moveset file index
		/// </summary>
		public UInt16 MovesetFileIndex;

		/// <summary>
		/// Parameters file index
		/// </summary>
		public UInt16 ParamsFileIndex;

		/// <summary>
		/// Theme Music
		/// </summary>
		public byte ThemeSong;

		/// <summary>
		/// Entrance/"TitanTron" Video
		/// </summary>
		public byte EntranceVideo;

		/// <summary>
		/// Unknown value
		/// </summary>
		public UInt16 Unknown;

		/// <summary>
		/// Costume pointers (4x)
		/// </summary>
		public UInt32[] CostumePointers;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerDefinition()
		{
			this.NamePointer = 0;
			this.WrestlerID4 = 0;
			this.WrestlerID2 = 0;
			this.Height = 0;
			this.Weight = 0;
			this.MovesetFileIndex = 0;
			this.ParamsFileIndex = 0;
			this.ThemeSong = 0;
			this.EntranceVideo = 0;
			this.Unknown = 0;
			this.CostumePointers = new UInt32[4];
		}

		/// <summary>
		/// Constructor from loaded data.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WrestlerDefinition(BinaryReader br)
		{
			this.CostumePointers = new UInt32[4];
			this.ReadData(br);
		}

		/// <summary>
		/// Read WrestlerDefinition data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] np = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(np);
			}
			this.NamePointer = BitConverter.ToUInt32(np,0);

			byte[] id4 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			this.WrestlerID4 = BitConverter.ToUInt16(id4, 0);

			byte[] id2 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id2);
			}
			this.WrestlerID2 = BitConverter.ToUInt16(id2, 0);

			byte[] h = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(h);
			}
			this.Height = BitConverter.ToUInt16(h, 0);

			byte[] w = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(w);
			}
			this.Weight = BitConverter.ToUInt16(w, 0);

			byte[] moveIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(moveIdx);
			}
			this.MovesetFileIndex = BitConverter.ToUInt16(moveIdx, 0);

			byte[] paramIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(paramIdx);
			}
			this.ParamsFileIndex = BitConverter.ToUInt16(paramIdx, 0);

			this.ThemeSong = br.ReadByte();
			this.EntranceVideo = br.ReadByte();

			byte[] unk = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			this.Unknown = BitConverter.ToUInt16(unk, 0);

			for (int i = 0; i < 4; i++)
			{
				byte[] cosptr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(cosptr);
				}
				this.CostumePointers[i] = BitConverter.ToUInt32(cosptr, 0);
			}
		}

		/// <summary>
		/// Get wrestler name from ROM.
		/// </summary>
		/// <param name="br"></param>
		/// <returns></returns>
		public string GetName(BinaryReader br)
		{
			UInt32 nameAddr = Z64Rom.PointerToRom(this.NamePointer);
			br.BaseStream.Seek(nameAddr, SeekOrigin.Begin);
			string s = String.Empty;
			while (br.PeekChar() != 0)
			{
				s += br.ReadChar();
			}
			return s;
		}
	}
}
