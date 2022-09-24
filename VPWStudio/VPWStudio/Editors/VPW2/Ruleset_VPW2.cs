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

		private string[] DefaultRulesetExplanations = new string[]
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
			tbMatchRuleset.Text = String.Format("0x{0:X2}", curRuleset.RulesetType);
			tbTimeLimit.Text = String.Format("0x{0:X2}", curRuleset.TimeLimit);
			tbRoundLength.Text = String.Format("0x{0:X2}", curRuleset.RoundLength);
			tbOutsideCount.Text = String.Format("0x{0:X2}", curRuleset.OutsideCount);
			tbPinfall.Text = String.Format("0x{0:X2}", curRuleset.Pinfall);
			tbSubmission.Text = String.Format("0x{0:X2}", curRuleset.Submission);
			tbTKO.Text = String.Format("0x{0:X2}", curRuleset.TKO);
			tbRopeBreak.Text = String.Format("0x{0:X2}", curRuleset.RopeBreak);
			tbQuickMatch.Text = String.Format("0x{0:X2}", curRuleset.QuickMatch);
			tbBlood.Text = String.Format("0x{0:X2}", curRuleset.Blood);
			tbChangeTitleRingOut.Text = String.Format("0x{0:X2}", curRuleset.ChangeTitleOnRingOut);
			tbTimeLimitDecision.Text = String.Format("0x{0:X2}", curRuleset.TimeLimitDecision);
			tbInterference.Text = String.Format("0x{0:X2}", curRuleset.Interference);
			tbTagHelpTimer.Text = String.Format("0x{0:X2}", curRuleset.TagHelpTimer);
			tbStartPoints.Text = String.Format("0x{0:X2}", curRuleset.StartPoints);
			tbRopeEscape.Text = String.Format("0x{0:X2}", curRuleset.RopeEscape);
			tbDown.Text = String.Format("0x{0:X2}", curRuleset.Down);
			tbSuplex.Text = String.Format("0x{0:X2}", curRuleset.Suplex);
			tbNumRounds.Text = String.Format("0x{0:X2}", curRuleset.NumRounds);
			tbGongSave.Text = String.Format("0x{0:X2}", curRuleset.GongSave);
		}
	}
}
