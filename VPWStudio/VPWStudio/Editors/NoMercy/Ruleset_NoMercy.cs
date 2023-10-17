using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.NoMercy;

namespace VPWStudio.Editors.NoMercy
{
	public partial class Ruleset_NoMercy : Form
	{
		public MatchRuleset[] Rulesets = new MatchRuleset[56];

		#region Ruleset Strings
		// todo: match ruleset types
		// 0x00 = single
		// 0x01 = tag
		// 0x02 = triple threat
		// 0x03 = handicap match
		// 0x04 = cage match
		// 0x05 = ladder match
		// 0x06 = guest referee
		// 0x07 = ?
		// 0x08 = ?
		// 0x09 = ironman match
		// 0x0A = ?
		// 0x0B = ?
		// 0x0C = ?
		// 0x0D = Royal Rumble
		// 0x0E = ?

		private readonly string[] CommonYesNoStrings = new string[]
		{
			"Yes",
			"No"
		};

		// Note: a few match types only have Yes/No (Cage, Ladder)
		private readonly string[] BloodStrings = new string[]
		{
			"Yes",
			"First Blood",
			"No",
		};

		private readonly string[] TimeLimits_Normal = new string[]
		{
			"5 Minutes",
			"10 Minutes",
			"15 Minutes",
			"30 Minutes",
			"60 Minutes",
			"No Limit",
		};

		private readonly string[] TimeLimits_Ironman = new string[]
		{
			"5 Minutes",
			"10 Minutes",
			"15 Minutes",
			"30 Minutes",
			"60 Minutes",
		};

		private readonly string[] OutsideStrings_Normal = new string[]
		{
			"10 Counts",
			"20 Counts",
			"Hardcore",
			"No Count"
		};

		private readonly string[] OutsideStrings_BattleRoyal = new string[]
		{
			"Lose",
			"Hardcore",
			"No"
		};

		private readonly string[] TagHelpTimerStrings = new string[]
		{
			"5 Seconds",
			"10 Seconds",
			"20 Seconds",
			"30 Seconds",
			"60 Seconds",
			"No Tag"
		};
		#endregion

		public Ruleset_NoMercy()
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
				cbRulesets.Items.Add(String.Format("0x{0:X2}", i));
			}
			cbRulesets.EndUpdate();
			cbRulesets.SelectedIndex = 0;
		}

		private void cbRulesets_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbRulesets.SelectedIndex < 0)
			{
				return;
			}

			MatchRuleset curRuleset = Rulesets[cbRulesets.SelectedIndex];
			tbMatchRuleset.Text = String.Format("0x{0:X2}", curRuleset.RulesetType);
			tbTimeLimit.Text = String.Format("0x{0:X2} ()", curRuleset.TimeLimit);
			tbCountOut.Text = String.Format("0x{0:X2} ()", curRuleset.CountOut);
			tbPin.Text = String.Format("0x{0:X2} ({1})", curRuleset.Pinfall, CommonYesNoStrings[curRuleset.Pinfall]);
			tbSubmission.Text = String.Format("0x{0:X2} ({1})", curRuleset.Submission, CommonYesNoStrings[curRuleset.Submission]);
			tbTKO.Text = String.Format("0x{0:X2} ({1})", curRuleset.TKO, CommonYesNoStrings[curRuleset.TKO]);
			tbRopeBreak.Text = String.Format("0x{0:X2} ({1})", curRuleset.RopeBreak, CommonYesNoStrings[curRuleset.RopeBreak]);
			tbDQ.Text = String.Format("0x{0:X2} ({1})", curRuleset.DQ, CommonYesNoStrings[curRuleset.DQ]);
			tbBlood.Text = String.Format("0x{0:X2} ()", curRuleset.Blood);
			tbInterference.Text = String.Format("0x{0:X2} ({1})", curRuleset.Interference, CommonYesNoStrings[curRuleset.Interference]);
			tbTagHelpTime.Text = String.Format("0x{0:X2} ()", curRuleset.TagHelpTime);
			tbRoyalRumbleTimer.Text = String.Format("0x{0:X2} ({1})", curRuleset.TimeCount, CommonYesNoStrings[curRuleset.TimeCount]);
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
	}
}
