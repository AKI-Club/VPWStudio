using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors.VPW2
{
	public partial class StoryMode_VPW2 : Form
	{
		/// <summary>
		/// Story Mode teams
		/// </summary>
		public List<StoryModeTeam_Modern> StoryTeams = new List<StoryModeTeam_Modern>();

		/// <summary>
		/// Default Champions
		/// </summary>
		public byte[] DefaultChampions = new byte[5];

		public StoryMode_VPW2()
		{
			InitializeComponent();

			// 18x teams (Z64 0xDB4F0)
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			bool hasTeamLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry smtEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StoryModeTeams"]);
				if (smtEntry != null)
				{
					romReader.BaseStream.Seek(smtEntry.Address, SeekOrigin.Begin);
					hasTeamLocation = true;
				}
			}
			if (!hasTeamLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Story Mode Teams location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StoryModeTeams"].Offset, SeekOrigin.Begin);
			}

			lbTeams.BeginUpdate();
			// xxx: hardcoded amount of teams
			for (int i = 0; i < 18; i++)
			{
				StoryTeams.Add(new StoryModeTeam_Modern(romReader));
				lbTeams.Items.Add(String.Format("Team {0}", i));
			}
			lbTeams.EndUpdate();

			bool hasChampionLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry dcEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["DefaultChampions"]);
				if (dcEntry != null)
				{
					romReader.BaseStream.Seek(dcEntry.Address, SeekOrigin.Begin);
					hasChampionLocation = true;
				}
			}
			if (!hasChampionLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Story Mode Default Champions location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["DefaultChampions"].Offset, SeekOrigin.Begin);
			}

			// 5x champions (Z64 0xDB544)
			// xxx: hardcoded length
			DefaultChampions = romReader.ReadBytes(5);
			romReader.Close(); // we're done with this

			tbTripleCrown.Text = String.Format("0x{0:X2}", DefaultChampions[0]);
			tbWorldTag1.Text = String.Format("0x{0:X2}", DefaultChampions[1]);
			tbAsiaTag1.Text = String.Format("0x{0:X2}", DefaultChampions[2]);
			tbWorldTag2.Text = String.Format("0x{0:X2}", DefaultChampions[3]);
			tbAsiaTag2.Text = String.Format("0x{0:X2}", DefaultChampions[4]);
		}

		private void UpdateTeamValues()
		{
			StoryModeTeam_Modern curTeam = StoryTeams[lbTeams.SelectedIndex];
			tbWrestler1.Text = String.Format("0x{0:X2}", curTeam.WrestlerID2_1);
			tbWrestler2.Text = String.Format("0x{0:X2}", curTeam.WrestlerID2_2);
			tbUnknown.Text = String.Format("0x{0:X4}", curTeam.Unknown);
		}

		private void lbTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}
			UpdateTeamValues();
		}
	}
}
