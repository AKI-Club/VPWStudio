using System;
using System.IO;
using System.Xml;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// WWF WrestleMania 2000 Wrestler Definition.
	/// </summary>
	[Serializable]
	public class WrestlerDefinition : BaseWrestlerDefinition
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

		// todo: store wrestler name string?

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerDefinition()
		{
			NamePointer = 0;
			WrestlerID4 = 0;
			WrestlerID2 = 0;
			Height = 0;
			Weight = 0;
			MovesetFileIndex = 0;
			ParamsFileIndex = 0;
			ThemeSong = 0;
			EntranceVideo = 0;
			Unknown = 0;
			CostumePointers = new UInt32[4];
		}

		/// <summary>
		/// Constructor from loaded data.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WrestlerDefinition(BinaryReader br)
		{
			CostumePointers = new UInt32[4];
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
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
			NamePointer = BitConverter.ToUInt32(np,0);

			byte[] id4 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			WrestlerID4 = BitConverter.ToUInt16(id4, 0);

			byte[] id2 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id2);
			}
			WrestlerID2 = BitConverter.ToUInt16(id2, 0);

			byte[] h = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(h);
			}
			Height = BitConverter.ToUInt16(h, 0);

			byte[] w = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(w);
			}
			Weight = BitConverter.ToUInt16(w, 0);

			byte[] moveIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(moveIdx);
			}
			MovesetFileIndex = BitConverter.ToUInt16(moveIdx, 0);

			byte[] paramIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(paramIdx);
			}
			ParamsFileIndex = BitConverter.ToUInt16(paramIdx, 0);

			ThemeSong = br.ReadByte();
			EntranceVideo = br.ReadByte();

			byte[] unk = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			Unknown = BitConverter.ToUInt16(unk, 0);

			for (int i = 0; i < 4; i++)
			{
				byte[] cosptr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(cosptr);
				}
				CostumePointers[i] = BitConverter.ToUInt32(cosptr, 0);
			}
		}

		/// <summary>
		/// Write WrestlerDefinition data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] np = BitConverter.GetBytes(NamePointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(np);
			}
			bw.Write(np);

			byte[] id4 = BitConverter.GetBytes(WrestlerID4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			bw.Write(id4);

			byte[] id2 = BitConverter.GetBytes(WrestlerID2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id2);
			}
			bw.Write(id2);

			byte[] h = BitConverter.GetBytes(Height);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(h);
			}
			bw.Write(h);

			byte[] w = BitConverter.GetBytes(Weight);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(w);
			}
			bw.Write(w);

			byte[] moves = BitConverter.GetBytes(MovesetFileIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(moves);
			}
			bw.Write(moves);

			byte[] param = BitConverter.GetBytes(ParamsFileIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(param);
			}
			bw.Write(param);

			bw.Write(ThemeSong);
			bw.Write(EntranceVideo);

			byte[] unk = BitConverter.GetBytes(Unknown);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			bw.Write(unk);

			for (int i = 0; i < 4; i++)
			{
				byte[] cosptr = BitConverter.GetBytes(CostumePointers[i]);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(cosptr);
				}
				bw.Write(cosptr);
			}
		}
		#endregion

		#region XML Read/Write
		public override void ReadXml(XmlReader xr)
		{
			// not implemented yet
		}

		public override void WriteXml(XmlWriter xr)
		{
			// not implemented yet
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Get wrestler name from ROM.
		/// </summary>
		/// <param name="br"></param>
		/// <returns></returns>
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
		#endregion
	}
}
