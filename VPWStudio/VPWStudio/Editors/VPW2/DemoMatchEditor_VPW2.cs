using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Editors.VPW2
{
	public partial class DemoMatchEditor_VPW2 : Form
	{
		private int NUM_MATCHES = 38;
		private int BYTES_PER_MATCH = 5;

		public byte[] DemoMatchData;

		public DemoMatchEditor_VPW2()
		{
			InitializeComponent();

			DemoMatchData = new byte[NUM_MATCHES* BYTES_PER_MATCH];

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry sdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["AttractModeDemoMatches"]);
				if (sdEntry != null)
				{
					romReader.BaseStream.Seek(sdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Attract Mode Demo Match location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["AttractModeDemoMatches"].Offset, SeekOrigin.Begin);
			}

			DemoMatchData = romReader.ReadBytes(NUM_MATCHES * BYTES_PER_MATCH);

			romReader.Close();
			PopulateMatchList();
			cbDemoMatches.SelectedIndex = 0;
		}

		private void PopulateMatchList()
		{
			cbDemoMatches.BeginUpdate();
			for (int i = 0; i < NUM_MATCHES; i++)
			{
				cbDemoMatches.Items.Add(String.Format("Match {0}",i+1));
			}
			cbDemoMatches.EndUpdate();
		}

		private void cbDemoMatches_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbDemoMatches.SelectedIndex < 0)
			{
				return;
			}

			tbWrestler1.Text = String.Format("0x{0:X2}", DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH)]);
			tbWrestler2.Text = String.Format("0x{0:X2}", DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH)+1]);
			tbWrestler3.Text = String.Format("0x{0:X2}", DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH)+2]);
			tbWrestler4.Text = String.Format("0x{0:X2}", DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH)+3]);
			byte arenaRules = DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 4];
			tbRuleset.Text = String.Format("0x{0:X2} (arena {1}, ruleset {2})", arenaRules, (arenaRules&0xF0)>>4, arenaRules&0x0F);
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
