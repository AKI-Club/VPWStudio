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
				cbRulesets.Items.Add(String.Format("Ruleset 0x{0:X2}",i));
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
