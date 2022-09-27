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
		public MatchRuleset[] Rulesets = new MatchRuleset[58];

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
			tbTimeLimit.Text = String.Format("0x{0:X2}", curRuleset.TimeLimit);
			tbCountOut.Text = String.Format("0x{0:X2}", curRuleset.CountOut);
			tbPin.Text = String.Format("0x{0:X2}", curRuleset.Pinfall);
			tbSubmission.Text = String.Format("0x{0:X2}", curRuleset.Submission);
			tbTKO.Text = String.Format("0x{0:X2}", curRuleset.TKO);
			tbRopeBreak.Text = String.Format("0x{0:X2}", curRuleset.RopeBreak);
			tbDQ.Text = String.Format("0x{0:X2}", curRuleset.DQ);
			tbBlood.Text = String.Format("0x{0:X2}", curRuleset.Blood);
			tbInterference.Text = String.Format("0x{0:X2}", curRuleset.Interference);
			tbTagHelpTime.Text = String.Format("0x{0:X2}", curRuleset.TagHelpTime);
			tbRoyalRumbleTimer.Text = String.Format("0x{0:X2}", curRuleset.TimeCount);
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
