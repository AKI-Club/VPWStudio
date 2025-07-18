﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	#region Location File Entry
	/// <summary>
	/// Location Type
	/// </summary>
	public enum LocationType
	{
		/// <summary>
		/// Invalid type.
		/// </summary>
		Invalid = -1,

		/// <summary>
		/// Found in ROM. (Z64 format assumed)
		/// </summary>
		ROM = 0,

		/// <summary>
		/// Found in RAM.
		/// </summary>
		RAM,

		/// <summary>
		/// File Table ID. A four digit hex value representing an index into the File Table.
		/// </summary>
		FTID,
	}

	/// <summary>
	/// Location Handler Type
	/// </summary>
	public enum LocationHandlerType
	{
		/// <summary>
		/// Default
		/// </summary>
		None,

		/// <summary>
		/// Changes to game data. "$name"
		/// </summary>
		DataLocation,

		/// <summary>
		/// Changes to game code. "%name"
		/// </summary>
		CodeChange,

		/// <summary>
		/// Locations of code segments (overlays). "@name"
		/// </summary>
		CodeSegment,
	}

	/// <summary>
	/// Location Entry
	/// </summary>
	public class LocationFileEntry
	{
		#region Class Members
		/// <summary>
		/// Location type
		/// </summary>
		public LocationType Type;

		/// <summary>
		/// Location address
		/// </summary>
		public UInt32 Address;

		/// <summary>
		/// Data length
		/// </summary>
		public int Length;

		/// <summary>
		/// Comment
		/// </summary>
		public string Comment;

		/// <summary>
		/// Location type handler
		/// </summary>
		public LocationHandlerType Handler;
		#endregion

		/// <summary>
		/// Default constructor
		/// </summary>
		public LocationFileEntry()
		{
			this.Type = LocationType.Invalid;
			this.Address = 0;
			this.Length = 1;
			this.Comment = String.Empty;
			this.Handler = LocationHandlerType.None;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_type">Location type</param>
		/// <param name="_addr">Address</param>
		/// <param name="_length">Data length</param>
		/// <param name="_comment">Comment about location</param>
		public LocationFileEntry(LocationType _type, UInt32 _addr, int _length, string _comment)
		{
			this.Type = _type;
			this.Address = _addr;
			this.Length = _length;
			this.Comment = _comment;
			// handler gets set separately.
			this.Handler = LocationHandlerType.None;
		}
	}
	#endregion

	/// <summary>
	/// Location File
	/// </summary>
	public class LocationFile
	{
		#region Special Constants
		public static Dictionary<string, string> SpecialEntryStrings = new Dictionary<string, string>()
		{
			// Everything in this Dictionary assumes Z64 ROM locations.

			#region DataLocation
			{ "FileTable", "$FILETABLE" }, // ROM location of filetable
			{ "FirstFile", "$FIRSTFILE" }, // ROM location of first file
			{ "WrestlerDefs", "$WRESTLERDEFS" }, // ROM location of wrestler definitions
			{ "StableDefs", "$STABLEDEFS" }, // ROM location of stable definitions

			{ "CodeSegDefs", "$CODESEGDEFS" }, // ROM location of code segment definitions

			// World Tour, VPW64, and Revenge share BodyTypeDefs and HeadDefs.
			// If VPW64 didn't do its own thing for CostumeDefs, it'd be here too.
			{ "BodyTypeDefs", "$BODYTYPEDEFS" }, // ROM location of body type definitions
			{ "CostumeDefs", "$COSTUMEDEFS" }, // ROM location of costume definitions (World Tour and Revenge only)
			{ "HeadDefs", "$HEADDEFS" }, // ROM location of head/mask definitions

			{ "WrestlerBodyDefs", "$WRESTLERBODYDEFS" }, // world tour, vpw64, revenge
			{ "WrestlerDefaultCostumeDefs", "$DEFAULTCOSTUMEDEFS" }, // vpw64, revenge

			{ "WrestlerDefaultCostumePointers", "$DEFAULTCOSTUMEPOINTERS" }, // full pointer table
			// todo: pointers to pointers, corresponding with ID4 numbering

			{ "WrestlerHeightTable", "$WRESTLERHEIGHTTABLE" }, // world tour, vpw64, revenge

			// VPW64 costume definitions
			{ "VPW64Costumes_Small", "$VPW64COSTUMES_SMALL" },
			{ "VPW64Costumes_Medium", "$VPW64COSTUMES_MED" },
			{ "VPW64Costumes_Large", "$VPW64COSTUMES_LARGE" },
			{ "VPW64Costumes_Saladin", "$VPW64COSTUMES_SALADIN" },
			{ "VPW64Costumes_Baba", "$VPW64COSTUMES_BABA" },
			{ "VPW64Costumes_Judoka", "$VPW64COSTUMES_JUDOKA" },
			{ "VPW64Costumes_Female", "$VPW64COSTUMES_FEMALE" },
			{ "VPW64Costumes_Unused", "$VPW64COSTUMES_UNUSED" },

			// game introduction stuff for World Tour

			// game introduction stuff for VPW64
			{ "IntroDefs_VPW64_Anims", "$INTRODEFS_VPW64_ANIMS" },

			// game introduction stuff for Revenge to No Mercy
			{ "IntroDefs_Later_Anims", "$INTRODEFS_LATER_ANIMS" },
			{ "IntroDefs_Later_Images", "$INTRODEFS_LATER_IMAGES" },
			{ "IntroDefs_Later_Sequence", "$INTRODEFS_LATER_SEQUENCE" },
			{ "IntroDefs_Later_CameraMotion", "$INTRODEFS_LATER_CAMERAMOTION" },
			// todo: game ending sequences use same formats

			// might be shared between WM2K, VPW2, No Mercy
			{ "DefaultFace_FacialHair_VertDisplacement", "$DEFAULTFACE_FACIALHAIR_VERTDISPLACEMENT" },
			{ "DefaultFace_PaintAccessories_VertDisplacement", "$DEFAULTFACE_PAINTACCESSORIES_VERTDISPLACEMENT" },
			{ "FacialHair_VertDisplacement", "$FACIALHAIR_VERTDISPLACEMENT" },
			{ "FacePaint_VertDisplacement", "$FACEPAINT_VERTDISPLACEMENT" },
			{ "FacePaint_Type", "$FACEPAINT_TYPE" },
			{ "FaceAccessories_VertDisplacement", "$FACEACCESSORIES_VERTDISPLACEMENT" },
			{ "FaceAccessories_Type", "$FACEACCESSORIES_TYPE" },

			{ "DefaultRulesets", "$DEFAULT_RULESETS" },

			{ "AttractModeDemoMatches", "$ATTRACT_MODE_DEMO_MATCHES" },

			{ "ChampionshipDefs", "$CHAMPIONSHIPDEFS" }, // ROM location of championship definitions

			// arena-related items (may need per-game values)
			// - object counts
			// - various pointers
			// - stage-related data (Revenge through VPW2)

			// WM2K only?
			{ "TagTeamDefs", "$TAGTEAMDEFS" }, // ROM location of tag team definitions

			// WM2K and VPW2:
			{ "StoryModeSinglesParticipants", "$STORY_MODE_SINGLES_PARTICIPANTS" }, // ROM location of story mode singles participants
			{ "StoryModeSingleGroups", "$STORY_MODE_SINGLE_GROUPS" }, // ROM location of story mode singles groupings
			{ "StoryModeTeams", "$STORY_MODE_TEAMS" }, // ROM location of story mode teams
			{ "StoryModeTeamGroups", "$STORY_MODE_TEAM_GROUPS" }, // ROM location of story mode team groupings
			{ "StoryModeSchedule", "$STORY_MODE_SCHEDULE" }, // ROM location of story mode schedule
			{ "StoryModeBookingInstructions", "$STORY_MODE_BOOKING_INSTRUCTIONS" }, // ROM location of story mode booking instructions
			{ "DefaultChampions", "$DEFAULT_CHAMPIONS" }, // ROM location of default champions

			// todo: WM2K and NoMercy EntranceDef and TitantronFrames
			// $ENTRANCEDEFS
			// $TITANTRON_FRAMES_START // ROM location of first Titantron script

			// move-related items
			{ "MasterMoveMods_FirstEntries", "$MASTER_MOVE_MODS_FIRST_ENTRIES" },
			{ "MasterMoveMods", "$MASTER_MOVE_MODS" },
			{ "MasterMoveModPointers", "$MASTER_MOVE_MOD_POINTERS" },

			// tables for bit packing (WM2K and later)
			{ "BitPacking_MainTable", "$BITPACKING_MAINTABLE" }, // ROM location of "menu item to number of bits" table
			{ "BitPacking_MoveGroup_Wrestling", "$BITPACKING_MOVEGROUP_WRESTLING" },
			{ "BitPacking_MoveGroup_Combo", "$BITPACKING_MOVEGROUP_COMBO" },
			{ "BitPacking_MoveGroup_Shoot", "$BITPACKING_MOVEGROUP_SHOOT" },

			// "global text", used in various menus
			{ "GlobalText_Start", "$GLOBAL_TEXT_START" },
			{ "GlobalText_Pointers", "$GLOBAL_TEXT_POINTERS" },

			// 1bpp blood texture masks
			{ "BloodTexture_Face", "$BLOODTEXTURE_FACE" },
			{ "BloodTexture_Neck", "$BLOODTEXTURE_NECK" },
			{ "BloodTexture_Chest1", "$BLOODTEXTURE_CHEST1" },
			{ "BloodTexture_Chest2", "$BLOODTEXTURE_CHEST2" },
			#endregion

			#region CodeChange

			#region SetupFileTable
			// SetupFileTable
			{ "SetupFileTable_FtSize1", "%SETUPFT_FTSIZE1" },
			{ "SetupFileTable_FtLocation", "%SETUPFT_FTLOCATION" },

			// todo: filetable size is larger in No Mercy
			{ "SetupFileTable_FtSize2", "%SETUPFT_FTSIZE2" },
			{ "SetupFileTable_FtSize2Minus1", "%SETUPFT_FTSIZE2_MINUS1" },
			{ "SetupFileTable_FtBegins", "%SETUPFT_FTBEGINS" },
			{ "SetupFileTable_FtMaxFilesMinus1", "%SETUPFT_MAXFILES_MINUS1" },
			#endregion

			#region GetFileLoc
			// GetFileLoc
			{ "GetFileLoc_MaxFiles", "%GETFILELOC_MAXFILES" },
			{ "GetFileLoc_FtBegins", "%GETFILELOC_FTBEGINS" },
			#endregion

			#region LoadFile
			// LoadFile
			{ "LoadFile_MaxFiles", "%LOADFILE_MAXFILES" },
			{ "LoadFile_FtBegins", "%LOADFILE_FTBEGINS" },
			#endregion

			#endregion // CodeChange
		};
		#endregion

		#region Class Members
		/// <summary>
		/// List of locations
		/// </summary>
		public List<LocationFileEntry> Locations;
		#endregion

		#region Parsing Tables
		/// <summary>
		/// String to LocationType mapping.
		/// </summary>
		private static readonly Dictionary<String, LocationType> LocationTypes = new Dictionary<string, LocationType>()
		{
			{ "ROM", LocationType.ROM },
			{ "RAM", LocationType.RAM },
			{ "FTID", LocationType.FTID }
		};
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LocationFile()
		{
			this.Locations = new List<LocationFileEntry>();
		}

		#region Load/Save
		/// <summary>
		/// Load locations from file.
		/// </summary>
		/// <param name="_path">Path to location file to open.</param>
		public void LoadFile(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Open);
			StreamReader sr = new StreamReader(fs);

			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();

				// comment support
				if (line.StartsWith("#"))
				{
					continue;
				}

				// handle entry
				string[] tokens = line.Split(new char[] { ':', ',', ';' });
				LocationFileEntry entry = new LocationFileEntry(
					LocationType.Invalid,
					UInt32.Parse(tokens[1], NumberStyles.HexNumber),
					int.Parse(tokens[2]),
					tokens[3]
				);

				// fix location type
				if (LocationTypes.ContainsKey(tokens[0]))
				{
					entry.Type = LocationTypes[tokens[0]];
				}

				// handle special entry possibilities
				if (SpecialEntryStrings.ContainsValue(tokens[3]))
				{
					if (tokens[3].StartsWith("$"))
					{
						// data location entry
						entry.Handler = LocationHandlerType.DataLocation;
					}
					else if (tokens[3].StartsWith("%"))
					{
						// code change entry
						entry.Handler = LocationHandlerType.CodeChange;
					}

					// right now, there are no "@" entries in the table
				}
				else
				{
					// handle things I haven't explicitly defined
					if (tokens[3].StartsWith("$"))
					{
						// data location entry
						entry.Handler = LocationHandlerType.DataLocation;
					}
					else if (tokens[3].StartsWith("%"))
					{
						// code change entry
						entry.Handler = LocationHandlerType.CodeChange;
					}
					else if (tokens[3].StartsWith("@"))
					{
						// code segment location entry
						entry.Handler = LocationHandlerType.CodeSegment;
					}
				}

				Locations.Add(entry);
			}

			sr.Close();
		}

		/// <summary>
		/// Save locations to file.
		/// </summary>
		/// <param name="_path">Path to save location file.</param>
		/// <param name="_topComment">Optional comment placed at the top.</param>
		public void SaveFile(string _path, string _topComment)
		{
			FileStream fs = new FileStream(_path, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs,Encoding.UTF8);

			if (!_topComment.Equals(String.Empty))
			{
				sw.WriteLine(String.Format("# {0}", _topComment));
			}

			foreach (LocationFileEntry e in this.Locations)
			{
				sw.WriteLine(String.Format("{0}:{1:X},{2};{3}", e.Type.ToString(), e.Address, e.Length, e.Comment));
			}

			sw.Flush();
			sw.Close();
		}
		#endregion

		/// <summary>
		/// This is a hacky routine. That is all.
		/// </summary>
		/// <param name="_comment">Comment to search for.</param>
		/// <returns>LocationFileEntry with this comment, or null if not found.</returns>
		public LocationFileEntry GetEntryFromComment(string _comment)
		{
			foreach (LocationFileEntry e in this.Locations)
			{
				if (e.Comment.Equals(_comment))
				{
					return e;
				}
			}

			return null;
		}

		/// <summary>
		/// Get a List of all entries using the specified LocationType.
		/// </summary>
		/// <param name="_type">LocationType to use.</param>
		/// <returns>List of all LocationFileEntry with the specified LocationType.</returns>
		public List<LocationFileEntry> GetEntriesOfLocationType(LocationType _type)
		{
			List<LocationFileEntry> result = new List<LocationFileEntry>();
			foreach (LocationFileEntry e in this.Locations)
			{
				if (e.Type == _type)
				{
					result.Add(e);
				}
			}
			return result;
		}

		/// <summary>
		/// Get a List of all entries using the specified LocationHandlerType.
		/// </summary>
		/// <param name="_type">LocationHandlerType to use.</param>
		/// <returns>List of all LocationFileEntry with the specified LocationHandlerType.</returns>
		public List<LocationFileEntry> GetEntriesOfHandlerType(LocationHandlerType _type)
		{
			List<LocationFileEntry> result = new List<LocationFileEntry>();
			foreach (LocationFileEntry e in this.Locations)
			{
				if (e.Handler == _type)
				{
					result.Add(e);
				}
			}
			return result;
		}

		/// <summary>
		/// Get a list of all entries whose name starts with the specified string.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public List<LocationFileEntry> GetEntriesStartingWith(string s)
		{
			List<LocationFileEntry> entries = new List<LocationFileEntry>();
			foreach (LocationFileEntry lfe in Locations)
			{
				if (lfe.Comment.StartsWith(s))
				{
					entries.Add(lfe);
				}
			}

			return entries;
		}

		/// <summary>
		/// Get a list of all entries whose name starts with "%SOUND".
		/// </summary>
		/// <returns>List of all LocationFileEntry whose comment starts with "%SOUND".</returns>
		public List<LocationFileEntry> GetSoundEntries()
		{
			return GetEntriesStartingWith("%SOUND");
		}

		/// <summary>
		/// Get a list of all entries whose name starts with "@CODESEG".
		/// </summary>
		/// <returns>List of all LocationFileEntry whose comment starts with "@CODESEG".</returns>
		public List<LocationFileEntry> GetCodeSegEntries()
		{
			return GetEntriesStartingWith("@CODESEG");
		}
	}
}
