using System;
using System.IO;
using System.Globalization;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Virtual Pro-Wrestling 2 Wrestler Definition.
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
		/// Announcment name
		/// </summary>
		public byte NameCall;

		/// <summary>
		/// Height value (in cm; add 0x23 (35) for real value)
		/// </summary>
		public byte Height;

		/// <summary>
		/// Weight value (in kg; add 0x2D (45) for real value)
		/// </summary>
		public byte Weight;

		/// <summary>
		/// Voice sample 1
		/// </summary>
		public byte Voice1;

		/// <summary>
		/// Voice sample 2
		/// </summary>
		public byte Voice2;

		/// <summary>
		/// Moveset file index
		/// </summary>
		public UInt16 MovesetFileIndex;

		/// <summary>
		/// Parameters file index
		/// </summary>
		public UInt16 ParamsFileIndex;

		/// <summary>
		/// Index into default appearances table
		/// </summary>
		public UInt16 AppearanceIndex;

		/// <summary>
		/// Index into profile/default names table
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
			NameCall = 0;
			Height = 0;
			Weight = 0;
			Voice1 = 0;
			Voice2 = 0;
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
			NameCall = br.ReadByte();
			Height = br.ReadByte();
			Weight = br.ReadByte();
			Voice1 = br.ReadByte();
			Voice2 = br.ReadByte();

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
		private void WriteData(BinaryWriter bw)
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
			bw.Write(NameCall);
			bw.Write(Height);
			bw.Write(Weight);
			bw.Write(Voice1);
			bw.Write(Voice2);

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

			byte[] appear = BitConverter.GetBytes(AppearanceIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(appear);
			}
			bw.Write(appear);

			byte[] profile = BitConverter.GetBytes(ProfileIndex);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(profile);
			}
			bw.Write(profile);

			// terminator
			bw.Write((Int16)0);
		}
		#endregion
	}
}
