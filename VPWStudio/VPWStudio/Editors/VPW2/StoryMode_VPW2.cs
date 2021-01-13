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

		private AkiText DefaultNames;

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

			romReader.Close(); // we're done with this

			tbTripleCrown.Text = String.Format("0x{0:X2} {1}", DefaultChampions[0], DefaultNames.Entries[DefaultChampions[0]*2].Text);
			tbWorldTag1.Text = String.Format("0x{0:X2} {1}", DefaultChampions[1], DefaultNames.Entries[DefaultChampions[1]*2].Text);
			tbAsiaTag1.Text = String.Format("0x{0:X2} {1}", DefaultChampions[2], DefaultNames.Entries[DefaultChampions[2]*2].Text);
			tbWorldTag2.Text = String.Format("0x{0:X2} {1}", DefaultChampions[3], DefaultNames.Entries[DefaultChampions[3]*2].Text);
			tbAsiaTag2.Text = String.Format("0x{0:X2} {1}", DefaultChampions[4], DefaultNames.Entries[DefaultChampions[4]*2].Text);
		}

		private void UpdateTeamValues()
		{
			StoryModeTeam_Modern curTeam = StoryTeams[lbTeams.SelectedIndex];
			tbWrestler1.Text = String.Format("0x{0:X2} {1}", curTeam.WrestlerID2_1, DefaultNames.Entries[curTeam.WrestlerID2_1 * 2].Text);
			tbWrestler2.Text = String.Format("0x{0:X2} {1}", curTeam.WrestlerID2_2, DefaultNames.Entries[curTeam.WrestlerID2_2 * 2].Text);
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
