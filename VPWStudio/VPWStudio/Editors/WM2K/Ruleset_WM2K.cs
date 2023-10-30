using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.WM2K;

namespace VPWStudio.Editors.WM2K
{
	public partial class Ruleset_WM2K : Form
	{
		public MatchRuleset[] Rulesets = new MatchRuleset[12];

		// fun fact: The rule values mean different things based on the core ruleset type!
		// Some values only get used in certain ruleset types.

		#region Ruleset Strings
		private readonly string[] DefaultRulesetExplanations = new string[]
		{
			"Default Singles",
			"Default Martial Arts (unused)",
			"Default Tag",
			"Default Royal Rumble",
			"? Singles",
			"? Tag",
			"? Singles",
			"? Royal Rumble",
			"? Singles Cage?",
			"? Singles",
			"? Singles",
			"? Singles Cage?",
		};

		private readonly string[] RulesetStrings = new string[]
		{
			"Singles",
			"Martial Arts",
			"Tag Team",
			"Royal Rumble"
		};

		private readonly string[] CommonYesNoStrings = new string[]
		{
			"On",
			"Off"
		};

		private readonly string[] BloodStrings = new string[]
		{
			"On",
			"First Blood",
			"Off",
		};

		private readonly string[] TimeLimits_Wrestling = new string[]
		{
			"5 Minutes",
			"10 Minutes",
			"15 Minutes",
			"20 Minutes",
			"25 Minutes",
			"30 Minutes",
			"35 Minutes",
			"40 Minutes",
			"45 Minutes",
			"50 Minutes",
			"55 Minutes",
			"60 Minutes",
			"No Limit",
		};

		private readonly string[] TimeLimits_MartialArts = new string[]
		{
			"3 Minutes",
			"5 Minutes",
			"10 Minutes",
			"15 Minutes",
			"20 Minutes",
			"30 Minutes",
			"60 Minutes",
			"No Limit"
		};

		private readonly string[] OutsideStrings_Normal = new string[]
		{
			"10 Count",
			"20 Count",
			"Lumberjack",
			"No DQ",
			"No"
		};

		private readonly string[] OutsideStrings_BattleRoyal = new string[]
		{
			"Loss",
			"Anywhere",
			"Off"
		};

		private readonly string[] SubmissionStrings = new string[]
		{
			"On",
			"Off",
			"mystery third option"
		};

		private readonly string[] NumRoundsStrings = new string[]
		{
			"1 Round",
			"2 Rounds",
			"3 Rounds",
			"4 Rounds",
			"5 Rounds",
			"8 Rounds",
			"10 Rounds",
			"12 Rounds",
			"15 Rounds",
			"Off"
		};

		private readonly string[] NumPointsStrings = new string[]
		{
			"3 Points",
			"5 Points",
			"10 Points",
			"15 Points",
			"Free",
		};

		private readonly string[] TagHelpTimerStrings = new string[]
		{
			"5 Seconds",
			"10 Seconds",
			"15 Seconds",
			"20 Seconds",
			"30 Seconds",
			"40 Seconds",
			"50 Seconds",
			"60 Seconds",
			"No Touch/Tornado Tag"
		};

		// used for Down and Rope Escape
		private readonly string[] MartialArtsScoringStrings = new string[]
		{
			"1 Point",
			"2 Points",
			"3 Points",
			"Free",
			"Off"
		};

		// Suplex doesn't have an "Off" feature
		private readonly string[] SuplexPointsStrings = new string[]
		{
			"1 Point",
			"2 Points",
			"3 Points",
			"Free"
		};
		#endregion

		public Ruleset_WM2K()
		{
			InitializeComponent();

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry sdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["DefaultRulesets"]);
				if (sdEntry != null)
				{
					romReader.BaseStream.Seek(sdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Default Ruleset location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["DefaultRulesets"].Offset, SeekOrigin.Begin);
			}
			for (int i = 0; i < Rulesets.Length; i++)
			{
				Rulesets[i] = new MatchRuleset(romReader);
			}
			romReader.Close();

