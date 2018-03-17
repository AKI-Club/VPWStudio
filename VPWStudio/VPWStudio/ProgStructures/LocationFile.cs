using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
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
		/// Found in RAM. (GameShark code)
		/// </summary>
		RAM,
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

	/// <summary>
	/// Location File
	/// </summary>
	public class LocationFile
	{
		#region Special Constants
		public static Dictionary<string, string> SpecialEntryStrings = new Dictionary<string, string>()
		{
			#region DataLocation
			{ "FileTable", "$FILETABLE" }, // ROM location of filetable
			{ "FirstFile", "$FIRSTFILE" }, // ROM location of first file
			{ "WrestlerDefs", "$WRESTLERDEFS" }, // ROM location of wrestler definitions
			{ "StableDefs", "$STABLEDEFS" }, // ROM location of stable definitions

			// these three are used for World Tour, VPW64, and Revenge at least.
			// the other three games probably have their own ways of doing things.
			{ "BodyTypeDefs", "$BODYTYPEDEFS" }, // ROM location of body type definitions
			{ "CostumeDefs", "$COSTUMEDEFS" }, // ROM location of costume definitions
			{ "HeadDefs", "$HEADDEFS" }, // ROM location of head/mask definitions
			#endregion

			#region CodeChange
			// SetupFileTable
			{ "SetupFileTable_FtSize1", "%SETUPFT_FTSIZE1" },
			{ "SetupFileTable_FtLoc1", "%SETUPFT_FTLOCATION" },
			{ "SetupFileTable_FtSize2", "%SETUPFT_FTSIZE2" },
			{ "SetupFileTable_FtSize2Minus1", "%SETUPFT_FTSIZE2_MINUS1" },
			{ "SetupFileTable_FtBegins", "%SETUPFT_FTBEGINS" },
			{ "SetupFileTable_FtMaxFilesMinus1", "%SETUPFT_MAXFILES_MINUS1" },

			// GetFileLoc
			{ "GetFileLoc_MaxFiles", "%GETFILELOC_MAXFILES" },
			{ "GetFileLoc_FtBegins", "%GETFILELOC_FTBEGINS" },

			// LoadFile
			{ "LoadFile_MaxFiles", "%LOADFILE_MAXFILES" },
			{ "LoadFile_FtBegins", "%LOADFILE_FTBEGINS" },
			#endregion
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
		private static Dictionary<String, LocationType> LocationTypes = new Dictionary<string, LocationType>()
		{
			{ "ROM", LocationType.ROM },
			{ "RAM", LocationType.RAM },
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
				}

				this.Locations.Add(entry);
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
	}
}
