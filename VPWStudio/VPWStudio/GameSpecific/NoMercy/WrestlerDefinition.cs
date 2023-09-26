using System;
using System.IO;

namespace VPWStudio.GameSpecific.NoMercy
{
	/// <summary>
	/// WWF No Mercy Wrestler Definition.
	/// </summary>
	[Serializable]
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
		public UInt16 WrestlerID2;

		/// <summary>
		/// Theme Music
		/// </summary>
		public byte ThemeSong;

		/// <summary>
		/// Entrance/"TitanTron" Video
		/// </summary>
		public byte EntranceVideo;

		/// <summary>
		/// Height value
		/// </summary>
		/// 0x00 = 5'0"
		/// 0x23 = 7'11"
		/// 0x24 = ?? (Short)
		/// 0x25 = ??? (Medium)
		/// 0x26 = !!! (Tall)
		/// 0x27 = fake 6'6" (Crash Holly)
		public byte Height;

		/// <summary>
		/// Byte with currently unknown purpose
		/// </summary>
		public byte Unknown;

		/// <summary>
		/// Weight value (in pounds; add 0x64 (100) for real value)
		/// </summary>
		/// Special case values starting at 600lbs:
		/// 0x01F4 = ?? (Light Heavy)
		/// 0x01F5 = ??? (Heavy)
		/// 0x01F6 = !!! (Super Heavy)
		/// 0x01F7 = fake 400 lbs. (Crash Holly)
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
		/// Index into appearances table?
		/// </summary>
		public UInt16 AppearanceIndex;

		/// <summary>
		/// Index into profile/default names table?
		/// </summary>
		public UInt16 ProfileIndex;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerDefinition()
		{
			WrestlerID4 = 0;
			WrestlerID2 = 0;
			ThemeSong = 0;
			EntranceVideo = 0;
			Height = 0;
			Unknown = 0;
			Weight = 0;
			MovesetFileIndex = 0;
			ParamsFileIndex = 0;
			AppearanceIndex = 0;
			ProfileIndex = 0;
		}

		/// <summary>
		/// Constructor from loaded data.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WrestlerDefinition(BinaryReader br)
		{
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

			ThemeSong = br.ReadByte();
			EntranceVideo = br.ReadByte();
			Height = br.ReadByte();
			Unknown = br.ReadByte();

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

			byte[] appearIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(appearIdx);
			}
			AppearanceIndex = BitConverter.ToUInt16(appearIdx, 0);

			byte[] profileIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(profileIdx);
			}
			ProfileIndex = BitConverter.ToUInt16(profileIdx, 0);

			// prepare for another possible read
			br.ReadBytes(2);
		}

		/// <summary>
		/// Write WrestlerDefinition data using a BinaryWriter.
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

			byte[] id2 = BitConverter.GetBytes(WrestlerID2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id2);
			}
			bw.Write(id2);

			bw.Write(ThemeSong);
			bw.Write(EntranceVideo);
			bw.Write(Height);
			bw.Write(Unknown);

			byte[] w = BitConverter.GetBytes(Weight);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(w);
			}
			bw.Write(w);

			byte[] moveIdx = BitConverter.GetBytes(MovesetFileIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(moveIdx);
			}
			bw.Write(moveIdx);

			byte[] paramIdx = BitConverter.GetBytes(ParamsFileIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(paramIdx);
			}
			bw.Write(paramIdx);

			byte[] appearIdx = BitConverter.GetBytes(AppearanceIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(appearIdx);
			}
			bw.Write(appearIdx);

			byte[] profileIdx = BitConverter.GetBytes(ProfileIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(profileIdx);
			}
			bw.Write(profileIdx);

			bw.Write((Int16)0);
		}
		#endregion
	}
}
