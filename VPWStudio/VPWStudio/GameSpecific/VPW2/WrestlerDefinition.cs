using System;
using System.IO;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Virtual Pro-Wrestling 2 Wrestler Definition.
	/// </summary>
	public class WrestlerDefinition : IWrestlerDefinition
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
		/// Index into appearances table?
		/// </summary>
		public UInt16 AppearanceIndex;

		/// <summary>
		/// Index into profile/default names table?
		/// </summary>
		public UInt16 ProfileIndex;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerDefinition()
		{
			this.WrestlerID4 = 0;
			this.WrestlerID2 = 0;
			this.ThemeSong = 0;
			this.NameCall = 0;
			this.Height = 0;
			this.Weight = 0;
			this.Voice1 = 0;
			this.Voice2 = 0;
			this.MovesetFileIndex = 0;
			this.ParamsFileIndex = 0;
			this.AppearanceIndex = 0;
			this.ProfileIndex = 0;
		}

		/// <summary>
		/// Constructor from loaded data.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WrestlerDefinition(BinaryReader br)
		{
			this.ReadData(br);
		}

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
			this.WrestlerID4 = BitConverter.ToUInt16(id4, 0);

			byte[] id2 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id2);
			}
			this.WrestlerID2 = BitConverter.ToUInt16(id2, 0);

			this.ThemeSong = br.ReadByte();
			this.NameCall = br.ReadByte();
			this.Height = br.ReadByte();
			this.Weight = br.ReadByte();
			this.Voice1 = br.ReadByte();
			this.Voice2 = br.ReadByte();

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

			byte[] appearIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(appearIdx);
			}
			this.AppearanceIndex = BitConverter.ToUInt16(appearIdx, 0);

			byte[] profileIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(profileIdx);
			}
			this.ProfileIndex = BitConverter.ToUInt16(profileIdx, 0);

			// prepare for another possible read
			br.ReadBytes(2);
		}
	}
}
