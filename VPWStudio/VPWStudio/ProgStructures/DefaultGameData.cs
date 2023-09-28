using System;
using System.Collections.Generic;

namespace VPWStudio
{
	public class DefaultGameData
	{
		#region Default Locations
		/// <summary>
		/// An entry in DefaultLocationData.
		/// </summary>
		public class DefaultLocationDataEntry
		{
			public UInt32 Offset;
			public UInt32 Length;

			public DefaultLocationDataEntry()
			{
				Offset = 0;
				Length = 0;
			}

			public DefaultLocationDataEntry(UInt32 _off, UInt32 _len)
			{
				Offset = _off;
				Length = _len;
			}
		}

		#region Primary Offsets
		/// <summary>
		/// Default location data.
		/// </summary>
		public class DefaultLocationData
		{
			public Dictionary<string, DefaultLocationDataEntry> Locations;

			public DefaultLocationData()
			{
				Locations = new Dictionary<string, DefaultLocationDataEntry>();
			}

			public DefaultLocationData(Dictionary<string, DefaultLocationDataEntry> _entry)
			{
				Locations = _entry;
			}
		}

		/// <summary>
		/// Fallback LocationData for each SpecificGame.
		/// </summary>
		/// This primarily exists so the program can still be useful without the LocationFiles directory.
		public static Dictionary<SpecificGame, DefaultLocationData> DefaultLocations = new Dictionary<SpecificGame, DefaultLocationData>()
		{
			#region WCW vs. nWo - World Tour
			{
				SpecificGame.WorldTour_NTSC_U_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x5846, 8) },

