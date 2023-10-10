using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Editors.VPW2
{
	public partial class Ruleset_VPW2 : Form
	{
		public MatchRuleset[] Rulesets = new MatchRuleset[23];

		// fun fact: The rule values mean different things based on the core ruleset type!
		// Some values only get used in certain ruleset types.

		#region Ruleset Strings
		private readonly string[] DefaultRulesetExplanations = new string[]
		{
			"Default Singles",
			"Default Martial Arts",
			"Default Tag",
			"Default Battle Royal",
			"RRS/KRS Singles",
			"RRS/KRS Tag",
			"RRS/KRS Singles - Champion Carnival League",
			"RRS/KRS Singles - Champion Carnival Final",
			"RRS/KRS Tag - World's Strongest Tag League",
			"RRS/KRS Tag - World's Strongest Tag League Final",
			"RRS/KRS Singles - Fan Appreciation Day Tournament",
			"RRS/KRS Tag - Fan Appreciation Day Tournament",
			"RRS/KRS Battle Royal - New Year's Giant Series",
			"RRS/KRS Single - Triple Crown Championship",
			"RRS/KRS Tag - Tag Championship",
			"RRS/KRS Tag - All-Asia Tag Championship",
			"Demo - Single",
			"Demo - Tag",
			"Demo - Martial Arts 1",
			"Demo - Martial Arts 2",
			"Demo - Martial Arts 3",
			"Demo - Martial Arts 4",
			"Demo - Martial Arts 5",
		};

		private readonly string[] RulesetStrings = new string[]
		{
			"Singles",
			"Martial Arts",
			"Tag Team",
			"Battle Royal"
		};

		private readonly string[] CommonYesNoStrings = new string[]
		{
			"On",
			"Off"
		};

		private readonly string[] BloodStrings = new string[]
		{
			"On",
			"Referee Stop",
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
			"Anywhere",
			"Off"
		};

		private readonly string[] OutsideStrings_BattleRoyal = new string[]
		{
			"Loss",
			"Anywhere",
			"Off"
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

		public Ruleset_VPW2()
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
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["DefaultRulesets"].Offset, SeekOrigin.Begin);
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

			tbRoundLength.Text = String.Format("0x{0:X2} ({1})", curRuleset.RoundLength, TimeLimits_MartialArts[curRuleset.RoundLength]);

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
			tbSubmission.Text = String.Format("0x{0:X2} ({1})", curRuleset.Submission, CommonYesNoStrings[curRuleset.Submission]);
			tbTKO.Text = String.Format("0x{0:X2} ({1})", curRuleset.TKO, CommonYesNoStrings[curRuleset.TKO]);
			tbRopeBreak.Text = String.Format("0x{0:X2} ({1})", curRuleset.RopeBreak, CommonYesNoStrings[curRuleset.RopeBreak]);
			tbQuickMatch.Text = String.Format("0x{0:X2} ({1})", curRuleset.QuickMatch, CommonYesNoStrings[curRuleset.QuickMatch]);
			tbBlood.Text = String.Format("0x{0:X2} ({1})", curRuleset.Blood, BloodStrings[curRuleset.Blood]);
			tbChangeTitleRingOut.Text = String.Format("0x{0:X2} ({1})", curRuleset.ChangeTitleOnRingOut, CommonYesNoStrings[curRuleset.ChangeTitleOnRingOut]);
			tbTimeLimitDecision.Text = String.Format("0x{0:X2} ({1})", curRuleset.TimeLimitDecision, CommonYesNoStrings[curRuleset.TimeLimitDecision]);
			tbInterference.Text = String.Format("0x{0:X2} ({1})", curRuleset.Interference, CommonYesNoStrings[curRuleset.Interference]);
			tbTagHelpTimer.Text = String.Format("0x{0:X2} ({1})", curRuleset.TagHelpTimer, TagHelpTimerStrings[curRuleset.TagHelpTimer]);
			tbStartPoints.Text = String.Format("0x{0:X2} ({1})", curRuleset.StartPoints, NumPointsStrings[curRuleset.StartPoints]);
			tbRopeEscape.Text = String.Format("0x{0:X2} ({1})", curRuleset.RopeEscape, MartialArtsScoringStrings[curRuleset.RopeEscape]);
			tbDown.Text = String.Format("0x{0:X2} ({1})", curRuleset.Down, MartialArtsScoringStrings[curRuleset.Down]);
			tbSuplex.Text = String.Format("0x{0:X2} ({1})", curRuleset.Suplex, SuplexPointsStrings[curRuleset.Suplex]);
			tbNumRounds.Text = String.Format("0x{0:X2} ({1})", curRuleset.NumRounds, NumRoundsStrings[curRuleset.NumRounds]);
			tbGongSave.Text = String.Format("0x{0:X2} ({1})", curRuleset.GongSave, CommonYesNoStrings[curRuleset.GongSave]);
		}
	}
}
