using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Virtual Pro-Wrestling 2 match ruleset.
	/// </summary>
	public class MatchRuleset
	{
		#region Class Members
		/// <summary>
		/// Ruleset value.
		/// </summary>
		/// 0=single, 1=martial arts, 2=tag, 3=battle royal
		public byte RulesetType;

		// time limit
		public byte TimeLimit;

		// round length
		public byte RoundLength;

		/// <summary>
		/// Outside count
		/// </summary>
		/// Battle Royal has different values than other ruleset types.
		public byte OutsideCount;

		/// <summary>
		/// Pinfalls
		/// </summary>
		public byte Pinfall;

		// give up
		public byte Submission;

		/// <summary>
		/// TKO
		/// </summary>
		public byte TKO;

		// rope break
		public byte RopeBreak;

		// quick match
		public byte QuickMatch;

		/// <summary>
		/// Blood
		/// </summary>
		public byte Blood;

		// change title on ring out
		public byte ChangeTitleOnRingOut;

		// time limit decision
		public byte TimeLimitDecision;

		// interference
		public byte Interference;

		// tag help timer
		public byte TagHelpTimer;

		// [mma] starting num. points
		public byte StartPoints;

		// [mma] rope escape
		public byte RopeEscape;

		// [mma] down
		public byte Down;

		// [mma] suplex
		public byte Suplex;

		// [mma] number of rounds
		public byte NumRounds;

		// [mma] gong save
		public byte GongSave;

		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MatchRuleset()
		{
			RulesetType = 0;
			TimeLimit = 0;
			RoundLength = 0;
			OutsideCount = 0;
			Pinfall = 0;
			Submission = 0;
			TKO = 0;
			RopeBreak = 0;
			QuickMatch = 0;
			Blood = 0;
			ChangeTitleOnRingOut = 0;
			TimeLimitDecision = 0;
			Interference = 0;
			TagHelpTimer = 0;
			StartPoints = 0;
			RopeEscape = 0;
			Down = 0;
			Suplex = 0;
			NumRounds = 0;
			GongSave = 0;
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
			RoundLength = br.ReadByte();
			OutsideCount = br.ReadByte();
			Pinfall = br.ReadByte();
			Submission = br.ReadByte();
			TKO = br.ReadByte();
			RopeBreak = br.ReadByte();
			QuickMatch = br.ReadByte();
			Blood = br.ReadByte();
			ChangeTitleOnRingOut = br.ReadByte();
			TimeLimitDecision = br.ReadByte();
			Interference = br.ReadByte();
			TagHelpTimer = br.ReadByte();
			StartPoints = br.ReadByte();
			RopeEscape = br.ReadByte();
			Down = br.ReadByte();
			Suplex = br.ReadByte();
			NumRounds = br.ReadByte();
			GongSave = br.ReadByte();
		}

		/// <summary>
		/// Write Ruleset data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(RulesetType);
			bw.Write(TimeLimit);
			bw.Write(RoundLength);
			bw.Write(OutsideCount);
			bw.Write(Pinfall);
			bw.Write(Submission);
			bw.Write(TKO);
			bw.Write(RopeBreak);
			bw.Write(QuickMatch);
			bw.Write(Blood);
			bw.Write(ChangeTitleOnRingOut);
			bw.Write(TimeLimitDecision);
			bw.Write(Interference);
			bw.Write(TagHelpTimer);
			bw.Write(StartPoints);
			bw.Write(RopeEscape);
			bw.Write(Down);
			bw.Write(Suplex);
			bw.Write(NumRounds);
			bw.Write(GongSave);
		}
		#endregion
	}
}
