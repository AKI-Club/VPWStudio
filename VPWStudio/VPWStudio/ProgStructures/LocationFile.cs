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
	/// Location Entry
	/// </summary>
	public class LocationFileEntry
	{
		/// <summary>
		/// Location type
		/// </summary>
		public LocationType Type;

		/// <summary>
		/// Location address
		/// </summary>
		public UInt32 Address;

		/// <summary>
		/// Data width
		/// </summary>
		public int Width;

		/// <summary>
		/// Comment
		/// </summary>
		public string Comment;

		/// <summary>
		/// Default constructor
		/// </summary>
		public LocationFileEntry()
		{
			this.Type = LocationType.Invalid;
			this.Address = 0;
			this.Width = 1;
			this.Comment = String.Empty;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_type">Location type</param>
		/// <param name="_addr">Address</param>
		/// <param name="_width">Data width</param>
		/// <param name="_comment">Comment about location</param>
		public LocationFileEntry(LocationType _type, UInt32 _addr, int _width, string _comment)
		{
			this.Type = _type;
			this.Address = _addr;
			this.Width = _width;
			this.Comment = _comment;
		}
	}

	/// <summary>
	/// Location File
	/// </summary>
	public class LocationFile
	{
		#region Special Constants
		
		#endregion

		#region Class Members
		/// <summary>
		/// List of locations
		/// </summary>
		public List<LocationFileEntry> Locations;
		#endregion

		#region Special Class Members
		/// <summary>
		/// Location of the filetable in ROM.
		/// </summary>
		public LocationFileEntry FileTable = null;

		/// <summary>
		/// Location of the first valid wrestler definition in ROM.
		/// </summary>
		public LocationFileEntry WrestlerDefs = null;

		/// <summary>
		/// Location of the first "file" (entry 0x0001) in the ROM.
		/// </summary>
		public LocationFileEntry FirstFile = null;

		/// <summary>
		/// 
		/// </summary>
		public List<LocationFileEntry> CodeChangeEntries = null;
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

		/// <summary>
		/// Special Class Member tokens
		/// </summary>
		private static List<String> SpecialTypes = new List<string>()
		{
			#region Data Locations ("$VALUE")
			"$FILETABLE",    // (this.FileTable) Location of file table
			"$WRESTLERDEFS", // (this.WrestlerDefs) Location of wrestler definitions
			"$FIRSTFILE",    // (this.FirstFile) Location of first file listed in filetable
			#endregion

			#region Code Locations ("%VALUE")
			#endregion
		};
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public LocationFile()
		{
			this.Locations = new List<LocationFileEntry>();
			this.CodeChangeEntries = new List<LocationFileEntry>();
		}

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
				if (SpecialTypes.Contains(tokens[3]))
				{
					if (tokens[3].StartsWith("$"))
					{
						if (tokens[3].Contains("FILETABLE"))
						{
							this.FileTable = entry;
						}

						if (tokens[3].Contains("WRESTLERDEFS"))
						{
							this.WrestlerDefs = entry;
						}

						if (tokens[3].Contains("FIRSTFILE"))
						{
							this.FirstFile = entry;
						}
					}
					else if (tokens[3].StartsWith("%"))
					{
						// add entry to CodeChangeEntries
						this.CodeChangeEntries.Add(entry);
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
				sw.WriteLine(String.Format("{0}:{1:X},{2};{3}", e.Type.ToString(), e.Address, e.Width, e.Comment));
			}

			sw.Flush();
			sw.Close();
		}
	}
}
