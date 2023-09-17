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
	public partial class DemoMatch_VPW2 : Form
	{
		private readonly int NUM_MATCHES = 38;

		private readonly int BYTES_PER_MATCH = 5;

		/// <summary>
		/// Default wrestler names.
		/// </summary>
		private AkiText DefaultNames;

		public byte[] DemoMatchData;

		public DemoMatch_VPW2()
		{
			InitializeComponent();

			DemoMatchData = new byte[NUM_MATCHES* BYTES_PER_MATCH];

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			// load wrestler names
			FileTableEntry defWrestlerNames = Program.CurrentProject.ProjectFileTable.Entries[0x006C];
			if (!String.IsNullOrEmpty(defWrestlerNames.ReplaceFilePath))
			{
				FileStream fs = new FileStream(Program.ConvertRelativePath(defWrestlerNames.ReplaceFilePath), FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				DefaultNames = new AkiText(br);
				br.Close();
			}
			else
			{
				MemoryStream outStream = new MemoryStream();
				BinaryWriter outWriter = new BinaryWriter(outStream);

				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, 0x006C);

				outStream.Seek(0, SeekOrigin.Begin);
				BinaryReader outReader = new BinaryReader(outStream);
				DefaultNames = new AkiText(outReader);
				outReader.Close();
				outWriter.Close();
			}

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

			byte wres1 = DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH)];
			byte wres2 = DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 1];
			byte wres3 = DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 2];
			byte wres4 = DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 3];
			tbWrestler1.Text = String.Format("0x{0:X2} {1}", wres1, wres1 != 0 ? DefaultNames.Entries[wres1 * 2].Text : String.Empty);
			tbWrestler2.Text = String.Format("0x{0:X2} {1}", wres2, wres2 != 0 ? DefaultNames.Entries[wres2 * 2].Text : String.Empty);
			tbWrestler3.Text = String.Format("0x{0:X2} {1}", wres3, wres3 != 0 ? DefaultNames.Entries[wres3 * 2].Text : String.Empty);
			tbWrestler4.Text = String.Format("0x{0:X2} {1}", wres4, wres4 != 0 ? DefaultNames.Entries[wres4 * 2].Text : String.Empty);
			byte arenaRules = DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 4];
			tbRuleset.Text = String.Format("0x{0:X2} (arena {1}, ruleset {2})", arenaRules, (arenaRules&0xF0)>>4, (arenaRules&0x0F)|0x10);
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
