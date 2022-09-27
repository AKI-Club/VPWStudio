using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.NoMercy
{
	/// <summary>
	/// WWF No Mercy Match Ruleset.
	/// </summary>
	public class MatchRuleset
	{
		#region Class Members
		public byte RulesetType;

		public byte TimeLimit;

		public byte CountOut;

		public byte Pinfall;
		public byte Submission;
		public byte TKO;
		public byte RopeBreak;
		public byte DQ;
		public byte Blood;
		public byte Interference;
		public byte TagHelpTime;

		/// <summary>
		/// Royal Rumble countdown timer between entries
		/// </summary>
		public byte TimeCount;
		#endregion

		#region Constructors
		public MatchRuleset()
		{
			RulesetType = 0;
			TimeLimit = 0;
			CountOut = 0;
			Pinfall = 0;
			Submission = 0;
			TKO = 0;
			RopeBreak = 0;
			DQ = 0;
			Blood = 0;
			Interference = 0;
			TagHelpTime = 0;
			TimeCount = 0;
		}

		public MatchRuleset(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			RulesetType = br.ReadByte();
			TimeLimit = br.ReadByte();
			CountOut = br.ReadByte();
			Pinfall = br.ReadByte();
			Submission = br.ReadByte();
			TKO = br.ReadByte();
			RopeBreak = br.ReadByte();
			DQ = br.ReadByte();
			Blood = br.ReadByte();
			Interference = br.ReadByte();
			TagHelpTime = br.ReadByte();
			TimeCount = br.ReadByte();
		}

		public void WriteData(BinaryWriter bw)
		{
			bw.Write(RulesetType);
			bw.Write(TimeLimit);
			bw.Write(CountOut);
			bw.Write(Pinfall);
			bw.Write(Submission);
			bw.Write(TKO);
			bw.Write(RopeBreak);
			bw.Write(DQ);
			bw.Write(Blood);
			bw.Write(Interference);
			bw.Write(TagHelpTime);
			bw.Write(TimeCount);
		}
		#endregion
	}
}
