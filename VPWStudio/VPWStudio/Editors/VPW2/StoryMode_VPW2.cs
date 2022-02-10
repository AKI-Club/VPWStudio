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
	public partial class StoryMode_VPW2 : Form
	{
		#region Participant Members
		/// <summary>
		/// Story Mode singles participants
		/// </summary>
		public List<StoryModeSingleEntry> StorySinglesParticipants = new List<StoryModeSingleEntry>();

		// story mode singles tier groupings (two bytes per entry; 4 entries)
		public byte[] StorySingleTierGroupings = new byte[8];

		// story mode singles promotion/relegation values (two bytes per entry; terminated by 0xFF, 0xFF)
		public byte[] StorySinglePromoRelegate = new byte[8];

		/// <summary>
		/// Story Mode teams
		/// </summary>
		public List<StoryModeTeamEntry> StoryTeams = new List<StoryModeTeamEntry>();

		// story mode tag tier groupings (two bytes per entry; 3 entries)
		public byte[] StoryTagTierGroupings = new byte[6];

		// story mode tag promotion/relegation values (two bytes per entry; terminated by 0xFF, 0xFF)
		public byte[] StoryTagPromoRelegate = new byte[2];

		/// <summary>
		/// Default Champions
		/// </summary>
		public byte[] DefaultChampions = new byte[5];
		#endregion

		#region Event Schedule
		public List<StoryModeEvent> EventSchedule = new List<StoryModeEvent>();
		#endregion

		#region Booking Instructions
		public List<StoryModeBookingInstruction> BookingInstructions = new List<StoryModeBookingInstruction>();
		#endregion

		/// <summary>
		/// Default wrestler names.
		/// </summary>
		private AkiText DefaultNames;

		// file ID 0x000C
		private AkiText EventText;

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

			// load event text
			FileTableEntry eventTextEntry = Program.CurrentProject.ProjectFileTable.Entries[0x000C];
			if (!String.IsNullOrEmpty(eventTextEntry.ReplaceFilePath))
			{
				FileStream fs = new FileStream(Program.ConvertRelativePath(eventTextEntry.ReplaceFilePath), FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				EventText = new AkiText(br);
				br.Close();
			}
			else
			{
				MemoryStream outStream = new MemoryStream();
				BinaryWriter outWriter = new BinaryWriter(outStream);

				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, 0x000C);

				outStream.Seek(0, SeekOrigin.Begin);
				BinaryReader outReader = new BinaryReader(outStream);
				EventText = new AkiText(outReader);
				outReader.Close();
				outWriter.Close();
			}

			LoadSingles(romReader);
			LoadTeams(romReader);
			LoadChampions(romReader);
			LoadEvents(romReader);
			LoadBookingInstructions(romReader);

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
				StoryModeSingleEntry entrant = new StoryModeSingleEntry(romReader);
				StorySinglesParticipants.Add(entrant);
				lbSinglesParticipants.Items.Add(String.Format("{0:D2} {1}", i, DefaultNames.Entries[entrant.WrestlerID2 * 2 + 1].Text));
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
			// xxx: also hardcoded amount
			StorySinglePromoRelegate = romReader.ReadBytes(8);

			tbSingleRelegate1.Text = string.Format("{0}", StorySinglePromoRelegate[0]);
			tbSinglePromote1.Text = string.Format("{0}", StorySinglePromoRelegate[1]);
			tbSingleRelegate2.Text = string.Format("{0}", StorySinglePromoRelegate[2]);
			tbSinglePromote2.Text = string.Format("{0}", StorySinglePromoRelegate[3]);
			tbSingleRelegate3.Text = string.Format("{0}", StorySinglePromoRelegate[4]);
			tbSinglePromote3.Text = string.Format("{0}", StorySinglePromoRelegate[5]);
			tbSingleRelegate4.Text = string.Format("{0}", StorySinglePromoRelegate[6]);
			tbSinglePromote4.Text = string.Format("{0}", StorySinglePromoRelegate[7]);
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
				StoryModeTeamEntry teamEntry = new StoryModeTeamEntry(romReader);
				StoryTeams.Add(teamEntry);
				lbTeams.Items.Add(String.Format("{0:D2} {1}/{2}", i,
					DefaultNames.Entries[teamEntry.WrestlerID2_1 * 2 + 1].Text,
					DefaultNames.Entries[teamEntry.WrestlerID2_2 * 2 + 1].Text
				));
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

			romReader.ReadBytes(2);

			// promotion/relegation values
			// xxx: also hardcoded amount
			StoryTagPromoRelegate = romReader.ReadBytes(2);
			tbTagRelegate.Text = string.Format("{0}", StoryTagPromoRelegate[0]);
			tbTagPromote.Text = string.Format("{0}", StoryTagPromoRelegate[1]);
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

		private void LoadEvents(BinaryReader romReader)
		{
			bool hasEventLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry eventEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StoryModeSchedule"]);
				if (eventEntry != null)
				{
					romReader.BaseStream.Seek(eventEntry.Address, SeekOrigin.Begin);
					hasEventLocation = true;
				}
			}
			if (!hasEventLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Story Mode Event Schedule location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StoryModeSchedule"].Offset, SeekOrigin.Begin);
			}

			// 45 entries (Z64 0x6AED0)
			// xxx: hardcoded length
			cbEvents.BeginUpdate();
			for (int i = 0; i < 45; i++)
			{
				EventSchedule.Add(new StoryModeEvent(romReader));
				cbEvents.Items.Add(string.Format("Event {0}{1}", i, i==0 ? " do not edit":string.Empty));
			}
			cbEvents.EndUpdate();
			cbEvents.SelectedIndex = 0;
		}

		private void LoadBookingInstructions(BinaryReader romReader)
		{
			bool hasBookingInstructionLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry biEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StoryModeBookingInstructions"]);
				if (biEntry != null)
				{
					romReader.BaseStream.Seek(biEntry.Address, SeekOrigin.Begin);
					hasBookingInstructionLocation = true;
				}
			}
			if (!hasBookingInstructionLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Story Mode Booking Instructions location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StoryModeBookingInstructions"].Offset, SeekOrigin.Begin);
			}

			// 24 sets of booking instructions, 20 bytes per set (Z64 0xDB5A0)
			cbBookingInstructions.BeginUpdate();
			for (int i = 0; i < 24; i++)
			{
				BookingInstructions.Add(new StoryModeBookingInstruction(romReader));
				cbBookingInstructions.Items.Add(string.Format("Set {0}", i));
			}
			cbBookingInstructions.EndUpdate();
			cbBookingInstructions.SelectedIndex = 0;
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
			StoryModeSingleEntry curWrestler = StorySinglesParticipants[lbSinglesParticipants.SelectedIndex];
			tbSingleWrestler.Text = String.Format("0x{0:X2} {1}", curWrestler.WrestlerID2, DefaultNames.Entries[curWrestler.WrestlerID2 * 2].Text);
			tbSingleSkillLevel.Text = String.Format("{0}", curWrestler.SkillLevel);
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

		private void btnChangeWrestlerSingle_Click(object sender, EventArgs e)
		{
			if (lbSinglesParticipants.SelectedIndex < 0)
			{
				return;
			}

			SelectWrestlerDialog swd = new SelectWrestlerDialog(SelectWrestlerDialog.WrestlerIDMode.ID2, StorySinglesParticipants[lbSinglesParticipants.SelectedIndex].WrestlerID2);
			if (swd.ShowDialog() == DialogResult.OK)
			{
				int selectedIndex = lbSinglesParticipants.SelectedIndex;
				StoryModeSingleEntry curWrestler = StorySinglesParticipants[selectedIndex];
				curWrestler.WrestlerID2 = (byte)swd.ReturnID;
				tbSingleWrestler.Text = String.Format("0x{0:X2} {1}", curWrestler.WrestlerID2, DefaultNames.Entries[curWrestler.WrestlerID2 * 2].Text);
				lbSinglesParticipants.Items[selectedIndex] = String.Format("{0:D2} {1}", selectedIndex, DefaultNames.Entries[curWrestler.WrestlerID2 * 2 + 1].Text);
			}
		}
		#endregion

		#region Teams
		private void UpdateTeamValues()
		{
			StoryModeTeamEntry curTeam = StoryTeams[lbTeams.SelectedIndex];
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

		private void UpdateTagTeamListEntry(int index)
		{
			lbTeams.Items[index] = String.Format("{0:D2} {1}/{2}", index,
				DefaultNames.Entries[StoryTeams[index].WrestlerID2_1 * 2 + 1].Text,
				DefaultNames.Entries[StoryTeams[index].WrestlerID2_2 * 2 + 1].Text
			);
		}

		private void btnChangeWrestlerTeam1_Click(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}

			SelectWrestlerDialog swd = new SelectWrestlerDialog(SelectWrestlerDialog.WrestlerIDMode.ID2, StoryTeams[lbTeams.SelectedIndex].WrestlerID2_1);
			if (swd.ShowDialog() == DialogResult.OK)
			{
				int selectedIndex = lbTeams.SelectedIndex;
				StoryModeTeamEntry curTeam = StoryTeams[selectedIndex];
				curTeam.WrestlerID2_1 = (byte)swd.ReturnID;
				tbTeamWrestler1.Text = String.Format("0x{0:X2} {1}", curTeam.WrestlerID2_1, DefaultNames.Entries[curTeam.WrestlerID2_1 * 2].Text);
				UpdateTagTeamListEntry(selectedIndex);
			}
		}

		private void btnChangeWrestlerTeam2_Click(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}

			SelectWrestlerDialog swd = new SelectWrestlerDialog(SelectWrestlerDialog.WrestlerIDMode.ID2, StoryTeams[lbTeams.SelectedIndex].WrestlerID2_2);
			if (swd.ShowDialog() == DialogResult.OK)
			{
				int selectedIndex = lbTeams.SelectedIndex;
				StoryModeTeamEntry curTeam = StoryTeams[selectedIndex];
				curTeam.WrestlerID2_2 = (byte)swd.ReturnID;
				tbTeamWrestler2.Text = String.Format("0x{0:X2} {1}", curTeam.WrestlerID2_2, DefaultNames.Entries[curTeam.WrestlerID2_2 * 2].Text);
				UpdateTagTeamListEntry(selectedIndex);
			}
		}
		#endregion

		#region Promotion/Relegation
		#endregion

		#region Default Champions
		private void btnChangeTripleCrown_Click(object sender, EventArgs e)
		{
			SelectWrestlerDialog swd = new SelectWrestlerDialog(SelectWrestlerDialog.WrestlerIDMode.ID2, DefaultChampions[0]);
			if (swd.ShowDialog() == DialogResult.OK)
			{
				DefaultChampions[0] = (byte)swd.ReturnID;
				tbTripleCrown.Text = String.Format("0x{0:X2} {1}", DefaultChampions[0], DefaultNames.Entries[DefaultChampions[0] * 2].Text);
			}
		}

		private void btnChangeWorldTag1_Click(object sender, EventArgs e)
		{
			SelectWrestlerDialog swd = new SelectWrestlerDialog(SelectWrestlerDialog.WrestlerIDMode.ID2, DefaultChampions[1]);
			if (swd.ShowDialog() == DialogResult.OK)
			{
				DefaultChampions[1] = (byte)swd.ReturnID;
				tbWorldTag1.Text = String.Format("0x{0:X2} {1}", DefaultChampions[1], DefaultNames.Entries[DefaultChampions[1] * 2].Text);
			}
		}

		private void btnChangeWorldTag2_Click(object sender, EventArgs e)
		{
			SelectWrestlerDialog swd = new SelectWrestlerDialog(SelectWrestlerDialog.WrestlerIDMode.ID2, DefaultChampions[2]);
			if (swd.ShowDialog() == DialogResult.OK)
			{
				DefaultChampions[3] = (byte)swd.ReturnID;
				tbWorldTag2.Text = String.Format("0x{0:X2} {1}", DefaultChampions[3], DefaultNames.Entries[DefaultChampions[3] * 2].Text);
			}
		}

		private void btnChangeAsiaTag1_Click(object sender, EventArgs e)
		{
			SelectWrestlerDialog swd = new SelectWrestlerDialog(SelectWrestlerDialog.WrestlerIDMode.ID2, DefaultChampions[2]);
			if (swd.ShowDialog() == DialogResult.OK)
			{
				DefaultChampions[2] = (byte)swd.ReturnID;
				tbAsiaTag1.Text = String.Format("0x{0:X2} {1}", DefaultChampions[2], DefaultNames.Entries[DefaultChampions[2] * 2].Text);
			}
		}

		private void btnChangeAsiaTag2_Click(object sender, EventArgs e)
		{
			SelectWrestlerDialog swd = new SelectWrestlerDialog(SelectWrestlerDialog.WrestlerIDMode.ID2, DefaultChampions[2]);
			if (swd.ShowDialog() == DialogResult.OK)
			{
				DefaultChampions[4] = (byte)swd.ReturnID;
				tbAsiaTag2.Text = String.Format("0x{0:X2} {1}", DefaultChampions[4], DefaultNames.Entries[DefaultChampions[4] * 2].Text);
			}
		}
		#endregion

		#region Event Schedule
		private void UpdateEventValues()
		{
			StoryModeEvent eventData = EventSchedule[cbEvents.SelectedIndex];
			tbBulletinBoardMessage.Text = string.Format("{0}", eventData.BulletinBoardMessage);
			cbPromotionRelegation.Checked = eventData.HandlePromotionRelegation;
			cbShowTourScene.Checked = eventData.ShowTourOpeningScene;
			cbQualifyingRequirement.Checked = eventData.HasQualifyingRequirement;

			if (eventData.EventLocation == 0)
			{
				tbEventLocation.Text = string.Format("{0} (arena)", eventData.EventLocation);
			}
			else if (eventData.EventLocation <= 0x15)
			{
				tbEventLocation.Text = string.Format("{0} - {1}", eventData.EventLocation, EventText.GetEntry(209 + eventData.EventLocation));
			}
			else
			{
				tbEventLocation.Text = string.Format("{0}", eventData.EventLocation);
			}

			tbArenaType.Text = string.Format("{0}", eventData.ArenaType);
			tbPlayerParticipation.Text = string.Format("{0}", eventData.PlayerParticipation);
			tbShowNumber.Text = string.Format("{0}", eventData.ShowNumber);
			tbBookingInstructions.Text = string.Format("{0}", eventData.BookingInstructions);
			tbEventName.Text = string.Format("{0}", eventData.EventName);
			tbMonthNumber.Text = string.Format("{0}", eventData.MonthNumber);
		}

		private void cbEvents_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbEvents.SelectedIndex < 0)
			{
				return;
			}
			UpdateEventValues();
		}

		private void btnViewBooking_Click(object sender, EventArgs e)
		{
			if (cbEvents.SelectedIndex < 0)
			{
				return;
			}

			cbBookingInstructions.SelectedIndex = EventSchedule[cbEvents.SelectedIndex].BookingInstructions;
			tabCtrlMain.SelectedTab = tabCtrlMain.TabPages["tpBookingInstructions"];
		}
		#endregion

		#region Booking Instructions
		private string GetMatchString(ushort values)
		{
			if (values == StoryModeBookingInstruction.NO_MATCH)
			{
				return string.Format("0x{0:X4} (no match)", values);
			}

			// handle special cases
			if (values == StoryModeBookingInstruction.CHAMPION_CARNIVAL_FINAL)
			{
				return string.Format("0x{0:X4} Champion Carnival Final", values);
			}
			else if (values == StoryModeBookingInstruction.TAG_LEAGUE_FINAL)
			{
				return string.Format("0x{0:X4} Tag League Final", values);
			}
			else if (values == StoryModeBookingInstruction.BATTLE_ROYAL)
			{
				return string.Format("0x{0:X4} Battle Royal", values);
			}
			else if (values == StoryModeBookingInstruction.SINGLES_TOURNAMENT)
			{
				return string.Format("0x{0:X4} Singles Tournament", values);
			}
			else if (values == StoryModeBookingInstruction.TAG_TOURNAMENT)
			{
				return string.Format("0x{0:X4} Tag Tournament", values);
			}
			else if (values == StoryModeBookingInstruction.CHAMPION_CARNIVAL_LEAGUE)
			{
				return string.Format("0x{0:X4} Champion Carnival League", values);
			}
			else if (values == StoryModeBookingInstruction.TAG_LEAGUE)
			{
				return string.Format("0x{0:X4} Tag League", values);
			}

			return string.Format("0x{0:X4}", values);
		}

		private void UpdateBookingValues()
		{
			StoryModeBookingInstruction set = BookingInstructions[cbBookingInstructions.SelectedIndex];
			tbMatch1.Text = GetMatchString(set.Values[0]);
			tbMatch2.Text = GetMatchString(set.Values[1]);
			tbMatch3.Text = GetMatchString(set.Values[2]);
			tbMatch4.Text = GetMatchString(set.Values[3]);
			tbMatch5.Text = GetMatchString(set.Values[4]);
			tbMatch6.Text = GetMatchString(set.Values[5]);
			tbMatch7.Text = GetMatchString(set.Values[6]);
			tbMatch8.Text = GetMatchString(set.Values[7]);
			tbMatch9.Text = GetMatchString(set.Values[8]);
			tbMatch10.Text = GetMatchString(set.Values[9]);
		}

		private void cbBookingInstructions_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbBookingInstructions.SelectedIndex < 0)
			{
				return;
			}
			UpdateBookingValues();
		}
		#endregion
	}
}