					// data defs
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2F100, 176) },
					{ "HeadDefs", new DefaultLocationDataEntry(0x2FD50, 32) },
					{ "CostumeDefs", new DefaultLocationDataEntry(0x3368C, 180) },
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x37BF8, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x37EC8, 96) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x39490, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x7C1A78, 21996) },

					// relocatable code addresses
					{ "RelocatableCodeAddress1", new DefaultLocationDataEntry(0x337A0, 4) },
					{ "RelocatableCodeAddress2", new DefaultLocationDataEntry(0x337A4, 4) },
					{ "RelocatableCodeAddress3", new DefaultLocationDataEntry(0x337C4, 4) },
					{ "RelocatableCodeAddress4", new DefaultLocationDataEntry(0x337C8, 4) },
				})
			},
			{
				SpecificGame.WorldTour_NTSC_U_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x5846, 8) },

					// data defs
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2F170, 176) },
					{ "HeadDefs", new DefaultLocationDataEntry(0x2FDC0, 32) },
					{ "CostumeDefs", new DefaultLocationDataEntry(0x336FC, 180) },
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x37C68, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x37F38, 96) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x39500, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x7C1C70, 21996) },

					// relocatable code addresses
					{ "RelocatableCodeAddress1", new DefaultLocationDataEntry(0x33810, 4) },
					{ "RelocatableCodeAddress2", new DefaultLocationDataEntry(0x33814, 4) },
					{ "RelocatableCodeAddress3", new DefaultLocationDataEntry(0x33834, 4) },
					{ "RelocatableCodeAddress4", new DefaultLocationDataEntry(0x33838, 4) },
				})
			},
			{
				SpecificGame.WorldTour_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x5826, 8) },

					// data defs
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2F150, 176) },
					{ "HeadDefs", new DefaultLocationDataEntry(0x2FDA0, 32) },
					{ "CostumeDefs", new DefaultLocationDataEntry(0x336DC, 180) },
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x37BF8, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x37EC8, 96) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x39490, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x7C1C00, 21996) },

					// relocatable code addresses
					{ "RelocatableCodeAddress1", new DefaultLocationDataEntry(0x337F0, 4) },
					{ "RelocatableCodeAddress2", new DefaultLocationDataEntry(0x337F4, 4) },
					{ "RelocatableCodeAddress3", new DefaultLocationDataEntry(0x33814, 4) },
					{ "RelocatableCodeAddress4", new DefaultLocationDataEntry(0x33818, 4) },
				})
			},
			#endregion

			{
				SpecificGame.VPW64_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x5966, 8) },

					// data defs
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2FCE4, 176) },
					{ "WrestlerBodyDefs", new DefaultLocationDataEntry(0x2FF74, 212) },
					// no "CostumeDefs" entry here; see below
					{ "HeadDefs", new DefaultLocationDataEntry(0x31A44, 36) },
					{ "WrestlerDefaultCostumeDefs", new DefaultLocationDataEntry(0x3F038,0) }, // xxx: set length!!
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x49438, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x4989C, 176) },

					// costume definitions (yes, VPW64 does it differently from World Tour)
					{ "VPW64Costumes_Small", new DefaultLocationDataEntry(0x3EE40, 504) },
					{ "VPW64Costumes_Medium", new DefaultLocationDataEntry(0x36EC0, 384) },
					{ "VPW64Costumes_Large", new DefaultLocationDataEntry(0x32CF0, 84) },
					{ "VPW64Costumes_Saladin", new DefaultLocationDataEntry(0x31B58, 12) },
					{ "VPW64Costumes_Baba", new DefaultLocationDataEntry(0x31C08, 8) },
					{ "VPW64Costumes_Judoka", new DefaultLocationDataEntry(0x31CB4, 8) },
					{ "VPW64Costumes_Female", new DefaultLocationDataEntry(0x31D60, 8) },
					{ "VPW64Costumes_Unused", new DefaultLocationDataEntry(0x31EAC, 16) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x4AD00, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0xC7B578, 37432) },

					// relocatable code addresses
					{ "RelocatableCodeAddress1", new DefaultLocationDataEntry(0x3FAC0, 4) },
					{ "RelocatableCodeAddress2", new DefaultLocationDataEntry(0x3FAC4, 4) },
					{ "RelocatableCodeAddress3", new DefaultLocationDataEntry(0x3FAE4, 4) },
					{ "RelocatableCodeAddress4", new DefaultLocationDataEntry(0x3FAE8, 4) },
				})
			},

			#region WCW/nWo Revenge
			{
				SpecificGame.Revenge_NTSC_U,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x40CA, 4) },

					// data defs
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x323F0, 208) },
					{ "HeadDefs", new DefaultLocationDataEntry(0x33744, 40) },
					{ "CostumeDefs", new DefaultLocationDataEntry(0x36AA4, 592) },
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x3ADEC, 0) },
					{ "ChampionshipDefs", new DefaultLocationDataEntry(0x3B084, 100) },
					{ "StableDefs", new DefaultLocationDataEntry(0x3B0F8, 104) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0x80124, 3340) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0x80E30, 64) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0xDAC50, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0xCE2752, 30632) },
				})
			},
			{
				SpecificGame.Revenge_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x3FEA, 4) },

					// data defs
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2FB40, 208) },
					{ "HeadDefs", new DefaultLocationDataEntry(0x30E94, 40) },
					{ "CostumeDefs", new DefaultLocationDataEntry(0x341F4, 592) },
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x3823C, 0) },
					{ "ChampionshipDefs", new DefaultLocationDataEntry(0x384D4, 100) },
					{ "StableDefs", new DefaultLocationDataEntry(0x38548, 104) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0x7D6B4, 3340) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0x7E3C0, 64) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0xD81E0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0xCDFCE2, 30632) },
				})
			},
			#endregion

			#region WWF WrestleMania 2000
			{
				SpecificGame.WM2K_NTSC_U,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x48EA, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x41DB0, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x41EE0, 132) },

					// bit packing related
					{ "BitPacking_MainTable", new DefaultLocationDataEntry(0x3D7A0, 258) },
					{ "BitPacking_MoveGroup_Wrestling", new DefaultLocationDataEntry(0x3C700, 1590) },
					{ "BitPacking_MoveGroup_Combo", new DefaultLocationDataEntry(0x3CD38, 1600) },
					{ "BitPacking_MoveGroup_Shoot", new DefaultLocationDataEntry(0x3D378, 1050) },

					{ "DefaultFace_FacialHair_VertDisplacement", new DefaultLocationDataEntry(0x47168, 52) },
					{ "DefaultFace_PaintAccessories_VertDisplacement", new DefaultLocationDataEntry(0x4719C, 52) },
					{ "FacialHair_VertDisplacement", new DefaultLocationDataEntry(0x473A0, 32) },
					{ "FacePaint_VertDisplacement", new DefaultLocationDataEntry(0x473E8, 32) },
					{ "FacePaint_Type", new DefaultLocationDataEntry(0x47408, 32) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0x7927C, 7920) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0x7B16C, 96) },

					{ "TagTeamDefs", new DefaultLocationDataEntry(0x6CA04, 396) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x144AA0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x11778BE, 41248) },
				})
			},
			{
				SpecificGame.WM2K_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x478A, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x3F850, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x3F980, 132) },

					// bit packing related
					{ "BitPacking_MainTable", new DefaultLocationDataEntry(0x3B160, 258) },
					{ "BitPacking_MoveGroup_Wrestling", new DefaultLocationDataEntry(0x3A0C0, 1590) },
					{ "BitPacking_MoveGroup_Combo", new DefaultLocationDataEntry(0x3A6F8, 1600) },
					{ "BitPacking_MoveGroup_Shoot", new DefaultLocationDataEntry(0x3AD38, 1050) },

					{ "DefaultFace_FacialHair_VertDisplacement", new DefaultLocationDataEntry(0x44C08, 52) },
					{ "DefaultFace_PaintAccessories_VertDisplacement", new DefaultLocationDataEntry(0x44C3C, 52) },
					{ "FacialHair_VertDisplacement", new DefaultLocationDataEntry(0x44E40, 32) },
					{ "FacePaint_VertDisplacement", new DefaultLocationDataEntry(0x44E88, 32) },
					{ "FacePaint_Type", new DefaultLocationDataEntry(0x44EA8, 32) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0x73FDC, 7920) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0x75ECC, 96) },

					{ "TagTeamDefs", new DefaultLocationDataEntry(0x67794, 396) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x12C070, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x116F3C2, 41480) },
				})
			},
			{
				SpecificGame.WM2K_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x48EA, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x41DB0, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x41EE0, 132) },

					// bit packing related
					{ "BitPacking_MainTable", new DefaultLocationDataEntry(0x3D7A0, 258) },
					{ "BitPacking_MoveGroup_Wrestling", new DefaultLocationDataEntry(0x3C700, 1590) },
					{ "BitPacking_MoveGroup_Combo", new DefaultLocationDataEntry(0x3CD38, 1600) },
					{ "BitPacking_MoveGroup_Shoot", new DefaultLocationDataEntry(0x3D378, 1050) },

					{ "DefaultFace_FacialHair_VertDisplacement", new DefaultLocationDataEntry(0x47168, 52) },
					{ "DefaultFace_PaintAccessories_VertDisplacement", new DefaultLocationDataEntry(0x4719C, 52) },
					{ "FacialHair_VertDisplacement", new DefaultLocationDataEntry(0x473A0, 32) },
					{ "FacePaint_VertDisplacement", new DefaultLocationDataEntry(0x473E8, 32) },
					{ "FacePaint_Type", new DefaultLocationDataEntry(0x47408, 32) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0x7929C, 7920) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0x7B18C, 96) },

					{ "TagTeamDefs", new DefaultLocationDataEntry(0x6CA24, 396) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x144AC0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x11778DE, 41248) },
				})
			},
			#endregion

			{
				SpecificGame.VPW2_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x48DA, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x3FBE4, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x408BC, 136) },

					// bit packing related
					{ "BitPacking_MainTable", new DefaultLocationDataEntry(0x3E530, 268) },
					{ "BitPacking_MoveGroup_Wrestling", new DefaultLocationDataEntry(0x3D4E0, 1530) },
					{ "BitPacking_MoveGroup_Combo", new DefaultLocationDataEntry(0x3DADC, 1550) },
					{ "BitPacking_MoveGroup_Shoot", new DefaultLocationDataEntry(0x3E0EC, 1080) },

					{ "DefaultFace_FacialHair_VertDisplacement", new DefaultLocationDataEntry(0x469B8, 110) },
					{ "DefaultFace_PaintAccessories_VertDisplacement", new DefaultLocationDataEntry(0x46A28, 110) },
					{ "FacialHair_VertDisplacement", new DefaultLocationDataEntry(0x46C58, 32) },
					{ "FacePaint_VertDisplacement", new DefaultLocationDataEntry(0x46CD8, 32) },
					{ "FacePaint_Type", new DefaultLocationDataEntry(0x46D18, 32) },
					{ "FaceAccessories_VertDisplacement", new DefaultLocationDataEntry(0x46CF8, 32) },
					{ "FaceAccessories_Type", new DefaultLocationDataEntry(0x46D38, 32) },

					{ "DefaultRulesets", new DefaultLocationDataEntry(0x6DEAC, 460) },

					{ "StoryModeSinglesParticipants", new DefaultLocationDataEntry(0xDB43C, 160) },
					{ "StoryModeSingleGroups", new DefaultLocationDataEntry(0xDB4DC, 8) },
					{ "StoryModeTeams", new DefaultLocationDataEntry(0xDB4F0, 74) },
					{ "StoryModeTeamGroups", new DefaultLocationDataEntry(0xDB538, 6) },
					{ "DefaultChampions", new DefaultLocationDataEntry(0xDB544, 5) },
					{ "StoryModeSchedule", new DefaultLocationDataEntry(0x6AED0, 180) },
					{ "StoryModeBookingInstructions", new DefaultLocationDataEntry(0xDB5A0, 480) },

					{ "AttractModeDemoMatches", new DefaultLocationDataEntry(0xDC280, 190) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0x7C710, 4360) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0x7DEA8, 192) },
					{ "IntroDefs_Later_Sequence", new DefaultLocationDataEntry(0x7E098, 2292) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x152DF0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x1310F40, 52364) },
				})
			},

			#region WWF No Mercy
			{
				SpecificGame.NoMercy_NTSC_U_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x46DE, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x46658, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x48424, 192) },

					// bit packing related
					{ "BitPacking_MainTable", new DefaultLocationDataEntry(0x44F84, 278) },
					{ "BitPacking_MoveGroup_Wrestling", new DefaultLocationDataEntry(0x44310, 1580) },
					{ "BitPacking_MoveGroup_Combo", new DefaultLocationDataEntry(0x4493C, 1600) },

					{ "DefaultRulesets", new DefaultLocationDataEntry(0x73898, 696) },

					{ "AttractModeDemoMatches", new DefaultLocationDataEntry(0x803B8, 330) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0xA9890, 3220) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0xAA524, 96) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x1BD1B0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C3238, 77848) },
				})
			},
			{
				SpecificGame.NoMercy_NTSC_U_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x46DE, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x465B8, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x48384, 192) },

					// bit packing related
					{ "BitPacking_MainTable", new DefaultLocationDataEntry(0x44EE4, 278) },
					{ "BitPacking_MoveGroup_Wrestling", new DefaultLocationDataEntry(0x44270, 1580) },
					{ "BitPacking_MoveGroup_Combo", new DefaultLocationDataEntry(0x4489C, 1600) },

					{ "DefaultRulesets", new DefaultLocationDataEntry(0x73828, 696) },

					{ "AttractModeDemoMatches", new DefaultLocationDataEntry(0x80348, 330) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0xA9820, 3220) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0xAA4B4, 96) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x1BD150, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C31D8, 77848) },
				})
			},
			{
				SpecificGame.NoMercy_PAL_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x46DE, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x46658, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x48424, 192) },

					// bit packing related
					{ "BitPacking_MainTable", new DefaultLocationDataEntry(0x44F84, 278) },
					{ "BitPacking_MoveGroup_Wrestling", new DefaultLocationDataEntry(0x44310, 1580) },
					{ "BitPacking_MoveGroup_Combo", new DefaultLocationDataEntry(0x4493C, 1600) },

					{ "DefaultRulesets", new DefaultLocationDataEntry(0x73898, 696) },

					{ "AttractModeDemoMatches", new DefaultLocationDataEntry(0x803B8, 330) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0xA9900, 3220) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0xAA594, 96) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x1BD220, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C32A8, 77848) },
				})
			},
			{
				SpecificGame.NoMercy_PAL_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x46DE, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x464B8, 0) },
					{ "StableDefs", new DefaultLocationDataEntry(0x48284, 192) },

					// bit packing related
					{ "BitPacking_MainTable", new DefaultLocationDataEntry(0x44DE4, 278) },
					{ "BitPacking_MoveGroup_Wrestling", new DefaultLocationDataEntry(0x44170, 1580) },
					{ "BitPacking_MoveGroup_Combo", new DefaultLocationDataEntry(0x4479C, 1600) },

					{ "DefaultRulesets", new DefaultLocationDataEntry(0x73728, 696) },

					{ "AttractModeDemoMatches", new DefaultLocationDataEntry(0x80248, 330) },

					{ "IntroDefs_Later_Anims", new DefaultLocationDataEntry(0xA9790, 3220) },
					{ "IntroDefs_Later_Images", new DefaultLocationDataEntry(0xAA424, 96) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x1BD0C0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C3148, 77848) },
				})
			},
			{
				SpecificGame.NoMercy_Proto_NTSC_September2000,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>()
				{
					// code changes
					{ "SetupFT_FTLocation", new DefaultLocationDataEntry(0x46CE, 4) },

					// data defs
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x46698, 0) },

					// filetable-related
					{ "FirstFile", new DefaultLocationDataEntry(0x1BB930, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C0DB2, 77774) },
				})
			}
			#endregion
		};

		/// <summary>
		/// Get an entry from the DefaultLocations dictionary.
		/// </summary>
		/// <param name="game">SpecificGame type.</param>
		/// <param name="name">Location name to look up.</param>
		/// <returns>DefaultLocationDataEntry if found, or null if not found.</returns>
		public static DefaultLocationDataEntry GetEntry(SpecificGame game, string name)
		{
			if (DefaultLocations[game].Locations.ContainsKey(name))
			{
				return DefaultLocations[game].Locations[name];
			}
			else{
				return null;
			}
		}

		/// <summary>
		/// Return a list of entries starting with the specified string.
		/// </summary>
		/// <param name="game"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static List<DefaultLocationDataEntry> GetEntriesStartingWith(SpecificGame game, string b)
		{
			List<DefaultLocationDataEntry> entries = new List<DefaultLocationDataEntry>();
			foreach (KeyValuePair<string, DefaultLocationDataEntry> entry in DefaultLocations[game].Locations)
			{
				if (entry.Key.StartsWith(b))
				{
					entries.Add(entry.Value);
				}
			}
			return entries;
		}
		#endregion

		#region Sound Offsets
		// I'm honestly not sure why this is in a separate dictionary from the default data above.
		public static Dictionary<SpecificGame, DefaultLocationData> SoundOffsets = new Dictionary<SpecificGame, DefaultLocationData>()
		{
			{
				SpecificGame.WorldTour_NTSC_U_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x450A,8) },
					{ "Sound02", new DefaultLocationDataEntry(0x450E,8) },
					{ "Sound03", new DefaultLocationDataEntry(0x4556,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x4576,8) },
					{ "Sound05", new DefaultLocationDataEntry(0x457A,8) },
					{ "Sound06", new DefaultLocationDataEntry(0x45BE,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x485A,8) },
					{ "Sound08", new DefaultLocationDataEntry(0x48A2,8) },
					{ "Sound09", new DefaultLocationDataEntry(0x48BA,4) }
				})
			},
			{
				SpecificGame.WorldTour_NTSC_U_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x450A,8) },
					{ "Sound02", new DefaultLocationDataEntry(0x450E,8) },
					{ "Sound03", new DefaultLocationDataEntry(0x4556,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x4576,8) },
					{ "Sound05", new DefaultLocationDataEntry(0x457A,8) },
					{ "Sound06", new DefaultLocationDataEntry(0x45BE,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x485A,8) },
					{ "Sound08", new DefaultLocationDataEntry(0x48A2,8) },
					{ "Sound09", new DefaultLocationDataEntry(0x48BA,4) }
				})
			},
			{
				SpecificGame.WorldTour_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x44EA,8) },
					{ "Sound02", new DefaultLocationDataEntry(0x44EE,8) },
					{ "Sound03", new DefaultLocationDataEntry(0x4536,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x4556,8) },
					{ "Sound05", new DefaultLocationDataEntry(0x455A,8) },
					{ "Sound06", new DefaultLocationDataEntry(0x459E,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x483A,8) },
					{ "Sound08", new DefaultLocationDataEntry(0x4882,8) },
					{ "Sound09", new DefaultLocationDataEntry(0x489A,4) }
				})
			},
			{
				SpecificGame.VPW64_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x460E,8) },
					{ "Sound02", new DefaultLocationDataEntry(0x4612,8) },
					{ "Sound03", new DefaultLocationDataEntry(0x465A,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x467A,8) },
					{ "Sound05", new DefaultLocationDataEntry(0x467E,8) },
					{ "Sound06", new DefaultLocationDataEntry(0x46C2,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x495E,8) },
					{ "Sound08", new DefaultLocationDataEntry(0x49A6,8) },
					{ "Sound09", new DefaultLocationDataEntry(0x49BE,4) }
				})
			},
			{
				SpecificGame.Revenge_NTSC_U,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x3D2A,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x3D36,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x3D66,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x3D6E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x3DD6,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x3E5E,8) }
				})
			},
			{
				SpecificGame.Revenge_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x3C4A,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x3C56,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x3C86,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x3C8E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x3CF6,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x3D7E,8) }
				})
			},
			{
				SpecificGame.WM2K_NTSC_U,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x432A,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x4336,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x4366,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x436E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x439A,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x43A2,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x43CE,4) },
					{ "Sound08", new DefaultLocationDataEntry(0x43D6,4) },
					{ "Sound09", new DefaultLocationDataEntry(0x4402,4) },
					{ "Sound10", new DefaultLocationDataEntry(0x440A,4) },
					{ "Sound11", new DefaultLocationDataEntry(0x447A,4) },
					{ "Sound12", new DefaultLocationDataEntry(0x44DE,8) },
					{ "Sound13", new DefaultLocationDataEntry(0x4512,8) },
				})
			},
			{
				SpecificGame.WM2K_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x41DA,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x41E6,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x4216,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x421E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x424A,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x4252,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x427E,4) },
					{ "Sound08", new DefaultLocationDataEntry(0x4286,4) },
					{ "Sound09", new DefaultLocationDataEntry(0x42B2,4) },
					{ "Sound10", new DefaultLocationDataEntry(0x42BA,4) },
					{ "Sound11", new DefaultLocationDataEntry(0x432A,4) },
					{ "Sound12", new DefaultLocationDataEntry(0x438E,8) },
					{ "Sound13", new DefaultLocationDataEntry(0x43C2,8) },
				})
			},
			{
				SpecificGame.WM2K_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x432A,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x4336,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x4366,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x436E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x439A,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x43A2,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x43CE,4) },
					{ "Sound08", new DefaultLocationDataEntry(0x43D6,4) },
					{ "Sound09", new DefaultLocationDataEntry(0x4402,4) },
					{ "Sound10", new DefaultLocationDataEntry(0x440A,4) },
					{ "Sound11", new DefaultLocationDataEntry(0x447A,4) },
					{ "Sound12", new DefaultLocationDataEntry(0x44DE,8) },
					{ "Sound13", new DefaultLocationDataEntry(0x4512,8) },
				})
			},
			{
				SpecificGame.VPW2_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x432A, 4) },  // (0x432A,  0x432E); sndtbl-1.wbk
					{ "Sound02", new DefaultLocationDataEntry(0x4336, 4) },  // (0x4336,  0x433A); sndtbl-1.ptr
					{ "Sound03", new DefaultLocationDataEntry(0x4366, 4) },  // (0x4366,  0x436A); sndtbl-2.wbk
					{ "Sound04", new DefaultLocationDataEntry(0x436E, 4) },  // (0x436E,  0x4372); sndtbl-2.ptr
					{ "Sound05", new DefaultLocationDataEntry(0x439A, 4) },  // (0x439A,  0x439E); sndtbl-2.ptr
					{ "Sound06", new DefaultLocationDataEntry(0x43A2, 4) },  // (0x43A2,  0x43A6); sndtbl-1.tbl
					{ "Sound07", new DefaultLocationDataEntry(0x43CE, 4) },  // (0x43CE,  0x43D2); sndtbl-3.wbk
					{ "Sound08", new DefaultLocationDataEntry(0x43D6, 4) },  // (0x43D6,  0x43DA); sndtbl-3.ptr
					{ "Sound09", new DefaultLocationDataEntry(0x4402, 4) },  // (0x4402,  0x4406); sndtbl-3.ptr
					{ "Sound10", new DefaultLocationDataEntry(0x440A, 4) },  // (0x440A,  0x440E); sndtbl-2.tbl
					{ "Sound11", new DefaultLocationDataEntry(0x447A, 4) },  // (0x447A,  0x447E); load sndtbl-1.wbk
					{ "Sound12", new DefaultLocationDataEntry(0x44DE, 8) },  // (0x44DE,  0x44E6); load sndtbl-2.wbk
					{ "Sound13", new DefaultLocationDataEntry(0x4512, 8) },  // (0x4512,  0x451A); load sndtbl-3.wbk
					{ "Sound14", new DefaultLocationDataEntry(0x17312, 4) }, // (0x17312, 0x17316); sndtbl-4.wbk
					{ "Sound15", new DefaultLocationDataEntry(0x1731A, 4) }, // (0x1731A, 0x1731E); sndtbl-4.ptr
					{ "Sound16", new DefaultLocationDataEntry(0x1732E, 4) }, // (0x1732E, 0x17332); sndtbl-4.ptr
					{ "Sound17", new DefaultLocationDataEntry(0x17336, 4) }, // (0x17336, 0x1733A); sndtbl-3.tbl
					{ "Sound18", new DefaultLocationDataEntry(0x173AE, 4) }, // (0x173AE, 0x173B2); sndtbl-5.wbk
					{ "Sound19", new DefaultLocationDataEntry(0x173B6, 4) }, // (0x173B6, 0x173BA); sndtbl-5.ptr
					{ "Sound20", new DefaultLocationDataEntry(0x173CA, 4) }, // (0x173CA, 0x173CE); sndtbl-5.ptr
					{ "Sound21", new DefaultLocationDataEntry(0x173D2, 4) }, // (0x173D2, 0x173D6); sndtbl-4.tbl
					{ "Sound22", new DefaultLocationDataEntry(0x17466, 8) }, // (0x17466, 0x1746E); load sndtbl-4.wbk
					{ "Sound23", new DefaultLocationDataEntry(0x174AE, 8) }, // (0x174AE, 0x174B6); load sndtbl-5.wbk
					{ "Sound24", new DefaultLocationDataEntry(0x17772, 4) }, // (0x17772, 0x17776); sndtbl-6.wbk
					{ "Sound25", new DefaultLocationDataEntry(0x1777A, 4) }, // (0x1777A, 0x1777E); sndtbl-6.ptr
					{ "Sound26", new DefaultLocationDataEntry(0x177A6, 4) }, // (0x177A6, 0x177AA); sndtbl-6.ptr
					{ "Sound27", new DefaultLocationDataEntry(0x177AE, 4) }, // (0x177AE, 0x177B2); sndtbl-5.tbl
					{ "Sound28", new DefaultLocationDataEntry(0x177EE, 8) }, // (0x177EE, 0x177F6); load sndtbl-6.wbk
					{ "Sound29", new DefaultLocationDataEntry(0x179FA, 4) }, // (0x179FA, 0x179FE); sndtbl-7.wbk
					{ "Sound30", new DefaultLocationDataEntry(0x17A02, 4) }, // (0x17A02, 0x17A06); sndtbl-7.ptr
					{ "Sound31", new DefaultLocationDataEntry(0x17A22, 4) }, // (0x17A22, 0x17A26); sndtbl-7.ptr
					{ "Sound32", new DefaultLocationDataEntry(0x17A2A, 4) }, // (0x17A2A, 0x17A2E); sndtbl-6.tbl
					{ "Sound33", new DefaultLocationDataEntry(0x17A46, 4) }, // (0x17A46, 0x17A4A); sndtbl-8.wbk
					{ "Sound34", new DefaultLocationDataEntry(0x17A4E, 4) }, // (0x17A4E, 0x17A52); sndtbl-8.ptr
					{ "Sound35", new DefaultLocationDataEntry(0x17A6A, 4) }, // (0x17A6A, 0x17A6E); sndtbl-8.ptr
					{ "Sound36", new DefaultLocationDataEntry(0x17A72, 4) }, // (0x17A72, 0x17A76); sndtbl-7.tbl
					{ "Sound37", new DefaultLocationDataEntry(0x17B7A, 8) }, // (0x17B7A, 0x17B82); load sndtbl-8.wbk
					{ "Sound38", new DefaultLocationDataEntry(0x17B46, 8) }, // (0x17B46, 0x17B4E); load sndtbl-7.wbk
				})
			},
			{
				SpecificGame.NoMercy_NTSC_U_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x402A,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x4036,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x4066,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x406E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x409A,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x40A2,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x40CE,4) },
					{ "Sound08", new DefaultLocationDataEntry(0x40D6,4) },
					{ "Sound09", new DefaultLocationDataEntry(0x4102,4) },
					{ "Sound10", new DefaultLocationDataEntry(0x410A,4) },
					{ "Sound11", new DefaultLocationDataEntry(0x417A,4) },
					{ "Sound12", new DefaultLocationDataEntry(0x41DE,8) },
					{ "Sound13", new DefaultLocationDataEntry(0x4212,8) },
				})
			},
			{
				SpecificGame.NoMercy_NTSC_U_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x402A,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x4036,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x4066,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x406E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x409A,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x40A2,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x40CE,4) },
					{ "Sound08", new DefaultLocationDataEntry(0x40D6,4) },
					{ "Sound09", new DefaultLocationDataEntry(0x4102,4) },
					{ "Sound10", new DefaultLocationDataEntry(0x410A,4) },
					{ "Sound11", new DefaultLocationDataEntry(0x417A,4) },
					{ "Sound12", new DefaultLocationDataEntry(0x41DE,8) },
					{ "Sound13", new DefaultLocationDataEntry(0x4212,8) },
				})
			},
			{
				SpecificGame.NoMercy_PAL_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x402A,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x4036,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x4066,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x406E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x409A,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x40A2,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x40CE,4) },
					{ "Sound08", new DefaultLocationDataEntry(0x40D6,4) },
					{ "Sound09", new DefaultLocationDataEntry(0x4102,4) },
					{ "Sound10", new DefaultLocationDataEntry(0x410A,4) },
					{ "Sound11", new DefaultLocationDataEntry(0x417A,4) },
					{ "Sound12", new DefaultLocationDataEntry(0x41DE,8) },
					{ "Sound13", new DefaultLocationDataEntry(0x4212,8) },
				})
			},
			{
				SpecificGame.NoMercy_PAL_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "Sound01", new DefaultLocationDataEntry(0x402A,4) },
					{ "Sound02", new DefaultLocationDataEntry(0x4036,4) },
					{ "Sound03", new DefaultLocationDataEntry(0x4066,4) },
					{ "Sound04", new DefaultLocationDataEntry(0x406E,4) },
					{ "Sound05", new DefaultLocationDataEntry(0x409A,4) },
					{ "Sound06", new DefaultLocationDataEntry(0x40A2,4) },
					{ "Sound07", new DefaultLocationDataEntry(0x40CE,4) },
					{ "Sound08", new DefaultLocationDataEntry(0x40D6,4) },
					{ "Sound09", new DefaultLocationDataEntry(0x4102,4) },
					{ "Sound10", new DefaultLocationDataEntry(0x410A,4) },
					{ "Sound11", new DefaultLocationDataEntry(0x417A,4) },
					{ "Sound12", new DefaultLocationDataEntry(0x41DE,8) },
					{ "Sound13", new DefaultLocationDataEntry(0x4212,8) },
				})
			}
		};
		#endregion

		// rethink how you want to handle the rest of this.
		#endregion

		#region Default File Table Entries
		/// <summary>
		/// Dictionary of specific game types to default relevant File Table IDs.
		/// </summary>
		/// This has to be SpecificGame because WrestleMania 2000 NTSC-J has different IDs from WM2K NTSC-U/PAL.
		public static Dictionary<string, Dictionary<SpecificGame, int>> DefaultFileTableIDs = new Dictionary<string, Dictionary<SpecificGame, int>>()
		{
			{
				"CostumeColorPalette",
				new Dictionary<SpecificGame, int>()
				{
					// World Tour: no Costume Edit mode, so no file.

					{ SpecificGame.VPW64_NTSC_J, 0x0BCC },

					#region WCW/nWo Revenge
					{SpecificGame.Revenge_NTSC_U, 0x0A51 },
					{SpecificGame.Revenge_PAL, 0x0A51 },
					#endregion

					#region WWF WrestleMania 2000
					{ SpecificGame.WM2K_NTSC_U, 0x0A63 },
					{ SpecificGame.WM2K_PAL, 0x0A63 },
					{ SpecificGame.WM2K_NTSC_J, 0x0A9D },
					#endregion

					{ SpecificGame.VPW2_NTSC_J, 0x0E50 },

					#region WWF No Mercy
					{ SpecificGame.NoMercy_NTSC_U_10, 0x10F5 },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x10F5 },
					{ SpecificGame.NoMercy_PAL_10, 0x10F5 },
					{ SpecificGame.NoMercy_PAL_11, 0x10F5 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x10E2 }
					#endregion
				}
			},

			#region Animations
			{
				"FirstAnimationFileID",
				new Dictionary<SpecificGame, int>()
				{
					#region WCW/nWo World Tour
					{ SpecificGame.WorldTour_NTSC_U_10, 0x0B55 },
					{ SpecificGame.WorldTour_NTSC_U_11, 0x0B55 },
					{ SpecificGame.WorldTour_PAL, 0x0B55 },
					#endregion

					{ SpecificGame.VPW64_NTSC_J, 0x1347 },

					#region WCW/nWo Revenge
					{ SpecificGame.Revenge_NTSC_U, 0x0E39 },
					{ SpecificGame.Revenge_PAL, 0x0E39 },
					#endregion

					#region WWF WrestleMania 2000
					{ SpecificGame.WM2K_NTSC_U, 0x1609 },
					{ SpecificGame.WM2K_PAL, 0x1609 },
					{ SpecificGame.WM2K_NTSC_J, 0x1643 },
					#endregion

					{ SpecificGame.VPW2_NTSC_J, 0x1A90 },

					#region WWF No Mercy
					{ SpecificGame.NoMercy_NTSC_U_10, 0x2DD9 },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x2DD9 },
					{ SpecificGame.NoMercy_PAL_10, 0x2DD9 },
					{ SpecificGame.NoMercy_PAL_11, 0x2DD9 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x2DC6 }
					#endregion
				}
			},

			// "LastAnimationFileID"

			{
				"FirstMoveAnimationID",
				new Dictionary<SpecificGame, int>()
				{
					// Unsure if World Tour and VPW64 has and/or uses this value.
					// It could be something that was introduced in Revenge.

					#region WCW/nWo Revenge
					{ SpecificGame.Revenge_NTSC_U, 0x110B },
					{ SpecificGame.Revenge_PAL, 0x110B },
					#endregion

					#region WWF WrestleMania 2000
					{ SpecificGame.WM2K_NTSC_U, 0x19DB },
					{ SpecificGame.WM2K_PAL, 0x19DB },
					{ SpecificGame.WM2K_NTSC_J, 0x1A15 },
					#endregion

					{ SpecificGame.VPW2_NTSC_J, 0x2056 },

					#region WWF No Mercy
					{ SpecificGame.NoMercy_NTSC_U_10, 0x3322 },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x3322 },
					{ SpecificGame.NoMercy_PAL_10, 0x3322 },
					{ SpecificGame.NoMercy_PAL_11, 0x3322 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x330F },
					#endregion
				}
			},
			#endregion

			{
				"Toki1FileID",
				new Dictionary<SpecificGame, int>()
				{
					#region WCW/nWo World Tour
					{ SpecificGame.WorldTour_NTSC_U_10, 0x026A },
					{ SpecificGame.WorldTour_NTSC_U_11, 0x026A },
					{ SpecificGame.WorldTour_PAL, 0x026A },
					#endregion

					{ SpecificGame.VPW64_NTSC_J, 0x0211 },

					#region WCW/nWo Revenge
					{ SpecificGame.Revenge_NTSC_U, 0x020F },
					{ SpecificGame.Revenge_PAL, 0x020F },
					#endregion

					#region WWF WrestleMania 2000
					{ SpecificGame.WM2K_NTSC_U, 0x0435 },
					{ SpecificGame.WM2K_PAL, 0x0435 },
					{ SpecificGame.WM2K_NTSC_J, 0x046F },
					#endregion

					{ SpecificGame.VPW2_NTSC_J, 0x034B },

					#region WWF No Mercy
					{ SpecificGame.NoMercy_NTSC_U_10, 0x02BF },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x02BF },
					{ SpecificGame.NoMercy_PAL_10, 0x02BF },
					{ SpecificGame.NoMercy_PAL_11, 0x02BF },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x02BF },
					#endregion
				}
			},

			{
				"MoveDamageFileID",
				new Dictionary<SpecificGame, int>()
				{
					#region WWF WrestleMania 2000
					{ SpecificGame.WM2K_NTSC_U, 0x03AD },
					{ SpecificGame.WM2K_PAL, 0x03AD },
					{ SpecificGame.WM2K_NTSC_J, 0x03E7 },
					#endregion

					{ SpecificGame.VPW2_NTSC_J, 0x0277 },

					#region WWF No Mercy
					{ SpecificGame.NoMercy_NTSC_U_10, 0x01EF },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x01EF },
					{ SpecificGame.NoMercy_PAL_10, 0x01EF },
					{ SpecificGame.NoMercy_PAL_11, 0x01EF },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x01EF },
					#endregion
				}
			},

			{
				"WrestlerDefaultCostumeData",
				new Dictionary<SpecificGame, int>()
				{
					// pre-VPW2 games store default costume data in ROM

					{ SpecificGame.VPW2_NTSC_J, 0x006B },
					{ SpecificGame.NoMercy_NTSC_U_10, 1 },
					{ SpecificGame.NoMercy_NTSC_U_11, 1 },
					{ SpecificGame.NoMercy_PAL_10, 1 },
					{ SpecificGame.NoMercy_PAL_11, 1 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 1 },
				}
			},

			{
				"DefaultNameData",
				new Dictionary<SpecificGame, int>()
				{
					// pre-VPW2 games store wrestler names in ROM

					{ SpecificGame.VPW2_NTSC_J, 0x006C },
					{ SpecificGame.NoMercy_NTSC_U_10, 2 },
					{ SpecificGame.NoMercy_NTSC_U_11, 2 },
					{ SpecificGame.NoMercy_PAL_10, 2 },
					{ SpecificGame.NoMercy_PAL_11, 2 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 2 },
				}
			},

			#region Fonts
			{
				"DefaultLargeFont",
				new Dictionary<SpecificGame, int>()
				{
					#region WCW vs. nWo World Tour
					{ SpecificGame.WorldTour_NTSC_U_10, 0x0002 },
					{ SpecificGame.WorldTour_NTSC_U_11, 0x0002 },
					{ SpecificGame.WorldTour_PAL, 0x0002 },
					#endregion

					{ SpecificGame.VPW64_NTSC_J, 0x0002 },

					#region WCW/nWo Revenge
					{ SpecificGame.Revenge_NTSC_U, 0x0002 },
					{ SpecificGame.Revenge_PAL, 0x0002 },
					#endregion

					#region WWF WrestleMania 2000
					{ SpecificGame.WM2K_NTSC_U, 0x0001 },
					{ SpecificGame.WM2K_PAL, 0x0001 },
					{ SpecificGame.WM2K_NTSC_J, 0x0001 },
					#endregion

					{ SpecificGame.VPW2_NTSC_J, 0x0001 },

					#region WWF No Mercy
					{ SpecificGame.NoMercy_NTSC_U_10, 0x4477 },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x4477 },
					{ SpecificGame.NoMercy_PAL_10, 0x4477 },
					{ SpecificGame.NoMercy_PAL_11, 0x4477 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x4464 },
					#endregion
				}
			},

			{
				"DefaultSmallFont",
				new Dictionary<SpecificGame, int>()
				{
					#region WCW vs. nWo World Tour
					{ SpecificGame.WorldTour_NTSC_U_10, 0x0001 },
					{ SpecificGame.WorldTour_NTSC_U_11, 0x0001 },
					{ SpecificGame.WorldTour_PAL, 0x0001 },
					#endregion

					{ SpecificGame.VPW64_NTSC_J, 0x0001 },

					#region WCW/nWo Revenge
					{ SpecificGame.Revenge_NTSC_U, 0x0001 },
					{ SpecificGame.Revenge_PAL, 0x0001 },
					#endregion

					#region WWF WrestleMania 2000
					{ SpecificGame.WM2K_NTSC_U, 0x0002 },
					{ SpecificGame.WM2K_PAL, 0x0002 },
					{ SpecificGame.WM2K_NTSC_J, 0x0002 },
					#endregion

					{ SpecificGame.VPW2_NTSC_J, 0x0002 },

					#region WWF No Mercy
					{ SpecificGame.NoMercy_NTSC_U_10, 0x4478 },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x4478 },
					{ SpecificGame.NoMercy_PAL_10, 0x4478 },
					{ SpecificGame.NoMercy_PAL_11, 0x4478 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x4465 },
					#endregion
				}
			},
			#endregion

			#region Edit Mode-related
			// These entries don't exist for Revenge and earlier games.
			{
				"FirstSkinColorPalette",
				new Dictionary<SpecificGame, int>()
				{
					{ SpecificGame.WM2K_NTSC_U, 0x10DE },
					{ SpecificGame.WM2K_PAL, 0x10DE },
					{ SpecificGame.WM2K_NTSC_J, 0x1118 },

					{ SpecificGame.VPW2_NTSC_J, 0x173D },
				}
			},

			{
				"FirstFaceColorPalette",
				new Dictionary<SpecificGame, int>()
				{
					{ SpecificGame.WM2K_NTSC_U, 0x1112 },
					{ SpecificGame.WM2K_PAL, 0x1112 },
					{ SpecificGame.WM2K_NTSC_J, 0x114C },

					{ SpecificGame.VPW2_NTSC_J, 0x1745 },

					// No Mercy uses a per-face palette, unlike the other games.
					{ SpecificGame.NoMercy_NTSC_U_10, 0x1D72 },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x1D72 },
					{ SpecificGame.NoMercy_PAL_10, 0x1D72 },
					{ SpecificGame.NoMercy_PAL_11, 0x1D72 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x1D5F },
				}
			},

			{
				"FirstFaceTexture",
				new Dictionary<SpecificGame, int>()
				{
					// linear with shared palettes
					{ SpecificGame.WM2K_NTSC_U, 0x114F },
					{ SpecificGame.WM2K_PAL, 0x114F },
					{ SpecificGame.WM2K_NTSC_J, 0x1189 },

					// linear with shared palettes
					{ SpecificGame.VPW2_NTSC_J, 0x17F0 },

					// mixed with per-face palettes
					{ SpecificGame.NoMercy_NTSC_U_10, 0x1D73 },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x1D73 },
					{ SpecificGame.NoMercy_PAL_10, 0x1D73 },
					{ SpecificGame.NoMercy_PAL_11, 0x1D73 },
					{ SpecificGame.NoMercy_Proto_NTSC_September2000, 0x1D60 },
				}
			},

			{
				"FirstFrontHairPalette",
				new Dictionary<SpecificGame, int>()
				{
					{ SpecificGame.WM2K_NTSC_U, 0x1125 },
					{ SpecificGame.WM2K_PAL, 0x1125 },
					{ SpecificGame.WM2K_NTSC_J, 0x115F },

					{ SpecificGame.VPW2_NTSC_J, 0x17E5 },
				}
			},

			{
				"FirstFrontHairTexture",
				new Dictionary<SpecificGame, int>()
				{
					{ SpecificGame.WM2K_NTSC_U, 0x1182 },
					{ SpecificGame.WM2K_PAL, 0x1182 },
					{ SpecificGame.WM2K_NTSC_J, 0x11BC },

					{ SpecificGame.VPW2_NTSC_J, 0x185E },

					{ SpecificGame.NoMercy_NTSC_U_10, 0x1F09 },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x1F09 },
					{ SpecificGame.NoMercy_PAL_10, 0x1F09 },
					{ SpecificGame.NoMercy_PAL_11, 0x1F09 },
					// todo: SpecificGame.NoMercy_Proto_NTSC_September2000
				}
			},

			{
				"FirstFacialHairTexture",
				new Dictionary<SpecificGame, int>()
				{
					{ SpecificGame.WM2K_NTSC_U, 0x11B5 },
					{ SpecificGame.WM2K_PAL, 0x11B5 },
					{ SpecificGame.WM2K_NTSC_J, 0x11EF },

					{ SpecificGame.VPW2_NTSC_J, 0x18CC },

					// Note: No Mercy uses (texture, palette, palette)
					{ SpecificGame.NoMercy_NTSC_U_10, 0x1F6F },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x1F6F },
					{ SpecificGame.NoMercy_PAL_10, 0x1F6F },
					{ SpecificGame.NoMercy_PAL_11, 0x1F6F },
					// todo: SpecificGame.NoMercy_Proto_NTSC_September2000
				}
			},

			{
				"FirstFacePaintTexture",
				new Dictionary<SpecificGame, int>()
				{
					// WM2000 and No Mercy combine facepaint and face accessories into
					// one selection, which is why there's no entries for them here.

					{ SpecificGame.VPW2_NTSC_J, 0x18E8 },
				}
			},

			{
				"FirstFaceAccessoryTexture",
				new Dictionary<SpecificGame, int>()
				{
					{ SpecificGame.WM2K_NTSC_U, 0x11D4 },
					{ SpecificGame.WM2K_PAL, 0x11D4 },
					{ SpecificGame.WM2K_NTSC_J, 0x120E },

					{ SpecificGame.VPW2_NTSC_J, 0x190A },

					{ SpecificGame.NoMercy_NTSC_U_10, 0x264F },
					{ SpecificGame.NoMercy_NTSC_U_11, 0x264F },
					{ SpecificGame.NoMercy_PAL_10, 0x264F },
					{ SpecificGame.NoMercy_PAL_11, 0x264F },
					// todo: SpecificGame.NoMercy_Proto_NTSC_September2000
				}
			},

			{
				"FaceAccessoryPalette",
				new Dictionary<SpecificGame, int>()
				{
					{ SpecificGame.WM2K_NTSC_U, 0x112E },
					{ SpecificGame.WM2K_PAL, 0x112E },
					{ SpecificGame.WM2K_NTSC_J, 0x1168 },

					{ SpecificGame.VPW2_NTSC_J, 0x17EF },
				}
			},
			#endregion
		};
		#endregion

		#region Default Data Sizes
		// This section covers a number of hardcoded assumptions previously found elsewhere in the tool.

		/*
		 * todo: the endless shrimp buffet list at Red Corner Lobster
		 * - move damage data length (per-move)
		 * - number of entries for various tables
		 *   also other assumptions that I can't think of right now
		 */

		/// <summary>
		/// Number of Stables defined in each game.
		/// </summary>
		public static Dictionary<VPWGames, int> StableCount = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 6 },  // 4 main + 1 hidden + 1 for cruiserweight-only roster
			{ VPWGames.VPW64,    11 },  // 7 main + 1 hidden + 1 separate group (for holding Z on certain characters) + 2 for cruiserweight-only roster
			{ VPWGames.Revenge,  13 },  // 9 main + 2 manager-only (normally unselectable) + 2 for cruiserweight-only roster
			{ VPWGames.WM2K,     11 },  // 8 main + 1 hidden + 2 edit
			{ VPWGames.VPW2,     17 },  // 12 main + 3 hidden + 2 edit
			{ VPWGames.NoMercy,  12 }   // 6 main + 2 hidden + 2 empty (Superstars 6,7) + 2 edit
		};

		/// <summary>
		/// Number of Wrestlers defined in each game.
		/// </summary>
		/// This is not as consistent as I'd like, since some games have a cruiserweight-only roster.
		public static Dictionary<VPWGames, int> WrestlerCount = new Dictionary<VPWGames, int>()
		{
			// Notice! These two skip the duplicate cruiserweight-only definitions:
			{ VPWGames.WorldTour, 43 },
			{ VPWGames.VPW64,     99 },

			{ VPWGames.Revenge,   90 }, // 63 default + 14 cruiserweight-only + 13 managers
			{ VPWGames.WM2K,      76 },
			{ VPWGames.VPW2,     130 }, // 98 default + 16 edit + 16 controller pak

			// Note: there are another 37 slots unaccounted for in this value
			// (18x edit mode characters, 18x controller pak characters, 1x GBC Story Mode slot)
			{ VPWGames.NoMercy,   64 }, // Main wrestler count only; multiply by 4 to account for per-costume slot differences
		};
		#endregion
	}
}