			cbRulesets.BeginUpdate();
			for (int i = 0; i < Rulesets.Length; i++)
			{
				cbRulesets.Items.Add(String.Format("0x{0:X2} - {1}",i, DefaultRulesetExplanations[i]));
			}
			cbRulesets.EndUpdate();
			cbRulesets.SelectedIndex = 0;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void cbRulesets_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbRulesets.SelectedIndex < 0)
			{
				return;
			}

			MatchRuleset curRuleset = Rulesets[cbRulesets.SelectedIndex];
			tbMatchRuleset.Text = String.Format("0x{0:X2} ({1})", curRuleset.RulesetType, RulesetStrings[curRuleset.RulesetType]);

			switch(curRuleset.RulesetType)
			{
				case 3:
					// battle royal, forced to "none"
					tbTimeLimit.Text = String.Format("0x{0:X2} (None)", curRuleset.TimeLimit);
					break;

				default:
					// default
					tbTimeLimit.Text = String.Format("0x{0:X2} ({1})", curRuleset.TimeLimit, TimeLimits_Wrestling[curRuleset.TimeLimit]);
					break;
			}

			//tbUnused1.Text = String.Format("0x{0:X2} ({1})", curRuleset.Unused1, TimeLimits_MartialArts[curRuleset.RoundLength]);
			tbUnused1.Text = String.Format("0x{0:X2}", curRuleset.Unused1);

			switch (curRuleset.RulesetType) {
				case 1:
					tbOutsideCount.Text = String.Format("0x{0:X2} (Off)", curRuleset.OutsideCount);
					break;

				case 3:
					tbOutsideCount.Text = String.Format("0x{0:X2} ({1})", curRuleset.OutsideCount, OutsideStrings_BattleRoyal[curRuleset.OutsideCount]);
					break;

				default:
					tbOutsideCount.Text = String.Format("0x{0:X2} ({1})", curRuleset.OutsideCount, OutsideStrings_Normal[curRuleset.OutsideCount]);
					break;
			}

			tbPinfall.Text = String.Format("0x{0:X2} ({1})", curRuleset.Pinfall, CommonYesNoStrings[curRuleset.Pinfall]);
			tbSubmission.Text = String.Format("0x{0:X2} ({1})", curRuleset.Submission, SubmissionStrings[curRuleset.Submission]);
			tbTKO.Text = String.Format("0x{0:X2} ({1})", curRuleset.TKO, CommonYesNoStrings[curRuleset.TKO]);
			tbRopeBreak.Text = String.Format("0x{0:X2} ({1})", curRuleset.RopeBreak, CommonYesNoStrings[curRuleset.RopeBreak]);
			tbBlood.Text = String.Format("0x{0:X2} ({1})", curRuleset.Blood, BloodStrings[curRuleset.Blood]);
			tbUnused2.Text = String.Format("0x{0:X2} ({1})", curRuleset.Unused2, CommonYesNoStrings[curRuleset.Unused2]);
			tbUnused3.Text = String.Format("0x{0:X2} ({1})", curRuleset.Unused3, CommonYesNoStrings[curRuleset.Unused3]);
			tbInterference.Text = String.Format("0x{0:X2} ({1})", curRuleset.Interference, CommonYesNoStrings[curRuleset.Interference]);
			tbBloodCage.Text = String.Format("0x{0:X2} ({1})", curRuleset.BloodCage, CommonYesNoStrings[curRuleset.BloodCage]);
			tbTagHelpTimer.Text = String.Format("0x{0:X2} ({1})", curRuleset.TagHelpTimer, TagHelpTimerStrings[curRuleset.TagHelpTimer]);
			tbUnused4.Text = String.Format("0x{0:X2}", curRuleset.Unused4);
			tbUnused5.Text = String.Format("0x{0:X2}", curRuleset.Unused5);
			tbUnused6.Text = String.Format("0x{0:X2}", curRuleset.Unused6);
			tbUnused7.Text = String.Format("0x{0:X2}", curRuleset.Unused7);
			tbUnused8.Text = String.Format("0x{0:X2}", curRuleset.Unused8);
		}
	}
}
