using System;
using System.IO;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Story Mode Team used in Virtual Pro-Wrestling 2.
	/// </summary>
	public class StoryModeTeamEntry
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
		/// Percentage chance for title shots.
		/// </summary>
		public UInt16 TitleShotPercent;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StoryModeTeamEntry()
		{
			WrestlerID2_1 = 0;
			WrestlerID2_2 = 0;
			TitleShotPercent = 0;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_wrestler1">Wrestler 1</param>
		/// <param name="_wrestler2">Wrestler 2</param>
		/// <param name="_chance">Title Shot Chance</param>
		public StoryModeTeamEntry(byte _wrestler1, byte _wrestler2, UInt16 _chance)
		{
			WrestlerID2_1 = _wrestler1;
			WrestlerID2_2 = _wrestler2;
			TitleShotPercent = _chance;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StoryModeTeamEntry(BinaryReader br)
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

			byte[] titleShot = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(titleShot);
			}
			TitleShotPercent = BitConverter.ToUInt16(titleShot, 0);
		}

		/// <summary>
		/// Write StoryModeTeam_Modern data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(WrestlerID2_1);
			bw.Write(WrestlerID2_2);

			byte[] titleShot = BitConverter.GetBytes(TitleShotPercent);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(titleShot);
			}
			bw.Write(titleShot);
		}
		#endregion
	}
}
