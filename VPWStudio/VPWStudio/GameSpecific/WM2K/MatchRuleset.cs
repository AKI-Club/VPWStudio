using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// WWF WrestleMania 2000 match ruleset.
	/// </summary>
	public class MatchRuleset
	{
		#region Class Members
		/// <summary>
		/// Ruleset value.
		/// </summary>
		/// 0=single, 1=unused, 2=tag, 3=royal rumble
		public byte RulesetType;

		/// <summary>
		/// Match time limit.
		/// </summary>
		public byte TimeLimit;

		/// <summary>
		/// Corresponds to VPW2's Round Length.
		/// </summary>
		public byte Unused1;

		/// <summary>
		/// Outside count
		/// </summary>
		/// Royal Rumble has different values than other ruleset types.
		public byte OutsideCount;

		/// <summary>
		/// Pinfalls
		/// </summary>
		public byte Pinfall;

		/// <summary>
		/// Submission
		/// </summary>
		public byte Submission;

		/// <summary>
		/// TKO
		/// </summary>
		public byte TKO;

		/// <summary>
		/// Rope Break
		/// </summary>
		public byte RopeBreak;

		/// <summary>
		/// Blood (normal match)
		/// </summary>
		public byte Blood;

		/// <summary>
		/// Corresponds to VPW2's "Change Title on Ring Out".
		/// </summary>
		public byte Unused2;

		/// <summary>
		/// Corresponds to VPW2's "Time Limit Decision".
		/// </summary>
		public byte Unused3;

		/// <summary>
		/// Interference in normal matches; Time Count in Royal Rumble.
		/// </summary>
		public byte Interference;

		/// <summary>
		/// Blood (cage match)
		/// </summary>
		public byte BloodCage;

		/// <summary>
		/// Tag Team help timer.
		/// </summary>
		public byte TagHelpTimer;

		public byte Unused4;
		public byte Unused5;
		public byte Unused6;
		public byte Unused7;
		public byte Unused8;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MatchRuleset()
		{
			RulesetType = 0;
			TimeLimit = 0;
			Unused1 = 0;
			OutsideCount = 0;
			Pinfall = 0;
			Submission = 0;
			TKO = 0;
			RopeBreak = 0;
			Blood = 0;
			Unused2 = 0;
			Unused3 = 0;
			Interference = 0;
			BloodCage = 0;
			TagHelpTimer = 0;
			Unused4 = 0;
			Unused5 = 0;
			Unused6 = 0;
			Unused7 = 0;
			Unused8 = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public MatchRuleset(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read Ruleset data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			RulesetType = br.ReadByte();
			TimeLimit = br.ReadByte();
			Unused1 = br.ReadByte();
			OutsideCount = br.ReadByte();
			Pinfall = br.ReadByte();
			Submission = br.ReadByte();
			TKO = br.ReadByte();
			RopeBreak = br.ReadByte();
			Blood = br.ReadByte();
			Unused2 = br.ReadByte();
			Unused3 = br.ReadByte();
			Interference = br.ReadByte();
			BloodCage = br.ReadByte();
			TagHelpTimer = br.ReadByte();
			Unused4 = br.ReadByte();
			Unused5 = br.ReadByte();
			Unused6 = br.ReadByte();
			Unused7 = br.ReadByte();
			Unused8 = br.ReadByte();
		}

		/// <summary>
		/// Write Ruleset data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(TimeLimit);
			bw.Write(Unused1);
			bw.Write(OutsideCount);
			bw.Write(Pinfall);
			bw.Write(Submission);
			bw.Write(TKO);
			bw.Write(RopeBreak);
			bw.Write(Blood);
			bw.Write(Unused2);
			bw.Write(Unused3);
			bw.Write(Interference);
			bw.Write(BloodCage);
			bw.Write(TagHelpTimer);
			bw.Write(Unused4);
			bw.Write(Unused5);
			bw.Write(Unused6);
			bw.Write(Unused7);
			bw.Write(Unused8);
			bw.Write(RulesetType);
		}
		#endregion
	}
}
