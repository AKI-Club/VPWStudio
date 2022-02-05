using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Story Mode Singles Participant used in WrestleMania 2000 (assumed) and Virtual Pro-Wrestling 2.
	/// </summary>
	public class StoryModeSingle_Modern
	{
		#region Members
		/// <summary>
		/// Wrestler ID2 value for this slot.
		/// </summary>
		public byte WrestlerID2;

		/// <summary>
		/// Wrestler skill level. Valid values are 0-4.
		/// </summary>
		public byte SkillLevel;

		/// <summary>
		/// Percentage chance for title shots.
		/// </summary>
		public UInt16 TitleShotPercent;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StoryModeSingle_Modern()
		{
			WrestlerID2 = 0;
			SkillLevel = 0;
			TitleShotPercent = 0;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_id2">Wrestler ID2</param>
		/// <param name="_skill">Skill Level</param>
		/// <param name="_chance">Title Shot Chance</param>
		public StoryModeSingle_Modern(byte _id2, byte _skill, UInt16 _chance)
		{
			WrestlerID2 = _id2;
			SkillLevel = _skill;
			TitleShotPercent = _chance;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StoryModeSingle_Modern(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read StoryModeSingle_Modern data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			WrestlerID2 = br.ReadByte();
			SkillLevel = br.ReadByte();

			byte[] titleShot = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(titleShot);
			}
			TitleShotPercent = BitConverter.ToUInt16(titleShot, 0);
		}

		/// <summary>
		/// Write StoryModeSingle_Modern data using a BinaryReader.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(WrestlerID2);
			bw.Write(SkillLevel);

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
