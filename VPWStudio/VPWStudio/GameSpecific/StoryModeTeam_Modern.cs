using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Story Mode Team used in WrestleMania 2000 and Virtual Pro-Wrestling 2.
	/// </summary>
	public class StoryModeTeam_Modern
	{
		#region Members
		/// <summary>
		/// First wrestler on team.
		/// </summary>
		public byte WrestlerID2_1;

		/// <summary>
		/// Second wrestler on team.
		/// </summary>
		public byte WrestlerID2_2;

		/// <summary>
		/// Value with currently unknown purpose.
		/// </summary>
		public UInt16 Unknown;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StoryModeTeam_Modern()
		{
			WrestlerID2_1 = 0;
			WrestlerID2_2 = 0;
			Unknown = 0;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_wrestler1">Wrestler 1</param>
		/// <param name="_wrestler2">Wrestler 2</param>
		/// <param name="_unk">Unknown</param>
		public StoryModeTeam_Modern(byte _wrestler1, byte _wrestler2, UInt16 _unk)
		{
			WrestlerID2_1 = _wrestler1;
			WrestlerID2_2 = _wrestler2;
			Unknown = _unk;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StoryModeTeam_Modern(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read StoryModeTeam_Modern data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			WrestlerID2_1 = br.ReadByte();
			WrestlerID2_2 = br.ReadByte();

			byte[] unk = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			Unknown = BitConverter.ToUInt16(unk, 0);
		}

		/// <summary>
		/// Write StoryModeTeam_Modern data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(WrestlerID2_1);
			bw.Write(WrestlerID2_2);

			byte[] unk = BitConverter.GetBytes(Unknown);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			bw.Write(unk);
		}
		#endregion
	}
}
