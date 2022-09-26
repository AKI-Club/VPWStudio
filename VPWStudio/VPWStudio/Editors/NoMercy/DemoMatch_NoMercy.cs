using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Editors.NoMercy
{
	public partial class DemoMatch_NoMercy : Form
	{
		private int NUM_MATCHES = 33;
		private int BYTES_PER_MATCH = 10;

		public byte[] DemoMatchData;

		public DemoMatch_NoMercy()
		{
			InitializeComponent();

			DemoMatchData = new byte[NUM_MATCHES * BYTES_PER_MATCH];

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
				cbDemoMatches.Items.Add(String.Format("Match {0}", i + 1));
			}
			cbDemoMatches.EndUpdate();
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

		private void cbDemoMatches_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbDemoMatches.SelectedIndex < 0)
			{
				return;
			}

			short wrestler1 = (short)((DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH)])<<8 | DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 1]);
			short wrestler2 = (short)((DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 2])<<8 | DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 3]);
			short wrestler3 = (short)((DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 4])<<8 | DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 5]);
			short wrestler4 = (short)((DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 6])<<8 | DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 7]);
			short arena = (short)((DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 8])<<8 | DemoMatchData[(cbDemoMatches.SelectedIndex * BYTES_PER_MATCH) + 9]);

			tbWrestler1.Text = String.Format("0x{0:X4} (ID4 {1:X4}, costume {2})", wrestler1, (wrestler1&0xFFF), (wrestler1&0xF000)>>12);
			tbWrestler2.Text = String.Format("0x{0:X4} (ID4 {1:X4}, costume {2})", wrestler2, (wrestler2 & 0xFFF), (wrestler2 & 0xF000) >> 12);
			tbWrestler3.Text = String.Format("0x{0:X4} (ID4 {1:X4}, costume {2})", wrestler3, (wrestler3 & 0xFFF), (wrestler3 & 0xF000) >> 12);
			tbWrestler4.Text = String.Format("0x{0:X4} (ID4 {1:X4}, costume {2})", wrestler4, (wrestler4 & 0xFFF), (wrestler4 & 0xF000) >> 12);
			tbArena.Text = String.Format("0x{0:X4}", arena);
		}
	}
}
