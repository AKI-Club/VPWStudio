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
		/// Story Mode singles participants
		/// </summary>
		public List<StoryModeSingle_Modern> StorySinglesParticipants = new List<StoryModeSingle_Modern>();

		// todo: story mode singles tier groupings (two bytes per entry; 4 entries)
		public byte[] StorySingleTierGroupings = new byte[8];

		// todo: story mode singles promotion/relegation values (two bytes per entry; terminated by 0xFF, 0xFF)

		/// <summary>
		/// Story Mode teams
		/// </summary>
		public List<StoryModeTeam_Modern> StoryTeams = new List<StoryModeTeam_Modern>();

		// todo: story mode tag tier groupings (two bytes per entry; 3 entries)
		public byte[] StoryTagTierGroupings = new byte[6];

		// todo: story mode tag promotion/relegation values (two bytes per entry; terminated by 0xFF, 0xFF)

		/// <summary>
		/// Default Champions
		/// </summary>
		public byte[] DefaultChampions = new byte[5];

		private AkiText DefaultNames;

		public StoryMode_VPW2()
		{
			InitializeComponent();

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			// load wrestler names, so we're not just blindly messing with IDs
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

			LoadSingles(romReader);
			LoadTeams(romReader);
			LoadChampions(romReader);

			romReader.Close();
		}

		private void LoadSingles(BinaryReader romReader)
		{
			// 40 participants (Z64 0xDB43C)
			bool hasSinglesParticipantLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry smspEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StoryModeSinglesParticipants"]);
				if (smspEntry != null)
				{
					romReader.BaseStream.Seek(smspEntry.Address, SeekOrigin.Begin);
					hasSinglesParticipantLocation = true;
				}
			}
			if (!hasSinglesParticipantLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Story Mode Single Participants location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StoryModeSinglesParticipants"].Offset, SeekOrigin.Begin);
			}

			lbSinglesParticipants.BeginUpdate();
			// xxx: hardcoded amount of participants
			for (int i = 0; i < 40; i++)
			{
				StorySinglesParticipants.Add(new StoryModeSingle_Modern(romReader));
				lbSinglesParticipants.Items.Add(String.Format("Wrestler {0}", i));
			}
			lbSinglesParticipants.EndUpdate();

			// groupings
			bool hasSingleGroupingLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry sgEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StoryModeSingleGroups"]);
				if (sgEntry != null)
				{
					romReader.BaseStream.Seek(sgEntry.Address, SeekOrigin.Begin);
					hasSingleGroupingLocation = true;
				}
			}
			if (!hasSingleGroupingLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Story Mode Single Grouping location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StoryModeSingleGroups"].Offset, SeekOrigin.Begin);
			}

			// xxx: hardcoded amount
			StorySingleTierGroupings = romReader.ReadBytes(8);

			tbSingleTier1NumWrestlers.Text = string.Format("{0}", StorySingleTierGroupings[0]);
			tbSingleTier1InitialRank.Text = string.Format("{0}", StorySingleTierGroupings[1]);
			tbSingleTier2NumWrestlers.Text = string.Format("{0}", StorySingleTierGroupings[2]);
			tbSingleTier2InitialRank.Text = string.Format("{0}", StorySingleTierGroupings[3]);
			tbSingleTier3NumWrestlers.Text = string.Format("{0}", StorySingleTierGroupings[4]);
			tbSingleTier3InitialRank.Text = string.Format("{0}", StorySingleTierGroupings[5]);
			tbSingleGuestNumWrestlers.Text = string.Format("{0}", StorySingleTierGroupings[6]);
			tbSingleGuestInitialRank.Text = string.Format("{0}", StorySingleTierGroupings[7]);

			// promotion/relegation values
		}

		private void LoadTeams(BinaryReader romReader)
		{
			// 18x teams (Z64 0xDB4F0)
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

			// groupings
			bool hasTagGroupingLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry tgEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StoryModeTeamGroups"]);
				if (tgEntry != null)
				{
					romReader.BaseStream.Seek(tgEntry.Address, SeekOrigin.Begin);
					hasTagGroupingLocation = true;
				}
			}
			if (!hasTagGroupingLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Story Mode Tag Grouping location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StoryModeTeamGroups"].Offset, SeekOrigin.Begin);
			}

			// xxx: hardcoded amount
			StoryTagTierGroupings = romReader.ReadBytes(6);

			tbTagTier1NumTeams.Text = string.Format("{0}", StoryTagTierGroupings[0]);
			tbTagTier1InitialRank.Text = string.Format("{0}", StoryTagTierGroupings[1]);
			tbTagTier2NumTeams.Text = string.Format("{0}", StoryTagTierGroupings[2]);
			tbTagTier2InitialRank.Text = string.Format("{0}", StoryTagTierGroupings[3]);
			tbTagGuestNumTeams.Text = string.Format("{0}", StoryTagTierGroupings[4]);
			tbTagGuestInitialRank.Text = string.Format("{0}", StoryTagTierGroupings[5]);

			// promotion/relegation values
		}

		private void LoadChampions(BinaryReader romReader)
		{
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

			tbTripleCrown.Text = String.Format("0x{0:X2} {1}", DefaultChampions[0], DefaultNames.Entries[DefaultChampions[0] * 2].Text);
			tbWorldTag1.Text = String.Format("0x{0:X2} {1}", DefaultChampions[1], DefaultNames.Entries[DefaultChampions[1] * 2].Text);
			tbAsiaTag1.Text = String.Format("0x{0:X2} {1}", DefaultChampions[2], DefaultNames.Entries[DefaultChampions[2] * 2].Text);
			tbWorldTag2.Text = String.Format("0x{0:X2} {1}", DefaultChampions[3], DefaultNames.Entries[DefaultChampions[3] * 2].Text);
			tbAsiaTag2.Text = String.Format("0x{0:X2} {1}", DefaultChampions[4], DefaultNames.Entries[DefaultChampions[4] * 2].Text);
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

		#region Singles Participants
		private void UpdateSinglesValues()
		{
			StoryModeSingle_Modern curWrestler = StorySinglesParticipants[lbSinglesParticipants.SelectedIndex];
			tbSingleWrestler.Text = String.Format("0x{0:X2} {1}", curWrestler.WrestlerID2, DefaultNames.Entries[curWrestler.WrestlerID2 * 2].Text);
			tbSingleSkillLevel.Text = String.Format("0x{0:X2}", curWrestler.SkillLevel);
			tbSingleTitleShotPercent.Text = String.Format("{0}", curWrestler.TitleShotPercent);
		}

		private void lbSinglesParticipants_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbSinglesParticipants.SelectedIndex < 0)
			{
				return;
			}
			UpdateSinglesValues();
		}
		#endregion

		#region Teams
		private void UpdateTeamValues()
		{
			StoryModeTeam_Modern curTeam = StoryTeams[lbTeams.SelectedIndex];
			tbTeamWrestler1.Text = String.Format("0x{0:X2} {1}", curTeam.WrestlerID2_1, DefaultNames.Entries[curTeam.WrestlerID2_1 * 2].Text);
			tbTeamWrestler2.Text = String.Format("0x{0:X2} {1}", curTeam.WrestlerID2_2, DefaultNames.Entries[curTeam.WrestlerID2_2 * 2].Text);
			tbTeamTitleShotPercent.Text = String.Format("{0}", curTeam.TitleShotPercent);
		}

		private void lbTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}
			UpdateTeamValues();
		}
		#endregion

		#region Default Champions
		#endregion



	

		
	}
}
